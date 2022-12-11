namespace TCH_desktop
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new View.AuthForm());
        }
    }
}