using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class NonInstanceMemberException : InvalidStructureException
    {
        public NonInstanceMemberException(Type @class, string memberName)
            : base("{0} member {1} is static member instead of instance member", FormatType(@class), memberName)
        {
            Type = @class;
            MemberName = memberName;
        }

        public Type Type { get; }
        public string MemberName { get; }
    }
}
