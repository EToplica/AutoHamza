using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoHamza.Models.Model
{
    public class Brendi
    {
        [Key]
        public int BrendiID { get; set; }
        public string Emri { get; set; }
        public string Foto { get; set; }
        public bool IsActive { get; set; }
    }
}