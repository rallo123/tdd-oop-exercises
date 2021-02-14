using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TestTools.Structure
{
    public class StructureVerifier
    {
        public virtual void VerifyAccessLevel(Type type, AccessLevels[] accessLevels)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyAccessLevel(ConstructorInfo constructorInfo, AccessLevels[] accessLevels)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyAccessLevel(FieldInfo fieldInfo, AccessLevels[] accessLevels)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyAccessLevel(PropertyInfo propertyInfo, AccessLevels[] accessLevels, bool GetMethod = false, bool SetMethod = false)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyAccessLevel(MethodInfo methodInfo, AccessLevels[] accessLevels)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyBaseType(Type type, Type baseType)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyDeclaringType(FieldInfo fieldInfo, Type declaringType)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyDeclaringType(MethodInfo methodInfo, Type declaringType)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyDeclaringType(PropertyInfo propertyInfo, Type declaringType, bool GetMethod = false, bool SetMethod = false)
        {
            throw new NotImplementedException();
        }
        
        public virtual void VerifyFieldType(FieldInfo fieldInfo, Type type)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsAbstract(Type type, bool isAbstract)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsAbstract(MethodInfo methodInfo, bool isAbstract)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsAbstract(PropertyInfo propertyInfo, bool isAbstract, bool GetMethod = false, bool SetMethod = false)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsHideBySig(MethodInfo methodInfo, bool isHideBySig)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsHideBySig(PropertyInfo propertyInfo, bool isHideBySig, bool GetMethod = false, bool SetMethod = false)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsInitOnly(FieldInfo fieldInfo, bool isInitOnly)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsStatic(Type type, bool isStatic)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsStatic(FieldInfo fieldInfo, bool isStatic)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsStatic(MethodInfo methodInfo, bool isStatic)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsStatic(PropertyInfo propertyInfo, bool isStatic)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsSubclassOf(Type type, Type baseType)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsVirtual(MethodInfo methodInfo, bool isVirtual)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsVirtual(PropertyInfo propertyInfo, bool isVirtual, bool GetMethod = false, bool SetMethod = false)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyMemberType(MemberInfo memberInfo, MemberTypes[] memberTypes)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyPropertyType(PropertyInfo propertyInfo, Type type)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyCanRead(PropertyInfo propertyInfo, bool canRead)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsReadonly(PropertyInfo propertyInfo, MemberTypes[] memberTypes)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyIsWriteonly(PropertyInfo propertyInfo, MemberTypes[] memberTypes)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyCanWrite(PropertyInfo propertyInfo, bool canRead)
        {
            throw new NotImplementedException();
        }

        public virtual void VerifyTypeHasMember(Type targetType, string[] memberNames)
        {
            throw new NotImplementedException();
        }
    }
}
