using Lecture_9_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Integrated;
using TestTools.Operation;
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
            UnitTestObject<Course> course = test.CreateObject<Course>();
            UnitTestObject<Student> student = test.CreateObject<Student>();

            course.Arrange(() => new Course());
            student.Arrange(() => new Student());
            course.WithParameters(student).Act((c, s) => c.Enroll(s));
            course.WithParameters(student).Assert.IsTrue((c, s) => c.Students.SequenceEqual(new[] { s }));

            test.Execute();
        }

        [TestMethod("e. Course.Disenroll(Student s) removes student again")]
        public void CourseDisenrollRemovesStudentAgain()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Course> course = test.CreateObject<Course>();
            UnitTestObject<Student> student = test.CreateObject<Student>();

            course.Arrange(() => new Course());
            student.Arrange(() => new Student());
            course.WithParameters(student).Act((c, s) => c.Enroll(s));
            course.WithParameters(student).Act((c, s) => c.Disenroll(s));
            course.WithParameters(student).Assert.IsFalse((c, s) => c.Students.Any());

            test.Execute();
        }
        #endregion

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
            UnitTestObject<Course> course = test.CreateObject<Course>();
            UnitTestObject<Student> student = test.CreateObject<Student>();

            course.Arrange(() => new Course());
            student.Arrange(() => new Student() { ID = 5 });
            course.WithParameters(student).Act((c, s) => c.Enroll(s));
            course.WithParameters(student).Assert.IsTrue((c, s) => c.GetStudentByID(5) == s);

            test.Execute();
        }

        [TestMethod("f. Course.GetYoungestStudent() returns correctly")]
        public void CourseGetYoungestStudentReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Course> course = test.CreateObject<Course>();
            UnitTestObject<Student> youngestStudent = test.CreateObject<Student>();
            UnitTestObject<Student> oldestStudent = test.CreateObject<Student>();

            course.Arrange(() => new Course());
            youngestStudent.Arrange(() => new Student() { Age = 19 });
            oldestStudent.Arrange(() => new Student() { Age = 23 });
            course.WithParameters(youngestStudent).Act((c, s) => c.Enroll(s));
            course.WithParameters(oldestStudent).Act((c, s) => c.Enroll(s));
            course.WithParameters(youngestStudent).Assert.IsTrue((c, s) => c.GetYoungestStudent() == s);

            test.Execute();
        }

        [TestMethod("g. Course.GetOldestStudent() returns correctly")]
        public void CourseGetOldestStudentReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Course> course = test.CreateObject<Course>();
            UnitTestObject<Student> youngestStudent = test.CreateObject<Student>();
            UnitTestObject<Student> oldestStudent = test.CreateObject<Student>();

            course.Arrange(() => new Course());
            youngestStudent.Arrange(() => new Student() { Age = 19 });
            oldestStudent.Arrange(() => new Student() { Age = 23 });
            course.WithParameters(youngestStudent).Act((c, s) => c.Enroll(s));
            course.WithParameters(oldestStudent).Act((c, s) => c.Enroll(s));
            course.WithParameters(oldestStudent).Assert.IsTrue((c, s) => c.GetOldestStudent() == s);

            test.Execute();
        }

        [TestMethod("h. Course.GetAverageStudentAge() returns correctly")]
        public void CourseGetAverageStudentAgeReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Course> course = test.CreateObject<Course>();
            UnitTestObject<Student> youngestStudent = test.CreateObject<Student>();
            UnitTestObject<Student> oldestStudent = test.CreateObject<Student>();

            course.Arrange(() => new Course());
            youngestStudent.Arrange(() => new Student() { Age = 19 });
            oldestStudent.Arrange(() => new Student() { Age = 23 });
            course.WithParameters(youngestStudent).Act((c, s) => c.Enroll(s));
            course.WithParameters(oldestStudent).Act((c, s) => c.Enroll(s));
            course.Assert.IsTrue(c => c.GetAverageStudentAge() == 21.0);

            test.Execute();
        }
        #endregion
    }
}
