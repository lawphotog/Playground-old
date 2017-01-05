using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maybe
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new FixtureManager();
            var fixtures = manager.GetFixture().DefaultIfEmpty(
                new Fixture()
                {
                    Id = "default foo",
                    Name = "default bar"
                });

            foreach (var fixture in fixtures)
            {
                fixture.Id = "hello";
                fixture.Name = "world";
            }
        }
    }

    public class FixtureManager
    {
        public Maybe<Fixture> GetFixture()
        {
            var fixture = GetFixtureFromExternalSource();
            if (fixture == null) return new Maybe<Fixture>();

            return new Maybe<Fixture>(fixture);
        }

        private Fixture GetFixtureFromExternalSource()
        {
            return new Fixture()
            {
                Id = "foo",
                Name = "bar"
            };
        }
    }

    public class Fixture
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
