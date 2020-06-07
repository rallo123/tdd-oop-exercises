using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lecture_1_Tests.Helpers
{
    public static class MemberHelper
    {
        private static readonly BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        
        public static MemberInfo GetInfo(Type type, string[] path)
        {
            Type current = type;

            for(int i = 0; i < path.Length - 1; i++)
            {
                MemberInfo memberInfo = current.GetMember(path[i], bindingAttr).FirstOrDefault();

                if (memberInfo is FieldInfo fieldInfo)
                {
                    current = fieldInfo.FieldType;
                }
                else if (memberInfo is PropertyInfo propertyInfo)
                {
                    current = propertyInfo.PropertyType;
                }
                else throw new ArgumentException("Invalid path");
            }

            return current.GetMember(path[^1], bindingAttr).FirstOrDefault();
        }
        public static ConstructorInfo GetConstructorInfo(Type type, Type[] parameterTypes)
        {
            ConstructorInfo[] constructors = type.GetConstructors();

            foreach(var constructor in constructors)
            {
                ParameterInfo[] parameters = constructor.GetParameters();
                bool parametersMatch = parameters.Length == (parameterTypes?.Length ?? 0);

                int i = 0;
                while (parametersMatch && i < parameters.Length)
                {
                    if (parameters[i].ParameterType != parameterTypes[i]) 
                        parametersMatch = false;
                    i++;
                }

                if (parametersMatch)
                    return constructor;
            }
            throw new ArgumentException("no such constructor exists");
        }
        public static object CreateInstance(Type type, object[] parameters = null)
        {
            Type[] parameterTypes = parameters?.Select(par => par.GetType())?.ToArray();
            
            return GetConstructorInfo(type, parameterTypes).Invoke(parameters);
        }
        public static object GetValue(object instance, string[] path)
        {
            object current = instance;
            
            for(int i = 0; i < path.Length; i++)
            {
                MemberInfo memberInfo = instance.GetType().GetMember(path[i], bindingAttr).FirstOrDefault();

                if (memberInfo is FieldInfo fieldInfo)
                {
                    current = fieldInfo.GetValue(current);
                }
                else if (memberInfo is PropertyInfo propertyInfo)
                {
                    current = propertyInfo.GetValue(current);
                }
                else new ArgumentException("Invalid path");
            }

            return current;
        }
        public static void SetValue(object instance, string[] path, object value)
        {
            object lastPathElement = path.Length == 1 ? instance : GetValue(instance, path[0..^1]);
            MemberInfo memberInfo = lastPathElement.GetType().GetMember(path[^1], bindingAttr).FirstOrDefault();

            if (memberInfo is FieldInfo fieldInfo)
            {
                fieldInfo.SetValue(lastPathElement, value);
            }
            else if (memberInfo is PropertyInfo propertyInfo)
            {
                propertyInfo.SetValue(lastPathElement, value);
            }
            else new ArgumentException("Invalid path");
        }
        public static object CallMethod(object instance, string[] path, object[] parameters = null)
        {
            object lastPathElement = path.Length == 1 ? instance : GetValue(instance, path[0..^1]);
            MethodInfo memberInfo = lastPathElement.GetType().GetMethod(path[^1], bindingAttr);

            return memberInfo.Invoke(lastPathElement, parameters);
        }

        //Single element path versions
        public static MemberInfo GetInfo(Type type, string name)
        {
            return GetInfo(type, new string[] { name });
        }
        public static object GetValue(object instance, string name)
        {
            return GetValue(instance, new string[] { name });
        }
        public static void SetValue(object instance, string name, object value)
        {
            SetValue(instance, new string[] { name }, value);
        }
        public static object CallMethod(object instance, string name, object[] parameters = null)
        {
            return CallMethod(instance, new string[] { name }, parameters);
        }
        
        //Safe versions
        public static MemberInfo TryGetInfo(Type type, string[] path)
        {
            try { return GetInfo(type, path); }
            catch { return null; }
        }
        public static ConstructorInfo TryGetConstructorInfo(Type type, Type[] parameterTypes)
        {
            try { return GetConstructorInfo(type, parameterTypes); }
            catch { return null; }
        }
        public static object TryCreateInstance(Type type, object[] parameters = null)
        {
            try { return CreateInstance(type, parameters); }
            catch { return null; }
        }
        public static object TryGetValue(object instance, string[] path)
        {
            try { return GetValue(instance, path); }
            catch { return null; }
        }
        public static void TrySetValue(object instance, string[] path, object value)
        {
            try { SetValue(instance, path, value); }
            catch { }
        }
        public static object TryCallMethod(object instance, string[] path, object[] parameters = null)
        {
            try { return CallMethod(instance, path, parameters); }
            catch { return null; }
        } 

        //Safe single element path versions
        public static MemberInfo TryGetInfo(Type type, string name)
        {
            try { return GetInfo(type, name); }
            catch { return null; }
        }
        public static object TryGetValue(object instance, string name)
        {
            try { return GetValue(instance, name); }
            catch { return null; }
        }
        public static void TrySetValue(object instance, string name, object value)
        {
            try { SetValue(instance, name, value); }
            catch { }
        }
        public static object TryCallMethod(object instance, string name, object[] parameters = null)
        {
            try { return CallMethod(instance, name, parameters); }
            catch { return null; }
        }
    }
}
