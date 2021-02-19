using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Helpers
{
    internal static class TypeExtensions
    {
        public static MemberInfo[] GetAllMembers(this Type type)
        {
            return type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        }

        public static bool IsStatic(this Type type)
        {
            return type.IsAbstract && type.IsSealed;
        }
    }
}
