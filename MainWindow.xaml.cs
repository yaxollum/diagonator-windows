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
            var left = leftMargin;
            var right = SystemParameters.PrimaryScreenWidth - rightMargin;
            var top = topMargin;
            var bottom = SystemParameters.PrimaryScreenHeight - bottomMargin;

            var width = right - left;
            var height = bottom - top;

            var theta = lineDirection * Math.PI / 180;
            var dist = Math.Sin(theta) * width + Math.Abs(Math.Cos(theta)) * height;
            var lineCount = (int)(dist / lineSpacing + 1);

            for (int i = 0; i < lineCount; i++)
            {
                double x1, y1, x2, y2;

                double left_y;
                if (theta < Math.PI / 2)
                {
                    left_y = i * lineSpacing / Math.Cos(theta);
                }
                else
                {
                    left_y = height + i * lineSpacing / Math.Cos(theta);
                }

                if (left_y > height)
                {
                    x1 = (left_y - height) / Math.Tan(theta);
                    y1 = height;
                }
                else if (left_y < 0)
                {
                    x1 = left_y / Math.Tan(theta);
                    y1 = 0;
                }
                else
                {
                    x1 = 0;
                    y1 = left_y;
                }

                double right_y = left_y - width * Math.Tan(theta);
                if (right_y < 0)
                {
                    x2 = width + right_y / Math.Tan(theta);
                    y2 = 0;
                }
                else if (right_y > height)
                {
                    x2 = width + (right_y - height) / Math.Tan(theta);
                    y2 = height;
                }
                else
                {
                    x2 = width;
                    y2 = right_y;
                }

                var myLine = new Line()
                {
                    Stroke = Brushes.Black,
                    X1 = x1 + left,
                    X2 = x2 + left,
                    Y1 = y1 + top,
                    Y2 = y2 + top,
                    StrokeThickness = lineWidth
                };
                myGrid.Children.Add(myLine);
            }
        }
    }
}