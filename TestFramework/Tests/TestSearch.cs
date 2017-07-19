using Pages;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class TestSearch
    {
        [SetUp]
        public void SetDriver()
        {
            Driver.SetDriver(AllDrivers.FireFox);
        }

        [Test]
        public void GoToPlasticAndReconstructiveSurgeryJournaltest()
        {
            JournalPlasticReconstructiveSurgeryPage page = LogicSteps.GoToJournalPlasticReconstructiveSurgery(
                LogicSteps.NavigateToPage(@"http://journals.lww.com")
                .LoginAs("Vladtest", "1234qwer"));
            LogicSteps.Close(page);
        }
    }
}
