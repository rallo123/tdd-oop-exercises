using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class NonFieldOrPropertyException : InvalidStructureException
    {
        public NonFieldOrPropertyException(Type @class, string memberName, Type actualMemberType)
            : base("{0}.{1} is {2} instead of field or property", FormatType(@class), memberName, FormatMemberType(actualMemberType))
        {
            Type = @class;
            MemberName = memberName;
            ActualMemberType = actualMemberType;
        }

        public Type Type { get; }
        public string MemberName { get; }
        public Type ActualMemberType { get; }
    }
}
