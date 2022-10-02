using PdfSharp;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/htmltopdf", async (PostBody body) => {
    var htmlString = body.htmlString;
    Console.WriteLine(htmlString);
    var memoryStream = new MemoryStream();
    iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlString,memoryStream);
    // create Byte Array with PDF content
    var byteArray = memoryStream.ToArray();
    return byteArray;
});

app.Run();