
using Rucula.OAuth.LocalCredentials.Application.Notification;

using Rucula.OAuth.LocalCredentials.Core.Repositories;

using MediatR;

namespace Rucula.OAuth.LocalCredentials.Application.Commands.Logout.Create;

public class CreateLogoutCommandHendler : CreateBaseCommand, IRequestHandler<CreateLogoutCommandRequest, bool>
{
    readonly IAuthRepository _authRepository;

    public CreateLogoutCommandHendler(INotificationError notificationError, IAuthRepository authRepository) : base(notificationError)
    {
        this._authRepository = authRepository;
    }

    public async Task<bool> Handle(CreateLogoutCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await _authRepository.LogoutAsync();
        }
        catch (Exception)
        {
            Notify(message: "Oops! We were unable to process your request.");
        }

        return true;
    }
}
