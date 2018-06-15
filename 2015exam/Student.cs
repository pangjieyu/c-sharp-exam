using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015exam
{
    public class Student
    {
        public Int64 Sno { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public int Score { get; set; }
        public Student(Int64 Sno, string Name, string Course, int Score)
        {
            this.Sno = Sno;
            this.Name = Name;
            this.Course = Course;
            this.Score = Score;
        }
        public Student()
        {
            new Student(0, "未命名", "无", 0);
        }
        
        public override string ToString()
        {
            string str = this.Sno.ToString() + "，" + this.Name.ToString() + "，" + this.Course.ToString() + "，" + this.Score.ToString();
            return str;
        }

        public static double Avg(List<Student> students)
        {
            double sum = 0;
            int count = 0;
            foreach(var student in students)
            {
                sum += student.Score;
                count++;
            }
            return sum / count;
        }
    }
}
