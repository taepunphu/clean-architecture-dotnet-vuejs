using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Data.Contexts;
using Travel.Domain.Entities;

namespace Travel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourPackagesController(TravelDbContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPackages()
        {
            return Ok(context.TourPackages);
        }

        [HttpPost]
        public IActionResult AddPackage(TourPackage tourPackage)
        {
            context.TourPackages.Add(tourPackage);
            context.SaveChanges();

            return Ok(tourPackage);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePackage([FromRoute] int id)
        {
            var package = context.TourPackages.Find(id);
            if (package == null)
            {
                return NotFound();
            }

            context.TourPackages.Remove(package);
            context.SaveChanges();

            return Ok(package);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePackage([FromRoute] int id, [FromBody] TourPackage tourPackage)
        {
            if (id != tourPackage.Id)
            {
                return BadRequest();
            }

            context.Entry(tourPackage).State = EntityState.Modified;
            context.SaveChanges();

            return Ok(tourPackage);
        }
    }
}