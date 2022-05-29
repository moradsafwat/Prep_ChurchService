using AvaMina.Data;
using AvaMina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Repositories
{
    public class ServantRepository: Repository<Servant>, IServantRepository
    {
        public ServantRepository(ApplicationDbContext _db):base (_db)
        {

        }
    }
}
