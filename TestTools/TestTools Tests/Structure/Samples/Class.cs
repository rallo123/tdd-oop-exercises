using System;
using System.Collections.Generic;
using System.Text;

namespace Namespace
{
    public class Class
    {   
        private int PrivateIntField;
        public int PublicIntField = 0;
        
        private int PrivateIntProperty { get; set; }
        private int PrivateReadonlyIntProperty { get; }
        private int PrivateWriteonlyIntProperty { set { } }
        public int PublicIntProperty { get; set; }
        
        private void PrivateMethodWithoutParameters() { }
        private int PrivateMethodWithParameters(int i) { return i; }
        public void PublicMethodWithoutParameters() { }
        public int PublicMethodWithParameters(int i) { return i; }

        private Class() { }
        public Class(int i) { }
    }
}
