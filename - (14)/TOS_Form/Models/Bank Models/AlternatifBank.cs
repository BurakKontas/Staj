using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOS_Form.Models.Bank_Models
{
    class AlternatifBank
    {
        public Header header = new Header();
        public Details details = new Details();
        public Footer footer = new Footer();
        //TODO:
        //  private static adet = 0;
        //  private static sonDosyaTarihi = datenow()
        //  tarih eğer son dosya ile ayni ise adeti 1 arttiracak farkli ise adeti 0 yapip sonDosyaTarihi ni değistirecek

        /// <summary>
        /// Alternatif Bank icin TOS dosyasi olusturmak icin gereken class doldurma islemi
        /// </summary>
        /// <param name="headerFirmaKodu">Firmanin Vergi dairesi adi + firmanin vergi numarasi</param>
        /// <param name="headerTarih">GGAAYYYY formatinda</param>
        /// <param name="bankaKodu">Havale/eft'nin cikis banka kodu</param>
        /// <param name="subeKodu">Havale/eft'nin cikis sube kodu (Gonderen IBAN dolu ise burasi dolu olmak zorunda değil)</param>
        /// <param name="hesapNO">Havale/eft'nin cikis hesap numarasi (Gonderen IBAN dolu ise burasi dolu olmak zorunda değil)</param>
        /// <param name="farkSubeKodu">Fark Sube kodu</param>
        /// <param name="farkHesapNO">Fark Hesap No</param>
        /// <param name="karsiBankaKodu">Havale/eft'nin varis banka kodu (Alici IBAN dolu ise burasi zorunlu değil)</param>
        /// <param name="karsiSubeKodu">Havale/eft'nin varis sube kodu (Alici IBAN dolu ise burasi zorunlu değil)</param>
        /// <param name="karsiHesapNO">Alacaklinin hesap numarasi (Alici IBAN dolu ise burasi zorunlu değil)</param>
        /// <param name="saticiMusteriNO">Musteri No</param>
        /// <param name="aliciAdi">Havale/eft'yi alanin adi</param>
        /// <param name="aliciAdresi">Havale/eft'yi alanin adresi</param>
        /// <param name="aliciTelefonu">Havele/eft'yi alanin telefon numarasi</param>
        /// <param name="aliciBabaAdi">Havele/eft'yi alanin baba adi</param>
        /// <param name="aciklama">Karsi tarafa gidecek aciklama</param>
        /// <param name="referans">Isleme kurum tarafindan verilebilecek referans numarasi (tarafinizdan 16 adet sifir olarak gonderilecektir.)</param>
        /// <param name="parametre">Bankaya islem icin bilgi iletmek amacli</param>
        /// <param name="tutarTam">15 hane tam kisim</param>
        /// <param name="tutarOndalik">2 hane ondalik kisim </param>
        /// <param name="paraBirimi">EFT icin TRY zorunlu </param>
        /// <param name="islemTarihi">Islemin gerceklestirileceği tarih</param>
        /// <param name="gonderenIBAN">Gonderen hesabin IBAN numarasi (Sube kodu, Hesap no alanlari girildiyse burasi zorunlu değil)</param>
        /// <param name="aliciIBAN">Alici hesabin IBAN numarasi (Karsi banka kodu, karsi sube kodu, karsi hesap no dolu ise burasi zorunlu değil)</param>
        /// <param name="odemeTuru">Detayli bilgi dosyada</param>
        /// <param name="footerToplamKayitSayisi">Detay kayit toplami</param>
        public AlternatifBank(string headerFirmaKodu, string headerTarih, string bankaKodu, string subeKodu, string hesapNO, string farkSubeKodu, string farkHesapNO, string karsiBankaKodu, string karsiSubeKodu, string karsiHesapNO, string saticiMusteriNO, string aliciAdi, string aliciAdresi, string aliciTelefonu, string aliciBabaAdi, string aciklama, string referans, string parametre, string tutarTam, string tutarOndalik, string paraBirimi, string islemTarihi, string gonderenIBAN, string aliciIBAN, string odemeTuru, string footerToplamKayitSayisi)
        {
            //Header
            header.KayitTipi = new Field("B",1,true);
            header.FirmaKodu = new Field(headerFirmaKodu, 15, true);
            header.Tarih = new Field(headerTarih,8);

            //Details
            details.KayitTipi = new Field("D",1,true);
            details.BankaKodu = new Field(bankaKodu, 4);
            details.SubeKodu = new Field(subeKodu, 5);
            details.HesapNO = new Field(hesapNO, 18);
            details.FarkSubeKodu = new Field(farkSubeKodu, 5);
            details.FarkHesapNO = new Field(farkHesapNO, 18);
            details.KarsiBankaKodu = new Field(karsiBankaKodu, 4);
            details.KarsiSubeKodu = new Field(karsiSubeKodu,5);
            details.KarsiHesapNO = new Field(karsiHesapNO, 18, true);
            details.SaticiMusteriNO = new Field(saticiMusteriNO, 10);
            details.AliciAdi = new Field(aliciAdi, 40, true);
            details.AliciAdresi = new Field(aliciAdresi, 40, true);
            details.AliciTelefonu = new Field(aliciTelefonu, 20);
            details.AliciBabaAdi = new Field(aliciBabaAdi, 30, true);
            details.Aciklama = new Field(aciklama, 100, true);
            details.Referans = new Field(referans,16,true);
            details.Parametre = new Field(parametre,40,true);
            details.TutarTam = new Field(tutarTam,15);
            details.TutarOndalik = new Field(tutarOndalik,2);
            details.ParaBirimi = new Field(paraBirimi,5,true);
            details.IslemTarihi = new Field(islemTarihi,8);
            details.IslemKodu = new Field("00",2,true); //sizin tarafinizdan hep 00 olarak gonderilecektir diyor
            details.DurumKodu = new Field("00",2,true); //sizin tarafinizdan hep 00 olarak gonderilecektir diyor
            details.GonderenIBAN = new Field(gonderenIBAN,26,true);
            details.AliciIBAN = new Field(aliciIBAN,26,true);
            details.OdemeTuru = new Field(odemeTuru,2);

            //footer
            footer.KayitTipi = new Field("T",1,true);
            footer.ToplamKayitSayisi = new Field(footerToplamKayitSayisi,5);

            //Sira
            header.Sira = new List<string> { "KayitTipi","FirmaKodu","Tarih" }; //gibi olacak diğerleride
            details.Sira = new List<string> { "KayitTipi", "BankaKodu", "SubeKodu", "HesapNO", "FarkSubeKodu", "KarsiBankaKodu", "KarsiSubeKodu", "AliciAdi", "IslemKodu", "DurumKodu", "GonderenIBAN", "AliciIBAN", "OdemeTuru" }; //hepsini doldurmadim
            footer.Sira = new List<string> { "KayitTipi", "ToplamKayitSayisi" };
        }

    }
}
