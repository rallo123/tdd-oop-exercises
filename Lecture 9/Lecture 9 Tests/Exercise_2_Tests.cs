using Lecture_9_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Unit;
using TestTools.Structure;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_9_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_9_Tests
{
    [TestClass]
    public class Exercise_2_Tests
    {
        #region Exercise 2A
        [TestMethod("a. Student.ID is a public property")]
        public void StudentIDIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Student, int>(s => s.ID, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("b. Student.FirstName is a public property")]
        public void StudentFirstNameIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Student, string>(s => s.FirstName, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("c. Student.LastName is a public property")]
        public void StudentLastNameIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Student, string>(s => s.LastName, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("d. Student.LastName is a public property")]
        public void StudentAgeIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Student, int>(s => s.Age, IsPublicProperty);
            test.Execute();
        }
        #endregion

        #region Exercise 2B
        [TestMethod("a. Course.Student is a readonly property")]
        public void CourseStudentIsAReadonlyProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Course, IEnumerable<Student>>(c => c.Students, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("b. Course.Enroll(Student s) is a public method")]
        public void CourseEnrollIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Course, Student>((c, s) => c.Enroll(s), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("c. Course.Disenroll(Student s) is a public method")]
        public void CourseDisenrollIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Course, Student>((c, s) => c.Disenroll(s), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("d. Course.Enroll(Student s) adds student")]
        public void CourseEnrollAddsStudent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Course> course = test.CreateVariable<Course>();
            TestVariable<Student> student = test.CreateVariable<Student>();

            test.Arrange(course, Expr(() => new Course()));
            test.Arrange(student, Expr(() => new Student()));
            test.Act(Expr(course, student, (c, s) => c.Enroll(s)));
            test.Assert.IsTrue(Expr(course, student, (c, s) => c.Students.SequenceEqual(new[] { s })));

            test.Execute();
        }

        [TestMethod("e. Course.Disenroll(Student s) removes student again")]
        public void CourseDisenrollRemovesStudentAgain()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Course> course = test.CreateVariable<Course>();
            TestVariable<Student> student = test.CreateVariable<Student>();

            test.Arrange(course, Expr(() => new Course()));
            test.Arrange(student, Expr(() => new Student()));
            test.Act(Expr(course, student, (c, s) => c.Enroll(s)));
            test.Act(Expr(course, student, (c, s) => c.Disenroll(s)));
            test.Assert.IsFalse(Expr(course, student, (c, s) => c.Students.Any()));

            test.Execute();
        }

        #endregion

        [TestMethod("e. Course.Disenroll(Student s) removes student again")]
        public void CourseDisenrollRemovesStudentAgain2()
        {
            Course course = new Course();
            Student student = new Student();

            course.Enroll(student);
            course.Disenroll(student);

            Assert.IsFalse(course.Students.Any());
        }

        #region Exercise 2C
        [TestMethod("a. Course.GetStudentByID(int id) is a public method")]
        public void CourseGetStudentByIDIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Course, int, Student>((c, i) => c.GetStudentByID(i), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("b. Course.GetYoungestStudent() is a public method")]
        public void CourseGetYoungestStudentIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Course, Student>(c => c.GetYoungestStudent(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("c. Course.GetOldestStudent() is a public method")]
        public void CourseGetOldestStudentIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Course, Student>(c => c.GetOldestStudent(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("d. Course.GetAverageStudentAge() is a public method")]
        public void CourseGetAverageStudentAgeIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Course, double>(c => c.GetAverageStudentAge(), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("e. Course.GetStudentByID(int id) returns correctly")]
        public void CourseGetStudentByIDReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Course> course = test.CreateVariable<Course>();
            TestVariable<Student> student = test.CreateVariable<Student>();

            test.Arrange(course, Expr(() => new Course()));
            test.Arrange(student, Expr(() => new Student() { ID = 5 }));
            test.Act(Expr(course, student, (c, s) => c.Enroll(s)));
            test.Assert.IsTrue(Expr(course, student, (c, s) => c.GetStudentByID(5) == s));

            test.Execute();
        }

        [TestMethod("f. Course.GetYoungestStudent() returns correctly")]
        public void CourseGetYoungestStudentReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Course> course = test.CreateVariable<Course>();
            TestVariable<Student> youngestStudent = test.CreateVariable<Student>();
            TestVariable<Student> oldestStudent = test.CreateVariable<Student>();

            test.Arrange(course, Expr(() => new Course()));
            test.Arrange(youngestStudent, Expr(() => new Student() { Age = 19 }));
            test.Arrange(oldestStudent, Expr(() => new Student() { Age = 23 }));
            test.Act(Expr(course, youngestStudent, (c, s) => c.Enroll(s)));
            test.Act(Expr(course, oldestStudent, (c, s) => c.Enroll(s)));
            test.Assert.IsTrue(Expr(course, youngestStudent, (c, s) => c.GetYoungestStudent() == s));

            test.Execute();
        }

        [TestMethod("g. Course.GetOldestStudent() returns correctly")]
        public void CourseGetOldestStudentReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Course> course = test.CreateVariable<Course>();
            TestVariable<Student> youngestStudent = test.CreateVariable<Student>();
            TestVariable<Student> oldestStudent = test.CreateVariable<Student>();

            test.Arrange(course, Expr(() => new Course()));
            test.Arrange(youngestStudent, Expr(() => new Student() { Age = 19 }));
            test.Arrange(oldestStudent, Expr(() => new Student() { Age = 23 }));
            test.Act(Expr(course, youngestStudent, (c, s) => c.Enroll(s)));
            test.Act(Expr(course, oldestStudent, (c, s) => c.Enroll(s)));
            test.Assert.IsTrue(Expr(course, oldestStudent, (c, s) => c.GetOldestStudent() == s));
            test.Execute();
        }

        [TestMethod("h. Course.GetAverageStudentAge() returns correctly")]
        public void CourseGetAverageStudentAgeReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Course> course = test.CreateVariable<Course>();
            TestVariable<Student> youngestStudent = test.CreateVariable<Student>();
            TestVariable<Student> oldestStudent = test.CreateVariable<Student>();

            test.Arrange(course, Expr(() => new Course()));
            test.Arrange(youngestStudent, Expr(() => new Student() { Age = 19 }));
            test.Arrange(oldestStudent, Expr(() => new Student() { Age = 23 }));
            test.Act(Expr(course, youngestStudent, (c, s) => c.Enroll(s)));
            test.Act(Expr(course, oldestStudent, (c, s) => c.Enroll(s)));
            test.Assert.AreEqual(Expr(course, youngestStudent, (c, s) => c.GetAverageStudentAge()), Const(21.0)));

            test.Execute();
        }
        #endregion
    }
}
