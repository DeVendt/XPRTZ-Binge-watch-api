#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XPRTZ_Binge_watch_api.Data;
using XPRTZ_Binge_watch_api.Models;

namespace XPRTZ_Binge_watch_api.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ShowsController : Controller
    {
        private readonly IDataService _dataService;

        public ShowsController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        // GET: Shows
        public async Task<ActionResult> Index()
        {
            return View(await _dataService.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Show>> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id is null.");
            }

            var show = await _dataService.FindById((int)id);

            if (show == null)
            {
                return NotFound("Show couldnt be found");
            }

            return View(show);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Show>> Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("name is null.");
            }

            var show = await _dataService.FindByName(name);

            if (show == null)
            {
                return NotFound("Show couldnt be found based on name");
            }

            return View(show);
        }

        [HttpPut]
        public async Task<ActionResult<Show>> Put(Show model)
        {
            if (model == null)
            {
                return BadRequest("Id is null.");
            }

            var succes = await _dataService.Create(model);

            if (!succes)
                return BadRequest("Model couldnt be added.");

            return View(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Show>> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id is null.");
            }

            var state = await _dataService.DeleteByID((int)id);

            if (!state)
            {
                return BadRequest("Show couldnt be deleted");
            }

            return Ok();
        }
    }
}
