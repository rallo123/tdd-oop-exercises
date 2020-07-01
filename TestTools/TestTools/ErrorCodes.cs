using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Helpers
{
    public static class ErrorCodes
    {
        //{0} = class type, {1} = member name
        public static readonly string InstanceMemberIsMissing = "{0} does not contain instance member {1}";
        public static readonly string StaticMemberIsMissing = "{0} does not contain static member {1}";
        public static readonly string InstancePropertyIsMissingGet = "{0} instance property {1} is missing get method";
        public static readonly string StaticPropertyIsMissingGet = "{0} static property {1} is missing get method";
        public static readonly string InstancePropertyIsMissingSet = "{0} instance property {1} is missing set method";
        public static readonly string StaticPropertyIsMissingSet = "{0} static property {1} is missing set method";
        public static readonly string InstanceMethodIsMissing = "{0} does not contain instance method {1}";
        public static readonly string StaticMethodIsMissing = "{0} does not contain static method {1}";
        public static readonly string ConstructorIsMissing = "{0} does not contain constructor {1}";

        //{0} = class type, {1} = member name, {2} = actual member type, {3} = expected member type
        public static readonly string InstanceMemberIsWrongMemberType = "{0} instance member {1} is {2} instead of {3}";
        public static readonly string StaticMemberIsWrongMemberType = "{0} static member {1} is {2} instead of {3}";

        //{0} = class type, {1} = member name, {2} = actual member type 
        public static readonly string InstanceMemberIsNotFieldOrProperty = "{0} instance member {1} is {2} instead of field or property";
        public static readonly string StaticMemberIsIsNotFieldOrProperty = "{0} static member {1} is {2} instead field or property";

        //{0} = class type, {1} = member name, {2} = (return)type of member
        public static readonly string InstanceFieldIsWrongType = "{0} instance field {1} is not of type {2}";
        public static readonly string StaticFieldIsWrongType = "{0} static field {1} is not of type {2}";
        public static readonly string InstancePropertyIsWrongType = "{0} instance property {1} is not of type {2}";
        public static readonly string StaticPropertyIsWrongType = "{0} static property {1} is not of type {2}";
        public static readonly string InstanceMethodIsWrongReturnType = "{0} instance method {1} return type is not {2}";
        public static readonly string StaticMethodIsWrongReturnType = "{0} static method {1} return type {2}";

        //{0} class type, {1} member name / member declaration, {2} = access level 
        public static readonly string InstanceFieldHasWrongAccessLevel = "{0} instance field {1} is not {2}";
        public static readonly string StaticFieldHasWrongAccessLevel = "{0} static field {1} is not {2}";
        public static readonly string InstancePropertyGetHasWrongAccessLevel = "{0} instance property {1} get accessor is not {2}";
        public static readonly string StaticPropertyGetHasWrongAccessLevel = "{0} static property {1} get accessor is not {2}";
        public static readonly string InstancePropertySetHasWrongAccessLevel = "{0} instance property {1} set accessor is not {2}";
        public static readonly string StaticPropertySetHasWrongAccessLevel = "{0} static property {1} set accessor is not {2}";
        public static readonly string InstanceMethodHasWrongAccessLevel = "{0} instance method {1} is not {2}";
        public static readonly string StaticMethodHasWrongAccessLevel = "{0} static method {1} is not {2}";
        public static readonly string ConstructorHasWrongAccessLevel = "{0} constructor {1} is not {2}";

        //{0} = chain
        public static readonly string ElementIsNull = "{0} cannot be null";

        //{0} = object, {1} = type
        public static readonly string ObjectIsWrongType = "{0} is not of type {1}";
    }
}
