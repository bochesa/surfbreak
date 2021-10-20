using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Surfbreak.Models;
using Surfbreak.Models.Surfspot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Surfbreak
{
    public class SurfspotController : Controller
    {
        private readonly SurfspotRepository repo;
        private readonly WeatherConditionProxy proxy;

        public SurfspotController(SurfspotRepository repo, WeatherConditionProxy proxy)
        {
            this.repo = repo;
            this.proxy = proxy;
        }
        [Route("/surfspot/{id?}")]
        public IActionResult Surfspot(int id=1)
        {
            var surfspot = repo.GetSurfspotById(id);
            //insert weather info from API proxy - check URI
            //string weatherConditionproxy = await proxy.GetWeatherInfo("11","55", DateTime.Now);
            //WeatherConditions weatherConditions = JsonConvert.DeserializeObject<WeatherConditions>(weatherConditionproxy);

            var surfspotView = new SurfspotViewModel { Surfspot = surfspot};

            return View(surfspotView);
        }
        //[HttpGet]
        //public async Task<WeatherConditions> ShowString()
        //{
        //    string weatherConditionproxy = await proxy.GetWeatherInfo("11", "55", DateTime.Now);
        //    WeatherConditions weatherConditions = JsonConvert.DeserializeObject<WeatherConditions>(weatherConditionproxy);

        //    return weatherConditions;
        //}
        [Authorize]
        [HttpGet]
        [Route("Surfspot/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        [Route("surfspot/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var surfspot = repo.GetSurfspotById(id);
            if(surfspot != null)
                return View(surfspot);

            return View(Response.StatusCode = 404);
        }
        [Authorize]
        [HttpPost]
        [Route("surfspot/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, byte[] rowVersion)
        {
            var surfspot = repo.GetSurfspotById(id);
            repo.UpdateRowVersion(surfspot, rowVersion);
            if(await TryUpdateModelAsync(surfspot, "", s => s.Name))
            {
                try
                {
                    repo.UpdateSurfspot(surfspot);
                    await repo.SaveChangesAsync();
                    return RedirectToAction("Surfspot", new { id = surfspot.Id });
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.Single();
                    var clientValues = (Surfspot)entry.Entity;
                    var databaseEntry = entry.GetDatabaseValues();
                    if(databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Ikke muligt at gemme. Surfspot er slettet af en anden bruger.");
                    }
                    else
                    {
                        var databaseValues = (Surfspot)databaseEntry.ToObject();

                        if (databaseValues.Name != clientValues.Name)
                        { 
                            ModelState.AddModelError("Name", $"Nuværende navn: {databaseValues.Name}"); 
                        }
                        ModelState.AddModelError(string.Empty, "Det Surfspot du er ved at ændre " +
                                                               "er blevet redigeret af en anden bruger. " +
                                                               "Din redigering er blevet annulleret og " +
                                                               "de nye værdier er blevet opdateret til vinduet. " +
                                                               "Hvis du stadig ønsker at ændre Dette surfspot " +
                                                               "så fortsæt, ellers tryk tilbage");
                        surfspot.RowVersion = databaseValues.RowVersion;
                    }
                    
                }

            }
            return View(surfspot);

        }
        [Authorize]
        [HttpPost]
        public IActionResult Comments(Comment comment)
        {
            repo.AddComment(comment);
            repo.SaveChanges();
            return RedirectToAction("Surfspot", "Surfspot", new { id = comment.SurfspotId});

        }

    }
}
