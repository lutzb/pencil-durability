namespace PencilDurability.test
{
    using NUnit.Framework;

    [TestFixture]
    public class PencilTest
    {
        [Test]
        public void Write_WhenGivenPaper_AppendsTextToTheEndOfThePaper()
        {
            var subject = new Pencil(50);
            var paper = "She sells sea shells";

            subject.Write(ref paper, " down by the sea shore.");

            Assert.AreEqual("She sells sea shells down by the sea shore.", paper);
        }

        [Test]
        public void Write_OnlyWritesLettersWhilePointIsNotDull()
        {
            var subject = new Pencil(5);
            var paper = "";

            subject.Write(ref paper, "12345678");

            Assert.AreEqual("12345   ", paper);
        }

        [Test]
        public void Write_DoesNotLosePointDurabilityForSpaceCharacters()
        {
            var subject = new Pencil(5);
            var paper = "";

            subject.Write(ref paper, "123 45678");

            Assert.AreEqual("123 45   ", paper);
        }
    }
}