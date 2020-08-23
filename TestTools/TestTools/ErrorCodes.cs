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

        public static readonly string MemberIsNonInstanceMember = "{0} member {1} is static member instead of instance member";
        public static readonly string MemberIsNonStaticMember = "{0} member {1} is instance member instead of static member";

        //{0} = class type, {1} = member name, {2} = actual member type, {3} = expected member type
        public static readonly string MemberIsWrongMemberType = "{0} member {1} is {2} instead of {3}";

        //{0} = class type, {1} = member name, {2} = actual member type 
        public static readonly string MemberIsNotFieldOrProperty = "{0}.{1} is {2} instead of field or property";

        //{0} = class type, {1} = member name, {2} = (return)type of member
        public static readonly string FieldIsWrongType = "{0}.{1} is not of type {2}";
        public static readonly string PropertyIsWrongType = "{0}.{1} is not of type {2}";
        public static readonly string MethodIsWrongReturnType = "{0}.{1}'s return type is not {2}";

        //{0} class type, {1} member name / member declaration 
        public static readonly string FieldIsPrivate = "{0}.{1} is private";
        public static readonly string FieldIsNonPrivate = "{0}.{1} is not private";
        public static readonly string FieldIsProtected = "{0}.{1} is protected";
        public static readonly string FieldIsNonProtected = "{0}.{1} is not protected";
        public static readonly string FieldIsPublic = "{0}.{1} is public";
        public static readonly string FieldIsNonPublic = "{0}.{1} is not public";

        public static readonly string PropertyGetIsPrivate = "{0}.{1}'s get accessor is private";
        public static readonly string PropertyGetIsNonPrivate = "{0}.{1}'s get accessor is not private";
        public static readonly string PropertyGetIsProtected = "{0}.{1}'s get accessor is protected";
        public static readonly string PropertyGetIsNonProtected = "{0}.{1}'s get accessor is not protected";
        public static readonly string PropertyGetIsPublic = "{0}.{1}'s get accessor is public";
        public static readonly string PropertyGetIsNonPublic = "{0}.{1}'s get accessor is not public";
        public static readonly string PropertySetIsPrivate = "{0}.{1}'s set accessor is private";
        public static readonly string PropertySetIsNonPrivate = "{0}.{1}'s set accessor is not private";
        public static readonly string PropertySetIsProtected = "{0}.{1}'s set accessor is protected";
        public static readonly string PropertySetIsNonProtexted = "{0}.{1}'s set accessor is not protected";
        public static readonly string PropertySetIsPublic = "{0}.{1}'s set accessor is public";
        public static readonly string PropertySetIsNonPublic = "{0}.{1}'s set accessor is not public";

        public static readonly string MethodIsPrivate = "{0}.{1} is private";
        public static readonly string MethodIsNonPrivate = "{0}.{1} is not private";
        public static readonly string MethodIsProtected = "{0}.{1} is protected";
        public static readonly string MethodIsNonProtected = "{0}.{1} is not protected";
        public static readonly string MethodIsPublic = "{0}.{1} is public";
        public static readonly string MethodIsNonPublic = "{0}.{1} is not public";

        public static readonly string ConstructorIsPrivate = "{0} constructor {1} is private";
        public static readonly string ConstructorIsNonPrivate = "{0} constructor {1} is not private";
        public static readonly string ConstructorIsProtected = "{0} constructor {1} is protected";
        public static readonly string ConstructorIsNonProtected = "{0} constructor {1} is not protected";
        public static readonly string ConstructorIsPublic = "{0} constructor {1} is public";
        public static readonly string ConstructorIsNonPublic = "{0} constructor {1} is not public";

        //{0} class type, {1} member name / member declaration 
        public static readonly string PropertyGetHasWrongDeclaringType = "{0} does not declare its own version of {1} get accessor";
        public static readonly string PropertySetHasWrongDeclaringType = "{0} does not declare its own version of {1} set accessor";
        public static readonly string MethodHasWrongDeclaringType = "{0} does not declare its own version of {1}";

        public static readonly string PropertyGetIsAbstract = "{0}.{1} get accessor is abstract";
        public static readonly string PropertyGetIsNonAbstract = "{0}.{1} get accessor is not abstract";
        public static readonly string PropertySetIsAbstract = "{0}.{1} set accessor is abstract";
        public static readonly string PropertySetIsNonAbstract = "{0}.{1} set accessor is not abstract";
        public static readonly string MethodIsAbstract = "{0}.{1} is abstract";
        public static readonly string MethodIsNonAbstract = "{0}.{1} is not abstract";

        public static readonly string PropertyGetIsVirtual = "{0}.{1} get accessor is virtual";
        public static readonly string PropertyGetIsNonVirtual = "{0}.{1} get accessor is not virtual";
        public static readonly string PropertySetIsVirtual = "{0}.{1} set accessor is virtual";
        public static readonly string ProeprtySetIsNonVirtual = "{0}.{1} set accessor is not virtual";
        public static readonly string MethodIsVirtual = "{0}.{1} is virtual";
        public static readonly string MethodIsNonVirtual = "{0}.{1} is not virtual";

        //{0} = chain
        public static readonly string ElementIsNull = "{0} cannot be null";

        //{0} = object, {1} = type
        public static readonly string ObjectIsWrongType = "{0} is not of type {1}";
    }
}
