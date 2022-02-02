using Microsoft.AspNetCore.Mvc;
using Seeds_API.Models;

namespace Controller_Seed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller_Seeds : ControllerBase
    {

        [HttpPost("Process_Data")]
        public IActionResult Process_Data(List<Seed> seedlist)
        {
            var num_good =
            from s in seedlist
            where ((s.SeedLevel) < 100 && (s.SeedStatus) == "Good")
            select s;
            int num_vezes_good = num_good.Count();

            var num_ready =
            from s in seedlist
            where ((s.SeedLevel) == 100)
            select s;
            int num_vezes_ready = num_ready.Count();

            var num_bad =
            from s in seedlist
            where ((s.SeedStatus) == "Bad")
            select s;
            int num_vezes_bad = num_bad.Count();

            string resultados = ($"Dados Enviados com sucesso \n Sementes Boas: {num_vezes_good}. " +
                                 $"\n Sementes Ruins: {num_vezes_bad}. \n Sementes Prontas: {num_vezes_ready}.");

            return Ok(resultados);


        }

    }
}
