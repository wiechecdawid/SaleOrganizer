using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SaleOrganizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : Controller
    {
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "cloth1", "cloth2" };
        }
    }
}
