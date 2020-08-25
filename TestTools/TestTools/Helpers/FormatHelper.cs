using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Structure;

namespace TestTools.Helpers
{
    public static class FormatHelper
    {
        public static string FormatAccessLevel(AccessLevel accessLevel)
        {
            return accessLevel.ToString().ToLower();
        }

        public static string FormatMethodDeclaration(string methodName, MethodOptions options)
        {
            return FormatType(options.ReturnType) + " " + methodName + "(" + FormatParameters(options.Parameters) + ")";
        }

        public static string FormatMethodAccess(Type classType, MethodOptions options)
        {
            return options.Name + "(" + FormatParameters(options.Parameters) + ")";
        }

        public static string FormatConstructorDeclaration(Type classType,  ConstructorOptions options)
        {
            return FormatType(classType) + "(" + FormatParameters(options.Parameters) + ")";
        }

        private static string FormatParameters(ParameterOptions[] parameters)
        {
            StringBuilder builder = new StringBuilder();

            int i = 0; 
            foreach(ParameterOptions parameter in parameters)
            {
                if (i != 0)
                    builder.Append(", ");

                if (parameter.Name != null)
                {
                    builder.Append(string.Format("{0} {1}", FormatType(parameter.ParameterType), parameter.Name));
                }
                else builder.Append(string.Format("{0} par{1}", FormatType(parameter.ParameterType), i + 1));
                i++;
            }

            return builder.ToString();
        }

        public static string FormatMemberType(Type memberType)
        {
            if (memberType == null)
                throw new ArgumentNullException(nameof(memberType));
            if (memberType.IsSubclassOf(memberType))
                throw new ArgumentException($"Type {memberType.Name} is not subtype of MemberInfo");

            if (TypeHelper.IsType(typeof(FieldInfo), memberType))
                return "field";
            if (TypeHelper.IsType(typeof(PropertyInfo), memberType))
                return "property";
            if (TypeHelper.IsType(typeof(MethodInfo), memberType))
                return "method";
            if (TypeHelper.IsType(typeof(ConstructorInfo), memberType))
                return "constructor";

            throw new NotImplementedException("Unknown MemberInfo type");
        }

        public static string FormatType(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            Dictionary<Type, string> BuiltinTypes = new Dictionary<Type, string>()
            {
                [typeof(void)] = "void",
                [typeof(bool)] = "bool",
                [typeof(int)] = "int",
                [typeof(byte)] = "byte",
                [typeof(sbyte)] = "sbyte",
                [typeof(char)] = "char",
                [typeof(decimal)] = "decimal",
                [typeof(double)] = "double",
                [typeof(float)] = "float",
                [typeof(int)] = "int",
                [typeof(uint)] = "uint",
                [typeof(long)] = "long",
                [typeof(ulong)] = "ulong",
                [typeof(short)] = "short",
                [typeof(ushort)] = "ushort",
                [typeof(string)] = "string",
                [typeof(object)] = "object"
            };

            if (BuiltinTypes.ContainsKey(type))
                return BuiltinTypes[type];

            else return type.Name;
        }

        public static string FormatDefinitionChain(IElement definition)
        {
            string prefix = "";

            if (definition.PreviousElement != null)
                prefix += ".";

            return prefix + definition.Name;
        }
    }
}
