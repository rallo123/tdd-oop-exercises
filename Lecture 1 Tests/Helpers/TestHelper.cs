using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using static Lecture_1_Tests.Helpers.MemberHelper;

namespace Lecture_1_Tests.Helpers
{
    public static class TestHelper
    {
        //# Console tests
        private static string CaptureConsoleOutput(Action action)
        {
            string capturedOutput; 
            
            var originalConsoleOut = Console.Out;
            using(var writer = new StringWriter())
            {
                Console.SetOut(writer);
                action();
                writer.Flush();
                capturedOutput = writer.GetStringBuilder().ToString();
            }
            Console.SetOut(originalConsoleOut);

            return capturedOutput;
        }

        public static void TestConsoleOutput(Action expected, Action actual)
        {
            string expectedOutput = CaptureConsoleOutput(expected);
            string actualOutput = CaptureConsoleOutput(actual);

            Console.WriteLine("# Expected");
            Console.WriteLine((!string.IsNullOrEmpty(expectedOutput)) ? expectedOutput : "no output");
            Console.WriteLine();
            Console.WriteLine("# Actual");
            Console.WriteLine((!string.IsNullOrEmpty(actualOutput)) ? actualOutput : "no output");

            Assert.IsTrue(
                expectedOutput.Trim().Equals(actualOutput.Trim()), 
                "Expected and actual output (might) differ."
            );
        }

        //# Structural tests
        private static string FormatPath(Type type, string[] path)
        {
            return type.Name + "." + String.Join(".", path);
        }
        private static string FormatMethod(Type type, string name, Type returnType, Type[] parameterTypes)
        {
            StringBuilder signatureBuilder = new StringBuilder();

            signatureBuilder.Append(returnType != null ? returnType.Name : "void");
            signatureBuilder.Append(" ");

            signatureBuilder.Append(name);

            signatureBuilder.Append("(");
            if (parameterTypes != null)
            {
                for (int i = 0; i < parameterTypes.Length; i++)
                {
                    if (i != 0)
                        signatureBuilder.Append(", ");
                    signatureBuilder.Append(type.Name + " par" + i);
                }
            }
            signatureBuilder.Append(")");

            return signatureBuilder.ToString();
        }

        public static void TestMemberExists(Type type, string name)
        {
            TestMemberExists(type, new string[] { name });
        }
        public static void TestMemberExists(Type type, string[] path)
        {
            Assert.IsNotNull(
                TryGetInfo(type, path),
                $"{FormatPath(type, path)} is not a member"
            );
        }

        public static void TestConstructorExists(Type type, Type[] parameterTypes = null)
        {
            Assert.IsNotNull(
                TryGetConstructorInfo(type, parameterTypes),
                $"{FormatMethod(type, type.Name, null, parameterTypes)} is not constructor"
            );
        }

        public static void TestMemberIsMethod(Type type, string name)
        {
            TestMemberIsMethod(type, new string[] { name });
        }
        public static void TestMemberIsMethod(Type type, string[] path)
        {
            TestMemberExists(type, path);

            Assert.IsTrue(
                TryGetInfo(type, path) is MethodInfo,
                $"{FormatPath(type, path)} is not a method"
            );
        }

        public static void TestMemberIsProperty(Type type, string name)
        {
            TestMemberIsProperty(type, new string[] { name });
        }
        public static void TestMemberIsProperty(Type type, string[] path)
        {
            TestMemberExists(type, path);
            
            Assert.IsTrue(
                TryGetInfo(type, path) is PropertyInfo,
                $"{FormatPath(type, path)} is not a property"
            );
        }
        
        public static void TestMemberIsPropertyWithGetMethod(Type type, string name, bool? isPrivate = null, bool? isProtected = null, bool? isPublic = null)
        {
            TestMemberIsPropertyWithGetMethod(type, name, isPrivate, isProtected, isPublic);
        }
        public static void TestMemberIsPropertyWithGetMethod(Type type, string[] path, bool? isPrivate = null, bool? isProtected = null, bool? isPublic = null)
        {
            TestMemberIsProperty(type, path);

            PropertyInfo info = (PropertyInfo) TryGetInfo(type, path);

            Assert.IsTrue(
                info.CanRead,
                $"{FormatPath(type, path)} is missing get method"
            );

            if (isPrivate != null)
            {
                Assert.IsTrue(
                    info.GetGetMethod().IsPrivate == isPrivate,
                    (!isPrivate ?? false) ? $"{FormatPath(type, path)} get method is not private" : $"{FormatPath(type, path)} get method is private"
                );
            }

            if (isProtected != null)
            {
                Assert.IsTrue(
                    info.GetGetMethod().IsFamily == isProtected,
                    (!isProtected ?? false) ? $"{FormatPath(type, path)} get method is not protected" : $"{FormatPath(type, path)} get method is protected"
                );
            }

            if (isPublic != null)
            {
                Assert.IsTrue(
                    info.GetGetMethod().IsPublic == isPublic,
                    (!isPublic ?? false) ? $"{FormatPath(type, path)} get method is not public" : $"{FormatPath(type, path)} get method is public"
                );
            }
        }

        public static void TestMemberIsPropertyWithSetMethod(Type type, string name, bool? isPrivate = null, bool? isProtected = null, bool? isPublic = null)
        {
            TestMemberIsPropertyWithSetMethod(type, new string[] { name }, isPrivate, isProtected, isPublic);
        }
        public static void TestMemberIsPropertyWithSetMethod(Type type, string[] path, bool? isPrivate = null, bool? isProtected = null, bool? isPublic = null)
        {
            TestMemberIsProperty(type, path);

            PropertyInfo info = (PropertyInfo)TryGetInfo(type, path);

            Assert.IsTrue(
                info.CanWrite,
                $"{FormatPath(type, path)} is missing set method"
            );

            if (isPrivate != null)
            {
                Assert.IsTrue(
                    info.GetSetMethod().IsPrivate == isPrivate,
                    (!isPrivate ?? false) ? $"{FormatPath(type, path)} set method is not private" : $"{FormatPath(type, path)} set method is private"
                );
            }

            if (isProtected != null)
            {
                Assert.IsTrue(
                    info.GetSetMethod().IsFamily == isProtected,
                    (!isProtected ?? false) ? $"{FormatPath(type, path)} set method is not protected" : $"{FormatPath(type, path)} set method is protected"
                );
            }

            if (isPublic != null)
            {
                Assert.IsTrue(
                    info.GetSetMethod().IsPublic == isPublic,
                    (!isPublic ?? false) ? $"{FormatPath(type, path)} set method is not public" : $"{FormatPath(type, path)} set method is public"
                );
            }
        }

        public static void TestMemberIsPropertyWithGetAndSetMethods(Type type, string name, bool? isPrivate = null, bool? isProtected = null, bool? isPublic = null)
        {
            TestMemberIsPropertyWithGetAndSetMethods(type, new string[] { name }, isPrivate, isProtected, isPublic);
        }
        public static void TestMemberIsPropertyWithGetAndSetMethods(Type type, string[] path, bool? isPrivate = null, bool? isProtected = null, bool? isPublic = null)
        {
            TestMemberIsPropertyWithGetMethod(type, path, isPrivate, isProtected, isPublic);
            TestMemberIsPropertyWithSetMethod(type, path, isPrivate, isProtected, isPublic);
        }

        public static void TestMemberIsFieldOrPropertyOfType(Type type, string name, Type memberType)
        {
            TestMemberIsFieldOrPropertyOfType(type, new string[] { name }, memberType);
        }
        public static void TestMemberIsFieldOrPropertyOfType(Type type, string[] path, Type memberType)
        {
            TestMemberExists(type, path);

            MemberInfo memberInfo = TryGetInfo(type, path);

            if (memberInfo is FieldInfo fieldInfo)
            {
                Assert.IsTrue(
                    fieldInfo.FieldType == memberType,
                    $"{FormatPath(type, path)} is not of type {memberType.Name}"
                );
            }
            else if (memberInfo is PropertyInfo propertyInfo)
            {
                Assert.IsTrue(
                    propertyInfo.PropertyType == memberType,
                    $"{FormatPath(type, path)} is not of type {memberType.Name}"
                );
            }
            else throw new ArgumentException("Member is not field or property");
        }

        public static void TestMemberIsMethodOfSignature(Type type, string name, Type returnType, Type[] parameterTypes = null)
        {
            TestMemberIsMethodOfSignature(type, new string[] { name }, returnType, parameterTypes);
        }
        public static void TestMemberIsMethodOfSignature(Type type, string[] path, Type returnType, Type[] parameterTypes = null)
        {
            TestMemberIsMethod(type, path);
            
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var method in methods)
            {
                if (!method.Name.Equals(path[^1]))
                    continue;

                ParameterInfo[] parameters = method.GetParameters();
                bool parametersMatch = parameters.Length == (parameterTypes?.Length ?? 0);

                int i = 0;
                while (parametersMatch && i < parameters.Length)
                {
                    if (parameters[i].ParameterType != parameterTypes[i])
                        parametersMatch = false;
                    i++;
                }

                if (parametersMatch)
                    return;
            }
            Assert.Fail($"{FormatMethod(type, FormatPath(type, path), returnType, parameterTypes)} is missing");
        }

        public static void TestValidAssignment(object instance, string name, object value)
        {
            TestValidAssignment(instance, new string[] { name }, value);
        }
        public static void TestValidAssignment(object instance, string[] path, object value)
        {
            TestMemberExists(instance.GetType(), path);

            MemberInfo memberInfo = TryGetInfo(instance.GetType(), path);

            if(memberInfo is FieldInfo)
            {
                //readonly fields might pose a problem
                //throw new NotImplementedException("Fields are not supported yet");
            }
            else if(memberInfo is PropertyInfo)
            {
                TestMemberIsPropertyWithSetMethod(instance.GetType(), path);
            }

            SetValue(instance, path, value);
        }
        
        public static void TestIgnoredAssignment(object instance, string name, object value)
        {
            TestIgnoredAssignment(instance, new string[] { name }, value);
        }
        public static void TestIgnoredAssignment(object instance, string[] path, object value)
        {
            TestMemberExists(instance.GetType(), path);

            MemberInfo memberInfo = TryGetInfo(instance.GetType(), path);

            if(memberInfo is FieldInfo)
            {
                //throw new NotImplementedException("Fields are not supported yet");
            }
            else if (memberInfo is PropertyInfo)
            {
                TestMemberIsPropertyWithGetAndSetMethods(instance.GetType(), path);
            }

            object oldValue = GetValue(instance, path);
            SetValue(instance, path, value);
            object newValue = GetValue(instance, path);

            Assert.IsTrue(
                newValue?.Equals(oldValue) ?? false,
                $"Assignment of {FormatPath(instance.GetType(), path)} with {value} changes value"
            );
        }

        public static void TestInvalidAssignment<TException>(object instance, string name, object value) where TException : Exception
        {
            TestInvalidAssignment<TException>(instance, new string[] { name }, value);
        }
        public static void TestInvalidAssignment<TException>(object instance, string[] path, object value) where TException : Exception
        {
            TestMemberExists(instance.GetType(), path);

            MemberInfo memberInfo = TryGetInfo(instance.GetType(), path);

            if (memberInfo is FieldInfo)
            {
                throw new NotImplementedException("Fields are not supported yet");
            }
            else if (memberInfo is PropertyInfo)
            {
                TestMemberIsPropertyWithSetMethod(instance.GetType(), path);
            }

            void Assignment() => SetValue(instance, path, value);

            Assert.ThrowsException<TException>(
                Assignment,
                $"Assignment of {FormatPath(instance.GetType(), path)} with {value} does not throw {typeof(TException).Name}"
            );
        }
    }
}
