using FluentMail;
using FluentMail.Elements;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

const string buttonStyle = "display:inline-block;background:#8ccaca;color:#ffffff;font-family:helvetica;font-size:12px;font-weight:normal;line-height:120%;margin:0;text-decoration:none;text-transform:none;padding:10px 25px;mso-padding-alt:0px;border-radius:40px;";

var email = new FluentMail.FluentMail()
    .Html(html =>
    {
        html.Lang("en");
    })
    .Head(head =>
    {
        head.Title("Tests page!");
        head.Meta("charset", "UTF-8");
        head.Meta("description", "Test page");
        head.Meta("keywords", "test, example, mail");
    })
    .Body(body => body
        .Row(row => row
            .Column(column => column
            .BackgroundColor("white")
            .H1("Proof", "text-align: center")
         ))
        .Row(row =>
        {   
            row.BackgroundColor("#f3f3f3");
            row.AddStyle("padding: 2rem 1rem");

            row.Column(column =>
            {
                column.Image("http://i.imgur.com/nwNZ0TW.png","random image","");
            });
            row.Column(column =>
            {
                column.H1("Article Tite");
                column.Paragraph("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur sit amet ipsum consequat.\r\n");
                column.Button("Read more", "https://www.google.com", buttonStyle);
            });
        })
    )
    .Build();



Console.WriteLine(email);