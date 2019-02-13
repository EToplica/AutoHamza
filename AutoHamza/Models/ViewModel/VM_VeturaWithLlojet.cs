using AutoHamza.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoHamza.Models.ViewModel
{
    public class VM_VeturaWithLlojet
    {
        public Vetura Vetura { get; set; }
        public List<LlojiVetures> llojetlist { get; set; }
    }
}