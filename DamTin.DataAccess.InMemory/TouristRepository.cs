using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using DamTin.Core.Models;

namespace DamTin.DataAccess.InMemory
{
    public class TouristRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Tourist> tourists;

        public TouristRepository()
        {
            tourists = cache["tourists"] as List<Tourist>;
            if (tourists == null) {
                tourists = new List<Tourist>();
            }
        }

        public void Commit()
        {
            cache["tourists"] = tourists;
        }

        public void Insert(Tourist t) {
            tourists.Add(t);
        }

        public void Update(Tourist tourist) {
            Tourist touristToUpdate = tourists.Find(t => t.Id == tourist.Id);

            if (touristToUpdate != null) {
                touristToUpdate = tourist;
            }
            else
            {
                throw new Exception("Tourist not found!");
            }
        }

        public Tourist Find(string Id) {
            Tourist tourist = tourists.Find(t => t.Id == Id);

            if (tourist != null)
            {
                return tourist;
            }
            else
            {
                throw new Exception("Tourist not found!");
            }
        }

        public IQueryable<Tourist> Collection()
        {
            return tourists.AsQueryable();
        }

        public void Delete(string Id) {
            Tourist touristToDelete = tourists.Find(t => t.Id == Id);

            if (touristToDelete != null)
            {
                tourists.Remove(touristToDelete);
            }
            else
            {
                throw new Exception("Tourist not found!");
            }
        }
    }
}
