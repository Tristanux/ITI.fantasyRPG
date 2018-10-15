using System;
using NUnit.Framework;
using FluentAssertions;

namespace ITI.FantasyRPG.Tests
{
    [TestFixture]
    public class T1CharacterBase
    {
        // Just to remember the TestCase syntax ;)
        [TestCase(null, null)]
        [TestCase("", "Valid")]
        public void empty_test(string arg1, string arg2)
        {
            arg1.Should().Match(s => s == null || s.GetType() == typeof(string));
            arg2.Should().Match(s => s == null || s.GetType() == typeof(string));
        }
    }
}
