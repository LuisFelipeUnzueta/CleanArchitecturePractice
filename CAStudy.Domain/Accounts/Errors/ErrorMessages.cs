namespace CAStudy.Domain.Accounts.Errors;

public static class ErrorMessages
{
    #region Properties

    public static AccountErrorMessages Account { get; set; } = new();
    public static EmailErrorMessages Email { get; set; } = new();
    public static PasswordErrorMessages Password { get; set; } = new();
    public static VerificationCodeErrorMessages VerificationCode { get; set; } = new();
    public static DocumentErrorMessages Document { get; set; } = new();
    public static CpfErrorMessages Cpf { get; set; } = new();
    public static CnpjErrorMessages Cnpj { get; set; } = new();
    public static NameErrorMessages Name { get; set; } = new();
    public static CompositeNameErrorMessages CompositeName { get; set; } = new();
    public static LockOutErrorMessages LockOut { get; set; } = new();

    #endregion

    #region Error Messages

    public class AccountErrorMessages
    {
        public string EmailInUse { get; set; } = "This email is already in use.";
        public string EmailDenied { get; set; } = "This email is blocked in the system.";
        public string DomainDenied { get; set; } = "This domain is blocked in the system.";
        public string NotFound { get; set; } = "Account not found.";
        public string PasswordIsInvalid { get; set; } = "Invalid username or password.";
        public string IsInactive { get; set; } = "This account has not been activated yet.";
        public string IsAlreadyActive { get; set; } = "This account is already active.";
        public string IsLockedOut { get; set; } = "This account is locked.";
        public string EmailIsDifferent { get; set; } = "The provided email is different from the account email.";
        public string DocumentIsDifferent { get; set; } = "The provided document is different from the account document.";
    }

    public class EmailErrorMessages
    {
        public string Invalid { get; set; } = "Invalid email.";
        public string NullOrEmpty { get; set; } = "Email cannot be null or empty.";
    }

    public class PasswordErrorMessages
    {
        public string Invalid { get; set; } = "The provided password is invalid.";
        public string InvalidLength { get; set; } = "The password must be at least 12 characters long.";
        public string PasswordNull { get; set; } = "The password cannot be null.";
    }

    public class VerificationCodeErrorMessages
    {
        public string InvalidCode { get; set; } = "Invalid verification code.";
        public string NullOrEmpty { get; set; } = "No verification code was provided.";
        public string NullOrWhiteSpace { get; set; } = "The provided verification code is empty.";
        public string InvalidLenght { get; set; } = "The verification code must be 6 characters long.";
        public string Expired { get; set; } = "This verification code has expired.";
        public string AlreadyActive { get; set; } = "This verification code is already active.";
    }

    public class DocumentErrorMessages
    {
        public string Invalid { get; set; } = "The provided document is invalid.";
        public string Null { get; set; } = "No document was provided.";
    }

    public class CpfErrorMessages
    {
        public string Invalid { get; set; } = "The provided CPF is invalid.";
        public string InvalidLength { get; set; } = "The CPF must be 11 digits long.";
        public string InvalidNumber { get; set; } = "The provided CPF number is invalid.";
    }

    public class CnpjErrorMessages
    {
        public string Invalid { get; set; } = "The provided CNPJ is invalid.";
        public string InvalidLength { get; set; } = "The CNPJ must be 14 digits long.";
        public string InvalidNumber { get; set; } = "The provided CNPJ number is invalid.";
    }

    public class NameErrorMessages
    {
        public string Invalid { get; set; } = "The provided name is invalid.";
        public string InvalidNullOrEmpty { get; set; } = "The provided name cannot be null or empty.";
        public string InvalidLength { get; set; } = "The name must be at least 2 characters long.";
        public string InvalidLetters { get; set; } = "The provided name contains invalid characters.";
    }

    public class CompositeNameErrorMessages
    {
        public string Invalid { get; set; } = "The provided values are invalid.";
        public string InvalidNullOrWhiteSpace { get; set; } = "The provided values cannot be empty.";
        public string InvalidLength { get; set; } = "The field must be between 3 and 40 characters long.";
        public string InvalidLetters { get; set; } = "The character pattern is invalid.";
    }

    public class LockOutErrorMessages
    {
        public string Invalid { get; set; } = "The provided lockout is invalid.";
        public string InvalidLockOutExpired { get; set; } = "The provided lockout has expired.";
        public string InvalidLockOutReasonLength { get; set; } = "The length of the provided lockout reason is invalid.";
    }

    #endregion
}