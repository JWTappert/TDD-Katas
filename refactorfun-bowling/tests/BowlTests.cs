using System.Media;
using NUnit.Framework;

namespace refactorfun_bowling.tests
{
    [TestFixture]
    public class BowlTests
    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player();
        }

        [Test]
        public void SetsPlayerName()
        {
            
        }
    }
}