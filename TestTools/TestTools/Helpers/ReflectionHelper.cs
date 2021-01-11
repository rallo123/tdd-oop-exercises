using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestTools.Errors;
using TestTools.Structure;
using TestTools.Structure.Exceptions;

namespace TestTools.Helpers
{
    public static class ReflectionHelper
    {
        // Manipulation
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
            catch (Exception ex)
            {
                //rethrow of exception makes reflection transparent to user
                throw new AssertFailedException(ex.ToString(), ex);
            }
        }

        public static void SetValue(MemberInfo memberInfo, object instance, object value)
        {
            Action setAction;

            if (memberInfo is FieldInfo fieldInfo)
            {
                if (TypeHelper.IsOfType(fieldInfo.FieldType, value))
                    throw new ArgumentException($"INTERNAL: value ${value} is not of type {fieldInfo.FieldType}");
                setAction = () => fieldInfo.SetValue(instance, value);
            }
            else if (memberInfo is PropertyInfo propertyInfo)
            {
                if (TypeHelper.IsOfType(propertyInfo.PropertyType, value))
                    throw new ArgumentException($"INTERNAL: value ${value} is not of type {propertyInfo.PropertyType}");
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
                throw new AssertFailedException(ex.ToString(), ex);
            }
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
                throw new AssertFailedException(ex.InnerException.ToString(), ex.InnerException);
            }
        }

        // Infos
        public static FieldInfo GetFieldInfo(Type type, FieldRequirements options, bool isStatic = false)
        {
            string typeName = FormatHelper.FormatType(type);
            MemberInfo memberInfo = TryGetMemberByName(type, options.Name);
            FieldInfo fieldInfo = memberInfo as FieldInfo;

            if (memberInfo == null)
                throw new Structure.Exceptions.MissingMemberException(type, options.Name);
            
            if (isStatic && !HasMemberWithName(type, options.Name, true))
                throw new NonStaticMemberException(type, options.Name);
            
            if (!isStatic && !HasMemberWithName(type, options.Name, false))
                throw new NonInstanceMemberException(type, options.Name);
            
            if (fieldInfo == null)
                throw new InvalidMemberTypeException(type, options.Name, MemberTypes.Field, memberInfo.MemberType);
            
            if (fieldInfo.FieldType != options.FieldType)
                throw new InvalidFieldTypeException(type, options);

            if (options.IsInitOnly != null && options.IsInitOnly != fieldInfo.IsInitOnly)
                throw new InvalidFieldModifierException(type, options, MemberModifiers.Readonly, (bool)options.IsInitOnly);

            if (options.IsPrivate != null && options.IsPrivate != fieldInfo.IsPrivate)
                throw new InvalidFieldModifierException(type, options, MemberModifiers.Private, (bool)options.IsPrivate);

            if (options.IsFamily != null && options.IsFamily != fieldInfo.IsFamily)
                throw new InvalidFieldModifierException(type, options, MemberModifiers.Protected, (bool)options.IsFamily);

            if (options.IsPublic != null && options.IsPublic != fieldInfo.IsPublic)
                throw new InvalidFieldModifierException(type, options, MemberModifiers.Public, (bool)options.IsPublic);
            
            return (FieldInfo)memberInfo;
        }

        public static PropertyInfo GetPropertyInfo(Type type, PropertyRequirements options, bool isStatic = false)
        {
            MemberInfo memberInfo = TryGetMemberByName(type, options.Name, isStatic); 
            PropertyInfo propertyInfo = memberInfo as PropertyInfo;

            if (memberInfo == null)
                throw new Structure.Exceptions.MissingMemberException(type, options.Name);

            if (isStatic && !HasMemberWithName(type, options.Name, true))
                throw new NonStaticMemberException(type, options.Name);

            if (!isStatic && !HasMemberWithName(type, options.Name, false))
                throw new NonInstanceMemberException(type, options.Name);
           
            if (propertyInfo == null)
                throw new InvalidMemberTypeException(type, options.Name, MemberTypes.Property, memberInfo.MemberType);


            if (propertyInfo.PropertyType != options.PropertyType)
                throw new InvalidPropertyTypeException(type, options);
            
            if (options.GetMethod != null)
            {
                MethodRequirements getOptions = options.GetMethod;

                if (!propertyInfo.CanRead)
                    throw new PropertyMissingGetException(type, options);

                if (getOptions.IsAbstract != null && getOptions.IsAbstract != propertyInfo.GetMethod.IsAbstract)
                    throw new InvalidPropertyGetModifierException(type, options, MemberModifiers.Abstract, (bool)getOptions.IsAbstract);

                if (getOptions.IsVirtual != null && getOptions.IsVirtual == propertyInfo.GetMethod.IsVirtual)
                    throw new InvalidPropertyGetModifierException(type, options, MemberModifiers.Virtual, (bool)getOptions.IsVirtual);

                if (getOptions.DeclaringType != null && getOptions.DeclaringType != propertyInfo.GetMethod.DeclaringType)
                    throw new InvalidPropertyGetDeclaringTypeException(type, options);

                if (getOptions.IsPrivate != null && getOptions.IsPrivate != propertyInfo.GetMethod.IsPrivate)
                    throw new InvalidPropertyGetModifierException(type, options, MemberModifiers.Private, (bool)getOptions.IsPrivate);

                if (getOptions.IsFamily != null && getOptions.IsFamily != propertyInfo.GetMethod.IsFamily)
                    throw new InvalidPropertyGetModifierException(type, options, MemberModifiers.Protected, (bool)getOptions.IsFamily);

                if (getOptions.IsPublic != null && getOptions.IsPublic != propertyInfo.GetMethod.IsPublic)
                    throw new InvalidPropertyGetModifierException(type, options, MemberModifiers.Public, (bool)getOptions.IsPublic);
            }
            if (options.SetMethod != null)
            {
                MethodRequirements setOptions = options.SetMethod;

                if (!propertyInfo.CanWrite)
                    throw new PropertyMissingSetException(type, options);

                if (setOptions.IsAbstract != null && setOptions.IsAbstract != propertyInfo.SetMethod.IsAbstract)
                    throw new InvalidPropertySetModifierException(type, options, MemberModifiers.Abstract, (bool)setOptions.IsAbstract);

                if (setOptions.IsVirtual != null && setOptions.IsVirtual != propertyInfo.SetMethod.IsVirtual)
                    throw new InvalidPropertySetModifierException(type, options, MemberModifiers.Virtual, (bool)setOptions.IsAbstract);

                if (setOptions.DeclaringType != null && setOptions.DeclaringType != propertyInfo.SetMethod.DeclaringType)
                    throw new InvalidPropertySetDeclaringTypeException(type, options);

                if (setOptions.IsPrivate != null && setOptions.IsPrivate != propertyInfo.SetMethod.IsPrivate)
                    throw new InvalidPropertySetModifierException(type, options, MemberModifiers.Private, (bool)setOptions.IsPrivate);

                if (setOptions.IsFamily != null && setOptions.IsFamily != propertyInfo.SetMethod.IsFamily)
                    throw new InvalidPropertySetModifierException(type, options, MemberModifiers.Protected, (bool)setOptions.IsFamily);

                if (setOptions.IsPublic != null && setOptions.IsPublic != propertyInfo.SetMethod.IsPublic)
                    throw new InvalidPropertySetModifierException(type, options, MemberModifiers.Public, (bool)setOptions.IsPublic);
            }

            return propertyInfo;
        }

        public static MethodInfo GetMethodInfo(Type type, MethodRequirements options, bool isStatic = false)
        {
            string typeName = FormatHelper.FormatType(type);
            string methodDeclaration = FormatHelper.FormatMethodAccess(type, options);
            IEnumerable<MemberInfo> memberInfos = GetMembersByName(type, options.Name);
            IEnumerable<MethodInfo> methodInfos = memberInfos.OfType<MethodInfo>();
            MethodInfo methodInfo = methodInfos.FirstOrDefault(info => IsEachParameterMatchesType(info.GetParameters(), options.Parameters));

            if (!memberInfos.Any())
                throw new Structure.Exceptions.MissingMemberException(type, options.Name);

            if (isStatic && !HasMemberWithName(type, options.Name, true))
                throw new NonStaticMemberException(type, options.Name);

            if (!isStatic && !HasMemberWithName(type, options.Name, false))
                throw new NonInstanceMemberException(type, options.Name);

            if (!methodInfos.Any())
                throw new InvalidMemberTypeException(type, options.Name, MemberTypes.Method, memberInfos.First().MemberType);

            if (methodInfos.First().ReturnType != options.ReturnType)
                throw new InvalidMethodReturnTypeException(type, options);

            if (methodInfo == null)
                throw new Structure.Exceptions.MissingMethodException(type, options);

            if (options.IsAbstract != null && options.IsAbstract == methodInfo.IsAbstract)
                throw new InvalidMethodModifierException(type, options, MemberModifiers.Abstract, (bool)options.IsAbstract);  

            if (options.IsVirtual != null && options.IsVirtual == methodInfo.IsVirtual)
                throw new InvalidMethodModifierException(type, options, MemberModifiers.Virtual, (bool)options.IsVirtual);

            if (options.DeclaringType != null && options.DeclaringType == methodInfo.DeclaringType)
                throw new InvalidMethodDeclaringTypeException(type, options);

            if (options.IsPrivate != null && options.IsPrivate != methodInfo.IsPrivate)
                throw new InvalidMethodModifierException(type, options, MemberModifiers.Private, (bool)options.IsPrivate);

            if (options.IsFamily != null && options.IsFamily != methodInfo.IsFamily)
                throw new InvalidMethodModifierException(type, options, MemberModifiers.Protected, (bool)options.IsFamily);

            if (options.IsPublic != null && options.IsPublic != methodInfo.IsPublic)
                throw new InvalidMethodModifierException(type, options, MemberModifiers.Public, (bool)options.IsPublic);

            return methodInfo;
        }

        public static ConstructorInfo GetConstructorInfo(Type type, ConstructorRequirements options)
        {
            string typeName = FormatHelper.FormatType(type);
            string constructorDeclaration = FormatHelper.FormatConstructorDeclaration(type, options);
            IEnumerable <ConstructorInfo> constructorInfos = GetMembers(type, isStatic: false).OfType<ConstructorInfo>();
            ConstructorInfo constructorInfo = constructorInfos.FirstOrDefault(info => IsEachParameterMatchesType(info.GetParameters(), options.Parameters));

            if (constructorInfo == null)
                throw new MissingConstructorException(type, options);

            if (options.IsPrivate != null && options.IsPrivate != constructorInfo.IsPrivate)
                throw new InvalidConstructorModifierException(type, options, MemberModifiers.Private, (bool)options.IsPrivate);

            if (options.IsFamily != null && options.IsFamily != constructorInfo.IsFamily)
                throw new InvalidConstructorModifierException(type, options, MemberModifiers.Protected, (bool)options.IsFamily);

            if (options.IsPublic != null && options.IsPublic != constructorInfo.IsPublic)
                throw new InvalidConstructorModifierException(type, options, MemberModifiers.Public, (bool)options.IsPublic);

            return constructorInfo;
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

        public static MemberInfo TryGetMemberByName(Type type, string memberName, bool? isStatic = null)
        {
            return GetMembers(type, isStatic).FirstOrDefault(m => m.Name == memberName);
        }

        public static IEnumerable<MemberInfo> GetMembersByName(Type type, string memberName, bool? isStatic = null)
        {
            return GetMembers(type, isStatic).Where(m => m.Name == memberName);
        }

        public static bool HasMemberWithName(Type type, string memberName, bool? isStatic = null)
        {
            return TryGetMemberByName(type, memberName, isStatic) != null;
        }

        private static bool IsEachParameterMatchesType(ParameterInfo[] parameterInfos, ParameterOptions[] parameterOptions)
        {
            int i = 0; 
            foreach(ParameterInfo info in parameterInfos)
            {
                if (i > parameterOptions.Length - 1)
                    break;
                //too many parameters
                if (i > parameterInfos.Length - 1)
                    return false;
                //wrong parameter type
                if (info.ParameterType != parameterOptions[i].ParameterType && !info.IsOptional)
                    return false;
                //match
                if (info.ParameterType == parameterOptions[i].ParameterType)
                    i++;
            }
            //too few parameters
            if (i < parameterOptions.Length)
                return false;

            return true;
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
    }
}
