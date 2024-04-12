using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Tests
{
    [TestClass]
    public class VoterTester 
    {
        [TestMethod]
        public void CreateVoter()
        {
            var steve = new VoterModel("123", "SteveC", "stevesocool456", "Steve", "Obama", true);
            Assert.AreEqual("123", steve.Id);
            Assert.AreEqual("Obama", steve.GetChoice());
            Assert.AreEqual(true, steve.Voted);
        }

        [TestMethod]
        public void ChangedChoiceTester()
        {
            var steve = new VoterModel("123", "SteveC", "stevesocool456", "Steve", "Obama", true);
            steve.ChangedChoice("Churchill");
            Assert.AreEqual("Churchill", steve.GetChoice());
        }

        [TestMethod]
        public void ClearVoteTester()
        {
            var steve = new VoterModel("123", "SteveC", "stevesocool456", "Steve", "Obama", true);
            steve.ClearedChoice();
            Assert.AreEqual(null, steve.GetChoice());
            Assert.AreEqual(false, steve.Voted);
        }
    }
}
