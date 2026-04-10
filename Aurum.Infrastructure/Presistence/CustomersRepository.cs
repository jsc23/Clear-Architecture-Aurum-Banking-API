using System;
using Dapper;
using Domain.Models;
using System.Data;
using Aurum.Application.Common.Interfaces.Persistence;
using Aurum.Domain.Aggregates;
using Aurum.Application.Customers.Commands.AddAccountCredit;
using Domain.Domains;
using System.Security.Principal;
using Aurum.Application.Common.Errors;
using Aurum.Application.Adminstrator.Response.Commands;

namespace Aurum.Infrastructure.Presistence;

public class CustomersRepository : ICustomerRepository
{
    private readonly DapperContext _context;

    public CustomersRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<NewCustomerAccountAggregate> NewCustomerAccount(User user, NewCustomerAccountCommand command)
    {
        using (var db = _context.CreateConnection())
        {
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("@email", command.Emailaddress);
            var userExist = await db.QuerySingleOrDefaultAsync<User>("GetUserByEmail", dynamic, commandType: CommandType.StoredProcedure);
            if (userExist != null)
            {
                throw new DuplicateEmailException();
            }
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Gender", command.Gender);
                parameters.Add("@Givenname", command.Givenname);
                parameters.Add("@Surname", command.Surname);
                parameters.Add("@Streetaddress", command.Streetaddress);
                parameters.Add("@City", command.City);
                parameters.Add("@Zipcode", command.Zipcode);
                parameters.Add("@Country", command.Country);
                parameters.Add("@CountryCode", command.CountryCode);
                parameters.Add("@Birthday", command.Birthday);
                parameters.Add("@Telephonecountrycode", command.Telephonecountrycode);
                parameters.Add("@Telephonenumber", command.Telephonenumber);
                parameters.Add("@Emailaddress", command.Emailaddress);
                var customer = await db.QuerySingleAsync<Customer>("CreateCustomer", parameters, commandType: CommandType.StoredProcedure);


                DynamicParameters parameters2 = new DynamicParameters();
                parameters2.Add("@UserId", user.UserId);
                parameters2.Add("@Email", command.Emailaddress);
                parameters2.Add("@Password", user.Password);
                parameters2.Add("@Role", user.Role);
                db.ExecuteScalar("AddUser", parameters2, commandType: CommandType.StoredProcedure);


                //Insert to account & Disposition customerID
                DynamicParameters para = new DynamicParameters();
                para.Add("@customerId", customer.CustomerId);
                para.Add("@userId", user.UserId);
                para.Add("@frequency", command.CustomerAccount.Frequency);
                para.Add("@accountTypesId", command.CustomerAccount.AccountTypesId);
                
                var ListNewCustomer = await db.QueryAsync<NewCustomerAccountAggregate, Account, Customer, User, NewCustomerAccountAggregate>("CreateAccountReturnDisposition", (aggregate, account, customer, user) =>
                {
                    aggregate.Account = account;
                    aggregate.Customer = customer;
                    aggregate.User = user;
                    return aggregate;
                }, para, commandType: CommandType.StoredProcedure, splitOn: "AccountId, CustomerId, UserId");

                var result = ListNewCustomer.First();
                return result;

            }
            catch (Exception)
            {
                throw new InternalServerError();
            }
        }
    }
}

