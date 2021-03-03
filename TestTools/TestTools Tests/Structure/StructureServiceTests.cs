using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Structure;

namespace TestTools_Tests.Structure
{
    [AlternateNames("AlternateTestType")]
    public class TestType
    {
    }

    [TestClass]
    public class StructureServiceTests
    {
        [TestMethod("TranslateType uses TypeTranslator if no custom translator is defined on type")]
        public void TranslateTypeUsesTypeTranslatorIfNoCustomTranslatorIsDefinedOnType()
        {
            ITypeTranslator translator = Substitute.For<ITypeTranslator>();
            StructureService service = new StructureService("")
            {
                TypeTranslator = translator
            };

            service.TranslateType(typeof(object));

            translator.Received().Translate(typeof(object));
        }

        [TestMethod("TranslateType does not uses TypeTranslator if custom translator is defined on type")]
        public void TranslateTypeDoesNotUseTypeTranslatorIfCustomTranslatorIsDefinedOnType()
        {
            ITypeTranslator translator = Substitute.For<ITypeTranslator>();
            StructureService service = new StructureService("")
            {
                TypeTranslator = translator
            };

            service.TranslateType(typeof(TestType));

            translator.DidNotReceive().Translate(typeof(TestType));
        }

        [TestMethod("VerifyType(Type, ITypeVerifier[]) uses all type verifiers")]
        public void VerifyTypeOverloadUsesAllTypeVerifiers()
        {
            ITypeVerifier verifier1 = Substitute.For<ITypeVerifier>();
            ITypeVerifier verifier2 = Substitute.For<ITypeVerifier>();
            StructureService service = new StructureService("");

            service.VerifyType(typeof(object), new[] { verifier1, verifier2 });

            verifier1.Received().Verify(typeof(object), typeof(object));
            verifier2.Received().Verify(typeof(object), typeof(object));
        }

        [TestMethod("VerifyType(Type, ITypeVerifier[], TypeVerificationAspect[]) uses subset of all type verifiers")]
        public void VerifyTypeOverloadUsesSubsetOfAllTypeVerifiers()
        {
            ITypeVerifier verifier1 = Substitute.For<ITypeVerifier>();
            verifier1.Aspects.Returns(new[] { TypeVerificationAspect.AccessLevel });
            ITypeVerifier verifier2 = Substitute.For<ITypeVerifier>();
            verifier1.Aspects.Returns(new[] { TypeVerificationAspect.IsSubclassOf });
            StructureService service = new StructureService("");

            service.VerifyType(typeof(object), new[] { verifier1, verifier2 }, TypeVerificationAspect.AccessLevel);

            verifier1.Received().Verify(typeof(object), typeof(object));
            verifier2.DidNotReceive().Verify(typeof(object), typeof(object));
        }

        [TestMethod("VerifyType(Type) uses DefaultTypeVerifiers")]
        public void VerifyTypeOverloadUsesDefaultTypeVerifiers()
        {
            ITypeVerifier verifier = Substitute.For<ITypeVerifier>();
            StructureService service = new StructureService("");
            service.DefaultTypeVerifiers = new[] { verifier };

            service.VerifyType(typeof(object));

            verifier.Received().Verify(typeof(object), typeof(object));
        }

        [TestMethod("VerifyType(Type, TypeVerificationAspects) uses subset of DefaultTypeVerifiers")]
        public void VerifyTypeOverloadUsesSubsetOfDefaultTypeVerifiers()
        {
            ITypeVerifier verifier1 = Substitute.For<ITypeVerifier>();
            verifier1.Aspects.Returns(new[] { TypeVerificationAspect.AccessLevel });
            ITypeVerifier verifier2 = Substitute.For<ITypeVerifier>();
            verifier1.Aspects.Returns(new[] { TypeVerificationAspect.IsSubclassOf });
            StructureService service = new StructureService("");
            service.DefaultTypeVerifiers = new[] { verifier1, verifier2 };

            service.VerifyType(typeof(object), TypeVerificationAspect.AccessLevel);


            verifier1.Received().Verify(typeof(object), typeof(object));
            verifier2.DidNotReceive().Verify(typeof(object), typeof(object));
        }
    }
}
