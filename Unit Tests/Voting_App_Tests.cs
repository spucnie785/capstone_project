using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Models;

namespace Unit_Tests
{
    [TestClass]
    public class VoterTester
    {
	    public LoginModel TestLogin = new LoginModel("tester", "testerpassword");

        [TestMethod]
        public void CreateVoter()
        {
            var steve = new VoterModel(TestLogin, "Steve", "Obama", true);
            Assert.AreEqual("Obama", steve.GetChoice());
            Assert.AreEqual(true, steve.Voted);
        }

        [TestMethod]
        public void ChangedChoiceTester()
        {
            var steve = new VoterModel(TestLogin, "Steve", "Obama", true);
            steve.ChangedChoice("Churchill");
            Assert.AreEqual("Churchill", steve.GetChoice());
        }

        [TestMethod]
        public void ClearVoteTester()
        {
            var steve = new VoterModel(TestLogin, "Steve", "Obama", true);
            steve.ClearedChoice();
            Assert.AreEqual(null, steve.GetChoice());
            Assert.AreEqual(false, steve.Voted);
        }

        [TestMethod]
        public void AddToDatabaseTester()
        {

        }
    }
}
