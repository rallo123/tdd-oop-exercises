using System;
using System.Collections.Generic;
using System.Text;
using static TestTools.Helpers.FormatHelper;

namespace TestTools.Structure.Exceptions
{
    public class NonStaticMemberException : InvalidStructureException
    {
        public NonStaticMemberException(Type @class, string memberName)
            : base("{0} member {1} is instance member instead of static member", FormatType(@class), memberName)
        {
            Type = @class;
            MemberName = memberName;
        }

        public Type Type { get; }
        public string MemberName { get; }
    }
}
