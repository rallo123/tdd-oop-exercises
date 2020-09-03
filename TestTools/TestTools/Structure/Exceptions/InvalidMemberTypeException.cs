using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class InvalidMemberTypeException : InvalidStructureException
    {
        public InvalidMemberTypeException(Type @class, string memberName, MemberTypes expectedMemberType, MemberTypes actualMemberType)
            : base("{0} member {1} is {2} instead of {3}", FormatType(@class), memberName, FormatMemberType(expectedMemberType), FormatMemberType(actualMemberType))
        {
            Type = @class;
            MemberName = memberName;
            ExpectedMemberType = expectedMemberType;
            ActualMemberType = actualMemberType;
        }

        public Type Type { get; }
        public string MemberName { get; }
        public MemberTypes ExpectedMemberType { get; }
        public MemberTypes ActualMemberType { get; }
    }
}
