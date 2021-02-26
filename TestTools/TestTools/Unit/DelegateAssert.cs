using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Unit
{
    public static class DelegateAssert
    {
        public static void IsInvoked<TDelegate>(Action<TDelegate> subscribe) where TDelegate : Delegate
        {
            throw new NotImplementedException();
        }

        public static void IsInvoked<TDelegate>(Action<TDelegate> subscribe, TDelegate assertionCallback) where TDelegate : Delegate
        {
            throw new NotImplementedException();
        }

        public static void IsNotInvoked<TDelegate>(Action<TDelegate> subscribe) where TDelegate : Delegate
        {
            throw new NotImplementedException();
        }

        public static void Verify()
        {
            throw new NotImplementedException();
        }
    }
}
