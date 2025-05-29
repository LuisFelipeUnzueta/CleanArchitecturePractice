using CAStudy.Domain.Accounts.Enum;
using CAStudy.Domain.Accounts.Errors;
using CAStudy.Domain.Accounts.Errors.Exceptions;

namespace CAStudy.Domain.Accounts.ValueObjects;

public record Document
{
    private Document()
    {
    }

    protected Document(string number, EDocumentType type)
    {
        if (string.IsNullOrEmpty(number))
            throw new DocumentNullException(ErrorMessages.Document.Null);

        if (string.IsNullOrWhiteSpace(number))
            throw new InvalidDocumentException(ErrorMessages.Document.Invalid);

        Number = number.Trim();
        Type = type;
    }
    
    public string Number { get; } = string.Empty;
    
    public EDocumentType Type { get; }
    
    public static implicit operator string(Document document) => document.Number;
    
}