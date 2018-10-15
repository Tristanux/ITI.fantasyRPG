using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.FantasyRPG.Tests
{
    [TestFixture]
    public class T1CharacterBase
    {
        // Just to remember the TestCase syntax ;)
        [TestCase( null, null )]
        [TestCase( "", "Valid" )]
        public void empty_test( string arg1, string arg2 )
        {
            Assert.That(arg1 == null || arg1 is String);
            Assert.That(arg2 == null || arg2 is String);
        }
    }
}
