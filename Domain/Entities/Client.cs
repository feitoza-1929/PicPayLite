using PicPayLite.Domain.Accounts;
using PicPayLite.Domain.ValueObjects;
using EmailValidation;
using FluentResults;
using PicPayLite.Domain.Errors;
using System.Text.RegularExpressions;
using DocumentValidator;
using PicPayLite.Domain.Validation;

namespace PicPayLite.Domain.Clients
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public ClientType Type { get; private set; }
        public string DocumentValue { get; private set;}
        public DocumentType DocumentType { get; private set; }
        public Account Account { get; private set; }

        private Client(
            string name,
            string email, ClientType type,
            string documentValue,
            DocumentType documentType)
        {
            Name = name;
            Email = email;
            Type = type;
            DocumentValue = documentValue;
            DocumentType = documentType;
        }

        public static Result<Client> Create(
            string name,
            string email,
            ClientType type,
            string documentValue,
            DocumentType documentType)
        {

            if(NameValidation.Validate(name) is false)
                return Result.Fail(DomainErrors.Client.InvalidName);

            if(EmailValidator.Validate(email) is false)
                return Result.Fail(DomainErrors.Client.InvalidEmail);

            if(DocumentValidation.Validate(documentValue, documentType) is false)
                return Result.Fail(DomainErrors.Client.InvalidDocument);

            return new Client(name, email, type, documentValue, documentType);
        }
    }
}

