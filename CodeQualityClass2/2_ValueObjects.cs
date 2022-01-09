using System.Collections.Generic;

namespace CodeQualityClass2
{
    #region Bad
    public interface IUserService1
    {
        IDictionary<string, string> GetUserBankAccounts();
    } 
    #endregion

    #region Better
    public interface IUserService2
    {
        IDictionary<UserEmail, BankAccountNumber> GetUserBankAccounts();
    }
    public class UserEmail
    {
        public string Email { get; set; }
    }
    public class BankAccountNumber
    {
        public string AccountNumber { get; set; }
    } 
    #endregion
}
