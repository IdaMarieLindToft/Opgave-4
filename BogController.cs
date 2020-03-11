using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Opgave_1_Bog;

//Du skal lave en REST Service. Servicen skal kunne simpel CRUD for model klassen Bog (opgave 1), dvs de 5 default metoder,
//der kommer med skabelonen.
//REST servicen skal have en statisk list af bøger i controlleren.Vær opmærksom på Bog Ikke har en Id, Men du skal benytte Isbn13,
//som en unik identifikation af en bog, dvs.du skal modificere nogle af CRUD-metoderne til at benytte string isbn13 i stedet for int id.

namespace RESTService.Controllers
{
    [Route("api/bog/")]
    [ApiController]
    public class BogController : ControllerBase

    {
        private static readonly List<Bog> bogs = new List<Bog>()
        {
            new Bog("Hajens vej til Danmark", "Ulrikke Holt", 365, "HH12345678912"),
            new Bog("Herrens Veje", "Åge Nielsen", 678, "ILJ4567891234")
           
        };

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Bog>> Get()
        {
            return bogs;
        }

        // GET api/values/5
        [HttpGet("{isbn13}")]
        public Bog Get(string isbn13)
        {
            return bogs.Find(i => i.Isbn13 == isbn13);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            bogs.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Bog value)
        {
            Bog bog = Get(isbn13);
            if (bog != null)
            {
                bog.Titel = value.Titel;
                bog.Forfatter = value.Forfatter;
               bog.Sidetal = value.Sidetal;
                bog.Isbn13 = value.Isbn13;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Bog bog = Get(isbn13);
            bogs.Remove(bog);
        }

        
    }
}
