namespace Soundify.NET
{
    internal static class Program
    {
        public const string AppVersion = "1.0.0.2";
        private static readonly string MutexName = "SoundifyNETCoreApp";
        [STAThread]
        static void Main()
        {
            using var mutex = new Mutex(true, MutexName, out bool isNewInstance);
            if (isNewInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ApplicationConfiguration.Initialize();
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("Soundify.NET is already running!", "Soundify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}