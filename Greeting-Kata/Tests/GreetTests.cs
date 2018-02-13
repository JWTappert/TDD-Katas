using System;
using NUnit.Framework;
using FluentAssertions;
using Moq;

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
           var response =  Greeter.Greet("Billy");

            response.Should().Be("Hello, Billy.");
        }

        [Test]
        public void GrretHandlesNull()
        {
            var response = Greeter.Greet("");
            response.Should().Be("Hello, my friend.");
        }

        [Test]
        public void WhyAreYouYelling()
        {
            var response = Greeter.Greet("JOHNNY");
            response.Should().Be("HELLO, JOHNNY!");
        }
        
    }

    public class Greeter
    {
        public static string Greet(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "Hello, my friend.";
            return CheckIfYelling(name) ? $"HELLO, {name}!" : $"Hello, {name}.";
        }

        private static bool CheckIfYelling(string name)
        {
            foreach (var i in name)
            {
                if (char.IsLetter(i) && !char.IsUpper(i))
                    return false;
            }
            return true;
        }
    }
}