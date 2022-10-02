//deletion time varsa alma

//user class listesi döndürecek

//documentlerin içinde sadece name olacak

using System.Globalization;
using System.Linq;
using System.Xml.Linq;

string path = @"C:\Users\konta\Desktop";
string fileName = "mükellefListesi.xml";
string filePath = $"{path}/{fileName}";

List<User> users = new List<User>();

//sonradan basitleştirilebilir üst kısım

bool userFillable = false;

XDocument xDoc = XDocument.Load(filePath);

XElement rootElement = xDoc.Root; //root olarak <User> alacak

//Console.WriteLine(DateTime.Now);
//Console.WriteLine(parseDate("2020-07-07T13:13:17"));

//Console.WriteLine(DateTime.Now < parseDate("2020-07-07T13:13:17"));



foreach (XElement element in rootElement.Elements().Where(e => parseDate(e.Element("Documents").Element("Document").Element("Alias").Element("CreationTime").Value) > DateTime.Now.AddDays(-5)))
{

    User user = new User();
    //dümdüz gelen veriler
    user.Identifier = element.Element("Identifier").Value;
    user.Title = element.Element("Title").Value;
    user.Type = element.Element("Type").Value;
    user.AccountType = element.Element("AccountType").Value;

    //şimdi üstünde oynamalar gereken yerleri yapıyoruz
    var firstCreationTime = element.Element("FirstCreationTime").Value;
    user.FirstCreationTime = parseDate(firstCreationTime); //bir kontrol gerekmediğinden direk atadık

    XElement documents = element.Element("Documents");
    List<Document> docs = new List<Document>();
    foreach(XElement doc in documents.Elements())
    {
        if(doc.Attribute("type").Value == "Invoice")
        {
            foreach(XElement alias in doc.Elements())
            {
                if (alias.Element("DeletionTime") != null) continue;//eğer deletion time varsa yani silindiyse almayacak

                var creationTime = parseDate(alias.Element("CreationTime").Value);

                Document document = new Document();
                //document.CreationTime = creationTime;
                document.Name = alias.Element("Name").Value;
                docs.Add(document);
            }
        }
    }
    if (docs.Count == 0) continue; //eğer kayıt eklenmediyse yani hepsi geçmişte oluşturulacaksa eklemiyor

    user.Documents = docs;

    users.Add(user);
}

Console.WriteLine(users.Count);

//foreach(User user in users)
//{
//    Console.WriteLine(user.Identifier);
//}

//functions
DateTime parseDate(string value)
{
    var dateFormat = "yyyy-MM-dd'T'HH:mm:ss";
    CultureInfo provider = new CultureInfo("en-US");
    DateTime returnValue = DateTime.ParseExact(value, dateFormat, provider); //output : 06/07/2020 17:01:50

    return returnValue;
}
