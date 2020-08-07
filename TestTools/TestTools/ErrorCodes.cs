using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Helpers
{
    public static class ErrorCodes
    {
        //{0} = class type, {1} = member name
        public static readonly string MemberIsMissing = "{0} does not contain member {1}";
        public static readonly string PropertyIsMissingGet = "{0} property {1} is missing get method";
        public static readonly string PropertyIsMissingSet = "{0} property {1} is missing set method";
        public static readonly string MethodIsMissing = "{0} does not contain method {1}";
        public static readonly string ConstructorIsMissing = "{0} does not contain constructor {1}";

        // {0} = class type, {1} = member name
        public static readonly string MemberIsNonInstanceMember = "{0} member {1} is static member instead of instance member";
        public static readonly string MemberIsNonStaticMember = "{0} member {1} is instance member instead of static member";

        //{0} = class type, {1} = member name, {2} = actual member type, {3} = expected member type
        public static readonly string MemberIsWrongMemberType = "{0} member {1} is {2} instead of {3}";

        //{0} = class type, {1} = member name, {2} = actual member type 
        public static readonly string MemberIsNotFieldOrProperty = "{0} member {1} is {2} instead of field or property";

        //{0} = class type, {1} = member name, {2} = (return)type of member
        public static readonly string FieldIsWrongType = "{0} field {1} is not of type {2}";
        public static readonly string PropertyIsWrongType = "{0} property {1} is not of type {2}";
        public static readonly string MethodIsWrongReturnType = "{0} method {1} return type is not {2}";

        //{0} class type, {1} member name / member declaration, {2} = access level 
        public static readonly string FieldHasWrongAccessLevel = "{0} field {1} is not {2}";
        public static readonly string PropertyGetHasWrongAccessLevel = "{0} property {1} get accessor is not {2}";
        public static readonly string PropertySetHasWrongAccessLevel = "{0} property {1} set accessor is not {2}";
        public static readonly string MethodHasWrongAccessLevel = "{0} method {1} is not {2}";
        public static readonly string ConstructorHasWrongAccessLevel = "{0} constructor {1} is not {2}";

        //{0} = chain
        public static readonly string ElementIsNull = "{0} cannot be null";

        //{0} = object, {1} = type
        public static readonly string ObjectIsWrongType = "{0} is not of type {1}";
    }
}
