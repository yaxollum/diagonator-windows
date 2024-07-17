using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.CommandLine;
using System.Runtime.InteropServices;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var args = e.Args;
            var lineDirection = new Option<int>(
            name: "--line-direction",
            description: "Direction of the lines (counterclockwise from the bottom of the screen).")
            { ArgumentHelpName = "degrees" };
            var lineWidth = new Option<int>(
                name: "--line-width",
                description: "Width of the lines.")
            { ArgumentHelpName = "pixels" };
            var lineSpacing = new Option<int>(
                name: "--line-spacing",
                description: "Spacing between the lines.")
            { ArgumentHelpName = "pixels" };
            var topMargin = new Option<int>(name: "--top-margin") { ArgumentHelpName = "pixels" };
            var bottomMargin = new Option<int>(name: "--bottom-margin") { ArgumentHelpName = "pixels" };
            var leftMargin = new Option<int>(name: "--left-margin") { ArgumentHelpName = "pixels" };
            var rightMargin = new Option<int>(name: "--right-margin") { ArgumentHelpName = "pixels" };

            var shouldExit = true;
            var rootCommand = new RootCommand("A tool that draws diagonal lines across your screen.")
            { lineDirection, lineWidth, lineSpacing, topMargin, bottomMargin, leftMargin, rightMargin };
            rootCommand.SetHandler((lineDirection, lineWidth, lineSpacing, topMargin, bottomMargin, leftMargin, rightMargin) =>
            {
                new MainWindow(lineDirection, lineWidth, lineSpacing, topMargin, bottomMargin, leftMargin, rightMargin).Show();
                shouldExit = false;
            },
                lineDirection, lineWidth, lineSpacing, topMargin, bottomMargin, leftMargin, rightMargin);
            rootCommand.Invoke(args);
            if (shouldExit) { Current.Shutdown(); }
        }
    }

}
