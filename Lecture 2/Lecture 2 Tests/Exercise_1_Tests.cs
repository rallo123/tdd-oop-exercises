using Lecture_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.CompilerServices;
using System.Text;
using TestTools;
using TestTools.ConsoleSession;
using TestTools.Operation;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace Lecture_2_Tests
{
    [TestClass]
    public class Exercise_1_Tests
    {
#pragma warning disable IDE1006 // Naming Styles
        private ClassElement<Person> person => new ClassElement<Person>();
        
        private PropertyElement<Person, string> personFirstName => person.Property<string>("FirstName", get: new AccessorOptions { AccessLevel = AccessLevel.Public }, set: new AccessorOptions { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, string> personLastName => person.Property<string>("LastName", get: new AccessorOptions { AccessLevel = AccessLevel.Public }, set: new AccessorOptions { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, int> personAge => person.Property<int>("Age", get: new AccessorOptions { AccessLevel = AccessLevel.Public }, set: new AccessorOptions { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, Person> personMother => person.Property<Person>("Mother", get: new AccessorOptions { AccessLevel = AccessLevel.Public }, set: new AccessorOptions { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, Person> personFather => person.Property<Person>("Father", get: new AccessorOptions { AccessLevel = AccessLevel.Public }, set: new AccessorOptions { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, Person> personFatherMother => personFather.Property<Person>("Mother", get: new AccessorOptions { AccessLevel = AccessLevel.Public }, set: new AccessorOptions { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, Person> personFatherFather => personFather.Property<Person>("Father", get: new AccessorOptions { AccessLevel = AccessLevel.Public }, set: new AccessorOptions { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, int> personID => person.Property<int>("ID", get: new AccessorOptions { AccessLevel = AccessLevel.Public });

        private string CreateName(int length)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
                builder.Append("a");
            return builder.ToString();
        }

        private Person CreatePerson(string firstName = null, string lastName = null, int? age = null, Person mother = null, Person father = null)
        {
            Person instance = person.Constructor().Invoke();

            if(firstName != null)
                personFirstName.Set(instance, firstName);
            if(lastName != null)
                personLastName.Set(instance, lastName);
            if(age != null)
                personAge.Set(instance, age);
            if (mother != null)
                personMother.Set(instance, mother);
            if (father != null)
                personFather.Set(instance, father);

            return instance;
        }

        private ClassElement<PersonGenerator> generator => new ClassElement<PersonGenerator>();
        private FuncMethodElement<PersonGenerator, Person> generatorGeneratePerson => generator.FuncMethod<Person>("GeneratePerson", new MethodOptions { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<PersonGenerator, Person> generatorGenerateFamily => generator.FuncMethod<Person>("GenerateFamily", new MethodOptions { AccessLevel = AccessLevel.Public });
        private PersonGenerator CreateGenerator() => generator.Constructor().Invoke();

        private ClassElement<PersonPrinter> printer => new ClassElement<PersonPrinter>();
        private ActionMethodElement<PersonPrinter, Person> printerPrintPerson => printer.ActionMethod<Person>("PrintPerson", new MethodOptions { AccessLevel = AccessLevel.Public });
        private ActionMethodElement<PersonPrinter, Person> printerPrintFamily => printer.ActionMethod<Person>("PrintFamily", new MethodOptions { AccessLevel = AccessLevel.Public });
        private PersonPrinter CreatePrinter() => printer.Constructor().Invoke();

        private void DoNothing(object par) { }
#pragma warning restore IDE1006 // Naming Styles

        public Exercise_1_Tests()
        {
            bool PersonEquals(object obj1, object obj2)
            {
                Person person1 = obj1 as Person;
                Person person2 = obj2 as Person;

                if (person1 == null || person2 == null)
                    return false;
                if (personFirstName.Get(person1) != personFirstName.Get(person2))
                    return false;
                if (personLastName.Get(person1) != personLastName.Get(person2))
                    return false;
                if (personAge.Get(person1) != personAge.Get(person2))
                    return false;
                return true;
            }
            string PersonToString(object obj)
            {
                return $"{personFirstName.Get(obj)} {personLastName.Get(obj)} ({personAge.Get(obj)})";
            }

            ObjectMethodRegistry.RegisterEquals(person.Type, PersonEquals);
            ObjectMethodRegistry.RegisterToString(person.Type, PersonToString);
        }


        /* Exercise 1A */
        [TestMethod("a. Person.FirstName is public string property"), TestCategory("Exercise 1A")]
        public void FirstNameIsPublicStringProperty() => DoNothing(personFirstName);

        [TestMethod("b. Person.LastName is public string property"), TestCategory("Exercise 1A")]
        public void LastNameIsPublicStringProperty() => DoNothing(personLastName);

        [TestMethod("c. Person.Age is public int property"), TestCategory("Exercise 1A")]
        public void AgeIsPublicIntProperty() => DoNothing(personAge);
        
        [TestMethod("d. Person.FirstName ignores assigment of null"), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOfNull() => Assignment.Ignored(CreatePerson(), personFirstName, null);

        [TestMethod("e. Person.LastName ignores assigment of null"), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOfNull() => Assignment.Ignored(CreatePerson(), personLastName, null);
        
        [TestMethod("f. Person.FirstName ignores assigment of \"123456789\""), TestCategory("Exercise 1A")]
        public void AgeIgnoresAssignmentOf012345689() => Assignment.Ignored(CreatePerson(), personFirstName, "0123456789");

        [TestMethod("g. Person.LastName ignores assigment of \"123456789\""), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOf012345689() => Assignment.Ignored(CreatePerson(), personLastName, "0123456789");

        [TestMethod("h. Person.FirstName ignores assigment of string with length 101"), TestCategory("Exercise 1A")]
        public void FirstNameIgnoresAssignmentOfStringWithLength101() => Assignment.Ignored(CreatePerson(), personFirstName, CreateName(101));

        [TestMethod("i. Person.FirstName ignores assignment of string with length 101"), TestCategory("Exercise 1A")]
        public void LastNameIgnoresAssignmentOfStringWithLength101() => Assignment.Ignored(CreatePerson(), personLastName, CreateName(101));
        
        [TestMethod("j. Person.Age ignores assigment of -1"), TestCategory("Exercise 1A")]
        public void AgeIgnoresAssignmentOfMinusOne() => Assignment.Ignored(CreatePerson(), personAge, -1);


        /* Exercise 1B */
        [TestMethod("a. Person.Mother is public Person property"), TestCategory("Exercise 1B")]
        public void MotherIsPublicPersonProperty() => DoNothing(personMother);

        [TestMethod("b. Person.Father is public Person property"), TestCategory("Exercise 1B")]
        public void FatherIsPublicPersonProperty() => DoNothing(personFather);

        [TestMethod("c. Person.Mother ignores assigment if mother is younger than child"), TestCategory("Exercise 1B")]
        public void MotherIgnoresAssigmentIfMotherIsYoungerThanChild() => Assignment.Ignored(CreatePerson(age: 1), personMother, CreatePerson(age: 0));

        [TestMethod("d. Person.Father ignores assigment if mother is younger than child"), TestCategory("Exercise 1B")]
        public void FatherIgnoresAssigmentIfMotherIsYoungerThanChild() => Assignment.Ignored(CreatePerson(age: 1), personFather, CreatePerson(age: 0));


        /* Exercise 1C */
        [TestMethod("a. PersonGenerator.GeneratePerson takes no arguments and returns Person"), TestCategory("Exercise 1C")]
        public void GeneratePersonReturnsPerson() => DoNothing(generatorGeneratePerson);

        [TestMethod("b. PersonGenerator.GeneratePerson generates Adam Smith (36)"), TestCategory("Exercise 1C")]
        public void GeneratePersonCreatesAdamSmith() => Equality.Equals(generatorGeneratePerson.Invoke(CreateGenerator()), CreatePerson("Adam", "Smith", 36));


        /* Exercise 1D */
        [TestMethod("a. PersonGenerator.GenerateFamily takes no arguments and returns Person "), TestCategory("Exercise 1D")]
        public void GenerateFamilyReturnsPerson() => DoNothing(generatorGenerateFamily);

        [TestMethod("b. PersonGenerator.GenerateFamily generates Robin Rich (10) as child"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesRobinRichAsChild() => Equality.Equals(generatorGenerateFamily.Invoke(CreateGenerator()), CreatePerson("Robin", "Rich", 10));

        [TestMethod("c. PersonGenerator.GenerateFamily generates Waren Rich (36) as father"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesWarenRichAsFather() => Equality.Equals(personFather.Get(generatorGenerateFamily.Invoke(CreateGenerator())), CreatePerson("Warren", "Rich" ,36));

        [TestMethod("d. PersonGenerator.GenerateFamily generates Anna Smith (38) as mother"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesAnnaSmithAsMother() => Equality.Equals(personMother.Get(generatorGenerateFamily.Invoke(CreateGenerator())), CreatePerson("Anna", "Smith", 38));

        [TestMethod("e. PersonGenerator.GenerateFamily generates Gustav Rich (66) as grandfather"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesGustavRichAsGrandfather() => Equality.Equals(personFatherFather.Get(generatorGenerateFamily.Invoke(CreateGenerator())), CreatePerson("Gustav", "Rich", 66));

        [TestMethod("g. PersonGenerator.GenerateFamily generates Elsa Johnson (65) as grandmother"), TestCategory("Exercise 1D")]
        public void GenerateFamilyCreatesElsaJohnsonAsGrandMother() => Equality.Equals(personFatherMother.Get(generatorGenerateFamily.Invoke(CreateGenerator())), CreatePerson("Elsa", "Johnson", 65));


        /* Exercise 1E */
        [TestMethod("a. PersonPrinter.PrintPerson takes person as argument and returns nothing"), TestCategory("Exercise 1E")]
        public void PrintPersonTakesPersonAsArgumentAndReturnsNothing() => DoNothing(printerPrintPerson);

        [TestMethod("b. PersonPrinter.PrintPrints prints correctly"), TestCategory("Exercise 1E")]
        public void PrintPersonPrintsCorrectly()
        {
            ConsoleSession session = new ConsoleSession();
            session.Out("Adam Smith (36)");

            session.Start(() => printerPrintPerson.Invoke(CreatePrinter(), CreatePerson("Adam", "Smith", 36)));
        }

        /* Exercise 1F */
        [TestMethod("a. PersonPrinter.PrintFamily takes person as argument and returns nothing"), TestCategory("Exercise 1F")]
        public void PrintFamilyTakesPersonAsArgumentAndReturnsNothing() => DoNothing(printerPrintFamily);

        [TestMethod("b. PersonPrinter.PrintFamily prints correctly"), TestCategory("Exercise 1F")]
        public void PrintFamilyPrintsCorrectly()
        {
            ConsoleSession session = new ConsoleSession();
            session.Out("Robin Rich (10)\n");
            session.Out("  Warren Rich (36)\n");
            session.Out("    Gustav Rich (66)\n");
            session.Out("    Elsa Johnson (65)\n");
            session.Out("  Anna Smith (38)\n");

            Person gustav = CreatePerson("Gustav", "Rich", 66);
            Person elsa = CreatePerson("Elsa", "Johnson", 65);
            Person warren = CreatePerson("Warren", "Rich", 36, elsa, gustav);
            Person anna = CreatePerson("Anna", "Smith", 38);
            Person robin = CreatePerson("Robin", "Rich", 10, anna, warren);

            session.Start(() => printerPrintFamily.Invoke(CreatePrinter(), robin));
        }

        /* Exercise 1G */
        [TestMethod("a. Person has constructor which takes no arguments"), TestCategory("Exercise 1G")]
        public void PersonHasConstructorWhichTakesNoArguments() => DoNothing(person.Constructor());

        [TestMethod("b. Person has constructor which two persons as arguments"), TestCategory("Exercise 1G")]
        public void PersonHasconstructorWhichTakesTwoPersonsAsArguments() => DoNothing(person.Constructor<Person, Person>());

        [TestMethod("c. Person constructor with 2 persons as arguments sets mother and father property"), TestCategory("Exercise 1G")]
        public void PersonConstructorWithTwoPersonArgumentsSetsMotherAndFatherProperty()
        {
            Person mother = CreatePerson();
            personAge.Set(mother, 37);
            Person father = CreatePerson();
            personAge.Set(father, 37);
            Person child = person.Constructor<Person, Person>().Invoke(mother, father);

            Person motherValue = personMother.Get(child);
            Person fatherValue = personFather.Get(child);

            if (mother == motherValue && father == fatherValue)
                return;
            if (mother == fatherValue && father == motherValue)
                return;

            throw new AssertFailedException("Person constructor Person(Person par1, Person par2) does not set mother or father property");
        }

        /* Exercise 1H */
        [TestMethod("a. Person.ID is public read-only int property"), TestCategory("Exercise 1H")]
        public void IDIsPublicReadonlyIntProperty() => DoNothing(personID);

        [TestMethod("b. Person.ID increases by 1 for each new person"), TestCategory("Exercise 1H")]
        public void IDIncreasesByOneForEachNewPerson()
        {
            Person person1 = CreatePerson();
            Person person2 = CreatePerson();

            int increase = personID.Get(person2) - personID.Get(person1);

            if (increase != 1)
                Assert.Fail($"ID changes by {increase} instead of 1 for each new person");
        }
    }
}
