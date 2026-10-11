using Application;

namespace SpecControle.UnitTests
{
    public class FanApplicationStickerTextTests
    {
        [TestCase("Marine")]
        [TestCase("Transport")]
        [TestCase("Emergency operations")]
        [TestCase("Process air")]
        public void TestCreateFanApplicationTextContainsRequiredSentenceAndApplication(string application)
        {
            var result = DataHelper.CreateFanApplicationText(application);

            Assert.That(result, Is.EqualTo($"This fan is suitable exclusively for the following applications: {application}"));
        }

        [Test]
        public void TestCreateFanApplicationTextTrimsApplication()
        {
            var result = DataHelper.CreateFanApplicationText("  Marine ");

            Assert.That(result, Is.EqualTo("This fan is suitable exclusively for the following applications: Marine"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void TestCreateFanApplicationTextIsEmptyWithoutApplication(string application)
        {
            var result = DataHelper.CreateFanApplicationText(application);

            Assert.That(result, Is.Empty);
        }
    }
}
