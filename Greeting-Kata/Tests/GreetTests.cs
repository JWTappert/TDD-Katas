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

            response.Should().Be("Hello, Billy");
        }
        
    }

    public class Greeter
    {
        public string Greet(string name)
        {
            return $"Hello, {name}";
        }
    }
}