using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class MemberVerificationAspect
    {
        public MemberVerificationAspect()
        {
        }

        public static MemberVerificationAspect MemberType { get; } = new MemberVerificationAspect();

        public static MemberVerificationAspect ConstructorAccessLevel { get; } = new MemberVerificationAspect();

        public static MemberVerificationAspect EventHandlerType { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect EventAddAccessLevel { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect EventRemoveAccessLevel { get; } = new MemberVerificationAspect();

        public static MemberVerificationAspect FieldType { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect FieldAccessLevel { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect FieldWriteability { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect FieldIsStatic { get; } = new MemberVerificationAspect();

        public static MemberVerificationAspect MethodReturnType { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect MethodIsVirtual { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect MethodIsAbstract { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect MethodIsStatic { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect MethodDeclaringType { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect MethodAccessLevel { get; } = new MemberVerificationAspect();

        public static MemberVerificationAspect PropertyType { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect PropertyIsStatic { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect PropertyGetIsAbstract { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect PropertyGetIsVirtual { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect PropertyGetDeclaringType { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect PropertyGetAccessLevel { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect PropertySetIsAbstract { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect PropertySetIsVirtual { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect PropertySetDeclaringType { get; } = new MemberVerificationAspect();
        public static MemberVerificationAspect PropertySetAccessLevel { get; } = new MemberVerificationAspect();
    }
}
