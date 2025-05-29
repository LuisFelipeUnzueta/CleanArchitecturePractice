using CAStudy.Domain.Accounts.Enum;
using CAStudy.Domain.Accounts.Events;
using CAStudy.Domain.Accounts.ValueObjects;
using CAStudy.Domain.Shared.Abstractions;
using CAStudy.Domain.Shared.Aggregates.Abstractions;
using CAStudy.Domain.Shared.Entities;
using CAStudy.Domain.Shared.ValueObjects;

namespace CAStudy.Domain.Accounts.Entities;

public sealed class Account : Entity, IAggregateRoot
{
    #region Constructors

    private Account() : base(Guid.NewGuid(), Tracker.Create())
    {
    }

    private Account(
        Guid id,
        EAccountType type,
        CompositeName name,
        Email email,
        VerificationCode verificationCode,
        Password password,
        Document document,
        Tracker tracker,
        LockOut? lockout = null) : base(id, tracker)
    {
        Type = type;
        Name = name;
        Email = email;
        VerificationCode = verificationCode;
        Password = password;
        Document = document;
        Lockout = lockout;
    }

    #endregion

    #region Factories

    public static Account CreateProfessor(CompositeName name, Email email, Password password, Cpf cpf,
        IDateTimeProvider dateTimeProvider)
    {
        var id = Guid.NewGuid();
        var verificationCode = VerificationCode.Create(dateTimeProvider);
        var tracker = Tracker.Create(dateTimeProvider);
        var coach = new Account(id, EAccountType.Coach, name, email, verificationCode, password, cpf, tracker);
        coach.RaiseDomainEvent(new OnCoachCreatedEvent(id, name, email));

        return coach;
    }

    public static Account CreateStudent(CompositeName name, Email email, Password password, Cpf cpf,
        IDateTimeProvider dateTimeProvider)
    {
        var id = Guid.NewGuid();
        var verificationCode = VerificationCode.Create(dateTimeProvider);
        var tracker = Tracker.Create(dateTimeProvider);
        var trainer = new Account(id, EAccountType.Trainer, name, email, verificationCode, password, cpf, tracker);
        trainer.RaiseDomainEvent(new OnTrainerCreatedEvent(id, name, email));

        return trainer;
    }

    public static Account CreateCorporation(Name name, Email email, Password password, Cnpj cnpj,
        IDateTimeProvider dateTimeProvider)
    {
        var id = Guid.NewGuid();
        var compositeName = CompositeName.Create(name, string.Empty);
        var verificationCode = VerificationCode.Create(dateTimeProvider);
        var tracker = Tracker.Create(dateTimeProvider);
        var corporation = new Account(id, EAccountType.Corporation, compositeName, email, verificationCode, password,
            cnpj,
            tracker);
        corporation.RaiseDomainEvent(new OnCorporationCreatedEvent(id, name, email));

        return corporation;
    }

    #endregion

    #region Properties

    public EAccountType Type { get; }
    public CompositeName Name { get; } = null!;
    public Email Email { get; } = null!;
    public VerificationCode VerificationCode { get; private set; } = null!;
    public Password Password { get; } = null!;
    public Document Document { get; } = null!;
    public LockOut? Lockout { get; }

    #endregion

    #region Public Methods

    public void ResetVerificationCode(IDateTimeProvider dateTimeProvider)
    {
        VerificationCode = VerificationCode.Create(dateTimeProvider);
        RaiseDomainEvent(new OnResendEmailVerificationEvent(Id, Name, Email, VerificationCode));
    }

    public bool Authenticate(string plainTextPassword,IDateTimeProvider dateTimeProvider)
    {
        Tracker.Update(dateTimeProvider);
        return Password.Verify(Password.HashText, plainTextPassword);
    } 

    #endregion
}