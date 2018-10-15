using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;

namespace ITI.FantasyRPG.Tests
{
    //[TestFixture]
    public class PublicModelChecker
    {
        //[Test]
        //[Explicit]
        public void write_current_public_API_to_console_with_double_quotes()
        {
            //Console.WriteLine( GetPublicAPI( typeof( School ).Assembly ).ToString().Replace( "\"", "\"\"" ) );
        }

        //[Test]
        // Revenir sur la vérfication de l'API publique à la fin
        public void public_API_is_not_modified()
        {
            var model = XElement.Parse(@"<Assembly Name=""ITI.FantasyRPG"">
              <Types>
                <Type Name=""ITI.FantasyRPG.A_Type"">
                  <Member Type=""Method"" Name=""A_Method"" />
                  <Member Type=""Property"" Name=""A_Property"" />
                </Type>
                <Type Name=""ITI.FantasyRPG.Another_Type"">
                  <Member Type=""Method"" Name=""A_Method"" />
                  <Member Type=""Property"" Name=""A_Property"" />
                </Type>
              </Types>
            </Assembly>
            ");
            //var current = GetPublicAPI( typeof( School ).Assembly );
            //if( !XElement.DeepEquals( model, current ) )
            //{
            //    string m = model.ToString( SaveOptions.DisableFormatting );
            //    string c = current.ToString( SaveOptions.DisableFormatting );
            //    Assert.That( c, Is.EqualTo( m ) );
            //}
        }

        XElement GetPublicAPI( Assembly a )
        {
            return new XElement( "Assembly",
                                  new XAttribute( "Name", a.GetName().Name ),
                                  new XElement( "Types",
                                                AllNestedTypes( a.GetExportedTypes() )
                                                 .OrderBy( t => t.FullName )
                                                 .Select( t => new XElement( "Type",
                                                                                new XAttribute( "Name", t.FullName ),
                                                                                t.GetMembers()
                                                                                 .OrderBy( m => m.Name )
                                                                                 .Select( m => new XElement( "Member",
                                                                                                              new XAttribute( "Type", m.MemberType ),
                                                                                                              new XAttribute( "Name", m.Name ) ) ) ) ) ) );
        }

        IEnumerable<Type> AllNestedTypes( IEnumerable<Type> types )
        {
            foreach( Type t in types )
            {
                yield return t;
                foreach( Type nestedType in AllNestedTypes( t.GetNestedTypes() ) )
                {
                    yield return nestedType;
                }
            }
        }
    }
}
