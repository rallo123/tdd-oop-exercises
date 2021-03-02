using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestTools.Structure;

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

        public static ITypeTranslator GetCustomTranslator(this Type type)
        {
            return type.GetCustomAttributes().OfType<ITypeTranslator>().FirstOrDefault();
        }

        public static ITypeVerifier GetCustomVerifier(this Type type, TypeVerificationAspect aspect)
        {
            return type.GetCustomAttributes().OfType<ITypeVerifier>().FirstOrDefault(v => v.Aspects.Contains(aspect));
        }
    }
}
