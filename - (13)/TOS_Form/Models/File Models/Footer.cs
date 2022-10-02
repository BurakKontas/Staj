using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TOS_Form.Models
{
    internal class Footer
    {
        public Field KayitTipi { get; set; }
        public Field ToplamKayitSayisi { get; set; }
        public Field BankaKodu { get; set; }
        public Field TutarToplam { get; set; }
        public List<string> Sira { get; set; }

    }
}
