using TCH_desktop.Models;

namespace TCH_desktop.Presenter.interfaces
{
    public interface IAccountAction
    {
        public string CreateNewAccount(string email, string password, string confirmedPassword);

        public byte[] GetSalt();

        public string GetHashImage(string pswrd, byte[] salt);

        public bool CheckInputedEmail(string email);

        public LoginModel GetCurrentLoginData(string email);

        public User GetCurrentUserData(int loginId);

        public Employee GetCurrentEmployeeData(int userId);

        public int GetCurrentRailroadId(int userId);

        public int GetCurrentDepotId(int userId);
    }
}
