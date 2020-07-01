using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Helpers
{
    public static class TypeHelper
    {
        public static bool IsNullable(Type type)
        {
            if (type.IsValueType)
                return Nullable.GetUnderlyingType(type) != null;

            return true;
        }

        public static bool IsType(Type type, Type subtype)
        {
            return subtype == type || subtype.IsSubclassOf(type);
        }

        public static bool IsOfType(Type type, object value)
        {
            if (value == null && !IsNullable(type))
                return false;

            if (value != null && !(value.GetType() == type || value.GetType().IsSubclassOf(type)))
                return false;

            return true;
        }


    }
}
