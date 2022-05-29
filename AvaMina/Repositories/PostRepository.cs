using AvaMina.Data;
using AvaMina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaMina.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        //private readonly PrepChurchServiceDbContext db;
        public PostRepository(ApplicationDbContext _db):base(_db)
        {
        }
    }
}
