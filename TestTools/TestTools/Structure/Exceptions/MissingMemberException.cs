using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Exceptions
{
    public class MissingMemberException : InvalidStructureException
    {
        public MissingMemberException(Type @class, string memberName)
            : base("{0} does not contain member {1}", FormatHelper.FormatType(@class), memberName)
        {
            Type = @class;
            MemberName = memberName;
        }

        public Type Type { get; }
        public string MemberName { get; }
    }
}
