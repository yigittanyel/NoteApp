using NodeApp.DataAccess.Context;
using NodeApp.DataAccess.Repositories.Abstract;
using NodeApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.DataAccess.Repositories.Concrete
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NoteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
