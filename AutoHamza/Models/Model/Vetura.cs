using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoHamza.Models.Model
{
    public class Vetura
    {
        [Key]
        public int VeturaID { get; set; }
        public string Emri { get; set; }
        public bool IsActive { get; set; }
        public Brendi Brendi { get; set; } 
    }

    public class VeturaCreate
    {
        public string Emri { get; set; }
        public int BrendiID { get; set; }
    }
}