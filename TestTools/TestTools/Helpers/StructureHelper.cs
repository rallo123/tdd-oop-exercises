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

            AssertMemberExists(type, fieldName, ErrorCodes.MemberIsMissing);
            AssertMemberIsInstanceOrStatic(type, fieldName, isStatic);
            AssertMemberIs<FieldInfo>(type, memberInfo, ErrorCodes.MemberIsWrongMemberType);
            AssertMemberIsOfType(type, memberInfo, fieldType, ErrorCodes.FieldIsWrongType);
            AssertMemberHasAccessLevel(type, memberInfo, accessLevel, ErrorCodes.FieldHasWrongAccessLevel);
            
            return (FieldInfo)memberInfo;
        }

        public static PropertyInfo GetPropertyInfo(Type type, string propertyName, Type propertyType, PropertyAccessor get = null, PropertyAccessor set = null, bool isStatic = false)
        {
            MemberInfo memberInfo = GetMembers(type, isStatic).FirstOrDefault(m => m.Name == propertyName);
            PropertyInfo propertyInfo = memberInfo as PropertyInfo;

            AssertMemberExists(type, propertyName, ErrorCodes.MemberIsMissing);
            AssertMemberIsInstanceOrStatic(type, propertyName, isStatic);
            AssertMemberIs<PropertyInfo>(type, memberInfo, ErrorCodes.MemberIsWrongMemberType);
            AssertMemberIsOfType(type, memberInfo, propertyType, ErrorCodes.PropertyIsWrongType);

            if(get != null)
            {
                if (!propertyInfo.CanRead)
                {
                    string errorMessage = String.Format(
                        ErrorCodes.PropertyIsMissingGet,
                        FormatHelper.FormatType(type),
                        propertyName
                    );
                    throw new AssertFailedException(errorMessage);
                }
                string messageTemplate = String.Format(ErrorCodes.PropertyGetHasWrongAccessLevel, "{0}", propertyName, "{2}");
                AssertMemberHasAccessLevel(type, propertyInfo.GetMethod, get.AccessLevel, messageTemplate);
            }
            if(set != null)
            {
                if (!propertyInfo.CanWrite)
                {
                    string errorMessage = String.Format(ErrorCodes.PropertyIsMissingSet,
                        FormatHelper.FormatType(type),
                        propertyName
                    );
                    throw new AssertFailedException(errorMessage);
                }
                string messageTemplate = String.Format(ErrorCodes.PropertySetHasWrongAccessLevel, "{0}", propertyName, "{2}");
                AssertMemberHasAccessLevel(type, propertyInfo.SetMethod, set.AccessLevel, messageTemplate);
            }

            return propertyInfo;
        }

        public static MemberInfo GetFieldOrPropertyInfo(Type type, string memberName, Type memberType, AccessLevel? accessLevel = null, bool isStatic = false)
        {
            AssertMemberExists(type, memberName, ErrorCodes.MemberIsMissing);
            AssertMemberIsInstanceOrStatic(type, memberName, isStatic);
            MemberInfo memberInfo = GetMembers(type, isStatic).First(m => m.Name == memberName);

            if (memberInfo is FieldInfo)
                return GetFieldInfo(type, memberName, memberType, accessLevel, isStatic);
            if (memberInfo is PropertyInfo)
                return GetPropertyInfo(type, memberName, memberType, get: new PropertyAccessor(accessLevel), set: new PropertyAccessor(accessLevel));

            string errorMessage = String.Format(
                ErrorCodes.MemberIsNotFieldOrProperty,
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
            
            AssertMemberExists(type, methodName, ErrorCodes.MemberIsMissing);
            AssertMemberIsInstanceOrStatic(type, methodName, isStatic);
            AssertMemberIs<MethodInfo>(type, memberInfos.First(), ErrorCodes.MemberIsWrongMemberType);
            AssertMemberIsOfType(type, memberInfos.First(), returnType, ErrorCodes.MethodIsWrongReturnType);

            MethodInfo methodInfo = memberInfos.OfType<MethodInfo>().FirstOrDefault(info => IsEachParameterMatchesType(info.GetParameters(), parameterTypes));
            if(methodInfo == null)
            {
                string errorMessage = String.Format(
                    ErrorCodes.MethodIsMissing,
                    FormatHelper.FormatType(type),
                    FormatHelper.FormatMethodDeclaration(methodName, returnType, parameterTypes)
                );
                throw new AssertFailedException(errorMessage);
            }
            string messageTemplate = String.Format(ErrorCodes.MethodHasWrongAccessLevel, "{0}", FormatHelper.FormatMethodDeclaration(methodName, returnType, parameterTypes), "{2}");
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

        public static IEnumerable<MemberInfo> GetMembers(Type type, bool? isStatic = null)
        {
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Public;

            if (isStatic == null)
            {
                flags |= BindingFlags.Static;
                flags |= BindingFlags.Instance;
            }
            else flags |= ((bool)isStatic) ? BindingFlags.Static : BindingFlags.Instance;

            return type.GetMembers(flags);
        }

        private static void AssertMemberExists(Type type, string memberName, string messageTemplate)
        {
            if(GetMembers(type).Any(m => m.Name == memberName))
                return;

            string errorMessage = String.Format(
                messageTemplate,
                FormatHelper.FormatType(type),
                memberName
            );
            throw new AssertFailedException(errorMessage);
        }

        private static void AssertMemberIsInstanceOrStatic(Type type, string memberName, bool isStatic)
        {
            if (GetMembers(type, isStatic).Any(m => m.Name == memberName))
                return;

            string errorMessage = String.Format(
                isStatic ? ErrorCodes.MemberIsNonStaticMember : ErrorCodes.MemberIsNonInstanceMember,
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
                if (i < arguments.Length)
                {
                    if (!TypeHelper.IsOfType(parameterInfo.ParameterType, arguments[i]))
                    {
                        string errorMessage = String.Format(
                            "INTERNAL: Parameter {0} argument {1} is not of type {2}",
                            parameterInfo.Name,
                            ObjectMethodRegistry.ToString(arguments[i]),
                            FormatHelper.FormatType(parameterInfo.ParameterType)
                        );
                        throw new ArgumentException(errorMessage);
                    }
                    newArguments.Add(arguments[i]);
                    i++;
                }
                else if (parameterInfo.HasDefaultValue)
                {
                    newArguments.Add(parameterInfo.DefaultValue);
                }
                else throw new ArgumentException("INTERNAL: Too few arguments");
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
