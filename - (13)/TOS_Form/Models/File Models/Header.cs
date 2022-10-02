using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOS_Form.Models
{
    internal class Header
    {
        public Field KayitTipi { get; set; }
        public Field FirmaKodu { get; set; }
        public Field Tarih { get; set; }
        public Field KurumKodu { get; set; }
        public Field KurumHesapNO { get; set; }
        public Field SubeKodu { get; set; }
        public List<string> Sira { get; set; }
    }
}
