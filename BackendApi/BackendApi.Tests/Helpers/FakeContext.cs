using BackendApi.Models;
using BackendApi.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Tests.Helpers
{
    class FakeContext : IDbContext
    {
        private static IEnumerable<Artist> _artists;

        public FakeContext()
        {
            _artists =   PopulateList();
        }

        private static IEnumerable<Artist> PopulateList()
        {
            var artists = new List<Artist>();
            var sourceFile = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"helpers"), "*.txt").FirstOrDefault();
            if (sourceFile != null)
            {
                var data = File.ReadAllText(sourceFile, Encoding.Unicode);
                foreach (var line in data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var fields = line.Split('|');
                    artists.Add(new Artist
                    {
                        Name = fields[0].Trim(),
                        Id = Guid.Parse(fields[1].Trim()),
                        Country = fields[2].Trim(),
                        Aliases = fields[3].Trim(),
                    });
                }
            }
            return artists.AsEnumerable<Artist>();
        }

          public   int SaveChanges()
        {
            return default(int);
        }
        public new  IDbSet<T> Set<T>() where T : class
        {
            var items = _artists.ToList() as List<T>;
            var set= new FakeSet<T>(items);
            return set;
        }
    }
}
