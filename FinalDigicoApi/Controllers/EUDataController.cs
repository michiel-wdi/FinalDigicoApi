using FinalDigicoApi.API;
using FinalDigicoApi.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FinalDigicoApi.Controllers
{
    public class EUDataController : ControllerBase
    {
        public EUDataController([FromServices] DataService service)
        {
            this._service = service;
        }
        private readonly DataService _service;
        private bool myComparer(string textToSearch, string textToSearchFor)
        {
            var result = true;
            var search = textToSearchFor.Split(' ');
            foreach (var item in search)
            {
                result &= textToSearch.Contains(item);
            }
            return result;
        }

        [HttpGet("/ResetDB")]
        public ActionResult ResetDB()
        {
            _service.ResetDB();
            return Ok();
        }

        [HttpGet("/truesearch")]
        public async Task<IActionResult> trueSearch(string language, string type, string text, bool vieuwObsolete)
        {

            if (type.ToLower() == "occupation" || type.ToLower() == "skill")
            {
                var result = await BasicMigration.getDataAPISearchAsync(@"https://ec.europa.eu/esco/api/search?language=" + language + "&type=" + type.ToLower() + "&text=" + text + "&viewObsolete=" + vieuwObsolete);

                var defaultObject = result["_embedded"]["results"][0];
                var objectOI = (string)result["_embedded"]["results"]
                    .FirstOrDefault(
                        c => 
                        myComparer((string)c["searchHit"], text)
                        , defaultObject)["_links"]["self"]["href"];
                if (objectOI != null)
                {
                    if (type == "occupation")
                    {
                        
                        var resultOccupation = await BasicMigration.GetBasicOccupationAsync(objectOI, language);
                        _service.CreateBAsicOccupation(resultOccupation);
                        return Ok(JsonConvert.SerializeObject(resultOccupation, Formatting.Indented));
                    }
                    var resultSkill = await BasicMigration.getBasicSkill(objectOI, language);
                    _service.CreateBasicSkill(resultSkill);
                    return Ok(JsonConvert.SerializeObject(resultSkill, Formatting.Indented));

                }
            }
            return BadRequest();
        }

        [HttpGet("/showsearchresults")]
        public async Task<IActionResult> showsearchresults(string language, string type, string text, bool vieuwObsolete)
        {
            var result = await BasicMigration.getDataAPISearchAsync(@"https://ec.europa.eu/esco/api/search?language=" + language + "&type=" + type.ToLower() + "&text=" + text + "&viewObsolete=" + vieuwObsolete);
            return Ok(JsonConvert.SerializeObject(result));
        }


        [HttpGet("/getBasicSkill")]
        public async Task<IActionResult> getBasicSkill(string href, string language)
        {
            var result = await BasicMigration.getBasicSkill(href, language);

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet("/basicSkillfromOccupation")]
        public async Task<IActionResult> getbasicSkillfromOccupation(string href, string language)
        {

            return Ok(await BasicMigration.GetListSkillAsync(href, language, "hasEssentialSkill"));
        }

        [HttpGet("/basicOccupation")]
        public async Task<IActionResult> getbasicOccupation(string href, string language)
        {
            return Ok(await BasicMigration.GetBasicOccupationAsync(href, language));
        }

    }
}
