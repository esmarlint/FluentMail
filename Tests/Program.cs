using FluentMail;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var test = FluentMail.FluentMail.Create()
    .Html(html =>
    {
        html.Lang("es");
    })
    .Head(head =>
    {
        head.Title("Tests page!");
        head.Meta("charset", "UTF-8");
    })
    .Render();

Console.WriteLine(test);