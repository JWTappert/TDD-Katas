using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using Moq;

namespace Greeting_Kata.Tests
{
    [TestFixture()]
    public class GreetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GreetMethodTest()
        {
            var response = Greeter.Greet(new List<string> {"Billy"});

            response.Should().Be("Hello, Billy.");
        }

        [Test]
        public void GrretHandlesNull()
        {
            var response = Greeter.Greet(new List<string> {""});
            response.Should().Be("Hello, my friend.");
        }

        [Test]
        public void WhyAreYouYelling()
        {
            var response = Greeter.Greet(new List<string> {"JOHNNY"});

            response.Should().Be("HELLO, JOHNNY!");
        }

        [Test]
        public void AcceptsTwoNames()
        {
            var names = new List<string> {"Billy", "Bobby"};

            var response = Greeter.Greet(names);
            response.Should().Be("Hello, Billy and Bobby.");
        }
    }

    public class Greeter
    {
        public static string Greet(IList<string> names)
        {
            var greeting = "";
            var start = "Hello, ";
            var isYell = false;

            foreach (var name in names)
            {
                if (string.IsNullOrEmpty(name))
                    return start + "my friend.";

                isYell = CheckIfYelling(name);
                start = isYell ? $"HELLO, " : $"Hello, ";

                var index = names.IndexOf(name);

                if (index == 0)
                {
                    greeting = start + (names.Count > 2 ? $"{name}, " : $"{name}") + (isYell && names.Count < 2 ? "!" : ".");
                }
                else if (index == names.Count - 1)
                {
                    greeting = greeting + $"and {name}!";
                }
                else
                {
                    greeting = greeting + $"{name}, ";
                }
            }

            return greeting;
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