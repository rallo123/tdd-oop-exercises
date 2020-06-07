using Lecture_1;
using Lecture_1_Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static Lecture_1_Tests.Exercise_1_Helpers;
using static Lecture_1_Tests.Exercise_1_Tests;
using static Lecture_1_Tests.Exercise_1_PersonSamples;

namespace Lecture_1_Tests
{
    public static class Exercise_1_Helpers
    {
        public static T CreateT<T>(Dictionary<string, object> memberInitialize = null)
        {
            TestHelper.TestConstructorExists(typeof(T));

            T instance = (T)MemberHelper.CreateInstance(typeof(T));
            if (memberInitialize != null)
            {
                foreach (var member in memberInitialize)
                    TestHelper.TestValidAssignment(instance, member.Key, member.Value);
            }
            return instance;
        }
        public static Person CreatePerson(Dictionary<string, object> memberInitialize = null)
        {
            return CreateT<Person>(memberInitialize);
        }
        public static PersonGenerator CreatePersonGenerator()
        {
            return CreateT<PersonGenerator>();
        }
        public static PersonPrinter CreatePersonPrinter()
        {
            return CreateT<PersonPrinter>();
        }

        public static bool ArePersonsEqual(Person p1, Person p2)
        {
            if (!MemberHelper.TryGetValue(p1, "FirstName").Equals(MemberHelper.TryGetValue(p2, "FirstName")))
                return false;
            if (!MemberHelper.TryGetValue(p1, "LastName").Equals(MemberHelper.TryGetValue(p2, "LastName")))
                return false;
            if (!MemberHelper.TryGetValue(p1, "Age").Equals(MemberHelper.TryGetValue(p2, "Age")))
                return false;

            return true;
        }

        public static string PersonToString(Person p)
        {
            return $"{MemberHelper.TryGetValue(p, "FirstName")} {MemberHelper.TryGetValue(p, "LastName")} ({MemberHelper.TryGetValue(p, "Age")})";
        }
    }

    public static class Exercise_1_Tests
    {
        public static void TestPersonMemberIsProperty(string name)
        {
            TestHelper.TestMemberIsProperty(typeof(Person), name);
        }

        public static void TestPersonMemberIsPropertyWithPublicGetAndSetMethods(string name)
        {
            TestHelper.TestMemberIsPropertyWithGetAndSetMethods(typeof(Person), name, isPublic: true);
        }

        public static void TestPersonMemberIsOfType(string name, Type type)
        {
            TestHelper.TestMemberIsFieldOrPropertyOfType(typeof(Person), name, type);
        }

        public static void TestIgnoredAssigmentToPersonMember(string name, object value)
        {
            TestHelper.TestIgnoredAssignment(CreatePerson(), name, value);
        }

        public static void TestFamilyMember(string role, Person expected, Person actual)
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
    }

    public static class Exercise_1_PersonSamples
    {
        public static Person adam;
        public static Person gustav;
        public static Person elsa;
        public static Person warren;
        public static Person anna;
        public static Person robin;

        public static void InitializeSamples()
        {
            adam = CreatePerson(new Dictionary<string, object>()
            {
                ["FirstName"] = "Adam",
                ["LastName"] = "Smith",
                ["Age"] = 36
            });
            gustav = CreatePerson(new Dictionary<string, object>()
            {
                ["FirstName"] = "Gustav",
                ["LastName"] = "Rich",
                ["Age"] = 66
            });
            elsa = CreatePerson(new Dictionary<string, object>()
            {
                ["FirstName"] = "Elsa",
                ["LastName"] = "Johnson",
                ["Age"] = 65
            });
            warren = CreatePerson(new Dictionary<string, object>()
            {
                ["FirstName"] = "Warren",
                ["LastName"] = "Rich",
                ["Age"] = 36
            });
            anna = CreatePerson(new Dictionary<string, object>()
            {
                ["FirstName"] = "Anna",
                ["LastName"] = "Smith",
                ["Age"] = 38
            });
            robin = CreatePerson(new Dictionary<string, object>()
            {
                ["FirstName"] = "Robin",
                ["LastName"] = "Rich",
                ["Age"] = 10
            });
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
        public void FirstNameAssignmentIgnoredOnNull() => TestIgnoredAssigmentToPersonMember("FirstName", null);
        [TestMethod]
        public void LastNameAssignmentIgnoredOnNull() => TestIgnoredAssigmentToPersonMember("LastName", null);

        [TestMethod]
        public void FirstNameAssignmentIgnoredOnEmptyString() => TestIgnoredAssigmentToPersonMember("FirstName", "");
        [TestMethod]
        public void LastNameAssignmentIgnoredOnEmptyString() => TestIgnoredAssigmentToPersonMember("LastName", "");

        [TestMethod]
        public void FirstNameAssignmentIgnoredOnNumberCharachter() => TestIgnoredAssigmentToPersonMember("FirstName", "123456789");
        [TestMethod]
        public void LastNameAssignmentIgnoredOnNumbers() => TestIgnoredAssigmentToPersonMember("LastName", "123456789");

        [TestMethod]
        public void FirstNameAssigmentIgnoredOnStringWithLength101() => TestIgnoredAssigmentToPersonMember("FirstName", GenerateStringOfLength(101));
        [TestMethod]
        public void LastNameAssignmentIgnoredOnStringWithLength101() => TestIgnoredAssigmentToPersonMember("LastName", GenerateStringOfLength(101));

        [TestMethod]
        public void AgeIgnoresOnNegativeInt() => TestIgnoredAssigmentToPersonMember("Age", -1);
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
        public void MotherAssignmentIgnoredIfYoungerThanChild()
        {
            Person mother = CreatePerson();
            TestHelper.TestValidAssignment(mother, "Age", 0);
            
            Person child = CreatePerson();
            TestHelper.TestValidAssignment(child, "Age", 1);

            TestHelper.TestIgnoredAssignment(child, "Mother", mother);
        }
        [TestMethod]
        public void FatherAssignmentIgnoredIfYoungerThanChild()
        {
            Person father = CreatePerson();
            TestHelper.TestValidAssignment(father, "Age", 0);

            Person child = CreatePerson();
            TestHelper.TestValidAssignment(child, "Age", 1);

            TestHelper.TestIgnoredAssignment(child, "Mother", father);
        }
    }
    
    [TestClass]
    public class Exercise_1C_Tests
    {
        [TestInitialize]
        public void InitializeTests() => InitializeSamples();

        [TestMethod]
        public void PersonIsSmith()
        {
            TestHelper.TestMemberIsMethod(typeof(PersonGenerator), "GeneratePerson");
            TestHelper.TestMemberIsMethodOfSignature(typeof(PersonGenerator), "GeneratePerson", typeof(Person));

            Person actual = (Person)MemberHelper.TryCallMethod(CreatePersonGenerator(), "GeneratePerson");
            Assert.IsTrue(
                ArePersonsEqual(adam, actual),
                $"{PersonToString(actual)} does not match {PersonToString(adam)}"
            );
        }
    }

    [TestClass]
    public class Exercise_1D_Tests
    {
        private Person GetRoot()
        {
            TestHelper.TestMemberIsMethodOfSignature(typeof(PersonGenerator), "GeneratePerson", typeof(Person));
            TestHelper.TestMemberIsMethod(typeof(PersonGenerator), "GenerateFamily");

            return (Person)MemberHelper.TryCallMethod(CreatePersonGenerator(), "GenerateFamily");
        }
        private Person GetNode(string path)
        {
            TestHelper.TestMemberIsPropertyWithGetMethod(typeof(Person), path.Split("."));
            
            return (Person) MemberHelper.TryGetValue(GetRoot(), path.Split("."));
        }

        [TestInitialize]
        public void InitializeTests() => InitializeSamples();

        [TestMethod]
        public void ChildIsRobin() => TestFamilyMember("Child", robin, GetRoot());
        
        [TestMethod]
        public void MotherIsAnna() => TestFamilyMember("Mother", anna, GetNode("Mother"));

        [TestMethod]
        public void FatherIsWarren() => TestFamilyMember("Mother", warren, GetNode("Father"));

        [TestMethod]
        public void GrandMotherIsElsa() => TestFamilyMember("Grandmother", elsa, GetNode("Father.Mother"));

        [TestMethod]
        public void GrandFatherIsGustav() => TestFamilyMember("Grandfather", gustav, GetNode("Father.Father"));
    }
    
    [TestClass]
    public class Exercise_1E_Tests
    {
        [TestMethod]
        public void PrintPersonProducesExpectedOutput()
        {
            TestHelper.TestMemberIsMethod(typeof(PersonPrinter), "PrintPerson");
            TestHelper.TestMemberIsMethodOfSignature(typeof(PersonPrinter), "PrintPerson", null, new Type[] { typeof(Person) });

            static void expected() => Console.Write("Adam Smith (36)");
            static void actual() => MemberHelper.TryCallMethod(CreatePersonPrinter(), "PrintPerson", new object[] { adam });

            TestHelper.TestConsoleOutput(expected, actual);
        }
    }

    [TestClass]
    public class Exercise_1F_Tests
    {
        [TestMethod]
        public void PrintFamilyProducesExpectedOutput()
        {
            TestHelper.TestMemberIsPropertyWithSetMethod(typeof(Person), "Mother");
            TestHelper.TestMemberIsPropertyWithSetMethod(typeof(Person), "Father");
            TestHelper.TestMemberIsMethod(typeof(PersonPrinter), "PrintFamily");
            TestHelper.TestMemberIsMethodOfSignature(typeof(PersonGenerator), "PrintPerson", null, new Type[] { typeof(Person) });

            MemberHelper.SetValue(robin, "Mother", anna);
            MemberHelper.SetValue(robin, "Father", warren);
            MemberHelper.SetValue(warren, "Mother", elsa);
            MemberHelper.SetValue(warren, "Father", gustav);

            static void expected() {
                Console.WriteLine("Robin Rich (10)");
                Console.WriteLine("  Warran Rich (36)");
                Console.WriteLine("    Gustav Rich (66)");
                Console.WriteLine("    Elsa Johnson (65)");
                Console.WriteLine("  Anna Smith (38)");
            };
            static void actual() => MemberHelper.TryCallMethod(CreatePersonPrinter(), "PrintFamily", new object[] { robin });

            TestHelper.TestConsoleOutput(expected, actual);
        }
    }
}
