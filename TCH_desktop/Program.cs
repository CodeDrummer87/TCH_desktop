namespace TCH_desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run();  //.:: new MyForm()
        }
    }
}