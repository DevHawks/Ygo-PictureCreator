using System.Windows;

namespace Ygo_Picture_Creator
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Program.Run(e.Args);
        }
    }
}
