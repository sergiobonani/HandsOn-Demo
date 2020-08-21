using FluentValidation;
using Resource;
using Demo.Application.Interfaces;
using Demo.Application.Validation.Helpers;
using Demo.Application.ViewModels.Notifications;
using Demo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Validation
{
    public class ClientValidation : AbstractValidator<Client>
    {
        public ClientValidation()
        {
            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.ZipCode))
                .Length(8).WithMessage(string.Format(Geral.MustHaveCharacters, Geral.ZipCode, 8));

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.Name))
                .Length(10, 50).WithMessage(string.Format(Geral.MustHaveBetweenCharacters, Geral.Name, 10, 50));

            RuleFor(c => c.Gender)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.Gender))
                .Length(1).WithMessage(string.Format(Geral.MustHaveCharacters, Geral.Gender, 1));

            RuleFor(c => c.DateOfBirth)
                .NotNull().WithMessage(string.Format(Geral.Required, Geral.DateOfBirth));

            RuleFor(c => c.Address)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.Address))
                .Length(10, 100).WithMessage(string.Format(Geral.MustHaveBetweenCharacters, Geral.Name, 10, 100));

            RuleFor(c => c.AddressNumber)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.AddressNumber))
                .Length(1, 50).WithMessage(string.Format(Geral.MustHaveBetweenCharacters, Geral.Name, 1, 50));

            RuleFor(c => c.Complement)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.Complement))
                .Length(10, 100).WithMessage(string.Format(Geral.MustHaveBetweenCharacters, Geral.Name, 10, 100));

            RuleFor(c => c.District)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.District))
                .Length(5, 50).WithMessage(string.Format(Geral.MustHaveBetweenCharacters, Geral.Name, 5, 50));

            RuleFor(c => c.State)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.State))
                .Length(5, 50).WithMessage(string.Format(Geral.MustHaveBetweenCharacters, Geral.Name, 5, 50));

            RuleFor(c => c.City)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.City))
                .Length(5, 50).WithMessage(string.Format(Geral.MustHaveBetweenCharacters, Geral.Name, 5, 50));

            //RuleFor(c => c.Document)
            //    .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.Document))
            //    .Must(CpfCnpjValidationHelper.IsValid).WithMessage(string.Format(Geral.InvalidField, Geral.Document));
        }
    }
}
