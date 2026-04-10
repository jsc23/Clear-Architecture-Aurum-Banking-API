
using Aurum.Application.Authentication.Common;
using Aurum.Application.Common.Errors;
using Aurum.Application.Common.Interfaces;
using Aurum.Application.Common.Interfaces.Persistence;
using Aurum.Application.Services.Queries.Login;
using Domain.Domains;
using MediatR;
namespace Aurum.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmail(query.Email) is not User user)
        {
            throw new InvalidUser();
        }


        if (user.Password != query.Password)
        {
            throw new InvalidPassword();
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}