using System;
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
            var response = Greeter.Greet(new[] {"Billy"});

            response.Should().Be("Hello, Billy.");
        }

        [Test]
        public void GrretHandlesNull()
        {
            var response = Greeter.Greet(new[] {""});
            response.Should().Be("Hello, my friend.");
        }

        [Test]
        public void WhyAreYouYelling()
        {
            var response = Greeter.Greet(new[] {"JOHNNY"});

            response.Should().Be("HELLO, JOHNNY!");
        }

        [Test]
        public void AcceptsTwoNames()
        {
            var names = new[] {"Billy", "Bobby"};
            var response = Greeter.Greet(names);
            response.Should().Be("Hello, Billy and Bobby.");
        }
    }

    public class Greeter
    {
        public static string Greet(params string[] names)
        {
            if (names.Length < 2)
            {
                if (string.IsNullOrEmpty(names[0]))
                    return "Hello, my friend.";
                return CheckIfYelling(names[0]) ? $"HELLO, {names[0]}!" : $"Hello, {names[0]}.";
            }
            else if (names.Length >= 2)
            {
                var greeting = "Hello, ";

                for (int i = 0; i < names.Length; i++)
                {
                    if (i == names.Length - 1)
                        greeting = greeting + $"and {names[i]}";

                    greeting = greeting + names[i] + " ";
                }

                greeting = greeting + ".";
            }

            return "failed";
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