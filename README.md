# FluentMail
Mail template generator inspired by QuestPdf using the fluent pattern 
## The Problem

Crafting email templates using plain HTML can be a daunting task. The lack of structure, reusability, and maintainability in HTML makes it challenging to create sophisticated email layouts and ensure consistent styling across multiple templates. Moreover, achieving compatibility across various email clients often requires extensive testing and cumbersome workarounds.

## The Solution

FluentMail addresses these pain points by introducing a highly expressive and intuitive API for defining email templates. By leveraging the power of C# and a syntax inspired by modern UI frameworks, FluentMail empowers developers to create email templates in a more structured, readable, and maintainable manner.

## Example: FluentMail vs HTML

To illustrate the elegance and simplicity of FluentMail, let's compare how you would create a responsive email template with a styled box and a centered paragraph using FluentMail and traditional HTML.

### FluentMail
```csharp
var template = Email
    .Body(body => body
        .Box(box => box
            .Style(style => style
                .Padding(20)
                .Background("#f0f0f0")
            )
            .Text("Welcome to FluentMail!", text => text
                .Style(style => style
                    .TextAlign(TextAlign.Center)
                    .FontSize(16)
                )
            )
        )
    );
```
vs 
```html
<!DOCTYPE HTML>
<html>
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
        @media only screen and (max-width: 600px) {
            .container {
                width: 100% !important;
            }
        }
    </style>
</head>
<body>
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="600" class="container">
        <tr>
            <td align="center" bgcolor="#f0f0f0" style="padding: 20px;">
                <!--[if mso]>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="600">
                <tr>
                <td align="center" valign="top" width="600">
                <![endif]-->
                <p style="font-size: 16px; margin: 0; text-align: center;">Welcome to FluentMail!</p>
                <!--[if mso]>
                </td>
                </tr>
                </table>
                <![endif]-->
            </td>
        </tr>
    </table>
</body>
</html>

```

The FluentMail example showcases the expressiveness and readability of the library. The styled box and centered text are defined using a fluent and intuitive syntax, eliminating the need for complex HTML tables and inline styles. The resulting code is clean, concise, and easy to understand.
In contrast, the HTML example demonstrates the verbosity and intricacies involved in creating a compatible email template. The code is cluttered with tables, conditional comments, inline styles, and media queries to ensure proper rendering across different email clients.

# Key Features (Planned for Version 1)

- Highly intuitive and simplified syntax for defining email templates.
- Base set of components 
- Automatic generation of compatible HTML code from the defined templates.
- Support for dynamic data binding to personalize email content.
- Cross-client compatibility with popular email providers.
- Template validation to catch common errors and ensure proper structure.
- Extensible architecture to accommodate future enhancements and customizations.
- Units tests

# Roadmap

FluentMail is currently in the conceptual stage, and the development of Version 1 is being planned. The initial release will focus on providing the core functionality for creating and rendering email templates with a strong emphasis on simplicity and compatibility. Future versions will introduce additional features and improvements based on community feedback and requirements.
Contribution
As the project takes shape, contributions to FluentMail will be warmly welcomed. If you are excited about the potential of FluentMail and would like to contribute, please stay tuned for further updates and
