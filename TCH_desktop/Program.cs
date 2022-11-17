using TCH_desktop.Presenter;
using TCH_desktop.Presenter.interfaces;

namespace TCH_desktop
{
    internal static class Program
    {
        public static IAccountAction account = new AccountAction();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new View.AuthForm(account));
        }
    }
}