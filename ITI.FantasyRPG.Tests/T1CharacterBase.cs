using System;
using NUnit.Framework;
using FluentAssertions;

namespace ITI.FantasyRPG.Tests
{
    [TestFixture]
    public class T1CharacterBase
    {
        [Test]
        public void t1_creating_a_player_character_with_a_name()
        {
            {
                Player p = new Player("Shéogorath");
                p.Name.Should().Be("Shéogorath");
            }
            {
                var randomName = Guid.NewGuid().ToString();
                Player p = new Player(randomName);
                p.Name.Should().Be(randomName);
            }

            typeof(Player).GetProperty("Name").GetSetMethod().Should().BeNull("Player.Name must NOT be writeable");
        }

        [Test]
        public void t2_creating_a_player_character_with_basic_characteristics()
        {
            Player p = new Player("Shéogorath");

            p.Combat.Should().Be(10);
            p.Defense.Should().Be(10);
            p.Speed.Should().Be(10);

            typeof(Player).GetProperty("Combat").GetSetMethod().Should().BeNull("Player.Combat must be writeable ONLY from the inside");
            typeof(Player).GetProperty("Defense").GetSetMethod().Should().BeNull("Player.Defense must be writeable ONLY from the inside");
            typeof(Player).GetProperty("Speed").GetSetMethod().Should().BeNull("Player.Speed must be writeable ONLY from the inside");
        }

        [Test]
        public void t3_a_new_player_character_is_level_1()
        {
            Player p = new Player("Shéogorath");

            p.Level.Number.Should().Be(1);
            p.Level.Experience.Should().Be(0);
        }

        [Test]
        public void t4_a_player_character_can_level_up_by_gaining_experience()
        {
            Player p = new Player("Shéogorath");

            p.AddExperience(1000);

            p.Level.Number.Should().Be(2);
            p.Combat.Should().Be(15);
            p.Defense.Should().Be(15);
        }

        // Just to remember the TestCase syntax ;)
        //[TestCase(null, null)]
        //[TestCase("", "Valid")]
        //public void empty_test(string arg1, string arg2)
        //{
        //    arg1.Should().Match(s => s == null || s.GetType() == typeof(string));
        //    arg2.Should().Match(s => s == null || s.GetType() == typeof(string));
        //}
    }
}
