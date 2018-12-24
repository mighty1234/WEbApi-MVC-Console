using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace MVC.Controllers
{
    public class WeaponController : Controller
    {
        // GET: Weapon
        public ActionResult Index()
        {
            IEnumerable<MVCWEaponModel> weaponlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Weapons").Result;   
            weaponlist = response.Content.ReadAsAsync<IEnumerable<MVCWEaponModel>>().Result;
            return View(weaponlist);
        }

        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new MVCWEaponModel());
            }
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Weapons/"+id.ToString()).Result;
            return View(response.Content.ReadAsAsync<MVCWEaponModel>().Result);
        }
        [HttpPost]
        public ActionResult AddOrEdit(MVCWEaponModel weapon)
        {
            if (weapon.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Weapons", weapon).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Weapons/"+weapon.Id,weapon).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Weapons/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
          return RedirectToAction("Index");
        }

      
  

    }
}