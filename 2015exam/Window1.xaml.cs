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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            ReadPage("MainWindow.xaml", frame1);
        }
        
        public static void ReadPage(string path, Frame frame)
        {
            Uri source = new Uri(path, UriKind.Relative);
            object obj = null;
            try
            {
                obj = Application.LoadComponent(source);
            }
            catch
            {
                MessageBox.Show("未找到 " + source.OriginalString);
                return;
            }
            Page p = obj as Page;
            if (p != null)
            {
                frame.NavigationService.RemoveBackEntry();
                frame.Source = source;
                return;
            }
            Window w = obj as Window;
            if (w != null)
            {
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                w.ShowDialog();
            }
            else MessageBox.Show("无法将加载的对象转换为Window类型");
        }
    }
}
