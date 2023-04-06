using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReciTree.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }
    }
}