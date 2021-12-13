using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlienApi.Models;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;

namespace AlienApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AliensController : ControllerBase
  {
    private readonly AlienApiContext _db;

    public AliensController(AlienApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Alien>>> GetAliens(string Name, string OriginPlanet, string OriginSystem, int MaxNumberOfPlanets, int MinNumberOfPlanets, bool? BreathesOxygen, string KardashevRating, string Description)
    {
      var query = _db.Aliens.AsQueryable();

      if (Name != null)
      {
        query = query.Where(entry => entry.Name.StartsWith(Name));
      }

      if (OriginPlanet != null)
      {
        query = query.Where(entry => entry.OriginPlanet.StartsWith(OriginPlanet));
      }

      if (OriginSystem != null)
      {
        query = query.Where(entry => entry.OriginSystem.StartsWith(OriginSystem));
      }

      if (MaxNumberOfPlanets != 0)
      {
        query = query.Where(entry => entry.NumberOfPlanets <= MaxNumberOfPlanets);
      }

      if (MinNumberOfPlanets != 0)
      {
        query = query.Where(entry => entry.NumberOfPlanets >= MinNumberOfPlanets);
      }

      if (BreathesOxygen != null && BreathesOxygen == true)
      {
        query = query.Where(entry => entry.BreathesOxygen == true);
      } else if (BreathesOxygen != null && BreathesOxygen == false) {
        query = query.Where(entry => entry.BreathesOxygen == false);
      }

      if (KardashevRating != null)
      {
        query = query.Where(entry => entry.KardashevRating == KardashevRating);
      }

      if (Description != null)
      {
        query = query.Where(entry => entry.Description.Contains(Description));
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Alien>> GetAlien(int id)
    {
      var alien = await _db.Aliens.FindAsync(id);
      if (alien == null)
      {
        return NotFound();
      }
      return alien;
    }

    [HttpPost]
    public async Task<ActionResult<Alien>> Post(Alien alien)
    {
      _db.Aliens.Add(alien);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetAliens), new { id = alien.AlienId }, alien);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAlien(int id)
    {
      var alien = await _db.Aliens.FindAsync(id);
      if (alien == null)
      {
        return NotFound();
      }
      _db.Aliens.Remove(alien);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Alien>> Put(int id, Alien alien)
    {
      if (id != alien.AlienId)
      {
        return BadRequest();
      }
      _db.Entry(alien).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch(DbUpdateConcurrencyException)
      {
        if (!AlienExists(id)){
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

// Phrase object request like:
// [
//   {
//    "value": "Slimeballs",
//    "path": "name",
//    "op": "replace"
//   },
// ]



    [HttpPatch("{id}")]
    public async Task<ActionResult<Alien>> Patch(int id, [FromBody] JsonPatchDocument<Alien> patchEntity)
    {
      var entity = _db.Aliens.FirstOrDefault(alien => alien.AlienId == id);

      if (entity == null)
      {
        return NotFound();
      }
      patchEntity.ApplyTo(entity, ModelState);
      try
      {
        await _db.SaveChangesAsync();
      }
      catch(DbUpdateConcurrencyException)
      {
        if (!AlienExists(id)){
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return Ok(entity);
    }

    private bool AlienExists(int id)
    {
      return _db.Aliens.Any(e => e.AlienId == id);
    }
  }
}
