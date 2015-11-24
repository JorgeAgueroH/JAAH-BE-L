
using NUnit.Framework;
using SpecsFor;
using Should;
using System;
namespace Logger.UnitTests.ModelTests
{
    public class GivenLogModelMessageIsEmpty_WhenCallingValidate_ReturnsFalse : SpecsFor<Model.Log>
    {

        private bool _result;

        protected override void Given()
        {
            SUT.Message = String.Empty;
        }

        protected override void When()
        {
            _result = SUT.IsValidMessage();
        }

        [Test]
        public void then_the_message_is_invalid()
        {
            _result.ShouldBeFalse();
        }

    }
}
