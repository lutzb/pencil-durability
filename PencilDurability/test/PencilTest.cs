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
            var testToWrite = " down by the sea shore.";
            var expected = "She sells sea shells down by the sea shore.";

            subject.Write(ref paper, testToWrite);

            Assert.AreEqual(expected, paper);
        }

        [Test]
        public void Write_OnlyWritesLettersWhilePointIsNotDull()
        {
            var subject = new Pencil(5);
            var paper = "";
            var textToWrite = "12345678";
            var expected = "12345   ";

            subject.Write(ref paper, textToWrite);

            Assert.AreEqual(expected, paper);
        }

        [Test]
        public void Write_DoesNotLosePointDurabilityForSpaceCharacters()
        {
            var subject = new Pencil(5);
            var paper = "";
            var textToWrite = "123 45678";
            var expected = "123 45   ";

            subject.Write(ref paper, textToWrite);

            Assert.AreEqual(expected, paper);
        }

        [Test]
        public void Write_DoesNotLosePointDurabilityForNewlineCharacters()
        {
            var subject = new Pencil(5);
            var paper = "";
            var textToWrite = @"123
            45678";
            var expected = @"123
            45   ";

            subject.Write(ref paper, textToWrite);

            Assert.AreEqual(expected, paper);
        }

        [Test]
        public void Write_ReducesPencilPointDurabilityBy2ForCapitalLetters()
        {
            var subject = new Pencil(10);
            var paper = "";
            var textToWrite = "Hello World";
            var expected = "Hello Wor  ";

            subject.Write(ref paper, textToWrite);

            Assert.AreEqual(expected, paper);
        }

        [Test]
        public void Sharpen_RefreshesPointDurabilityToTheOriginalPointDurability()
        {
            var subject = new Pencil(5);
            var paper = "";
            var textToWrite = "12345";

            subject.Write(ref paper, textToWrite);
            subject.Sharpen();

            textToWrite = "67890";

            subject.Write(ref paper, textToWrite);

            var expected = "1234567890";

            Assert.AreEqual(expected, paper);
        }
    }
}