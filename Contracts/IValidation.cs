namespace Ecomm.Contracts
{
    public interface IValidation
    {
        
            bool CheckName(string name);
            bool CheckEmail(string email);
            bool CheckPassword(string password);
            bool ConfirmPasswordValidator(string password, string confirmPassword);
    }
}
