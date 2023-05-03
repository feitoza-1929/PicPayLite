using System.Text.RegularExpressions;
using DocumentValidator;
using FluentResults;
using PicPayLite.Domain.Errors;
using PicPayLite.Domain.ValueObjects;

namespace PicPayLite.Domain.Validation
{
    public class DocumentValidation
    {
        private static readonly Regex documentRx = new(@"^[\d]{1,14}$");
        public static bool Validate(string documentValue, DocumentType documentType) 
        {
            if (documentRx.IsMatch(documentValue) is false)
                return false;

            int CPFRange = 12;

            if (documentValue.Length == CPFRange && documentType != DocumentType.CPF)
                return false;

            int CNPJRange = 14;

            if (documentValue.Length == CNPJRange && documentType != DocumentType.CNPJ)
                return false;

            if (CpfValidation.Validate(documentValue) is false)
                return false;

            return true;
        }
    }
}