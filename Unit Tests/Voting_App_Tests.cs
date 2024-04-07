using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Tests
{
    [TestClass]
    public class VoterTester
    {
        [TestMethod]
        public void CreateVoter()
        {
            var steve = new Voter("123", "stevesocool456", "Steve", "Obama", true);
            Assert.AreEqual("123", steve.id);
            Assert.AreEqual("Obama", steve.Choice);
            Assert.AreEqual(true, steve.Voted);
        }

        [TestMethod]
        public void ChangedChoiceTester()
        {
            var steve = new Voter("123", "stevesocool456", "Steve", "Obama", true);
            steve.ChangedChoice("Churchill");
            Assert.AreEqual("Churchill", steve.Choice);
        }

        [TestMethod]
        public void ClearVoteTester()
        {
            var steve = new Voter("123", "stevesocool456", "Steve", "Obama", true);
            steve.ClearedChoice();
            Assert.AreEqual(null, steve.Choice);
            Assert.AreEqual(false, steve.Voted);
        }
    }
}
