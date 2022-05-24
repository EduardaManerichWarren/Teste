using FluentValidation;
using Teste.API.Models;

namespace Teste.API.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FullName)
                .NotNull();
            RuleFor(customer => customer.Email)
                .EmailAddress();
            RuleFor(customer => customer.Cpf)
                .MinimumLength(11)
                .Must(CpfValido)
                .WithMessage("Cpf invalido!");
            RuleFor(customer => customer.Cellphone)
                .NotNull();
            RuleFor(customer => customer.BirthDate)
                .NotNull();
            RuleFor(customer => customer.EmailSms)
                .NotNull();
            RuleFor(customer => customer.Whatsapp)
                .NotNull();
        }

        private bool CpfValido(string cpf)
        {
            String[] digitos = new string[11];
            for (var i = 0; i < 11; i++)
            {
                digitos[i] = cpf.Substring(i, 1);
            }
            int digito1 = 0;
            for (int i = 0; i < 9; i++)
            {
                digito1 += int.Parse(digitos[i]) * (10 - i);
                Console.WriteLine(digito1);
            }
            digito1 *= 10;
            digito1 %= 11;
            int digito2 = 0;
            for (int i = 0; i < 10; i++)
            {
                digito2 += int.Parse(digitos[i]) * (11 - i);
            }
            digito2 *= 10;
            digito2 %= 11;
            if ((digito1 == int.Parse(digitos[9])) && (digito2 == int.Parse(digitos[10])))
            {
                return true;
            }
            else { return false; }
        }
    }
}
