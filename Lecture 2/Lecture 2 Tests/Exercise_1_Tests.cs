using Lecture_2_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using TestTools.Integrated;
using static TestTools.Helpers.ExpressionHelper;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_1_Tests
    {
        TestFactory factory = new TestFactory("Lecture_2");

        private string CreateName(int length)
        {
            throw new NotImplementedException();
        }

        /* Exercise 1A */
        [TestMethod("a. Person.FirstName is public string property"), TestCategory("Exercise 1A")]
        public void FirstNameIsPublicStringProperty() {
            StructureTest test = factory.CreateStructureTest();
            Expression<Func<Person, string>> firstName = p => p.FirstName;

            test.AssertPropertyType(firstName, typeof(string));
            test.AssertPropertyGetterAndSetterPublic(firstName);
        }

        [TestMethod("b. Person.LastName is public string property"), TestCategory("Exercise 1A")]
        public void LastNameIsPublicStringProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            Expression<Func<Person, string>> lastName = p => p.FirstName;

            test.AssertPropertyType(lastName, typeof(string));
            test.AssertPropertyGetterAndSetterPublic(lastName);
        }

        [TestMethod("c. Person.Age is public int property"), TestCategory("Exercise 1A")]
        public void AgeIsPublicIntProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            Expression<Func<Person, int>> age = p => p.Age;

            test.AssertPropertyType(age, typeof(int));
            test.AssertPropertyGetterAndSetterPublic(age);
        }

        [TestMethod("d. Person.FirstName ignores assigment of null"), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOfNull() {
            Test test = factory.CreateTest();
            TestObject<Person> person = test.Create<Person>();

            test.Arrange(person, () => new Person());
            test.Act(person, Assignment<Person, string>(p => p.FirstName, null));
            test.AssertUnchanged(person, p => p.FirstName);

            test.Execute();
        }

        [TestMethod("e. Person.LastName ignores assigment of null"), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOfNull()
        {
            Test test = factory.CreateTest();
            TestObject<Person> person = test.Create<Person>();

            test.Arrange(person, () => new Person());
            test.Act(person, Assignment<Person, string>(p => p.LastName, null));
            test.AssertUnchanged(person, p => p.LastName);

            test.Execute();
        }

        [TestMethod("f. Person.FirstName ignores assigment of \"123456789\""), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOf012345689()
        {
            Test test = factory.CreateTest();
            TestObject<Person> person = test.Create<Person>();

            test.Arrange(person, () => new Person());
            test.Act(person, Assignment<Person, string>(p => p.FirstName, "123456789"));
            test.AssertUnchanged(person, p => p.FirstName);

            test.Execute();
        }

        [TestMethod("g. Person.LastName ignores assigment of \"123456789\""), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOf012345689()
        {
            Test test = factory.CreateTest();
            TestObject<Person> person = test.Create<Person>();

            test.Arrange(person, () => new Person());
            test.Act(person, Assignment<Person, string>(p => p.LastName, "123456789"));
            test.AssertUnchanged(person, p => p.LastName);

            test.Execute();
        }

        [TestMethod("h. Person.FirstName ignores assigment of string with length 101"), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOfStringWithLength101()
        {
            Test test = factory.CreateTest();
            TestObject<Person> person = test.Create<Person>();

            test.Arrange(person, () => new Person());
            test.Act(person, Assignment<Person, string>(p => p.FirstName, CreateName(101)));
            test.AssertUnchanged(person, p => p.FirstName);

            test.Execute();
        }

        [TestMethod("i. Person.LastName ignores assignment of string with length 101"), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOfStringWithLength101()
        {
            Test test = factory.CreateTest();
            TestObject<Person> person = test.Create<Person>();

            test.Arrange(person, () => new Person());
            test.Act(person, Assignment<Person, string>(p => p.LastName, CreateName(101)));
            test.AssertUnchanged(person, p => p.LastName);

            test.Execute();
        }

        [TestMethod("j. Person.Age ignores assigment of -1"), TestCategory("Exercise 1A")]
        public void AgeIgnoresAssignmentOfMinusOne()
        {
            Test test = factory.CreateTest();
            TestObject<Person> person = test.Create<Person>();

            test.Arrange(person, () => new Person());
            test.Act(person, Assignment<Person, int>(p => p.Age, -1));
            test.AssertUnchanged(person, p => p.Age);

            test.Execute();
        }

        /* Exercise 1B */
        [TestMethod("a. Person.Mother is public Person property"), TestCategory("Exercise 1B")]
        public void MotherIsPublicPersonProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            Expression<Func<Person, Person>> mother = p => p.Mother;

            test.AssertPropertyTypeMatchesDual(mother);
            test.AssertPropertyGetterAndSetterPublic(mother);
        }

        [TestMethod("b. Person.Father is public Person property"), TestCategory("Exercise 1B")]
        public void FatherIsPublicPersonProperty() {
            StructureTest test = factory.CreateStructureTest();
            Expression<Func<Person, Person>> father = p => p.Father;

            test.AssertPropertyTypeMatchesDual(father);
            test.AssertPropertyGetterAndSetterPublic(father);
        }

        [TestMethod("c. Person.Mother ignores assigment if mother is younger than child"), TestCategory("Exercise 1B")]
        public void MotherIgnoresAssigmentIfMotherIsYoungerThanChild()
        {
            Test test = factory.CreateTest();
            TestObject<Person> child = test.Create<Person>("child");
            TestObject<Person> mother = test.Create<Person>("mother");

            test.Arrange(child, () => new Person() { Age = 1});
            test.Arrange(mother, () => new Person() { Age = 0 });
            test.Act(child, mother, Assignment<Person, Person, Person>(p => p.Mother, p => p));
            test.AssertUnchanged(child, p => p.Mother);

            test.Execute();
        }
        
        [TestMethod("d. Person.Father ignores assigment if mother is younger than child"), TestCategory("Exercise 1B")]
        public void FatherIgnoresAssigmentIfMotherIsYoungerThanChild()
        {
            Test test = factory.CreateTest();
            TestObject<Person> child = test.Create<Person>("child");
            TestObject<Person> father = test.Create<Person>("father");

            test.Arrange(child, () => new Person() { Age = 1 });
            test.Arrange(father, () => new Person() { Age = 0 });
            test.Act(child, father, Assignment<Person, Person, Person>(p => p.Father, p => p));
            test.AssertUnchanged(child, p => p.Mother);

            test.Execute();
        }

        /* Exercise 1C */
        [TestMethod("a. PersonGenerator.GeneratePerson takes no arguments and returns Person"), TestCategory("Exercise 1C")]
        public void GeneratePersonReturnsPerson()
        {
            StructureTest test = factory.CreateStructureTest();
            Expression<Action<PersonGenerator>> generatePerson = gen => gen.GeneratePerson();

            test.AssertMethodSignatureMatchesDual(generatePerson);
            test.AssertPublicMethod(generatePerson);
        }

        [TestMethod("b. PersonGenerator.GeneratePerson generates Adam Smith (36)"), TestCategory("Exercise 1C")]
        public void GeneratePersonCreatesAdamSmith()
        {
            Test test = factory.CreateTest();
            TestObject<PersonGenerator> generator = test.Create<PersonGenerator>("generator");
            AnonymousTestObject<Person> person = test.CreateAnonymous<Person>("person");
            
            test.Arrange(generator, () => new PersonGenerator());

            test.Act(person, generator, Assignment<Person, PersonGenerator, Person>(p => p, g => g.GeneratePerson()));
            
            test.Assert(person, p => p.FirstName == "Adam");
            test.Assert(person, p => p.LastName == "Smith");
            test.Assert(person, p => p.Age == 36);

            test.Execute();
        }

        /* Exercise 1D */
        [TestMethod("a. PersonGenerator.GenerateFamily takes no arguments and returns Person "), TestCategory("Exercise 1D")]
        public void GenerateFamilyReturnsPerson()
        {
            StructureTest test = factory.CreateStructureTest();
            Expression<Action<PersonPrinter>> generateFamily = p => p.PrintPerson(null);

            test.AssertMethodSignatureMatchesDual(generateFamily);
            test.AssertPublicMethod(generateFamily);
        }

        [TestMethod("b. PersonGenerator.GenerateFamily generates Robin Rich (10) as child"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesRobinRichAsChild()
        {
            Test test = factory.CreateTest();
            TestObject<PersonGenerator> generator = test.Create<PersonGenerator>("generator");
            AnonymousTestObject<Person> child = test.CreateAnonymous<Person>("child");

            test.Arrange(generator, () => new PersonGenerator());
            test.Act(child, generator, Assignment<Person, PersonGenerator, Person>(p => p, g => g.GeneratePerson()));
            test.Assert(child, p => p.FirstName == "Robin");
            test.Assert(child, p => p.LastName == "Rich");
            test.Assert(child, p => p.Age == 10);

            test.Execute();
        }


        [TestMethod("c. PersonGenerator.GenerateFamily generates Waren Rich (36) as father"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesRobinRichAsFather()
        {
            Test test = factory.CreateTest();
            TestObject<PersonGenerator> generator = test.Create<PersonGenerator>("generator");
            AnonymousTestObject<Person> father = test.CreateAnonymous<Person>("father");

            test.Arrange(generator, () => new PersonGenerator());
            test.Act(father, generator, Assignment<Person, PersonGenerator, Person>(p => p, g => g.GeneratePerson().Father));
            test.Assert(father, p => p.FirstName == "Warren");
            test.Assert(father, p => p.LastName == "Rich");
            test.Assert(father, p => p.Age == 36);

            test.Execute();
        }


        [TestMethod("d. PersonGenerator.GenerateFamily generates Anna Smith (38) as mother"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesAnnaRichAsMother()
        {
            Test test = factory.CreateTest();
            TestObject<PersonGenerator> generator = test.Create<PersonGenerator>("generator");
            AnonymousTestObject<Person> mother = test.CreateAnonymous<Person>("mother");

            test.Arrange(generator, () => new PersonGenerator());
            test.Act(mother, generator, Assignment<Person, PersonGenerator, Person>(p => p, g => g.GeneratePerson().Mother));
            test.Assert(mother, p => p.FirstName == "Anna");
            test.Assert(mother, p => p.LastName == "Smith");
            test.Assert(mother, p => p.Age == 38);

            test.Execute();
        }


        [TestMethod("e. PersonGenerator.GenerateFamily generates Gustav Rich (66) as grandfather"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesGustavRichAsGrandfather()
        {
            Test test = factory.CreateTest();
            TestObject<PersonGenerator> generator = test.Create<PersonGenerator>("generator");
            AnonymousTestObject<Person> grandFather = test.CreateAnonymous<Person>("grandfather");

            test.Arrange(generator, () => new PersonGenerator());
            test.Act(grandFather, generator, Assignment<Person, PersonGenerator, Person>(p => p, g => g.GeneratePerson().Father.Father));
            test.Assert(grandFather, p => p.FirstName == "Gustav");
            test.Assert(grandFather, p => p.LastName == "Rich");
            test.Assert(grandFather, p => p.Age == 66);

            test.Execute();
        }

        [TestMethod("g. PersonGenerator.GenerateFamily generates Elsa Johnson (65) as grandmother"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesElsaJohnsonAsGrandMother()
        {
            Test test = factory.CreateTest();
            TestObject<PersonGenerator> generator = test.Create<PersonGenerator>("generator");
            AnonymousTestObject<Person> grandMother = test.CreateAnonymous<Person>("grandmother");

            test.Arrange(generator, () => new PersonGenerator());
            test.Act(grandMother, generator, Assignment<Person, PersonGenerator, Person>(p => p, g => g.GeneratePerson().Father.Mother));
            test.Assert(grandMother, p => p.FirstName == "Elsa");
            test.Assert(grandMother, p => p.LastName == "Johnson");
            test.Assert(grandMother, p => p.Age == 65);

            test.Execute();
        }

        /* Exercise 1E */
        [TestMethod("a. PersonPrinter.PrintPerson takes person as argument and returns nothing"), TestCategory("Exercise 1E")]
        public void PrintPersonTakesPersonAsArgumentAndReturnsNothing() {
            StructureTest test = factory.CreateStructureTest();
            Expression<Action<PersonPrinter>> printPerson = p => p.PrintPerson(null);
            
            test.AssertMethodSignatureMatchesDual(printPerson);
            test.AssertPublicMethod(printPerson);
        }

        [TestMethod("b. PersonPrinter.PrintPrints prints correctly"), TestCategory("Exercise 1E")]
        public void PrintPersonPrintsCorrectly()
        {
            Test test = factory.CreateTest();
            TestObject<Person> person = test.CreateAnonymous<Person>("person");
            TestObject<PersonPrinter> printer = test.CreateAnonymous<PersonPrinter>("printer");

            test.Arrange(printer, () => new PersonPrinter());
            test.Arrange(person, () => new Person() { FirstName = "Adam", LastName = "Smith", Age = 36 });
            test.Act(printer, person, (p1, p2) => p1.PrintPerson(p2));
            test.AssertWriteOut("Adam Smith (36)");

            test.Execute();
        }

        /* Exercise 1F */
        [TestMethod("a. PersonPrinter.PrintFamily takes person as argument and returns nothing"), TestCategory("Exercise 1F")]
        public void PrintFamilyTakesPersonAsArgumentAndReturnsNothing()
        {
            StructureTest test = factory.CreateStructureTest();
            Expression<Func<Person, int>> age = p => p.Age;

            test.AssertPropertyType(age, typeof(int));
            test.AssertPropertyGetterAndSetterPublic(age);
        }

        [TestMethod("b. PersonPrinter.PrintFamily prints correctly"), TestCategory("Exercise 1F")]
        public void PrintFamilyPrintsCorrectly()
        {
            Test test = factory.CreateTest();
            TestObject<Person> person = test.CreateAnonymous<Person>("person");
            TestObject<PersonPrinter> printer = test.CreateAnonymous<PersonPrinter>("printer");

            test.Arrange(person, () => 
                new Person() { 
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
                }
            );
            test.Act(printer, person, (p1, p2) => p1.PrintFamily(p2));
            test.AssertWriteOut("Adam Smith (36)\n");
            test.AssertWriteOut("Robin Rich (10)\n");
            test.AssertWriteOut("  Warren Rich (36)\n");
            test.AssertWriteOut("    Gustav Rich (66)\n");
            test.AssertWriteOut("    Elsa Johnson (65)\n");
            test.AssertWriteOut("  Anna Smith (38)\n");

            test.Execute();
        }

        /* Exercise 1G */
        [TestMethod("a. Person has constructor which takes no arguments"), TestCategory("Exercise 1G")]
        public void PersonHasConstructorWhichTakesNoArguments()
        {
            StructureTest test = factory.CreateStructureTest();
            Expression<Func<Person>> defaultConstructor = () => new Person();

            test.AssertConstructorSignatureMatchesDual(defaultConstructor);
            test.AssertConstructorPublic(defaultConstructor);
        }

        [TestMethod("b. Person has constructor which two persons as arguments"), TestCategory("Exercise 1G")]
        public void PersonHasconstructorWhichTakesTwoPersonsAsArguments()
        {
            StructureTest test = factory.CreateStructureTest();
            Expression<Func<Person>> secondConstructor = () => new Person(null, null);

            test.AssertConstructorSignatureMatchesDual(secondConstructor);
            test.AssertConstructorPublic(secondConstructor);
        }

        [TestMethod("c. Person constructor with 2 persons as arguments sets mother and father property"), TestCategory("Exercise 1G")]
        public void PersonConstructorWithTwoPersonArgumentsSetsMotherAndFatherProperty()
        {
            Test test = factory.CreateTest();
            TestObject<Person> mother = test.Create<Person>();
            TestObject<Person> father = test.Create<Person>();
            TestObject<Person> child = test.Create<Person>();

            test.Arrange(mother, () => new Person() { Age = 37 });
            test.Arrange(father, () => new Person() { Age = 37 });
            test.Arrange(child, mother, father, (p1, p2) => new Person(p1, p2));
            test.Assert<Person, Person>(child, mother, (p1, p2) => p1.Mother == p2);
            test.Assert<Person, Person>(child, father, (p1, p2) => p1.Father == p2);

            test.Execute();
        }

        /* Exercise 1H */
        [TestMethod("a. Person.ID is public read-only int property"), TestCategory("Exercise 1H")]
        public void IDIsPublicReadonlyIntProperty() { 
            StructureTest test = factory.CreateStructureTest();
            Expression<Func<Person, int>> id = p => p.ID;

            test.AssertReadOnlyProperty(id);
            test.AssertPropertyType(id, typeof(int));
            test.AssertPropertyGetterPublic(id);
        }

        [TestMethod("b. Person.ID increases by 1 for each new person"), TestCategory("Exercise 1H")]
        public void IDIncreasesByOneForEachNewPerson()
        {
            Test test = factory.CreateTest();
            TestObject<Person> person1 = test.Create<Person>();
            TestObject<Person> person2 = test.Create<Person>();

            test.AssertIncreased(person1, person2, p => p.ID);

            test.Execute();
        }
    }
}
