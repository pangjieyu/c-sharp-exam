using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2015exam
{
    /// <summary>
    /// Color.xaml 的交互逻辑
    /// </summary>
    public partial class Color : Window
    {
        public Color()
        {
            InitializeComponent();
        }
        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point p1 = e.GetPosition(canvas1);
            MessageBox.Show(string.Format("鼠标坐标为：X={0:f}, Y={1:f}", p1.X, p1.Y));

        }

    }
}
