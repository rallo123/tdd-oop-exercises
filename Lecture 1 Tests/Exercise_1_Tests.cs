using Lecture_1;
using Lecture_1_Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using static Lecture_1_Tests.Exercise_1_SharedTests;

namespace Lecture_1_Tests
{
    public static class Exercise_1_SharedTests
    {
        public static void TestPersonMemberIsProperty(string name) => TestHelper.TestMemberIsProperty(typeof(Person), name);
        
        public static void TestPersonMemberIsPropertyWithPublicGetAndSetMethods(string name) => TestHelper.TestMemberIsPropertyWithGetAndSetMethods(typeof(Person), name, isPublic: true);

        public static void TestPersonMemberIsOfType(string name, Type type) => TestHelper.TestMemberIsOfType(typeof(Person), name, type);

        public static void TestInvalidAssigmentToPersonMember<TException>(string name, object value) where TException : Exception
        {
            TestHelper.TestInvalidAssignment<TException>(new Person(), name, value);
        }
    }

    [TestClass]
    public class Exercise_1A_Tests
    {
        private string GenerateStringOfLength(int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
                stringBuilder.Append("a");
            return stringBuilder.ToString();
        }

        [TestMethod]
        public void FirstNameIsProperty() => TestPersonMemberIsProperty("FirstName");
        [TestMethod]
        public void LastNameIsProperty() => TestPersonMemberIsProperty("LastName");
        [TestMethod]
        public void AgeIsProperty() => TestPersonMemberIsProperty("Age");

        [TestMethod]
        public void FirstNameIsPublicProperty() => TestPersonMemberIsPropertyWithPublicGetAndSetMethods("FirstName");
        [TestMethod]
        public void LastNameIsPublicProperty() => TestPersonMemberIsPropertyWithPublicGetAndSetMethods("LastName");
        [TestMethod]
        public void AgeIsPublicProperty() => TestPersonMemberIsPropertyWithPublicGetAndSetMethods("Age");

        [TestMethod]
        public void FirstNameIsOfTypeString() => TestPersonMemberIsOfType("FirstName", typeof(string));
        [TestMethod]
        public void LastNameIsOfTypeString() => TestPersonMemberIsOfType("LastName", typeof(string));
        [TestMethod]
        public void AgeIsOfTypeInt() => TestPersonMemberIsOfType("Age", typeof(int));
        
        [TestMethod]
        public void FirstNameThrowsOnNull() => TestInvalidAssigmentToPersonMember<ArgumentNullException>("FirstName", null);
        [TestMethod]
        public void LastNameThrowsOnNull() => TestInvalidAssigmentToPersonMember<ArgumentNullException>("LastName", null);

        [TestMethod]
        public void FirstNameThrowsOnEmptyString() => TestInvalidAssigmentToPersonMember<ArgumentException>("FirstName", "");
        [TestMethod]
        public void LastNameThrowsOnEmptyString() => TestInvalidAssigmentToPersonMember<ArgumentException>("LastName", "");

        [TestMethod]
        public void FirstNameThrowsOnNumbers() => TestInvalidAssigmentToPersonMember<ArgumentException>("FirstName", "123456789");
        [TestMethod]
        public void LastNameThrowsOnNumbers() => TestInvalidAssigmentToPersonMember<ArgumentException>("LastName", "123456789");

        [TestMethod]
        public void FirstNameThrowsOnStringWithLength101() => TestInvalidAssigmentToPersonMember<ArgumentException>("FirstName", GenerateStringOfLength(101));
        [TestMethod]
        public void LastNameThrowsOnStringWithLength101() => TestInvalidAssigmentToPersonMember<ArgumentException>("LastName", GenerateStringOfLength(101));

        [TestMethod]
        public void AgeThrowsOnNegativeInt() => TestInvalidAssigmentToPersonMember<ArgumentException>("Age", -1);
    }

    [TestClass]
    public class Exercise_1B_Tests
    {
        [TestMethod]
        public void MotherIsProperty() => TestPersonMemberIsProperty("Mother");
        [TestMethod]
        public void FatherIsProperty() => TestPersonMemberIsProperty("Father");


        public void MotherIsPublicProperty() => TestPersonMemberIsPropertyWithPublicGetAndSetMethods("Mother");
        [TestMethod]
        public void FatherIsPublicProperty() => TestPersonMemberIsPropertyWithPublicGetAndSetMethods("Father");


        [TestMethod]
        public void MotherIsOfTypePerson() => TestPersonMemberIsOfType("Mother", typeof(Person));
        [TestMethod]
        public void FatherIsOfTypePerson() => TestPersonMemberIsOfType("Father", typeof(Person));

        [TestMethod]
        public void MotherThrowsIfYoungerThanChild()
        {
            Person mother = new Person();
            MemberHelper.SetValue(mother, "Age", 0);

            Person child = new Person();
            MemberHelper.SetValue(child, "Age", 1);

            TestHelper.TestInvalidAssignment<ArgumentException>(child, "Mother", mother);
        }
        [TestMethod]
        public void FatherThrowsIfYoungerThanChild()
        {
            Person father = new Person();
            MemberHelper.SetValue(father, "Age", 0);

            Person child = new Person();
            MemberHelper.SetValue(child, "Age", 1);

            TestHelper.TestInvalidAssignment<ArgumentException>(child, "Mother", father);
        }
    }
    [TestClass]
    public class Exercise_1C_Tests
    {
        readonly Person gustav = new Person()
        {
            FirstName = "Gustav",
            LastName = "Rich",
            Age = 66
        };
        readonly Person elsa = new Person()
        {
            FirstName = "Gustav",
            LastName = "Rich",
            Age = 66
        };
        readonly Person warren = new Person()
        {
            FirstName = "Warren",
            LastName = "Rich",
            Age = 36
        };
        readonly Person anna = new Person()
        {
            FirstName = "Anna",
            LastName = "Smith",
            Age = 38
        };
        readonly Person robin = new Person()
        {
            FirstName = "Robin",
            LastName = "Rich",
            Age = 10
        };
        
        private Person GetRoot()
        {
            //TODO add tests
            return (Person)MemberHelper.TryCallMethod(new FamilyGenerator(), "GenerateFamily");
        }
        private Person GetNode(string path)
        {
            //TODO add tests
            return (Person) MemberHelper.TryGetValue(GetRoot(), path.Split("."));
        }
        private string PersonToString(Person p)
        {
            return $"{MemberHelper.TryGetValue(p, "FirstName")} {MemberHelper.TryGetValue(p, "LastName")} ({MemberHelper.TryGetValue(p, "Age")})";
        }
        private bool ArePersonsEqual(Person p1, Person p2)
        {
            if (!MemberHelper.TryGetValue(p1, "FirstName").Equals(MemberHelper.TryGetValue(p2, "FirstName")))
                return false;
            if (!MemberHelper.TryGetValue(p1, "LastName").Equals(MemberHelper.TryGetValue(p2, "LastName")))
                return false;
            if (!MemberHelper.TryGetValue(p1, "Age").Equals(MemberHelper.TryGetValue(p2, "Age")))
                return false;

            return true;
        }

        private void TestFamilyMember(string role, Person expected, Person actual)
        {
            Assert.IsNotNull(
                actual,
                $"{role} is missing"
            );
            Assert.IsTrue(
                ArePersonsEqual(expected, actual),
                $"{role} {PersonToString(actual)} does not match {PersonToString(expected)}"
            );
        }
        
        [TestMethod]
        public void ChildIsRobin() {
            TestFamilyMember(
                "Child", 
                robin, 
                GetRoot());
        }

        [TestMethod]
        public void MotherIsAnna() => TestFamilyMember("Mother", anna, GetNode("Mother"));

        [TestMethod]
        public void FatherIsWarren() => TestFamilyMember("Mother", robin, GetNode("Father"));

        [TestMethod]
        public void GrandMotherIsElsa() => TestFamilyMember("Grandmother", elsa, GetNode("Father.Mother"));

        [TestMethod]
        public void GrandFatherIsGustav() => TestFamilyMember("Grandfather", gustav, GetNode("Father.Father"));
    }
}
