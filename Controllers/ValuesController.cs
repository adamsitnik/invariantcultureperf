using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InvariantCulture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("InvariantCultureIgnoreCase/{count}")]
        public ActionResult InvariantCultureIgnoreCase(int count)
        {
            var data = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
            for (var i = 0; i < count; i++)
            {
                data.TryAdd("Id_", i);
            }

            return Ok();
        }

        [HttpGet]
        [Route("OrdinalIgnoreCase/{count}")]
        public ActionResult OrdinalIgnoreCase(int count)
        {
            var data = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (var i = 0; i < count; i++)
            {
                data.TryAdd("Id_", i);
            }

            return Ok();
        }

        [HttpGet]
        [Route("CompareTo")]
        public ActionResult CompareTo()
        {
            CreateFortunes().Sort((a, b) => a.CompareTo(b));

            return Ok();
        }

        [HttpGet]
        [Route("CompareOrdinal")]
        public ActionResult CompareOrdinal()
        {
            CreateFortunes().Sort((a, b) => String.CompareOrdinal(a, b));

            return Ok();
        }

        [HttpGet]
        [Route("CompareOrdinalIgnoreCase")]
        public ActionResult CompareOrdinalIgnoreCase()
        {
            CreateFortunes().Sort((a, b) => StringComparer.OrdinalIgnoreCase.Compare(a, b));

            return Ok();
        }

        private static List<string> CreateFortunes() => new List<string>
        {
            "fortune: No such file or directory",
            "A computer scientist is someone who fixes things that aren''t broken.",
            "After enough decimal places, nobody gives a damn.",
            "A bad random number generator: 1, 1, 1, 1, 1, 4.33e+67, 1, 1, 1",
            "A computer program does what you tell it to do, not what you want it to do.",
            "Emacs is a nice operating system, but I prefer UNIX. — Tom Christaensen",
            "Any program that runs right is obsolete.",
            "A list is only as strong as its weakest link. — Donald Knuth",
            "Feature: A bug with seniority.",
            "Computers make very fast, very accurate mistakes.",
            "<script>alert(\"This should not be displayed in a browser alert box.\");</script>",
            "フレームワークのベンチマーク"
        };
    }
}
