using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MVCWEaponModel
    {
        public int Id { get; set; }
        public string Trunk { get; set; }
        public string Caliber { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Material { get; set; }
        public Nullable<bool> pikatini { get; set; }
        public Nullable<bool> Bulpup { get; set; }
        public Nullable<int> Magazine_Size { get; set; }
    }
}