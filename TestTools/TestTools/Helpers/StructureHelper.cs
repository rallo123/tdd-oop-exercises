using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestTools.Structure;

namespace TestTools.Helpers
{
    public static class StructureHelper
    {
        public static FieldInfo GetFieldInfo(Type type, string fieldName, Type fieldType, AccessLevel? accessLevel = null, bool isStatic = false)
        {
            MemberInfo memberInfo = GetMembers(type, isStatic).FirstOrDefault(m => m.Name == fieldName);

            AssertMemberExists(type, fieldName, isStatic, isStatic ? ErrorCodes.StaticMemberIsMissing : ErrorCodes.InstanceMemberIsMissing);
            AssertMemberIs<FieldInfo>(type, memberInfo, isStatic ? ErrorCodes.StaticMemberIsWrongMemberType : ErrorCodes.InstanceMemberIsWrongMemberType);
            AssertMemberIsOfType(type, memberInfo, fieldType, isStatic ? ErrorCodes.StaticFieldIsWrongType : ErrorCodes.InstanceFieldIsWrongType);
            AssertMemberHasAccessLevel(type, memberInfo, accessLevel, isStatic ? ErrorCodes.StaticFieldHasWrongAccessLevel : ErrorCodes.InstanceFieldHasWrongAccessLevel);
            
            return (FieldInfo)memberInfo;
        }

        public static PropertyInfo GetPropertyInfo(Type type, string propertyName, Type propertyType, PropertyAccessor get = null, PropertyAccessor set = null, bool isStatic = false)
        {
            MemberInfo memberInfo = GetMembers(type, isStatic).FirstOrDefault(m => m.Name == propertyName);
            PropertyInfo propertyInfo = memberInfo as PropertyInfo;

            AssertMemberExists(type, propertyName, isStatic, isStatic ? ErrorCodes.StaticMemberIsMissing : ErrorCodes.InstanceMemberIsMissing);
            AssertMemberIs<PropertyInfo>(type, memberInfo, isStatic ? ErrorCodes.StaticMemberIsWrongMemberType : ErrorCodes.InstanceMemberIsWrongMemberType);
            AssertMemberIsOfType(type, memberInfo, propertyType, isStatic ? ErrorCodes.StaticPropertyIsWrongType : ErrorCodes.InstancePropertyIsWrongType);

            if(get != null)
            {
                if (!propertyInfo.CanRead)
                {
                    string errorMessage = String.Format(
                        isStatic ? ErrorCodes.StaticPropertyIsMissingGet : ErrorCodes.InstancePropertyIsMissingGet,
                        FormatHelper.FormatType(type),
                        propertyName
                    );
                    throw new AssertFailedException(errorMessage);
                }
                string messageTemplate = String.Format(isStatic ? ErrorCodes.StaticPropertyGetHasWrongAccessLevel : ErrorCodes.InstancePropertyGetHasWrongAccessLevel, "{0}", propertyName, "{2}");
                AssertMemberHasAccessLevel(type, propertyInfo.GetMethod, get.AccessLevel, messageTemplate);
            }
            if(set != null)
            {
                if (!propertyInfo.CanWrite)
                {
                    string errorMessage = String.Format(
                        isStatic ? ErrorCodes.StaticPropertyIsMissingSet : ErrorCodes.InstancePropertyIsMissingSet,
                        FormatHelper.FormatType(type),
                        propertyName
                    );
                    throw new AssertFailedException(errorMessage);
                }
                string messageTemplate = String.Format(isStatic ? ErrorCodes.StaticPropertySetHasWrongAccessLevel : ErrorCodes.InstancePropertySetHasWrongAccessLevel, "{0}", propertyName, "{2}");
                AssertMemberHasAccessLevel(type, propertyInfo.SetMethod, set.AccessLevel, messageTemplate);
            }

            return propertyInfo;
        }

        public static MemberInfo GetFieldOrPropertyInfo(Type type, string memberName, Type memberType, AccessLevel? accessLevel = null, bool isStatic = false)
        {
            AssertMemberExists(type, memberName, isStatic, isStatic ? ErrorCodes.StaticMemberIsMissing : ErrorCodes.InstanceMemberIsMissing);
            MemberInfo memberInfo = GetMembers(type, isStatic).First(m => m.Name == memberName);

            if (memberInfo is FieldInfo)
                return GetFieldInfo(type, memberName, memberType, accessLevel, isStatic);
            if (memberInfo is PropertyInfo)
                return GetPropertyInfo(type, memberName, memberType, get: new PropertyAccessor(accessLevel), set: new PropertyAccessor(accessLevel));

            string errorMessage = String.Format(
                isStatic ? ErrorCodes.StaticMemberIsIsNotFieldOrProperty : ErrorCodes.InstanceMemberIsNotFieldOrProperty,
                FormatHelper.FormatType(type),
                memberName,
                FormatHelper.FormatMemberType(memberInfo.GetType())
            );
            throw new AssertFailedException(errorMessage);
        }

        public static MethodInfo GetMethodInfo(Type type, string methodName, Type returnType, AccessLevel? accessLevel = null, bool isStatic = false)
        {
            return GetMethodInfo(type, methodName, returnType, new Type[] { }, accessLevel, isStatic);
        }

        public static MethodInfo GetMethodInfo(Type type, string methodName, Type returnType, Type[] parameterTypes, AccessLevel? accessLevel = null, bool isStatic = false)
        {
            IEnumerable<MemberInfo> memberInfos = GetMembers(type, isStatic).Where(m => m.Name == methodName);
            
            AssertMemberExists(type, methodName, isStatic, isStatic ? ErrorCodes.StaticMemberIsMissing : ErrorCodes.InstanceMemberIsMissing);
            AssertMemberIs<MethodInfo>(type, memberInfos.First(), isStatic ? ErrorCodes.StaticMemberIsWrongMemberType : ErrorCodes.InstanceMemberIsWrongMemberType);
            AssertMemberIsOfType(type, memberInfos.First(), returnType, isStatic ? ErrorCodes.StaticMethodIsWrongReturnType : ErrorCodes.InstanceMethodIsWrongReturnType);

            MethodInfo methodInfo = memberInfos.OfType<MethodInfo>().FirstOrDefault(info => IsEachParameterMatchesType(info.GetParameters(), parameterTypes));
            if(methodInfo == null)
            {
                string errorMessage = String.Format(
                    isStatic ? ErrorCodes.StaticMethodIsMissing : ErrorCodes.InstanceMethodIsMissing,
                    FormatHelper.FormatType(type),
                    FormatHelper.FormatMethodDeclaration(methodName, returnType, parameterTypes)
                );
                throw new AssertFailedException(errorMessage);
            }
            string messageTemplate = String.Format(isStatic ? ErrorCodes.StaticMethodHasWrongAccessLevel : ErrorCodes.InstanceMethodHasWrongAccessLevel, "{0}", FormatHelper.FormatMethodDeclaration(methodName, returnType, parameterTypes), "{2}");
            AssertMemberHasAccessLevel(type, methodInfo, accessLevel, messageTemplate);

            return methodInfo;
        }

        public static ConstructorInfo GetConstructorInfo(Type type, AccessLevel? accessLevel = null)
        {
            return GetConstructorInfo(type, new Type[] { }, accessLevel);
        }

        public static ConstructorInfo GetConstructorInfo(Type type, Type[] parameterTypes, AccessLevel? accessLevel = null)
        {
            IEnumerable<ConstructorInfo> constructorInfos = GetMembers(type, isStatic: false).OfType<ConstructorInfo>();
            ConstructorInfo constructorInfo = constructorInfos.FirstOrDefault(info => IsEachParameterMatchesType(info.GetParameters(), parameterTypes));

            if(constructorInfo == null)
            {
                string errorMessage = String.Format(
                    ErrorCodes.ConstructorIsMissing,
                    FormatHelper.FormatType(type),
                    FormatHelper.FormatConstructorDeclaration(type, parameterTypes)
                );
                throw new AssertFailedException(errorMessage);
            }
            string messageTemplate = String.Format(ErrorCodes.ConstructorHasWrongAccessLevel, "{0}", FormatHelper.FormatConstructorDeclaration(type, parameterTypes), "{2}");
            AssertMemberHasAccessLevel(type, constructorInfo, accessLevel, messageTemplate);
            
            return constructorInfo;
        }

        public static object GetValue(MemberInfo memberInfo)
        {
            return GetValue(memberInfo, null);
        }

        public static object GetValue(MemberInfo memberInfo, object instance)
        {
            Func<object> getFunc;

            if (memberInfo is FieldInfo fieldInfo)
                getFunc = () => fieldInfo.GetValue(instance);
            else if (memberInfo is PropertyInfo propertyInfo)
                getFunc = () => propertyInfo.GetValue(instance);
            else throw new ArgumentException("INTERNAL: memberInfo is not field or property");

            try
            {
                return getFunc();
            }
            catch(Exception ex)
            {
                //rethrow of exception makes reflection transparent to user
                throw new AssertFailedException(ex.ToString());
            }
        }

        public static void SetValue(MemberInfo memberInfo, object value)
        {
            SetValue(memberInfo, null, value);
        }

        public static void SetValue(MemberInfo memberInfo, object instance, object value)
        {
            Action setAction;

            if (memberInfo is FieldInfo fieldInfo)
            {
                AssertObjectIsOfType(fieldInfo.FieldType, value);
                setAction = () => fieldInfo.SetValue(instance, value);
            }
            else if (memberInfo is PropertyInfo propertyInfo)
            {
                AssertObjectIsOfType(propertyInfo.PropertyType, value);
                setAction = () => propertyInfo.SetValue(instance, value);
            }
            else throw new ArgumentException("INTERNAL: memberInfo is not field or property");
            
            try
            {
                setAction();
            }
            catch (Exception ex)
            {
                //rethrow of exception makes reflection transparent to user
                throw new AssertFailedException(ex.ToString());
            }
        }

        public static object Invoke(MemberInfo memberInfo, object[] arguments)
        {
            return Invoke(memberInfo, null, arguments);
        }

        public static object Invoke(MemberInfo memberInfo, object instance, object[] arguments)
        {
            Func<object> invokeFunc;

            if (memberInfo is MethodInfo methodInfo)
            {
                object[] argumentsInclDefaultValues = GetArgumentsAndDefaults(methodInfo.GetParameters(), arguments);
                invokeFunc = () => methodInfo.Invoke(instance, argumentsInclDefaultValues);
            }
            else if (memberInfo is EventInfo eventInfo)
            {
                throw new NotImplementedException();
            }
            else if (memberInfo is ConstructorInfo constructorInfo)
            {
                object[] argumentsInclDefaultValues = GetArgumentsAndDefaults(constructorInfo.GetParameters(), arguments);
                invokeFunc = () => constructorInfo.Invoke(argumentsInclDefaultValues);
            }
            else throw new ArgumentException("INTERNAL: memberInfo is not method, event or constructor");

            try
            {
                return invokeFunc();
            }
            catch (Exception ex)
            {
                //rethrow of exception makes reflection transparent to user
                throw new AssertFailedException(ex.ToString());
            }
        }

        public static IEnumerable<MemberInfo> GetMembers(Type type, bool isStatic = false)
        {
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Public;

            flags |= isStatic ? BindingFlags.Static : BindingFlags.Instance;

            return type.GetMembers(flags);
        }

        private static void AssertMemberExists(Type type, string memberName, bool isStatic, string messageTemplate)
        {
            if(GetMembers(type, isStatic).Any(m => m.Name == memberName))
                return;

            string errorMessage = String.Format(
                messageTemplate,
                FormatHelper.FormatType(type),
                memberName
            );
            throw new AssertFailedException(errorMessage);
        }

        private static void AssertMemberIs<TMemberInfo>(Type type, MemberInfo info, string messageTemplate) where TMemberInfo : MemberInfo
        {
            if (TypeHelper.IsOfType(typeof(TMemberInfo), info))
                return;
            
            string errorMessage = String.Format(
                messageTemplate,
                FormatHelper.FormatType(type),
                info.Name,
                $"a {FormatHelper.FormatMemberType(info.GetType())}",
                $"a {FormatHelper.FormatMemberType(typeof(TMemberInfo))}"
            );
            throw new AssertFailedException(errorMessage);
        }

        private static void AssertMemberIsOfType(Type type, MemberInfo memberInfo, Type expectedType, string messageTemplate)
        {
            if (GetType(memberInfo) == expectedType)
                return;

            string errorMessage = String.Format(
                messageTemplate,
                FormatHelper.FormatType(type),
                memberInfo.Name,
                FormatHelper.FormatType(expectedType)
            );
            throw new AssertFailedException(errorMessage);
        }

        private static void AssertMemberHasAccessLevel(Type type, MemberInfo memberInfo, AccessLevel? accessLevel, string messageTemplate)
        {
            if (accessLevel == null)
                return;
            if (GetAccessLevel(memberInfo) == accessLevel)
                return;

            string errorMessage = String.Format(
                messageTemplate,
                FormatHelper.FormatType(type),
                memberInfo.Name,
                FormatHelper.FormatAccessLevel(accessLevel ?? AccessLevel.Private)
            );
            throw new AssertFailedException(errorMessage);
        }

        private static void AssertObjectIsOfType(Type type, object value)
        {
            if (TypeHelper.IsOfType(type, value))
                return;
            
            string errorMessage = String.Format(
                ErrorCodes.ObjectIsWrongType,
                ObjectMethodRegistry.ToString(value),
                FormatHelper.FormatType(type)
            );
            throw new AssertFailedException(errorMessage);
        }

        //matches strictly
        private static bool IsEachParameterMatchesType(ParameterInfo[] parameterInfos, Type[] parameterTypes)
        {
            int i = 0; 
            foreach(ParameterInfo info in parameterInfos)
            {
                if (i > parameterTypes.Length - 1)
                    break;
                //too many parameters
                if (i > parameterInfos.Length - 1)
                    return false;
                //wrong parameter type
                if (info.ParameterType != parameterTypes[i] && !info.IsOptional)
                    return false;
                //match
                if (info.ParameterType == parameterTypes[i])
                    i++;
            }
            //too few parameters
            if (i < parameterTypes.Length)
                return false;

            return true;
        }

        private static AccessLevel GetAccessLevel(MemberInfo memberInfo)
        {
            if (memberInfo is ConstructorInfo constructorInfo)
            {
                if (constructorInfo.IsPrivate)
                    return AccessLevel.Private;
                if (constructorInfo.IsFamily)
                    return AccessLevel.Protected;
                if (constructorInfo.IsPublic)
                    return AccessLevel.Public;
            }
            if (memberInfo is FieldInfo fieldInfo)
            {
                if (fieldInfo.IsPrivate)
                    return AccessLevel.Private;
                if (fieldInfo.IsFamily)
                    return AccessLevel.Protected;
                if (fieldInfo.IsPublic)
                    return AccessLevel.Public;
            }
            if (memberInfo is MethodInfo methodInfo)
            {
                if (methodInfo.IsPrivate)
                    return AccessLevel.Private;
                if (methodInfo.IsFamily)
                    return AccessLevel.Protected;
                if (methodInfo.IsPublic)
                    return AccessLevel.Public;
            }
            throw new NotImplementedException($"Unsupported MemberInfo type {memberInfo.GetType().Name}");
        }

        private static object[] GetArgumentsAndDefaults(ParameterInfo[] infos, object[] arguments)
        {
            if (infos.Length < arguments.Length)
                throw new ArgumentException("INTERNAL: Too many arguments");

            List<object> newArguments = new List<object>();
            int i = 0; 
            foreach(ParameterInfo parameterInfo in infos)
            {
                if (i < arguments.Length && TypeHelper.IsOfType(parameterInfo.ParameterType, arguments[i]))
                {
                    newArguments.Add(arguments[i]);
                    i++;
                }
                else newArguments.Add(parameterInfo.DefaultValue);
            }
            return newArguments.ToArray();
        }

        private static Type GetType(MemberInfo memberInfo)
        {
            if (memberInfo is FieldInfo fieldInfo)
                return fieldInfo.FieldType;
            if (memberInfo is PropertyInfo propertyInfo)
                return propertyInfo.PropertyType;
            if (memberInfo is MethodInfo methodInfo)
                return methodInfo.ReturnType;

            throw new NotImplementedException($"Unsupported MemberInfo type {memberInfo.GetType().Name}");
        }
    }
}
