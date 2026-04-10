using System.ComponentModel.DataAnnotations;
using Aurum.Application.Adminstrator.Response.Commands;
using Aurum.Application.Customers.Response.Commands;
using MediatR;

namespace Aurum.Application.Customers.Commands.AddAccountCredit;

public record NewCustomerAccountCommand(
    string Gender,
    string Givenname,
    string Surname,  
    string Streetaddress,
    string City,
    string Zipcode,
    string Country,
    string CountryCode,
    DateTime? Birthday,
    string? Telephonecountrycode,
    string? Telephonenumber,
    string Emailaddress,
    CustomerAccount CustomerAccount

    ) : IRequest<NewCustomerAccountResult>;

public record CustomerAccount(
    [Required]
    int AccountTypesId,
    string? Frequency);