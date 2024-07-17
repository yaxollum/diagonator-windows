using System.IO.Pipes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(int lineDirection, int lineWidth, int lineSpacing, int topMargin, int bottomMargin, int leftMargin, int rightMargin)
        {
            InitializeComponent();
            var myLine = new Line();
            myLine.Stroke = Brushes.Black;
            myLine.X1 = 1;
            myLine.X2 = 50;
            myLine.Y1 = 1;
            myLine.Y2 = 50;
            myLine.StrokeThickness = 2;
            myGrid.Children.Add(myLine);
        }
    }
}