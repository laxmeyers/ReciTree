using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReciTree.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly Auth0Provider _auth;

        public RecipesController(RecipesService recipesService, Auth0Provider auth)
        {
            _recipesService = recipesService;
            _auth = auth;
        }
    }
}