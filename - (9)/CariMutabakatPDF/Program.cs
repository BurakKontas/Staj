using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CariMutabakatPDF
{
    internal class CreatePDF
    {
        static void Main(string[] args)
        {
            //Değişkenler {{değişken}} şeklinde formatla belirli değişkenler olarak gelicek ve onların içeriğini replace ile değiştiricez
            Layout layoutContent = new Layout();
            layoutContent.department = "MUHASEBE DEPARTMANI DİKKATİNE";
            layoutContent.debt_recieve = "Nezdimizdeki {{targetCode}} nolu {{targetCompany}} hesabınız {{startDate}} tarihi itibarı ile {{balance}} {{currency}} {{situation}} göstermektedir.";
            layoutContent.description = "Hesabınızda mutabık olup, olmadığımızı aşağıdaki ekli bölümü imzalayarak bildirmenizi; mutabık değilseniz, bir hesap sureti göndermenizi rica ederiz.Bu vesile ile işlerinizde başarılar diler, konuya göstereceğiniz hassasiyeteşimdiden teşekkür ederiz.";
            layoutContent.signatureTitle = "Saygılarımızla";
            layoutContent.agreementLetterTitle = "MUTABAKAT MEKTUBU";
            layoutContent.agreementLetterContent = "Yukarıda tarafınızdan belirtilen {{startDate}} tarihi itibarı ile {{currency}} {{balance}} {{situation}} bakiyede mutabık olduğumuzu / olmadığımızı bildiririz";
            
            CreatePDF.createPDF("C:\\Users\\konta\\Desktop\\carimutabakat.pdf", "Kontas A.Ş.", "Örnek Mah. Deneme Sk. No:24/8 Ankara", "aburakkontas@hotmail.com", "Büyükçekmece", "1111111111", "Hedef A.Ş.", "HDF100546", "25/08/2022", "07/07/2077", "100.25", "TRY", "Alacak","",layoutContent);
        }

        private static BaseFont STF_Helvetica_Turkish = BaseFont.CreateFont("Helvetica", "CP1254", BaseFont.NOT_EMBEDDED);
        private static Font fontBold = new Font(STF_Helvetica_Turkish, 11, Font.BOLD, BaseColor.BLACK);
        private static Font fontNormal = new Font(STF_Helvetica_Turkish, 10, Font.NORMAL, BaseColor.BLACK);
        private static int dateBottomPadding = 20;
        private static int addressBottomPadding1 = 0;
        private static int addressBottomPadding2 = 0;
        private static int addressBottomPadding3 = 0;
        private static int addressBottomPadding4 = 25;
        private static int lineBottomPadding = 20;
        private static int targetCompanyBottomPadding = 10;
        private static int departmentBottomPadding = 10;
        private static int debt_recieveBottomPadding = 0;
        private static int descriptionBottomPadding = 10;
        private static int signatureTitleBottomPadding = 0;
        private static int signatureBottomPadding = 10;
        private static int agreementLetterTitleBottomPadding = 0;
        private static int agreementLetterContentBottomPadding = 50;
        private static int agreementSignatureBottomPadding1 = 0;
        private static int agreementSignatureBottomPadding2 = 0;
        private static int answeringPersonBottomPadding = 0;

        /// <summary>
        /// Değişken olarak verilen yerler {{değişken}} şeklinde belirtilen isimlerle verilmelidir
        /// </summary>
        public class Layout
        {
            public string department { get; set; }
            public string debt_recieve { get; set; }
            public string description { get; set; }
            public string signatureTitle { get; set; }
            public string agreementLetterTitle { get; set; }
            public string agreementLetterContent { get; set; }
        }

        /// <param name="outputDestination"> Dosyanın Kaydedileceği Lokasyon </param>
        /// <param name="companyName"> Faturayı Düzenleyen Şirketin Adı </param>
        /// <param name="companyAddress"> Faturayı Düzenleyen Şirketin Adresi </param>
        /// <param name="e_mail"> Faturayı Düzenleyen Şirketin E-Postası </param>
        /// <param name="revOffice"> Faturayı Düzenleyen Şirketin Vergi Dairesi </param>
        /// <param name="taxIdNum"> Faturayı Düzenleyen Şirketin Vergi Numarası </param>
        /// <param name="targetCompany"> Faturanın düzenlendiği şirketin adı </param>
        /// <param name="targetCode"> Faturanın düzenlendiği şirketin kodu </param>
        /// <param name="startDate"> Başlangıç Tarihi </param>
        /// <param name="endDate"> Bitiş Tarihi </param>
        /// <param name="balance"> Bakiye </param>
        /// <param name="currency"> Para Birimi </param>
        /// <param name="situation"> Borç/Alacak </param>
        /// <param name="answeringPerson"> Cevaplayan Kişinin Adı (Boş ("") bırakılabilir) </param>
        /// <param name="layoutContent"> Dinamik olarak Layout tipinde yazıları kontrol eden class gelecek </param>
        public static void createPDF(string outputDestination, string companyName, string companyAddress, string e_mail, string revOffice, string taxIdNum, string targetCompany, string targetCode, string startDate, string endDate, string balance, string currency, string situation, string answeringPerson, Layout layoutContent)
        {
            Document doc = new Document();
            PdfPTable tableLayout = new PdfPTable(10);
            PdfWriter.GetInstance(doc, new FileStream(outputDestination, FileMode.Create));
            doc.Open();

            //burda layout taki değişken stringleri replace ile güncelleyip göndereceğiz
            //AddContentToPDF fazla karışmasın istedim
            layoutContent.debt_recieve = layoutContent.debt_recieve
                .Replace("{{targetCode}}", targetCode)
                .Replace("{{targetCompany}}", targetCompany)
                .Replace("{{startDate}}", startDate)
                .Replace("{{balance}}", balance)
                .Replace("{{currency}}", currency)
                .Replace("{{situation}}", situation);

            layoutContent.agreementLetterContent = layoutContent.agreementLetterContent
                .Replace("{{startDate}}", startDate)
                .Replace("{{currency}}", currency)
                .Replace("{{currency}}", currency)
                .Replace("{{situation}}", situation);


            doc.Add(AddContentToPDF(tableLayout, companyName, companyAddress, e_mail, revOffice, taxIdNum, targetCompany, targetCode, startDate, endDate, balance, currency, situation, answeringPerson, layoutContent));
            doc.Close();
        } 



        private static PdfPTable AddContentToPDF(PdfPTable tableLayout, string companyName, string companyAddress, string e_mail, string revOffice, string taxIdNum, string targetCompany, string targetCode, string startDate, string endDate, string balance, string currency, string situation, string answeringPerson, Layout layoutContent)
        {
            float[] headers = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            AddCell(tableLayout,"",fontNormal,8, dateBottomPadding);
            AddCell(tableLayout, DateTime.Now.ToString("dd/MM/yyyy"),fontNormal,2, dateBottomPadding);

            AddCell(tableLayout, "", fontNormal, 2, addressBottomPadding1);
            AddCell(tableLayout, companyName, fontNormal, 6, addressBottomPadding1);
            AddCell(tableLayout, "", fontNormal, 2, addressBottomPadding1);

            AddCell(tableLayout, "", fontNormal, 2, addressBottomPadding2);
            AddCell(tableLayout, companyAddress, fontNormal, 6, addressBottomPadding2);
            AddCell(tableLayout, "", fontNormal, 2, addressBottomPadding2);

            AddCell(tableLayout, "", fontNormal, 2, addressBottomPadding3);
            AddCell(tableLayout, $"E-Mail: {e_mail}", fontNormal, 6, addressBottomPadding3);
            AddCell(tableLayout, "", fontNormal, 2, addressBottomPadding3);

            AddCell(tableLayout, "", fontNormal, 2, addressBottomPadding4);
            AddCell(tableLayout, $"Vergi Dairesi: {revOffice}      VKN: {taxIdNum}", fontNormal, 6, addressBottomPadding4);
            AddCell(tableLayout, "", fontNormal, 2, addressBottomPadding4);

            //border değişeceği için uzun şekilde yapıldı başka border olmayacağını göz önünde bulundurunda
            //bu şekilde yapması parametre eklemekten daha kısa
            tableLayout.AddCell(new PdfPCell(new Phrase(" ", fontNormal))
            {
                Colspan = 10,
                Border = 1,
                PaddingBottom = lineBottomPadding,
            });

            AddCell(tableLayout, "", fontNormal, 1, targetCompanyBottomPadding);
            AddCell(tableLayout, targetCompany, fontBold, 9, targetCompanyBottomPadding);

            AddCell(tableLayout, "", fontNormal, 1, departmentBottomPadding);
            AddCell(tableLayout, layoutContent.department, fontBold, 9, departmentBottomPadding);

            AddCell(tableLayout, "", fontNormal, 1, debt_recieveBottomPadding);
            AddCell(tableLayout, layoutContent.debt_recieve, fontNormal, 9, debt_recieveBottomPadding);

            AddCell(tableLayout, "", fontNormal, 1, descriptionBottomPadding);
            AddCell(tableLayout, layoutContent.description, fontNormal, 9, descriptionBottomPadding);

            AddCell(tableLayout, "", fontNormal, 1, signatureTitleBottomPadding);
            AddCell(tableLayout, layoutContent.signatureTitle, fontNormal, 9, signatureTitleBottomPadding);

            AddCell(tableLayout, "", fontNormal, 1, signatureBottomPadding);
            AddCell(tableLayout, companyName, fontNormal, 9, signatureBottomPadding);

            AddCell(tableLayout, "", fontNormal, 1, agreementLetterTitleBottomPadding);
            AddCell(tableLayout, layoutContent.agreementLetterTitle, fontNormal, 9, agreementLetterTitleBottomPadding);

            AddCell(tableLayout, "", fontNormal, 1, agreementLetterContentBottomPadding);
            AddCell(tableLayout, layoutContent.agreementLetterContent, fontNormal, 9, agreementLetterContentBottomPadding);

            AddCell(tableLayout, "", fontNormal, 2, agreementSignatureBottomPadding1);
            AddCell(tableLayout, "Mutabıkız", fontBold, 1, agreementSignatureBottomPadding1);
            AddCell(tableLayout, "", fontNormal, 4, agreementSignatureBottomPadding1);
            AddCell(tableLayout, "Mutabık Değiliz", fontBold, 2, agreementSignatureBottomPadding1);
            AddCell(tableLayout, "", fontNormal, 1, agreementSignatureBottomPadding1);

            AddCell(tableLayout, "", fontNormal, 1, agreementSignatureBottomPadding2);
            //colspanlar ile uyduramadım el ile ayarladım
            AddCell(tableLayout, "       Cevaplayan Adı Soyadı                                                   Cevaplayan Adı Soyadı", fontBold, 9, agreementSignatureBottomPadding2);
            if(answeringPerson != "")
            {
                AddCell(tableLayout, "", fontNormal, 1, answeringPersonBottomPadding);
                tableLayout.AddCell(new PdfPCell(new Phrase(answeringPerson, fontBold))
                {
                    Colspan = 3,
                    Border = 0,
                    PaddingBottom = answeringPersonBottomPadding,
                    HorizontalAlignment = Element.ALIGN_CENTER,

                });
                AddCell(tableLayout, "", fontNormal, 2, answeringPersonBottomPadding);
                tableLayout.AddCell(new PdfPCell(new Phrase(answeringPerson, fontBold))
                {
                    Colspan = 3,
                    Border = 0,
                    PaddingBottom = answeringPersonBottomPadding,
                    PaddingLeft = 25,
                    HorizontalAlignment = Element.ALIGN_CENTER,

                }); ;
                AddCell(tableLayout, "", fontNormal, 1, answeringPersonBottomPadding);
            }

            return tableLayout;
        }

        private static void AddCell(PdfPTable tableLayout,string content,Font font, int colspan,int paddingBottom)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(content, font))
            {
                Colspan = colspan,
                Border = 0,
                PaddingBottom = paddingBottom,
            });
        }
    }
}
