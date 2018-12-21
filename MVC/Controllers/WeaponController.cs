using MVC.Models;
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
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Weapon").Result;
            weaponlist = response.Content.ReadAsAsync<IEnumerable<MVCWEaponModel>>().Result;
            return View(weaponlist);
        }
    }
}