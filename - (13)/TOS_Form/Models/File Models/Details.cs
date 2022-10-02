using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TOS_Form.Models
{
    internal class Details
    {
        public Field KayitTipi { get; set; }
        public Field BankaKodu { get; set; }
        public Field SubeKodu { get; set; }
        public Field HesapNO { get; set; }
        public Field FarkSubeKodu { get; set; }
        public Field FarkHesapNO { get; set; }
        public Field KarsiBankaKodu { get; set; }
        public Field KarsiSubeKodu { get; set; }
        public Field KarsiHesapNO { get; set; }
        public Field SaticiMusteriNO { get; set; }
        public Field AliciAdi { get; set; }
        public Field AliciAdresi { get; set; }
        public Field AliciTelefonu { get; set; }
        public Field AliciBabaAdi { get; set; }
        public Field Aciklama { get; set; }
        public Field Referans { get; set; }
        public Field Parametre { get; set; }
        public Field TutarTam { get; set; }
        public Field Nokta { get; set; }
        public Field TutarOndalik { get; set; }
        public Field DovizCinsi { get; set; }
        public Field IslemTarihi { get; set; }
        public Field IslemKodu { get; set; }
        public Field DurumKodu { get; set; }
        public Field GonderenIBAN { get; set; }
        public Field AliciIBAN { get; set; }
        public Field OdemeTuru { get; set; }
        public Field IslemTuru { get; set; }
        public Field FirmaReferansi { get; set; }
        public Field BankaReferansi { get; set; }
        public Field IslemDetayi { get; set; }
        public Field BorcluHesap { get; set; }
        public Field Tutar { get; set; }
        public Field Valor { get; set; }
        public Field AraciBankaSwift { get; set; }
        public Field AlacakliBankaSwiftKodu { get; set; }
        public Field AlacakliBankaAdresi { get; set; }
        public Field LehdarHesapNumarasi { get; set; }
        public Field EkstreAciklama_DekontAciklamasi { get; set; }
        public Field SWIFTAciklama { get; set; }
        public Field YurtdisiMasrafYeri { get; set; }
        public Field Muh_MasrafTahsilHesapNo { get; set; }
        public Field PoliceVadesi { get; set; }
        public Field VesaikNO { get; set; }
        public Field VesaikVadesi { get; set; }
        public Field GumrukKodu { get; set; }
        public Field GumrukBeyannameNo_SerbestBolgeIslemFormuNo { get; set; }
        public Field GumrukBeyannameTarihi_SerbestBolgeIslemFormTarihi { get; set; }
        public Field KomisyonMasrafHesapNO { get; set; }
        public Field FaturaNumarasiveTarihi { get; set; }
        public Field TransferUlkesi { get; set; }
        public Field IhracatciAdSoyad_Unvan { get; set; }
        public Field IhracatciUlkesi { get; set; }
        public Field OdemeIceriği_AmaciKodu { get; set; }
        public Field ListeDisindaKalanDiğerOdemeIceriği_AmaciAciklamasi { get; set; }
        public Field Adres { get; set; }
        public Field Telefon { get; set; }
        public Field BabaAdi { get; set; }
        public Field VergiDairesi { get; set; }
        public Field VKN_TCKN { get; set; }
        public Field ParaBirimi { get; set; }
        public Field Islemodu { get; set; }
        public Field IBANBeyani { get; set; }
        public Field OdemeTarihi { get; set; }
        public Field AlacakliBanka { get; set; }
        public Field AlacakliSube { get; set; }
        public Field AlacakliHesap { get; set; }
        public Field Miktar { get; set; }
        public Field AlacakliAdiSoyadi { get; set; }
        public Field AlacakliAdresi { get; set; }
        public Field AlacakliTel { get; set; }
        public Field AlacakliVergi_TCKimlikNO { get; set; }
        public Field AlacakliVergiDairesi { get; set; }
        public Field AlacakliMusteriNo { get; set; }
        public Field AlacakliBabaAdi { get; set; }
        public Field AlacakliE_Mail { get; set; }
        public Field RezerveAlan1  { get; set; }
        public Field RezerveAlan2 { get; set; }
        public Field EFTSorguNO { get; set; }
        public List<string> Sira { get; set; }
    }
}
