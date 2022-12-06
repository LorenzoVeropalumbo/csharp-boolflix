using Boolflix.Models.DataHome;
using Boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Boolflix.Data;
using Boolflix.Models.Repository;

namespace Boolflix.Controllers
{   
    [Authorize]
    [Route("[controller]/[action]/{id?}", Order = 0)]
    public class AdminController : Controller
    {

        public BoolflixDbContext db;
        IdbContentRepository boolflixRepository;

        public AdminController(IdbContentRepository _boolflixRepository, BoolflixDbContext _db) : base()
        {
            db = _db;
            boolflixRepository = _boolflixRepository;
        }
        


    }
}
