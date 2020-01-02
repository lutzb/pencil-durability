namespace PencilDurability.test
{
    using NUnit.Framework;

    [TestFixture]
    public class PencilTest
    {
        [Test]
        public void Write_WhenGivenPaper_AppendsTextToTheEndOfThePaper()
        {
            var subject = new Pencil();
            var paper = "She sells sea shells";

            subject.Write(ref paper, " down by the sea shore.");

            Assert.AreEqual("She sells sea shells down by the sea shore.", paper);
        }
    }
}