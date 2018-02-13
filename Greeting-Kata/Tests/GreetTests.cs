using NUnit.Framework;
using FluentAssertions;

namespace Greeting_Kata.Tests
{
    [TestFixture()]
    public class GreetTests
    {
        private Greeter _greeter;

        [SetUp]
        public void Setup()
        {
            _greeter = new Greeter();
        }

        [Test]
        public void GreetMethodTest()
        {
           var response =  _greeter.Greet("Billy");

            response.Should().Be("Hello, Billy.");
        }

        [Test]
        public void GrretHandlesNull()
        {
            var response = _greeter.Greet("");
            response.Should().Be("Hello, my friend.");
        }
        
    }

    public class Greeter
    {
        public string Greet(string name)
        {
            return string.IsNullOrEmpty(name) ? $"Hello, my friend." : $"Hello, {name}.";
        }
    }
}