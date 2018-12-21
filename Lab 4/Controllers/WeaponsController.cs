using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Lab_4.Models;

namespace Lab_4.Controllers
{
    public class WeaponsController : ApiController
    {
        private CRUDEntities1 db = new CRUDEntities1();

        // GET: api/Weapons
        public IQueryable<Weapon> GetWeapon()
        {
            return db.Weapon;
        }

        // GET: api/Weapons/5
        [ResponseType(typeof(Weapon))]
        public IHttpActionResult GetWeapon(int id)
        {
            Weapon weapon = db.Weapon.Find(id);
            if (weapon == null)
            {
                return NotFound();
            }

            return Ok(weapon);
        }

        // PUT: api/Weapons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWeapon(int id, Weapon weapon)
        {
            

            if (id != weapon.Id)
            {
                return BadRequest();
            }

            db.Entry(weapon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Weapons
        [ResponseType(typeof(Weapon))]
        public IHttpActionResult PostWeapon(Weapon weapon)
        {
           

            db.Weapon.Add(weapon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = weapon.Id }, weapon);
        }

        // DELETE: api/Weapons/5
        [ResponseType(typeof(Weapon))]
        public IHttpActionResult DeleteWeapon(int id)
        {
            Weapon weapon = db.Weapon.Find(id);
            if (weapon == null)
            {
                return NotFound();
            }

            db.Weapon.Remove(weapon);
            db.SaveChanges();

            return Ok(weapon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WeaponExists(int id)
        {
            return db.Weapon.Count(e => e.Id == id) > 0;
        }
    }
}