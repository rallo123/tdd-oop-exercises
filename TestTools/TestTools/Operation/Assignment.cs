using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using TestTools.Structure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.Helpers;

namespace TestTools.Operation
{
    public static class Assignment
    {
        public static void Assigns(object instance, IAccessible accessible, object valueToAssign)
        {
            Assigns(instance, accessible, valueToAssign, valueToAssign);
        }

        public static void Assigns(object instance, IAccessible accessible, object valueToAssign, object valueAssigned)
        {
            accessible.Set(instance, valueToAssign);

            // "{0} = {1} changes value to {2} instead of {3}
            // Person.Age = 3 changes value to 2 instead of 3

            // Person.Mother = p changes value to p instead of null


            // "{0} = value threw Exception while value.ToString() -> ""

            object expectedValueAssigned = valueAssigned;
            object actualValueAssigned = accessible.Get(instance);
            if (!object.Equals(expectedValueAssigned, actualValueAssigned))
            {
                string message = string.Format(
                    "{0} = {3} changes {0} value to {1} instead of {2}",
                    FormatHelper.FormatDefinitionChain(accessible),
                    actualValueAssigned,
                    expectedValueAssigned,
                    valueToAssign
                );
                throw new AssertFailedException(message);
            }
        }

        public static void Mutates(object instance, IAccessible accessible, object valueToAssign, params Action<object>[] stateValidators)
        {
            accessible.Set(instance, valueToAssign);

            foreach (Action<object> stateValidator in stateValidators)
                stateValidator(instance);
        }

        public static void Mutates(Func<object> createInstance, IAccessible accessible, object valueToAssign, Action<object, object>[] mutationValidators)
        {
            object unmodifiedInstance = createInstance();
            object modifiedInstance = createInstance();
            accessible.Set(modifiedInstance, valueToAssign);

            foreach (Action<object, object> mutationValidator in mutationValidators)
                mutationValidator(unmodifiedInstance, modifiedInstance);
        }

        public static void Throws(object instance, IAccessible accessible, object valueToAssign)
        {
            string accessibleName = FormatHelper.FormatDefinitionChain(accessible);

            try
            {
                if (accessible is FieldElement field)
                    field.Info.SetValue(instance, valueToAssign);
                else if (accessible is PropertyElement property)
                    property.Set(instance, valueToAssign);
                else throw new NotImplementedException(string.Format("INTERNAL: Unsupported element type {0}", accessible.GetType().Name));

                throw new AssertFailedException(string.Format("Assignment {0} = {1} did not throw an Exception", accessibleName, valueToAssign));
            }
            catch (TargetException)
            {
            }
        }

        public static void Throws(object instance, IAccessible accessible, object valueToAssign, Type exceptionType)
        {
            string accessibleName = FormatHelper.FormatDefinitionChain(accessible);
            string exceptionName = FormatHelper.FormatType(exceptionType);

            try
            {
                if (accessible is FieldElement field)
                    field.Info.SetValue(instance, valueToAssign);
                else if (accessible is PropertyElement property)
                    property.Set(instance, valueToAssign);
                else throw new NotImplementedException(string.Format("Unsupported element type {0}", accessible.GetType().Name));

                throw new AssertFailedException(string.Format("Assignment {0} = {1} did not throw a {2}", accessibleName, valueToAssign, exceptionName));
            }
            catch (TargetException ex)
            {
                if (ex.InnerException.GetType() != exceptionType)
                    throw new AssertFailedException(string.Format($"Assignment {0} = {1} threw {2} instead of {3}", accessibleName, valueToAssign, ex.InnerException.GetType().Name, exceptionName));
            }
        }
    }
}
