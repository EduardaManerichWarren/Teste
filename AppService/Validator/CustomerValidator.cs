using FluentValidation;
using Teste.API.Extensions;
using DomainModels.Models;

namespace AppService.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer)
                .Must(x => x.EmailSms || x.Whatsapp);

            RuleFor(customer => customer.Id)
                .Empty();

            RuleFor(customer => customer.FullName)
                .NotNull()
                .Must(x => x.Split().Length >= 2);

            RuleFor(customer => customer.Email)
                .EmailAddress();

            RuleFor(customer => customer.Cpf)
                .Length(11)
                .Matches("[0-9]{11}")
                .WithMessage("Cpf deve conter apenas números!")
                .Must(ValidateCpf)
                .WithMessage("Cpf invalido!");

            RuleFor(customer => customer.Cellphone)
                .Must(x => !string.IsNullOrWhiteSpace(x));

            RuleFor(customer => customer.BirthDate)
                .NotNull();
        }

        private static bool ValidateCpf(string cpf)
        {
            var firstDigitAfterDash = 0;
            for (int i = 0; i < cpf.Length - 2; i++)
            {
                firstDigitAfterDash += cpf.ToIntAt(i) * (10 - i);
            }
            firstDigitAfterDash = firstDigitAfterDash * 10 % 11;

            var secondDigitAfterDash = 0;
            for (int i = 0; i < cpf.Length - 1; i++)
            {
                secondDigitAfterDash += cpf.ToIntAt(i) * (11 - i);
            }
            secondDigitAfterDash = secondDigitAfterDash * 10 % 11;

            return firstDigitAfterDash == cpf.ToIntAt(^2) && secondDigitAfterDash == cpf.ToIntAt(^1);
        }
    }
}
