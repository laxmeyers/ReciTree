using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReciTree.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}