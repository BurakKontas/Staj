using Newtonsoft.Json;

namespace ResponseMail.Classes.Mutabakat
{
    public class Class_SatisHareket
    {

        [JsonProperty("Tarih")]
        public string Tarih { get; set; }

        [JsonProperty("Saat")]
        public string Saat { get; set; }

        [JsonProperty("FisNo")]
        public string FisNo { get; set; }

        [JsonProperty("Plaka")]
        public string Plaka { get; set; }

        [JsonProperty("YakitTuru")]
        public string YakitTuru { get; set; }

        [JsonProperty("MiktarLT")]
        public string MiktarLT { get; set; }

        [JsonProperty("MiktarTL")]
        public string MiktarTL { get; set; }

        [JsonProperty("BirimFiyat")]
        public string BirimFiyat { get; set; }

        [JsonProperty("Departman")]
        public string Departman { get; set; }

        [JsonProperty("GrupKodu")]
        public string GrupKodu{ get; set; }

        [JsonProperty("Donem")]
        public string Donem { get; set; }

        [JsonProperty("IstasyonSehir")]
        public string IstasyonSehir { get; set; }
    }   
}                        
                      