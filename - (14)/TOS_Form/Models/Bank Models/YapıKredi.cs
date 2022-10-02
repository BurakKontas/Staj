using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOS_Form.Models.Bank_Models
{
    internal class YapıKredi
    {
        public Header header = new Header();
        public Details details = new Details();
        public Footer footer = new Footer();

        public YapıKredi(string headerFirmaKodu, string headerTarih, string bankaKodu, string subeKodu, string hesapNO, string farkSubeKodu, string footerToplamKayitSayisi)
        {
            header.KayitTipi = new Field("B", 1, true);
            header.FirmaKodu = new Field(headerFirmaKodu, 15, true);
            header.Tarih = new Field(headerTarih, 8);

            details.KayitTipi = new Field("D", 1, true);
            details.BankaKodu = new Field(bankaKodu, 4);
            details.SubeKodu = new Field(subeKodu, 5);
            details.HesapNO = new Field(hesapNO, 18);
            details.FarkSubeKodu = new Field(farkSubeKodu, 5);

            footer.KayitTipi = new Field("T", 1, true);
            footer.ToplamKayitSayisi = new Field(footerToplamKayitSayisi, 5);

            header.Sira = new List<string> { "KayitTipi", "FirmaKodu", "Tarih" }; //gibi olacak diğerleride
            details.Sira = new List<string> { "KayitTipi", "BankaKodu", "SubeKodu", "HesapNO", "FarkSubeKodu" }; //hepsini doldurmadim
            footer.Sira = new List<string> { "KayitTipi", "ToplamKayitSayisi" };
        }
    }
}
