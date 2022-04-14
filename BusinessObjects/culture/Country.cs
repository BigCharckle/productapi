using System;
using System.Collections.Generic;
using System.Text;
using Models.enums;
namespace Models.culture
{
    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
        public Currencies currency { get; set; }
        public decimal rate { get; set; }
    }
}
