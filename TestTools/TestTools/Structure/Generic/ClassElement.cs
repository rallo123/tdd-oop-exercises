using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using TestTools.Helpers;


namespace TestTools.Structure.Generic
{
    public class ClassElement<TRoot> : ClassElement, IExtendable<TRoot>
    {
        public ClassElement(ClassRequirements options = null) : base(typeof(TRoot), options)
        {
        }

        public FieldElement<TRoot, T> Field<T>(FieldRequirements options) => Extendable.Field<TRoot, T>(this, options);
        public FieldElement<TRoot, T> StaticField<T>(FieldRequirements options) 
        {
            options.FieldType = typeof(T);
            FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(typeof(TRoot), options, isStatic: true);
            return new FieldElement<TRoot, T>(fieldInfo) { PreviousElement = this };
        }

        public PropertyElement<TRoot, T> Property<T>(PropertyRequirements options) => Extendable.Property<TRoot, T>(this, options);
        public PropertyElement<TRoot, T> StaticProperty<T>(PropertyRequirements options) 
        {
            options.PropertyType = typeof(T);
            PropertyInfo propertyInfo = ReflectionHelper.GetPropertyInfo(typeof(TRoot), options, isStatic: true);
            return new PropertyElement<TRoot, T>(propertyInfo) { PreviousElement = this };
        }

        public new ActionMethodElement<TRoot> ActionMethod(MethodRequirements options) => Extendable.ActionMethod<TRoot>(this, options);
        public ActionMethodElement<TRoot, T1> ActionMethod<T1>(MethodRequirements options) => Extendable.ActionMethod<TRoot, T1>(this, options);
        public ActionMethodElement<TRoot, T1, T2> ActionMethod<T1, T2>(MethodRequirements options) => Extendable.ActionMethod<TRoot, T1, T2>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3> ActionMethod<T1, T2, T3>(MethodRequirements options) => Extendable.ActionMethod<TRoot, T1, T2, T3>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3, T4> ActionMethod<T1, T2, T3, T4>(MethodRequirements options) => Extendable.ActionMethod<TRoot, T1, T2, T3, T4>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3, T4, T5> ActionMethod<T1, T2, T3, T4, T5>(MethodRequirements options) => Extendable.ActionMethod<TRoot, T1, T2, T3, T4, T5>(this, options);

        public FuncMethodElement<TRoot, TResult> FuncMethod<TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, TResult> FuncMethod<T1, TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, T1, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, TResult> FuncMethod<T1, T2, TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, T1, T2, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, TResult> FuncMethod<T1, T2, T3, TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, T1, T2, T3, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, T4, TResult> FuncMethod<T1, T2, T3, T4, TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult> FuncMethod<T1, T2, T3, T4, T5, TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, options);

        public new ActionMethodElement<TRoot> StaticActionMethod(MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[0]);
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new ActionMethodElement<TRoot>(methodInfo) { PreviousElement = this };
        }
        public ActionMethodElement<TRoot, T1> StaticActionMethod<T1>(MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[] { typeof(T1) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new ActionMethodElement<TRoot, T1>(methodInfo) { PreviousElement = this };
        }
        public ActionMethodElement<TRoot, T1, T2> StaticActionMethod<T1, T2>(MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[] { typeof(T1), typeof(T2) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new ActionMethodElement<TRoot, T1, T2>(methodInfo) { PreviousElement = this };
        }
        public ActionMethodElement<TRoot, T1, T2, T3> StaticActionMethod<T1, T2, T3>(MethodRequirements options) 
        {
            options.OverwriteTypes(typeof(void), new Type[] { typeof(T1), typeof(T2), typeof(T3) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new ActionMethodElement<TRoot, T1, T2, T3>(methodInfo) { PreviousElement = this };
        }
        public ActionMethodElement<TRoot, T1, T2, T3, T4> StaticActionMethod<T1, T2, T3, T4>(MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new ActionMethodElement<TRoot, T1, T2, T3, T4>(methodInfo) { PreviousElement = this };
        }
        public ActionMethodElement<TRoot, T1, T2, T3, T4, T5> StaticActionMethod<T1, T2, T3, T4, T5>(MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new ActionMethodElement<TRoot, T1, T2, T3, T4, T5>(methodInfo) { PreviousElement = this };
        }

        public FuncMethodElement<TRoot, TResult> StaticFuncMethod<TResult>(MethodRequirements options) 
        {
            options.OverwriteTypes(typeof(TResult), new Type[0]);
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new FuncMethodElement<TRoot, TResult>(methodInfo) { PreviousElement = this };
        }
        public FuncMethodElement<TRoot, T1, TResult> StaticFuncMethod<T1, TResult>(MethodRequirements options)
        {
            options.OverwriteTypes(typeof(TResult), new Type[] { typeof(T1) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new FuncMethodElement<TRoot, T1, TResult>(methodInfo) { PreviousElement = this };
        }
        public FuncMethodElement<TRoot, T1, T2, TResult> StaticFuncMethod<T1, T2, TResult>(MethodRequirements options)
        {
            options.OverwriteTypes(typeof(TResult), new Type[] { typeof(T1), typeof(T2) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new FuncMethodElement<TRoot, T1, T2, TResult>(methodInfo) { PreviousElement = this };
        }
        public FuncMethodElement<TRoot, T1, T2, T3, TResult> StaticFuncMethod<T1, T2, T3, TResult>(MethodRequirements options)
        {
            options.OverwriteTypes(typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new FuncMethodElement<TRoot, T1, T2, T3, TResult>(methodInfo) { PreviousElement = this };
        }
        public FuncMethodElement<TRoot, T1, T2, T3, T4, TResult> StaticFuncMethod<T1, T2, T3, T4, TResult>(MethodRequirements options)
        {
            options.OverwriteTypes(typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new FuncMethodElement<TRoot, T1, T2, T3, T4, TResult>(methodInfo) { PreviousElement = this };

        }
        public FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult> StaticFuncMethod<T1, T2, T3, T4, T5, TResult>(MethodRequirements options) 
        {
            options.OverwriteTypes(typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: true);
            return new FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult>(methodInfo) { PreviousElement = this };
        }

        public new ConstructorElement<TRoot> Constructor(ConstructorRequirements options)
        {
            options.OverwriteTypes(new Type[0]);
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(typeof(TRoot), options);
            return new ConstructorElement<TRoot>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1> Constructor<T1>(ConstructorRequirements options)
        {
            options.OverwriteTypes( new Type[] { typeof(T1) });
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement<TRoot, T1>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2> Constructor<T1, T2>(ConstructorRequirements options)
        {
            options.OverwriteTypes(new Type[] { typeof(T1), typeof(T2) });
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement<TRoot, T1, T2>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2, T3> Constructor<T1, T2, T3>(ConstructorRequirements options)
        {
            options.OverwriteTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3) });
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement<TRoot, T1, T2, T3>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2, T3, T4> Constructor<T1, T2, T3, T4>(ConstructorRequirements options)
        {
            options.OverwriteTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement<TRoot, T1, T2, T3, T4>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2, T3, T4, T5> Constructor<T1, T2, T3, T4, T5>(ConstructorRequirements options)
        {
            options.OverwriteTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement<TRoot, T1, T2, T3, T4, T5>(constructorInfo);
        }
    }
}
