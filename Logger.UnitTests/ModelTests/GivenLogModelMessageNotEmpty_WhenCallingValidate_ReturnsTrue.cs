
using NUnit.Framework;
using SpecsFor;
using Should;
namespace Logger.UnitTests
{
    public class GivenLogModelMessageNotEmpty_WhenCallingValidate_ReturnTrue : SpecsFor<Model.Log>
    {
        private bool _result;

        protected override void Given()
        {
            SUT.Message = "Message is not empty";
        }

        protected override void When()
        {
            _result = SUT.IsValidMessage();
        }

        [Test]
        public void then_the_message_is_valid()
        {
            _result.ShouldBeTrue();
        } 
    }
}