using MediatR;

namespace Rucula.OAuth.LocalCredentials.Application.Commands.User.Create;

public class CreateUserCommandRequest : IRequest<bool>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
