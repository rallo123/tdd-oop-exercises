using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Helpers.StructureHelper;
using static Lecture_2_Tests.TestHelper;
using static TestTools.Unit.TestExpression;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_1_Tests
    {
        private string CreateName(int length)
        {
            throw new NotImplementedException();
        }

        #region Exercise 1A
        [TestMethod("a. Person.FirstName is public string property"), TestCategory("Exercise 1A")]
        public void FirstNameIsPublicStringProperty() {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, string>(p => p.FirstName);
            test.Execute();
        }

        [TestMethod("b. Person.LastName is public string property"), TestCategory("Exercise 1A")]
        public void LastNameIsPublicStringProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, string>(p => p.LastName);
            test.Execute();
        }

        [TestMethod("c. Person.Age is public int property"), TestCategory("Exercise 1A")]
        public void AgeIsPublicIntProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, int>(p => p.Age);
            test.Execute();
        }

        [TestMethod("d. Person.FirstName is initialized as \"Unknown\""), TestCategory("Exercise 1A")]
        public void FirstNameIsInitializedAsUnnamed()
        {
            Person person = new Person();
            Assert.AreEqual(person.FirstName, "Unknown");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>();
            test.Arrange(_person, Expr(() => new Person()));
            test.Assert.AreEqual(Expr(_person, p => p.FirstName), Const("Unknown"));
            test.Execute();
        }

        [TestMethod("e. Person.FirstName is initialized as \"Unknown\""), TestCategory("Exercise 1A")]
        public void LastNameIsInitializedAsUnnamed()
        {
            Person person = new Person();
            Assert.AreEqual(person.LastName, "Unknown");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Assert.AreEqual(Expr(_person, p => p.LastName), Const("Unknown"));
            test.Execute();
        }

        [TestMethod("f. Person.FirstName ignores assigment of null"), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOfNull() 
        {
            Person person = new Person();
            person.FirstName = null;
            Assert.AreEqual(person.FirstName, "Unknown");
            
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Act(Expr(_person, p => p.SetFirstName(null)));
            test.Assert.AreEqual(Expr(_person, p => p.FirstName), Const("Unknown"));
            test.Execute();
        }

        [TestMethod("g. Person.LastName ignores assigment of null"), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOfNull()
        {
            Person person = new Person();
            person.LastName = null;
            Assert.AreEqual(person.LastName, "Unknown");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Act(Expr(_person, p => p.SetLastName(null)));
            test.Assert.AreEqual(Expr(_person, p => p.LastName), Const("Unknown"));
            test.Execute();
        }

        [TestMethod("h. Person.FirstName ignores assigment of \"123456789\""), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOf012345689()
        {
            Person person = new Person();
            person.FirstName = "123456789";
            Assert.AreEqual(person.FirstName, "Unknown");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Act(Expr(_person, p => p.SetFirstName("123456789")));
            test.Assert.AreEqual(Expr(_person, p => p.FirstName), Const("Unknown"));
            test.Execute();
        }

        [TestMethod("i. Person.LastName ignores assigment of \"123456789\""), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOf012345689()
        {
            Person person = new Person();
            person.LastName = "123456789";
            Assert.AreEqual(person.LastName, "Unknown");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Act(Expr(_person, p => p.SetLastName("123456789")));
            test.Assert.AreEqual(Expr(_person, p => p.LastName), Const("Unknown"));
            test.Execute();
        }

        [TestMethod("j. Person.FirstName ignores assigment of string with length 101"), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOfStringWithLength101()
        {
            Person person = new Person();
            person.FirstName = CreateName(101);
            Assert.AreEqual(person.FirstName, "Unknown");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Act(Expr(_person, p => p.SetFirstName(CreateName(101))));
            test.Assert.AreEqual(Expr(_person, p => p.FirstName), Const("Unknown"));
            test.Execute();
        }

        [TestMethod("k. Person.LastName ignores assignment of string with length 101"), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOfStringWithLength101()
        {
            Person person = new Person();
            person.LastName = CreateName(101);
            Assert.AreEqual(person.LastName, "Unknown");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Act(Expr(_person, p => p.SetLastName(CreateName(101))));
            test.Assert.AreEqual(Expr(_person, p => p.LastName), Const("Unknown"));
            test.Execute();
        }

        [TestMethod("l. Person.Age is initialized as 0"), TestCategory("Exercise 1A")]
        public void AgeIsInitilizedAs0()
        {
            Person person = new Person();
            Assert.AreEqual(person.Age, 0);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Assert.AreEqual(Expr(_person, p => p.Age), Const(0));
            test.Execute();
        }

        [TestMethod("m. Person.Age ignores assigment of -1"), TestCategory("Exercise 1A")]
        public void AgeIgnoresAssignmentOfMinusOne()
        {
            Person person = new Person();
            person.Age = -1;
            Assert.AreEqual(person.Age, -1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Act(Expr(_person, p => p.SetAge(-1)));
            test.Assert.AreEqual(Expr(_person, p => p.Age), Const(-1));
            test.Execute();
        }
        #endregion

        #region Exercise 1B
        [TestMethod("a. Person.Mother is public Person property"), TestCategory("Exercise 1B")]
        public void MotherIsPublicPersonProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, Person>(p => p.Mother);
            test.Execute();
        }

        [TestMethod("b. Person.Father is public Person property"), TestCategory("Exercise 1B")]
        public void FatherIsPublicPersonProperty() {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, Person>(p => p.Father);
            test.Execute();
        }

        [TestMethod("c. Person.Mother is initialized as null"), TestCategory("Exercise 1A")]
        public void MotherIsInitilizedAsnull()
        {
            Person person = new Person();
            Assert.IsNull(person.Mother);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Assert.IsNull(Expr(_person, p => p.Mother));
            test.Execute();
        }

        [TestMethod("d. Person.Father is initialized as null"), TestCategory("Exercise 1A")]
        public void FatherIsInitilizedAsnull()
        {
            Person person = new Person();
            Assert.IsNull(person.Father);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person()));
            test.Assert.IsNull(Expr(_person, p => p.Father));
            test.Execute();
        }

        [TestMethod("c. Person.Mother ignores assigment if mother is younger than child"), TestCategory("Exercise 1B")]
        public void MotherIgnoresAssigmentIfMotherIsYoungerThanChild()
        {
            Person mother = new Person() { Age = 0 };
            Person child = new Person() { Age = 1 };
            
            child.Mother = mother;
            
            Assert.IsNull(child.Mother);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _child = test.CreateVariable<Person>(nameof(_child));
            TestVariable<Person> _mother = test.CreateVariable<Person>(nameof(_mother));
            test.Arrange(_child, Expr(() => new Person() { Age = 1 }));
            test.Arrange(_mother, Expr(() => new Person() { Age = 0 }));
            test.Act(Expr(_child, _mother, (p1, p2) => p1.SetMother(p2)));
            test.Assert.IsNull(Expr(_mother, p => p.Mother));
            test.Execute();
        }
        
        [TestMethod("d. Person.Father ignores assigment if mother is younger than child"), TestCategory("Exercise 1B")]
        public void FatherIgnoresAssigmentIfMotherIsYoungerThanChild()
        {
            Person father = new Person() { Age = 0 };
            Person child = new Person() { Age = 1 };
            
            child.Father = father;
            
            Assert.IsNull(child.Father);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _child = test.CreateVariable<Person>(nameof(_child));
            TestVariable<Person> _father = test.CreateVariable<Person>(nameof(_father));
            test.Arrange(_child, Expr(() => new Person() { Age = 1 }));
            test.Arrange(_father, Expr(() => new Person() { Age = 0 }));
            test.Act(Expr(_child, _father, (p1, p2) => p1.SetFather(p2)));
            test.Assert.IsNull(Expr(_father, p => p.Father));
            test.Execute();
        }
        #endregion

        #region Exercise 1C
        [TestMethod("a. PersonGenerator.GeneratePerson takes no arguments and returns Person"), TestCategory("Exercise 1C")]
        public void GeneratePersonReturnsPerson()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<PersonGenerator, Person>(g => g.GeneratePerson());
            test.Execute();
        }

        [TestMethod("b. PersonGenerator.GeneratePerson generates Adam Smith (36)"), TestCategory("Exercise 1C")]
        public void GeneratePersonCreatesAdamSmith()
        {
            PersonGenerator generator = new PersonGenerator();
            Person person = generator.GeneratePerson();

            Assert.AreEqual(person.FirstName, "Adam");
            Assert.AreEqual(person.LastName, "Smith");
            Assert.AreEqual(person.Age, 36);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> _generator = test.CreateVariable<PersonGenerator>(nameof(_generator));
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_generator, Expr(() => new PersonGenerator()));
            test.Arrange(_person, Expr(_generator, g => g.GeneratePerson()));
            test.Assert.AreEqual(Expr(_person, p => p.FirstName), Const("Adam"));
            test.Assert.AreEqual(Expr(_person, p => p.LastName), Const("Smith"));
            test.Assert.AreEqual(Expr(_person, p => p.Age), Const(36));
            test.Execute();
        }
        #endregion

        #region Exercise 1D
        [TestMethod("a. PersonGenerator.GenerateFamily takes no arguments and returns Person "), TestCategory("Exercise 1D")]
        public void GenerateFamilyReturnsPerson()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<PersonGenerator, Person>(g => g.GenerateFamily());
            test.Execute();
        }

        [TestMethod("b. PersonGenerator.GenerateFamily generates Robin Rich (10) as child"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesRobinRichAsChild()
        {
            PersonGenerator generator = new PersonGenerator();
            Person person = generator.GenerateFamily();

            Assert.AreEqual(person.FirstName, "Robin");
            Assert.AreEqual(person.LastName, "Rich");
            Assert.AreEqual(person.Age, 10);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> _generator = test.CreateVariable<PersonGenerator>(nameof(_generator));
            TestVariable<Person> _child = test.CreateVariable<Person>(nameof(_child));
            test.Arrange(_generator, Expr(() => new PersonGenerator()));
            test.Arrange(_child, Expr(_generator, g => g.GenerateFamily()));
            test.Assert.AreEqual(Expr(_child, p => p.FirstName), Const("Robin"));
            test.Assert.AreEqual(Expr(_child, p => p.LastName), Const("Rich"));
            test.Assert.AreEqual(Expr(_child, p => p.Age), Const(10));
            test.Execute();
        }

        [TestMethod("c. PersonGenerator.GenerateFamily generates Waren Rich (36) as father"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesRobinRichAsFather()
        {
            PersonGenerator generator = new PersonGenerator();
            Person father = generator.GenerateFamily().Father;

            Assert.AreEqual(father.FirstName, "Warran");
            Assert.AreEqual(father.LastName, "Rich");
            Assert.AreEqual(father.Age, 36);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> _generator = test.CreateVariable<PersonGenerator>(nameof(_generator));
            TestVariable<Person> _father = test.CreateVariable<Person>(nameof(_father));
            test.Arrange(_generator, Expr(() => new PersonGenerator()));
            test.Arrange(_father, Expr(_generator, g => g.GenerateFamily().Father));
            test.Assert.AreEqual(Expr(_father, p => p.FirstName), Const("Warren"));
            test.Assert.AreEqual(Expr(_father, p => p.LastName), Const("Rich"));
            test.Assert.AreEqual(Expr(_father, p => p.Age), Const(36));
            test.Execute();
        }

        [TestMethod("d. PersonGenerator.GenerateFamily generates Anna Smith (38) as mother"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesAnnaRichAsMother()
        {
            PersonGenerator generator = new PersonGenerator();
            Person mother = generator.GenerateFamily().Mother;

            Assert.AreEqual(mother.FirstName, "Anna");
            Assert.AreEqual(mother.LastName, "Smith");
            Assert.AreEqual(mother.Age, 38);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> _generator = test.CreateVariable<PersonGenerator>(nameof(_generator));
            TestVariable<Person> _mother = test.CreateVariable<Person>(nameof(_mother));
            test.Arrange(_generator, Expr(() => new PersonGenerator()));
            test.Arrange(_mother, Expr(_generator, g => g.GenerateFamily().Mother));
            test.Assert.AreEqual(Expr(_mother, p => p.FirstName), Const("Anna"));
            test.Assert.AreEqual(Expr(_mother, p => p.LastName), Const("Smith"));
            test.Assert.AreEqual(Expr(_mother, p => p.Age), Const(38));
            test.Execute();
        }

        [TestMethod("e. PersonGenerator.GenerateFamily generates Gustav Rich (66) as grandfather"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesGustavRichAsGrandfather()
        {
            PersonGenerator generator = new PersonGenerator();
            Person grandFather = generator.GenerateFamily().Father.Father;

            Assert.AreEqual(grandFather.FirstName, "Gustav");
            Assert.AreEqual(grandFather.LastName, "Rich");
            Assert.AreEqual(grandFather.Age, 66);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> _generator = test.CreateVariable<PersonGenerator>(nameof(_generator));
            TestVariable<Person> _grandFather = test.CreateVariable<Person>(nameof(_grandFather));
            test.Arrange(_generator, Expr(() => new PersonGenerator()));
            test.Arrange(_grandFather, Expr(_generator, g => g.GenerateFamily().Father.Father));
            test.Assert.AreEqual(Expr(_grandFather, p => p.FirstName), Const("Gustav"));
            test.Assert.AreEqual(Expr(_grandFather, p => p.LastName), Const("Rich"));
            test.Assert.AreEqual(Expr(_grandFather, p => p.Age), Const(66));
            test.Execute();
        }

        [TestMethod("f. PersonGenerator.GenerateFamily generates Elsa Johnson (65) as grandmother"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesElsaJohnsonAsGrandMother()
        {
            PersonGenerator generator = new PersonGenerator();
            Person grandFather = generator.GenerateFamily();

            Assert.AreEqual(grandFather.FirstName, "Elsa");
            Assert.AreEqual(grandFather.LastName, "Johnson");
            Assert.AreEqual(grandFather.Age, 65);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PersonGenerator> _generator = test.CreateVariable<PersonGenerator>(nameof(_generator));
            TestVariable<Person> _grandMother = test.CreateVariable<Person>(nameof(_grandMother));
            test.Arrange(_generator, Expr(() => new PersonGenerator()));
            test.Arrange(_grandMother, Expr(_generator, g => g.GenerateFamily().Father.Mother));
            test.Assert.AreEqual(Expr(_grandMother, p => p.FirstName), Const("Elsa"));
            test.Assert.AreEqual(Expr(_grandMother, p => p.LastName), Const("Johnson"));
            test.Assert.AreEqual(Expr(_grandMother, p => p.Age), Const(65));
            test.Execute();
        }
        #endregion

        #region Exercise 1E
        [TestMethod("a. PersonPrinter.PrintPerson takes person as argument and returns nothing"), TestCategory("Exercise 1E")]
        public void PrintPersonTakesPersonAsArgumentAndReturnsNothing() {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<PersonPrinter, Person>((p1, p2) => p1.PrintPerson(p2));
            test.Execute();
        }

        [TestMethod("b. PersonPrinter.PrintPrints prints correctly"), TestCategory("Exercise 1E")]
        public void PrintPersonPrintsCorrectly()
        {
            // Extended MSTest 
            Person person = new Person()
            {
                FirstName = "Adam",
                LastName = "Smith",
                Age = 66
            };
            PersonPrinter printer = new PersonPrinter();

            ConsoleAssert.WritesOut(
                () => printer.PrintPerson(person), 
                "Adam Smith (36)");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            TestVariable<PersonPrinter> _printer = test.CreateVariable<PersonPrinter>(nameof(_printer));
            test.Arrange(_person, Expr(() => new Person() { FirstName = "Adam", LastName = "Smith", Age = 36 }));
            test.Arrange(_printer, Expr(() => new PersonPrinter()));
            test.ConsoleAssert.WritesOut(
                Lambda(Expr(_printer, _person, (p1, p2) => p1.PrintPerson(p2))),
                Const("Adam Smith (36)"));
            test.Execute();
        }
        #endregion

        #region Exercise 1F
        [TestMethod("a. PersonPrinter.PrintFamily takes person as argument and returns nothing"), TestCategory("Exercise 1F")]
        public void PrintFamilyTakesPersonAsArgumentAndReturnsNothing()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<PersonPrinter, Person>((p1, p2) => p1.PrintFamily(p2));
            test.Execute();
        }

        [TestMethod("b. PersonPrinter.PrintFamily prints correctly"), TestCategory("Exercise 1F")]
        public void PrintFamilyPrintsCorrectly()
        {
            // Extended MSTest 
            Person person = new Person()
            {
                FirstName = "Warren",
                LastName = "Rich",
                Age = 36,
                Mother = new Person()
                {
                    FirstName = "Warren",
                    LastName = "Rich",
                    Age = 36
                },
                Father = new Person()
                {
                    FirstName = "Warren",
                    LastName = "Rich",
                    Age = 36,
                    Mother = new Person()
                    {
                        FirstName = "Elsa",
                        LastName = "Johnson",
                        Age = 65
                    },
                    Father = new Person()
                    {
                        FirstName = "Gustav",
                        LastName = "Rich",
                        Age = 66
                    }
                }
            };
            PersonPrinter printer = new PersonPrinter();

            string expectedOutput = string.Join(
                Environment.NewLine,
                "Adam Smith (36)",
                "Robin Rich (10)",
                "Warren Rich (36)",
                "Gustav Rich (66)",
                "Elsa Johnson (65)",
                "Anna Smith (38)");
            ConsoleAssert.WritesOut(() => printer.PrintFamily(person), expectedOutput);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>("person");
            TestVariable<PersonPrinter> _printer = test.CreateVariable<PersonPrinter>("printer");
            test.Arrange(_person, Expr(() => new Person() { 
                    FirstName = "Warren",
                    LastName = "Rich", 
                    Age = 36, 
                    Mother = new Person() { 
                        FirstName = "Warren", 
                        LastName = "Rich", 
                        Age = 36 
                    },
                    Father = new Person() { 
                        FirstName = "Warren", 
                        LastName = "Rich", 
                        Age = 36, 
                        Mother = new Person() { 
                            FirstName = "Elsa", 
                            LastName = "Johnson", 
                            Age = 65 
                        }, 
                        Father = new Person() { 
                            FirstName = "Gustav",
                            LastName = "Rich", 
                            Age = 66 
                        } 
                    }
                }));
            test.ConsoleAssert.WritesOut(
                Lambda(Expr(_printer, _person, (p1, p2) => p1.PrintFamily(p2))),
                Const(expectedOutput));
            test.Execute();
        }
        #endregion

        #region Exercise 1G
        [TestMethod("a. Person has constructor which takes no arguments"), TestCategory("Exercise 1G")]
        public void PersonHasConstructorWhichTakesNoArguments()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<Person>(
                () => new Person(),
                new MemberAccessLevelVerifier(AccessLevels.Public));
            test.Execute();
        }

        [TestMethod("b. Person has constructor which two persons as arguments"), TestCategory("Exercise 1G")]
        public void PersonHasconstructorWhichTakesTwoPersonsAsArguments()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<Person, Person, Person>(
                (p1, p2) => new Person(p1, p2), 
                new MemberAccessLevelVerifier(AccessLevels.Public));
            test.Execute();
        }

        [TestMethod("c. Person constructor with 2 persons as arguments sets mother and father property"), TestCategory("Exercise 1G")]
        public void PersonConstructorWithTwoPersonArgumentsSetsMotherAndFatherProperty()
        {
            Person mother = new Person() { Age = 37 };
            Person father = new Person() { Age = 37 };
            Person child = new Person(mother, father);

            Assert.AreSame(child.Mother, mother);
            Assert.AreSame(child.Father, father);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _mother = test.CreateVariable<Person>();
            TestVariable<Person> _father = test.CreateVariable<Person>();
            TestVariable<Person> _child = test.CreateVariable<Person>();
            test.Arrange(_mother, Expr(() => new Person() { Age = 37 }));
            test.Arrange(_father, Expr(() => new Person() { Age = 37 }));
            test.Arrange(_child, Expr(_mother, _father, (p1, p2) => new Person(p1, p2)));
            test.Assert.AreSame(Expr(_child, p => p.Mother), Expr(_mother, p => p));
            test.Assert.AreSame(Expr(_child, p => p.Father), Expr(_father, p => p));
            test.Execute();
        }
        #endregion

        #region Exercise 1H
        [TestMethod("a. Person.ID is public read-only int property"), TestCategory("Exercise 1H")]
        public void IDIsPublicReadonlyIntProperty() {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<Person, int>(p => p.ID);
            test.Execute();
        }

        [TestMethod("b. Person.ID increases by 1 for each new person"), TestCategory("Exercise 1H")]
        public void IDIncreasesByOneForEachNewPerson()
        {
            Person person1 = new Person();
            Person person2 = new Person();

            Assert.IsTrue(person1.ID + 1 == person2.ID);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person1 = test.CreateVariable<Person>(nameof(_person1));
            TestVariable<Person> _person2 = test.CreateVariable<Person>(nameof(_person2));
            test.Arrange(_person1, Expr(() => new Person()));
            test.Arrange(_person2, Expr(() => new Person()));
            test.Assert.IsTrue(Expr(_person1, _person2, (p1, p2) => p1.ID + 1 == p2.ID));
            test.Execute();
        }
        #endregion
    }
}
