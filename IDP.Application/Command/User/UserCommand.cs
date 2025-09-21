using IDP.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDP.Application.Command.User;

public class UserCommand : IRequest<bool>
{
    public required string FullName { get; set; }
    public required string CodeNumber { get; set; }
}
public class UserHandler : IRequestHandler<UserCommand, bool>
{
    
    public async Task<bool> Handle(UserCommand request, CancellationToken cancellationToken)
    {
        var user = new IDP.Domain.Entities.User { FullName = request.FullName, CodeNumber = request.CodeNumber };
        return true;
    }
    
}
