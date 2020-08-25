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
        public ClassElement(ClassOptions options = null) : base(typeof(TRoot), options)
        {
        }

        public FieldElement<TRoot, T> Field<T>(FieldOptions options) => Extendable.Field<TRoot, T>(this, options);
        public FieldStaticElement<TRoot, T> StaticField<T>(FieldOptions options) => Extendable.StaticField<TRoot, T>(this, options);

        public PropertyElement<TRoot, T> Property<T>(PropertyOptions options) => Extendable.Property<TRoot, T>(this, options);
        public PropertyStaticElement<TRoot, T> StaticProperty<T>(PropertyOptions options) => Extendable.StaticProperty<TRoot, T>(this, options);

        public new ActionMethodElement<TRoot> ActionMethod(MethodOptions options) => Extendable.ActionMethod<TRoot>(this, options);
        public ActionMethodElement<TRoot, T1> ActionMethod<T1>(MethodOptions options) => Extendable.ActionMethod<TRoot, T1>(this, options);
        public ActionMethodElement<TRoot, T1, T2> ActionMethod<T1, T2>(MethodOptions options) => Extendable.ActionMethod<TRoot, T1, T2>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3> ActionMethod<T1, T2, T3>(MethodOptions options) => Extendable.ActionMethod<TRoot, T1, T2, T3>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3, T4> ActionMethod<T1, T2, T3, T4>(MethodOptions options) => Extendable.ActionMethod<TRoot, T1, T2, T3, T4>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3, T4, T5> ActionMethod<T1, T2, T3, T4, T5>(MethodOptions options) => Extendable.ActionMethod<TRoot, T1, T2, T3, T4, T5>(this, options);

        public FuncMethodElement<TRoot, TResult> FuncMethod<TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, TResult> FuncMethod<T1, TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, T1, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, TResult> FuncMethod<T1, T2, TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, T1, T2, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, TResult> FuncMethod<T1, T2, T3, TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, T1, T2, T3, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, T4, TResult> FuncMethod<T1, T2, T3, T4, TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult> FuncMethod<T1, T2, T3, T4, T5, TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, options);

        public new ActionMethodStaticElement<TRoot> StaticActionMethod(MethodOptions options) => Extendable.StaticActionMethod<TRoot>(this, options);
        public ActionMethodStaticElement<TRoot, T1> StaticActionMethod<T1>(MethodOptions options) => Extendable.StaticActionMethod<TRoot, T1>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2> StaticActionMethod<T1, T2>(MethodOptions options) => Extendable.StaticActionMethod<TRoot, T1, T2>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3> StaticActionMethod<T1, T2, T3>(MethodOptions options) => Extendable.StaticActionMethod<TRoot, T1, T2, T3>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4> StaticActionMethod<T1, T2, T3, T4>(MethodOptions options) => Extendable.StaticActionMethod<TRoot, T1, T2, T3, T4>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> StaticActionMethod<T1, T2, T3, T4, T5>(MethodOptions options) => Extendable.StaticActionMethod<TRoot, T1, T2, T3, T4, T5>(this, options);

        public FuncMethodStaticElement<TRoot, TResult> StaticFuncMethod<TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, TResult> StaticFuncMethod<T1, TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, T1, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, TResult> StaticFuncMethod<T1, T2, TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, T1, T2, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> StaticFuncMethod<T1, T2, T3, TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, T1, T2, T3, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> StaticFuncMethod<T1, T2, T3, T4, TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> StaticFuncMethod<T1, T2, T3, T4, T5, TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, options);
        
        public new ConstructorElement<TRoot> Constructor(ConstructorOptions options)
        {
            options.OverwriteTypes(new Type[0]);
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(typeof(TRoot), options);
            return new ConstructorElement<TRoot>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1> Constructor<T1>(ConstructorOptions options)
        {
            options.OverwriteTypes( new Type[] { typeof(T1) });
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement<TRoot, T1>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2> Constructor<T1, T2>(ConstructorOptions options)
        {
            options.OverwriteTypes(new Type[] { typeof(T1), typeof(T2) });
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement<TRoot, T1, T2>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2, T3> Constructor<T1, T2, T3>(ConstructorOptions options)
        {
            options.OverwriteTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3) });
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement<TRoot, T1, T2, T3>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2, T3, T4> Constructor<T1, T2, T3, T4>(ConstructorOptions options)
        {
            options.OverwriteTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement<TRoot, T1, T2, T3, T4>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2, T3, T4, T5> Constructor<T1, T2, T3, T4, T5>(ConstructorOptions options)
        {
            options.OverwriteTypes(new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement<TRoot, T1, T2, T3, T4, T5>(constructorInfo);
        }
    }
}
