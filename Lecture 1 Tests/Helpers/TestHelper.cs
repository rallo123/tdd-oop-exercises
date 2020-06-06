using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using static Lecture_1_Tests.Helpers.MemberHelper;

namespace Lecture_1_Tests.Helpers
{
    public static class TestHelper
    {
        private static string FormatPath(Type type, string[] path)
        {
            return type.Name + "-instance." + String.Join(".", path);
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

        public static void TestMemberIsPropertyWithGetMethod(
            Type type,
            string name,
            bool? isPrivate = null,
            bool? isProtected = null,
            bool? isPublic = null
        )
        {
            TestMemberIsPropertyWithGetMethod(type, name, isPrivate, isProtected, isPublic);
        }
        public static void TestMemberIsPropertyWithGetMethod(
            Type type, 
            string[] path,
            bool? isPrivate = null,
            bool? isProtected = null,
            bool? isPublic = null
        )
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

        public static void TestMemberIsPropertyWithSetMethod(
            Type type,
            string name,
            bool? isPrivate = null,
            bool? isProtected = null,
            bool? isPublic = null
        )
        {
            TestMemberIsPropertyWithSetMethod(type, new string[] { name }, isPrivate, isProtected, isPublic);
        }
        public static void TestMemberIsPropertyWithSetMethod(
            Type type,
            string[] path,
            bool? isPrivate = null,
            bool? isProtected = null,
            bool? isPublic = null
        )
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

        public static void TestMemberIsPropertyWithGetAndSetMethods(
            Type type,
            string name,
            bool? isPrivate = null,
            bool? isProtected = null,
            bool? isPublic = null
        )
        {
            TestMemberIsPropertyWithGetAndSetMethod(type, new string[] { name }, isPrivate, isProtected, isPublic);
        }
        public static void TestMemberIsPropertyWithGetAndSetMethod(
            Type type,
            string[] path,
            bool? isPrivate = null,
            bool? isProtected = null,
            bool? isPublic = null
        )
        {
            TestMemberIsPropertyWithGetMethod(type, path, isPrivate, isProtected, isPublic);
            TestMemberIsPropertyWithSetMethod(type, path, isPrivate, isProtected, isPublic);
        }

        public static void TestMemberIsOfType(Type type, string name, Type memberType)
        {
            TestMemberIsOfType(type, new string[] { name }, memberType);
        }
        public static void TestMemberIsOfType(Type type, string[] path, Type memberType)
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
            else if (memberInfo is MethodInfo methodInfo)
            {
                Assert.IsTrue(
                    methodInfo.ReturnType == memberType,
                    $"{FormatPath(type, path)} return type is not {memberType.Name}"
                );
            }
            else throw new ArgumentException("Member is not field or property");
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
                throw new NotImplementedException("Fields are not supported yet");
            }
            else if(memberInfo is PropertyInfo)
            {
                TestMemberIsPropertyWithSetMethod(instance.GetType(), path);
            }

            SetValue(instance, path, value);
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
