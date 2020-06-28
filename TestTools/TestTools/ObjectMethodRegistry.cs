using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools
{
    public static class ObjectMethodRegistry
    {
        private static readonly Dictionary<Type, Func<object, object, bool>> equalsFunctions = new Dictionary<Type, Func<object, object, bool>>();
        private static readonly Dictionary<Type, Func<object, string>> toStringFunctions = new Dictionary<Type, Func<object, string>>();
        private static readonly Dictionary<Type, Func<object, int>> getHashCodeFunctions = new Dictionary<Type, Func<object, int>>();
        
        public static new bool Equals(object instance1, object instance2)
        {
            if (instance1 == null || instance2 == null)
                return instance1 == instance2;

            if (instance1.GetType().GetMethod("Equals").DeclaringType != typeof(object))
                return instance1.Equals(instance2);

            foreach(Type type in equalsFunctions.Keys)
            {
                if (instance1.GetType() == type || instance1.GetType().IsSubclassOf(type))
                    return equalsFunctions[type](instance1, instance2);
            }
            return instance1.Equals(instance2);
        }

        public static string ToString(object instance)
        {
            if (instance == null)
                return "null";

            Type type = instance.GetType();

            if (type.GetMethod("ToString", new Type[] { }).DeclaringType != typeof(object))
                return instance.ToString();

            foreach(Type key in toStringFunctions.Keys)
            {
                if (type == key || type.IsSubclassOf(key))
                    return toStringFunctions[key](instance);
            }
            return instance.ToString();
        }

        public static int GetHashCode(object instance)
        {
            if (instance == null)
                return 0;

            Type type = instance.GetType();

            if (type.GetMethod("GetHashCode").DeclaringType != typeof(object))
                return instance.GetHashCode();

            foreach (Type key in getHashCodeFunctions.Keys)
            {
                if (type.IsSubclassOf(key))
                    return getHashCodeFunctions[key](instance);
            }
            return instance.GetHashCode();
        }

        public static void RegisterEquals(Type type, Func<object, object, bool> equals)
        {
            if (equalsFunctions.ContainsKey(type))
                equalsFunctions[type] = equals;

            else equalsFunctions.Add(type, equals);
        }

        public static void RegisterToString(Type type, Func<object,string> toString)
        {
            if (toStringFunctions.ContainsKey(type))
                toStringFunctions[type] = toString;

            else toStringFunctions.Add(type, toString);
        }

        public static void RegisterGetHashCode(Type type, Func<object, int> getHashCode)
        {
            if (getHashCodeFunctions.ContainsKey(type))
                getHashCodeFunctions[type] = getHashCode;

            else getHashCodeFunctions.Add(type, getHashCode);
        }

        public static void DeregisterEquals(Type type)
        {
            equalsFunctions.Remove(type);
        }

        public static void DeregisterToString(Type type)
        {
            toStringFunctions.Remove(type);
        }

        public static void DeregisterGetHashCode(Type type)
        {
            getHashCodeFunctions.Remove(type);
        }
    }
}
