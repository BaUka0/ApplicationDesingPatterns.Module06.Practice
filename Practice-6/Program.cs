using System;
using System.Runtime.CompilerServices;

namespace Practice_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Logger logger = Logger.GetInstance();

             logger.SetLogLevel(LogLevel.WARNING);
             logger.Log(LogLevel.WARNING, "wdjlahvsdlkshjanbdlakawhbdb.amns");*/

            /*ReportStyle style = new ReportStyle { BackgroundColor = "White", FontColor = "Black", FontSize = 14 };

            List<(string sectionName, string sectionContent)> sections = new List<(string sectionName, string sectionContent)>
        {
            ("Introduction", "This is the introduction section."),
            ("Details", "Here are the details."),
            ("Conclusion", "This is the conclusion section.")
        };

            IReportBuilder textBuilder = new TextReportBuilder();
            ReportDirector director = new ReportDirector(textBuilder);
            director.BuildReport("Report Header", "This is the content of the report.", "Report Footer", style, sections);
            Report textReport = director.GetReport();
            textReport.Export("report.txt", Format.Text, textBuilder);

            IReportBuilder htmlBuilder = new HtmlReportBuilder();
            director = new ReportDirector(htmlBuilder);
            director.BuildReport("Report Header", "This is the content of the report.", "Report Footer", style, sections);
            Report htmlReport = director.GetReport();
            htmlReport.Export("report.html", Format.Html, htmlBuilder);

            PdfReportBuilder pdfBuilder = new PdfReportBuilder();
            director = new ReportDirector(pdfBuilder);
            director.BuildReport("Report Header", "This is the content of the report.", "Report Footer", style, sections);
            Report pdfReport = director.GetReport();
            pdfReport.Export("report.pdf", Format.Pdf, pdfBuilder);

            JsonReportBuilder jsonBuilder = new JsonReportBuilder();
            director = new ReportDirector(jsonBuilder);
            director.BuildReport("Report Header", "This is the content of the report.", "Report Footer", style, sections);
            Report jsonReport = director.GetReport();
            jsonReport.Export("report.json", Format.Json, jsonBuilder);

            Console.WriteLine("Отчеты созданы и экспортированы.");*/

            Weapon Akimbo = new Weapon(".50 Akimbo", 150);
            Armor shield = new Armor("Dome Shield", 300);
            List<Skill> skills = new List<Skill>
        {
            new Skill("Mesh Shield", 40),
            new Skill("Charge 'n' Slam", 35)
        };

            Character character1 = new Character(350, 500, 50, 100, Akimbo, shield, skills);

            Character character2 = character1.Clone();

            character2.weapon.Type = "Shotgun";
            character2.skills[0].Type = "Healing beam";

            Console.WriteLine($"Character 1 Weapon: {character1.weapon.Type}");
            Console.WriteLine($"Character 2 Weapon: {character2.weapon.Type}");

            Console.WriteLine($"Character 1 Skill: {character1.skills[0].Type}");
            Console.WriteLine($"Character 2 Skill: {character2.skills[0].Type}");
        }
    }
}