using System;

namespace Teste.API.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public DateTime BirthDate { get; set; }
        public bool EmailSms { get; set; }
        public bool Whatsapp { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        
        public Customer(Guid id, string fullName, string email, string cpf, string cellphone, DateTime birthDate, bool emailSms, bool whatsapp, string country, string city, string postalCode, string address, int number)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Cpf = cpf;
            Cellphone = cellphone;
            BirthDate = birthDate;
            EmailSms = emailSms;
            Whatsapp = whatsapp;
            Country = country;
            City = city;
            PostalCode = postalCode;
            Address = address;
            Number = number;
        }
    }
}
