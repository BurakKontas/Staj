using Newtonsoft.Json;
using System.ComponentModel;

namespace ResponseMail.Classes.Mutabakat
{
    public class CariEkstreler
    {
        [JsonProperty("Donem")]
        public string Donem { get; set; }

        [JsonProperty("Tarih")]
        public string Tarih { get; set; }

        [JsonProperty("CariKodu")]
        public string CariKodu { get; set; }

        [JsonProperty("CariAdi")]
        public string CariAdi { get; set; }

        [JsonProperty("VergiDairesiVergiNo")]
        public string VergiDairesiVergiNo { get; set; }

        [JsonProperty("Aciklama")]
        public string Aciklama { get; set; }

        [JsonProperty("Borc")]
        public string Borc { get; set; }

        [JsonProperty("Alacak")]
        public string Alacak { get; set; }

        [JsonProperty("IptalMi")]
        public string IptalMi { get; set; }

        [JsonProperty("Bakiye")]
        public string Bakiye { get; set; }

        [JsonProperty("DOVIZKODU")]
        public string DOVIZKODU { get; set; }

    }
}