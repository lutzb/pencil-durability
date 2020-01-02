namespace PencilDurability.test
{
    using NUnit.Framework;

    [TestFixture]
    public class PencilTest
    {
        [Test]
        public void HelloWorld_ReturnsHelloWorld()
        {
            var subject = new Pencil();

            var actual = subject.HelloWorld();

            Assert.AreEqual("Hello World", actual);
        }
    }
}