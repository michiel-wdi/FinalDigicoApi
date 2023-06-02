﻿using FinalDigicoApi.Objects;
using Newtonsoft.Json.Linq;

namespace FinalDigicoApi.API
{

    public static class BasicMigration
    {

        public static async Task<BasicSkill> getBasicSkill(string href, string language)
        {
            var client = new HttpClient();
            var clientresult = await client.GetAsync(href);
            var resultstring = await clientresult.Content.ReadAsStringAsync();

            JObject test = JObject.Parse(resultstring);

            var result = new BasicSkill()
            {
                discription = (string)test["description"][language]["literal"],
                name = (string)test["preferredLabel"][language],
                selfRef = (string)test["_links"]["self"]["href"],
                
            };
            return result;
        }

        internal static async Task<List<BasicSkill>> GetListSkillAsync(string href, string language, string whichSkills)
        {
            var client = new HttpClient();
            var clientResult = await client.GetAsync(href);
            var resultString = await clientResult.Content.ReadAsStringAsync();

            var occupation = JObject.Parse(resultString);


            var links = (JObject)occupation["_links"];
            if (!links.ContainsKey(whichSkills))
            {
                return null;
            }

            var tasks = new List<Task<BasicSkill>>();

            foreach (var item in occupation["_links"][whichSkills])
            {
                string itemHref = (string)item["href"];
                tasks.Add(Task.Run(async () => await getBasicSkill(itemHref, language)));
            }

            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }



        public static async Task<BasicOccupation>  GetBasicOccupationAsync(string href, string language)
        {
            var client = new HttpClient();
            var clientresult = await client.GetAsync(href);
            var resultstring = await clientresult.Content.ReadAsStringAsync();

            var occupation = JObject.Parse(resultstring);

            var basicOccupation = new BasicOccupation()
            {
                description = (string)occupation["description"][language]["literal"],
                name = (string)occupation["preferredLabel"][language],
                selfRef = (string)occupation["_links"]["self"]["href"]
            };

            var result = GetListSkillAsync(basicOccupation.selfRef, language, "hasOptionalSkill");
            basicOccupation.essentialSkills = await GetListSkillAsync(basicOccupation.selfRef, language, "hasEssentialSkill");
            basicOccupation.optionalSkills = result.Result;
            


            return basicOccupation;
        }

        public static async Task<JObject> getDataAPISearchAsync(string uri)
        {
            var client = new HttpClient();

            var resultString = await client.GetStringAsync(uri);
            var jObject = JObject.Parse(resultString);


            if ((int)jObject["total"] < (int)jObject["limit"])
            {
                return jObject;
            }


            var next = (string)jObject["_links"]["next"]["href"];
            for (int i = (int)jObject["offset"]; (i + 1) * (int)jObject["limit"] < (int)jObject["total"]; i++)
            {
                var existingResults = (JArray)jObject["_embedded"]["results"];

                var newresultString = await client.GetStringAsync(next);

                var newjObject = JObject.Parse(newresultString);
                var newResults = (JArray)newjObject["_embedded"]["results"];

                existingResults.Merge(newResults);


                if ((i + 2) * (int)jObject["limit"] < (int)jObject["total"])
                {
                    next = (string)newjObject["_links"]["next"]["href"];
                }
            }
            return jObject;
        }
    }
}