using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2015exam
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students;
        public MainWindow()
        {
            InitializeComponent();
            students = new List<Student>();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(int.Parse(scoreTextBox.Text)>100 || int.Parse(scoreTextBox.Text)<0)
            {
                MessageBox.Show("成绩不符合要求", "错误");
                scoreTextBox.Clear();
            }
            else
            {
                Student student = new Student(Int64.Parse(snoTextBox.Text), nameTextBox.Text, comboBox.Text, int.Parse(scoreTextBox.Text));
                students.Add(student);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(student.ToString());
                textBox.Text += sb.ToString();
            }
        }
        public static void WriteFile(string path, string strings)
        {
            if(!File.Exists(path))
            {
                FileStream m = File.Create(path);
                m.Close();
                m.Dispose();
            }
            StreamWriter sw = new StreamWriter(path);
            sw.Write(strings);
            sw.Flush();
            sw.Close();
            sw.Dispose();
            MessageBox.Show("保存成功");
        }
        public static void ReadFile(string path, TextBox textBox)
        {
            if(!File.Exists(path))
            {
                MessageBox.Show("文件不存在");
            }
            else
            {
                StreamReader sr = new StreamReader(path);
                string text = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                textBox.Text = text;
            }
        }

        public static void WriteXML<T>(T list, string path)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(T));
            FileStream file;
            if (!File.Exists(path))
            {
                file = System.IO.File.Create(path);
            }
            else
            {
                file = File.OpenWrite(path);
            }

            writer.Serialize(file, list);
            file.Close();
        }

        public void ReadXML<T>(ref T list, string path)
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(T));
            StreamReader file;
            if (File.Exists(path))
            {
                file = new System.IO.StreamReader(path);
                list = (T)reader.Deserialize(file);
                file.Close();
            }
            else
            {
                MessageBox.Show("文件不存在");
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string path = "chengji.txt";
            string xmlpath = "xuesheng.xml";
            WriteXML(students, xmlpath);
            WriteFile(path, textBox.Text);

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string path = "chengji.txt";
            string xmlpath = "xuesheng.xml";
            ReadXML(ref students, xmlpath);
            ReadFile(path, textBox);
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if(radioButton1.IsChecked == true)
            {
                var q = from i in students
                        where i.Sno.ToString() == textbox1.Text
                        select i;
                if(q.Count() == 0)
                {
                    MessageBox.Show("没有该学生");
                }
                else
                {
                    textbox2.Text = q.First().Course.ToString() + "," + q.First().Score.ToString();
                }
            }
        }
    }
}
