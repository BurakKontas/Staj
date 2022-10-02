using Aspose.Pdf;
using NReco.PdfGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace iText_HTML_to_PDF
{
    class Program
    {
        private static string _path = @"C:\Users\konta\source\repos\PDF Template\PDF Template\Template\";
        private static string _template = _path + "template.html";
        private static string _table = _path + "table.html";
        private static string _OUTPUT_FOLDER = @"C:\Users\konta\Desktop\";

        private static string sayiToYazi(decimal tutar)
        {
            string sTutar = tutar.ToString("F2").Replace('.', ',');
            string lira = sTutar.Substring(0, sTutar.IndexOf(','));
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "YALNIZ";

            string[] birler = { "", "BİR", "İKİ", "ÜÇ", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" };

            int grupSayisi = 6;


            lira = lira.PadLeft(grupSayisi * 3, '0');

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3)
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ";

                if (grupDegeri == "BİRYÜZ")
                    grupDegeri = "YÜZ";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))];

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))];

                if (grupDegeri != "")
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "BİRBİN")
                    grupDegeri = "BİN";

                yazi += grupDegeri;
            }

            if (yazi != "")
                yazi += " TL ";

            int yaziUzunlugu = yazi.Length;

            if (kurus.Substring(0, 1) != "0")
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

            if (kurus.Substring(1, 1) != "0")
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

            if (yazi.Length > yaziUzunlugu)
                yazi += " KURUŞ";
            else
                yazi += "";

            if (yazi.Contains("KURUŞ")) return yazi.Replace(" ", "").Replace("TL", "TL ");
            else return yazi.Replace(" ", "");
        }

        [Obsolete]
        private static List<string> createDataList(List<Data> dataList,string tableTemp,MainData mainData)
        {
            List<string> list = new List<string>();
            string table = null;
            int sıra = 0;
            double toplam = 0;
            int adet = 0;
            for(int i = 0; i < dataList.Count; i++)
            {
                table = string.Copy(tableTemp)
                .Replace("{{sırano}}",(++sıra).ToString())
                .Replace("{{unvan}}", dataList[i].Unvan)
                .Replace("{{iban}}", dataList[i].IBAN)
                .Replace("{{tutar}}", dataList[i].Tutar.ToString())
                .Replace("{{pb}}", dataList[i].ParaBirimi)
                .Replace("{{aciklama}}", dataList[i].Açıklama);
                list.Add(table);
                toplam += dataList[i].Tutar;
                adet++;
            }
            mainData.Quantity = adet;
            mainData.Price = Math.Round(toplam, 5);
            mainData.PriceText = sayiToYazi((decimal)mainData.Price);
            list.Add("<tr>" +
                "<td>Toplam</td>" +
                "<td></td>" +
                "<td></td>" +
                "<td>"+ mainData.Price.ToString() + "</td>" +
                "<td>{{exchange}}</td>" +
                "<td></td>" +
                "</tr>");
            return list;
        }

        [Obsolete]
        static void Main(string[] args)
        {
            /////////////////////////////////////////
            //Burası dinamik olacak sadece test
            MainData mainData = new MainData();
            mainData.Date = DateTime.Now.ToString("dd/MM/yyyy");
            mainData.BankName = "İş";
            mainData.BranchName = "Trakya Üniversitesi";
            mainData.Exchange = "TL";
            mainData.Account = "111000111";
            mainData.Company = "Kontaş A.Ş";
            List<Data> dataList = new List<Data>();
            var data = new Data();
            data.Tutar = 1.35;
            data.Açıklama = "CARİ KOD + FATURA NO";
            data.ParaBirimi = "TL";
            data.Unvan = "                              ";
            data.IBAN = "                              ";
            dataList.Add(data);
            dataList.Add(data);
            dataList.Add(data);
            dataList.Add(data);
            dataList.Add(data);
            dataList.Add(data);
            dataList.Add(data);
            dataList.Add(data);
            dataList.Add(data);
            dataList.Add(data);
            /////////////////////////////////
            string tableTemp = File.ReadAllText(_table);
            List<string> tables = createDataList(dataList, tableTemp,mainData);
            string table = "";
            tables.ForEach(t => table += t);
            string temp = File.ReadAllText(_template)
                .Replace("{{table}}", table)
                .Replace("{{date}}", mainData.Date)
                .Replace("{{bankName}}", mainData.BankName.ToUpper())
                .Replace("{{branchName}}", mainData.BranchName.ToUpper())
                .Replace("{{price}}", mainData.Price.ToString())
                .Replace("{{exchange}}", mainData.Exchange)
                .Replace("{{priceText}}", mainData.PriceText)
                .Replace("{{quantity}}", mainData.Quantity.ToString())
                .Replace("{{account}}", mainData.Account)
                .Replace("{{exchange}}", mainData.Exchange)
                .Replace("{{company}}", mainData.Company);
            string pdfDest = _OUTPUT_FOLDER + "output.pdf";
            var htmlContent = String.Format(temp);
            var htmlToPdf = new HtmlToPdfConverter();
            var pdfBytes = htmlToPdf.GeneratePdf(htmlContent);
            File.WriteAllBytes(pdfDest, pdfBytes);
        }
    }
}