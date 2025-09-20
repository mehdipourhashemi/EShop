using FluentValidation;
using IDP.Domain.IRepository.Command;
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
    private readonly IUserRepository _user;
    public UserHandler(IUserRepository user)
    {
        this._user = user;
    }
    public async Task<bool> Handle(UserCommand request, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.User() { FullName = request.FullName, CodeNumber = request.CodeNumber };
        return await _user.Insert(user);
    }
}
public sealed class UserCommandValidator : AbstractValidator<UserCommand>
{
    public UserCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage("کد ملی الزامی است")
            .Length(10)
            .WithMessage("کد ملی باید ۱۰ رقم باشد")
            .Matches(@"^\d{10}$")
            .WithMessage("کد ملی باید فقط شامل اعداد باشد");

    }
}