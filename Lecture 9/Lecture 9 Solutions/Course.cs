using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lecture_9_Solutions
{
    public class Course
    {
        List<Student> _students = new List<Student>();

        public IEnumerable<Student> Students
        {
            get { return _students; }
        }

        public void Enroll(Student student)
        {
            _students.Add(student);
        }

        public void Disenroll(Student student)
        {
            _students.Remove(student);
        }

        public Student GetStudentByID(int id)
        {
            return _students.First(s => s.ID == id);
        }

        public Student GetYoungestStudent()
        {
            return _students.OrderBy(s => s.Age).First();
        }

        public Student GetOldestStudent()
        {
            return _students.OrderByDescending(s => s.Age).First();
        }

        public double GetAverageStudentAge()
        {
            return _students.Select(s => s.Age).Average();
        }
    }
}
