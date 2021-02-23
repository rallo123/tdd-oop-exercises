using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class StructureVerifier
    {
        public virtual void VerifyAccessLevel(Type type, AccessLevels[] accessLevels)
        {
            if (accessLevels.Contains(ReflectionHelper.GetAccessLevel(type)))
                return;

            string message = string.Format(
                "{1} is not {2}",
                FormatHelper.FormatType(type),
                FormatHelper.FormatOrList(accessLevels.Select(FormatHelper.FormatAccessLevel)));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyAccessLevel(ConstructorInfo constructorInfo, AccessLevels[] accessLevels)
        {
            if (accessLevels.Contains(ReflectionHelper.GetAccessLevel(constructorInfo)))
                return;

            string message = string.Format(
                "{1} is not {2}",
                FormatHelper.FormatConstructor(constructorInfo),
                FormatHelper.FormatOrList(accessLevels.Select(FormatHelper.FormatAccessLevel)));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyAccessLevel(EventInfo eventInfo, AccessLevels[] accessLevels, bool AddMethod = false, bool RemoveMethod = false)
        {
            string message;

            if (AddMethod && !accessLevels.Contains(ReflectionHelper.GetAccessLevel(eventInfo.AddMethod)))
            {
                message = string.Format(
                    "{0}.{1} add accessor is not {2}",
                    FormatHelper.FormatType(eventInfo.AddMethod.DeclaringType),
                    eventInfo.Name,
                    FormatHelper.FormatOrList(accessLevels.Select(FormatHelper.FormatAccessLevel)));

                throw new InvalidStructureException(message);
            }
            else if (RemoveMethod && !accessLevels.Contains(ReflectionHelper.GetAccessLevel(eventInfo.RemoveMethod)))
            {
                message = string.Format(
                    "{0}.{1} set accessor is not {2}",
                    FormatHelper.FormatType(eventInfo.RemoveMethod.DeclaringType),
                    eventInfo.Name,
                    FormatHelper.FormatOrList(accessLevels.Select(FormatHelper.FormatAccessLevel)));

                throw new InvalidStructureException(message);
            }
        }

        public virtual void VerifyAccessLevel(FieldInfo fieldInfo, AccessLevels[] accessLevels)
        {
            if (accessLevels.Contains(ReflectionHelper.GetAccessLevel(fieldInfo)))
                return;

            string message = string.Format(
                "{0}.{1} is not {2}",
                FormatHelper.FormatType(fieldInfo.DeclaringType),
                fieldInfo.Name,
                FormatHelper.FormatOrList(accessLevels.Select(FormatHelper.FormatAccessLevel)));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyAccessLevel(PropertyInfo propertyInfo, AccessLevels[] accessLevels, bool GetMethod = false, bool SetMethod = false)
        {
            string message;

            if (GetMethod && !accessLevels.Contains(ReflectionHelper.GetAccessLevel(propertyInfo.GetMethod)))
            {
                message = string.Format(
                    "{0}.{1} get accessor is not {2}",
                    FormatHelper.FormatType(propertyInfo.GetMethod.DeclaringType),
                    propertyInfo.Name,
                    FormatHelper.FormatOrList(accessLevels.Select(FormatHelper.FormatAccessLevel)));

                throw new InvalidStructureException(message);
            }
            else if (SetMethod && !accessLevels.Contains(ReflectionHelper.GetAccessLevel(propertyInfo.SetMethod)))
            {
                message = string.Format(
                    "{0}.{1} set accessor is not {2}",
                    FormatHelper.FormatType(propertyInfo.GetMethod.DeclaringType),
                    propertyInfo.Name,
                    FormatHelper.FormatOrList(accessLevels.Select(FormatHelper.FormatAccessLevel)));

                throw new InvalidStructureException(message);
            }
        }

        public virtual void VerifyAccessLevel(MethodInfo methodInfo, AccessLevels[] accessLevels)
        {
            if (accessLevels.Contains(ReflectionHelper.GetAccessLevel(methodInfo)))
                return;

            string message = string.Format(
                "{0}.{1} is not {2}",
                FormatHelper.FormatType(methodInfo.DeclaringType),
                FormatHelper.FormatMethod(methodInfo),
                FormatHelper.FormatOrList(accessLevels.Select(FormatHelper.FormatAccessLevel)));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyBaseType(Type type, Type baseType)
        {
            if (type.BaseType == type)
                return;

            string message = string.Format(
                "{0} does not inherit from {1}",
                FormatHelper.FormatType(type),
                FormatHelper.FormatType(baseType));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyDeclaringType(FieldInfo fieldInfo, Type declaringType)
        {
            if (fieldInfo.DeclaringType == declaringType)
                return;

            string message = string.Format(
                "{0} does not declare the field {1}",
                FormatHelper.FormatType(declaringType),
                fieldInfo.Name);

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyDeclaringType(MethodInfo methodInfo, Type declaringType)
        {
            if (methodInfo.DeclaringType == declaringType)
                return;

            string message = string.Format(
                "{0} does not declare the method {1}",
                FormatHelper.FormatType(declaringType),
                FormatHelper.FormatMethod(methodInfo));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyDeclaringType(PropertyInfo propertyInfo, Type declaringType, bool GetMethod = false, bool SetMethod = false)
        {
            string message;

            if (GetMethod && propertyInfo.GetMethod.DeclaringType != declaringType)
            {
                message = string.Format(
                    "{0} does not declare property {1} get accessor",
                    FormatHelper.FormatType(declaringType),
                    propertyInfo.Name);

                throw new InvalidStructureException(message);
            }
            else if (SetMethod && propertyInfo.SetMethod.DeclaringType != declaringType)
            {
                message = string.Format(
                    "{0} does not declare property {1} set accessor",
                    FormatHelper.FormatType(declaringType),
                    propertyInfo.Name);

                throw new InvalidStructureException(message);
            }
        }


        public virtual void VerifyEventHandlerType(EventInfo eventInfo, Type type)
        {
            if (eventInfo.EventHandlerType == type)
                return;

            string message = string.Format(
                "{0}.{1} is not of type {2}",
                FormatHelper.FormatType(eventInfo.DeclaringType),
                eventInfo.Name,
                FormatHelper.FormatType(type));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyFieldType(FieldInfo fieldInfo, Type type)
        {
            if (fieldInfo.FieldType == type)
                return;

            string message = string.Format(
                "{0}.{1} is not of type {2}",
                FormatHelper.FormatType(fieldInfo.DeclaringType),
                fieldInfo.Name,
                FormatHelper.FormatType(type));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyIsAbstract(Type type, bool isAbstract)
        {
            if (type.IsAbstract == isAbstract)
                return;

            string template = isAbstract ? "{0} must be abstract" : "{0} cannot be abstract";
            string message = string.Format(
                    template,
                    FormatHelper.FormatType(type)); 

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyIsAbstract(MethodInfo methodInfo, bool isAbstract)
        {
            if (methodInfo.IsAbstract == isAbstract)
                return;

            string template = isAbstract ? "{0}.{1} must be abstract" : "{0}.{1} cannot be abstract";
            string message = string.Format(
                    template,
                    FormatHelper.FormatType(methodInfo.DeclaringType),
                    FormatHelper.FormatMethod(methodInfo));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyIsAbstract(PropertyInfo propertyInfo, bool isAbstract, bool GetMethod = false, bool SetMethod = false)
        {
            string template, message;

            if (GetMethod && propertyInfo.GetMethod.IsAbstract != isAbstract)
            {
                template = isAbstract ? "{0}.{1} get accessor must be abstract" : "{0}.{1} get accessor cannot be abstract";
                message = string.Format(
                        template,
                        FormatHelper.FormatType(propertyInfo.DeclaringType),
                        propertyInfo.Name);

                throw new InvalidStructureException(message);
            }
            else if (SetMethod && propertyInfo.SetMethod.IsAbstract != isAbstract)
            {
                template = isAbstract ? "{0}.{1} set accessor must be abstract" : "{0}.{1} set accessor cannot be abstract";
                message = string.Format(
                        template,
                        FormatHelper.FormatType(propertyInfo.DeclaringType),
                        propertyInfo.Name);

                throw new InvalidStructureException(message);
            }
        }

        public virtual void VerifyIsHideBySig(MethodInfo methodInfo, bool isHideBySig)
        {
            if (methodInfo.IsVirtual == isHideBySig)
                return;

            string template = isHideBySig ? "{0}.{1} cannot be new" : "{0}.{1} must be new";
            string message = string.Format(
                template,
                FormatHelper.FormatType(methodInfo.DeclaringType),
                FormatHelper.FormatMethod(methodInfo));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyIsHideBySig(PropertyInfo propertyInfo, bool isHideBySig, bool GetMethod = false, bool SetMethod = false)
        {
            string template, message;

            if (GetMethod && propertyInfo.GetMethod.IsAbstract != isHideBySig)
            {
                template = isHideBySig ? "{0}.{1} get accessor cannot be new" : "{0}.{1} get accessor must be new";
                message = string.Format(
                        template,
                        FormatHelper.FormatType(propertyInfo.DeclaringType),
                        propertyInfo.Name);

                throw new InvalidStructureException(message);
            }
            else if (SetMethod && propertyInfo.SetMethod.IsAbstract != isHideBySig)
            {
                template = isHideBySig ? "{0}.{1} set accessor cannot be new" : "{0}.{1} set accessor must be new";
                message = string.Format(
                        template,
                        FormatHelper.FormatType(propertyInfo.DeclaringType),
                        propertyInfo.Name);

                throw new InvalidStructureException(message);
            }
        }

        public virtual void VerifyIsInitOnly(FieldInfo fieldInfo, bool isInitOnly)
        {
            if (fieldInfo.IsInitOnly == isInitOnly)
                return;

            string template = isInitOnly ? "{0}.{1} cannot be readonly" : "{0}.{1} must be readonly";
            string message = string.Format(
                template,
                FormatHelper.FormatType(fieldInfo.DeclaringType),
                fieldInfo.Name);

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyIsStatic(Type type, bool isStatic)
        {
            bool typeIsStatic = type.IsAbstract && type.IsSealed;
            
            if (typeIsStatic == isStatic)
                return;

            string template = isStatic ? "{0} must be static" : "{0} cannot be static";
            string message = String.Format(
                template, 
                FormatHelper.FormatType(type));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyIsStatic(FieldInfo fieldInfo, bool isStatic)
        {
            if (fieldInfo.IsStatic == isStatic)
                return;

            string template = isStatic ? "{0}.{1} is an instance member instead a static member" : "{0}.{1} is a static member instead an instance member";
            string message = string.Format(
                template,
                FormatHelper.FormatType(fieldInfo.DeclaringType),
                fieldInfo.Name);

            throw new InvalidStructureException(message); 
        }

        public virtual void VerifyIsStatic(MethodInfo methodInfo, bool isStatic)
        {
            if (methodInfo.IsStatic == isStatic)
                return;

            string template = isStatic ? "{0}.{1} is an instance member instead a static member" : "{0}.{1} is a static member instead an instance member";
            string message = string.Format(
                    template,
                    FormatHelper.FormatType(methodInfo.DeclaringType),
                    FormatHelper.FormatMethod(methodInfo));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyIsStatic(PropertyInfo propertyInfo, bool isStatic)
        {
            if ((propertyInfo.GetMethod ?? propertyInfo.SetMethod).IsStatic == isStatic)
                return;

            string template = isStatic ? "{0}.{1} is an instance member instead a static member" : "{0}.{1} is a static member instead an instance member";
            string message = string.Format(
                template,
                FormatHelper.FormatType(propertyInfo.DeclaringType),
                propertyInfo.Name);

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyIsSubclassOf(Type type, Type baseType)
        {
            if (type.IsAssignableFrom(baseType))
                return;

            string message = string.Format(
                    "{0} is not a subclass of {1}",
                    FormatHelper.FormatType(type),
                    FormatHelper.FormatType(type));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyIsVirtual(MethodInfo methodInfo, bool isVirtual)
        {
            if (methodInfo.IsVirtual == isVirtual)
                return;

            string template = isVirtual ? "{0}.{1} must be virtual" : "{0}.{1} cannot be virtual";
            string message = string.Format(
                template,
                FormatHelper.FormatType(methodInfo.DeclaringType),
                FormatHelper.FormatMethod(methodInfo));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyIsVirtual(PropertyInfo propertyInfo, bool isVirtual, bool GetMethod = false, bool SetMethod = false)
        {
            string template, message;

            if (GetMethod && propertyInfo.GetMethod.IsAbstract != isVirtual)
            {
                template = isVirtual ? "{0}.{1} get accessor must be virtual" : "{0}.{1} get accessor cannot be virtual";
                message = string.Format(
                    template,
                    FormatHelper.FormatType(propertyInfo.DeclaringType),
                    propertyInfo.Name);

                throw new InvalidStructureException(message);
            }
            else if (SetMethod && propertyInfo.SetMethod.IsAbstract != isVirtual)
            {
                template = isVirtual ? "{0}.{1} set accessor must be virtual" : "{0}.{1} set accessor cannot be virtual";
                message = string.Format(
                    template,
                    FormatHelper.FormatType(propertyInfo.DeclaringType),
                    propertyInfo.Name);

                throw new InvalidStructureException(message);
            }
        }

        public virtual void VerifyMemberType(MemberInfo memberInfo, MemberTypes[] memberTypes)
        {
            if (memberTypes.Contains(memberInfo.MemberType))
                return;

            string message = string.Format(
                "{0}.{1} is {2} instead of {3}",
                FormatHelper.FormatType(memberInfo.DeclaringType),
                memberInfo.Name,
                FormatHelper.FormatMemberType(memberInfo.MemberType),
                FormatHelper.FormatOrList(memberTypes.Select(FormatHelper.FormatMemberType)));
            
            throw new InvalidStructureException(message);
        }

        public virtual void VerifyPropertyType(PropertyInfo propertyInfo, Type type)
        {
            if (propertyInfo.PropertyType == type)
                return;

            string message = string.Format(
                "{0}.{1} is not of type {2}",
                FormatHelper.FormatType(propertyInfo.DeclaringType),
                propertyInfo.Name,
                FormatHelper.FormatType(type));

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyCanRead(PropertyInfo propertyInfo, bool canRead)
        {
            if (propertyInfo.CanRead == canRead)
                return;

            string template = canRead ? "{0}.{1} must have a get accessor" : "{0}.{1} cannot have a get accessor";
            string message = string.Format(
                template,
                FormatHelper.FormatType(propertyInfo.DeclaringType),
                propertyInfo.Name);

            throw new InvalidStructureException(message);
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
            if (propertyInfo.CanRead == canRead)
                return;

            string template = canRead ? "{0}.{1} must have a get accessor" : "{0}.{1} cannot have a get accessor";
            string message = string.Format(
                template,
                FormatHelper.FormatType(propertyInfo.DeclaringType),
                propertyInfo.Name);

            throw new InvalidStructureException(message);
        }

        public virtual void VerifyTypeHasMember(Type targetType, string[] memberNames)
        {
            string message; 
            MemberInfo[] memberInfos = targetType.GetAllMembers();

            if (memberInfos.Any(info => memberNames.Contains(info.Name)))
                return;

            if (memberNames.Length == 1)
            {
                message = string.Format(
                    "{0} does not contain member {1}",
                    FormatHelper.FormatType(targetType),
                    memberNames[0]);
            }
            else
            {
                message = string.Format(
                    "{0} does not contain member {1} (or alternatively {2})",
                    FormatHelper.FormatType(targetType),
                    memberNames[0],
                    FormatHelper.FormatAndList(memberNames.Skip(1))
                );
            }
            throw new InvalidStructureException(message);
        }
    }
}
