using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using TestTools.Structure;

namespace TestTools.Helpers
{
    public static class FormatHelper
    {
        private readonly static Dictionary<Type, Func<object, string>> LiteralRepresentations = new Dictionary<Type, Func<object, string>>()
        {
            [null] = (o) => "null",
            [typeof(bool)] = (o) => ((bool)o).ToString(),
            [typeof(byte)] = (o) => $"(byte){(byte)o}",
            [typeof(char)] = (o) => $"'{(char)o}'",
            [typeof(decimal)] = (o) => $"{(decimal)o}M",
            [typeof(float)] = (o) => $"{(float)o}F",
            [typeof(int)] = (o) => ((int)o).ToString(),
            [typeof(long)] = (o) =>  $"{(long)o}L",
            [typeof(short)] = (o) => $"(short){(short)o}",
            [typeof(string)] = (o) => $"\"{(string)o}\"",
            [typeof(sbyte)] = (o) => $"(sbyte){(sbyte)o}",
            [typeof(uint)] = (o) => $"{(uint)o}U",
            [typeof(ulong)] = (o) => $"{(ulong)o}UL",
            [typeof(ushort)] = (o) => $"(ushort){(ushort)o}"
        };

        public static bool HasLiteralRepresentation(object value)
        {
            return HasLiteralRepresentation(value?.GetType());
        }

        public static bool HasLiteralRepresentation(Type type)
        {
            return LiteralRepresentations.ContainsKey(type);
        }

        public static string FormatAsLiteral(object value)
        {
            Type type = value?.GetType();

            if (LiteralRepresentations.ContainsKey(type))
                throw new ArgumentException($"INTERNAL: {value} cannot be represented as literal");
            return LiteralRepresentations[type](value);
        }
        
        public static string FormatList(string[] list)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < list.Length; i++)
            {
                builder.Append(list[i]);
                builder.Append((i < list.Length - 1) ? ", " : " & ");
            }
            return builder.ToString();
        }

        public static string FormatMemberModifier(MemberModifiers modifier)
        {
            return modifier.ToString().ToLower();
        }

        public static string FormatMethodAccess(Type classType, MethodRequirements options)
        {
            return options.Name + "(" + FormatParameters(options.Parameters) + ")";
        }

        public static string FormatMethodDeclaration(MethodRequirements options)
        {
            return FormatType(options.ReturnType) + " " + options.Name + "(" + FormatParameters(options.Parameters) + ")";
        }
        
        public static string FormatConstructorDeclaration(Type classType,  ConstructorRequirements options)
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

        public static string FormatMemberType(MemberTypes memberType)
        {
            return memberType.ToString().ToLower();
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
