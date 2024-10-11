using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

namespace Practice_6
{
    public enum Format
    {
        Text, Html, Pdf, Json
    }

    public interface IReportBuilder
    {
        void SetHeader(string header);
        void SetContent(string content);
        void SetFooter(string footer);
        void AddSection(string sectionName, string sectionContent);
        void SetStyle(ReportStyle style);
        Report GetReport();
    }

    public class TextReportBuilder : IReportBuilder
    {
        private Report report = new Report();
        public void SetHeader(string header)
        {
            report.Header = header + "\n";
        }
        public void SetContent(string content)
        {
            report.Content = content + "\n";
        }
        public void SetFooter(string footer)
        {
            report.Footer = footer + "\n";
        }
        public void AddSection(string sectionName, string sectionContent)
        {
            report.Sections.Add($"{sectionName}:\n{sectionContent}\n");
        }
        public void SetStyle(ReportStyle style)
        {
            report.Style = style;
        }
        public Report GetReport()
        {
            return report;
        }
    }

    public class HtmlReportBuilder : IReportBuilder
    {
        private Report report = new Report();

        public void SetHeader(string header)
        {
            report.Header = $"<h1>{header}</h1>";
        }
        public void SetContent(string content)
        {
            report.Content = $"<p>{content}</p>";
        }
        public void SetFooter(string footer)
        {
            report.Footer = $"<footer>{footer}</footer>";
        }
        public void AddSection(string sectionName, string sectionContent)
        {
            report.Sections.Add($"<h3>{sectionName}</h3>:\n<p>{sectionContent}</p>\n");
        }
        public void SetStyle(ReportStyle style)
        {
            report.Style = style;
        }
        public Report GetReport()
        {
            return report;
        }
    }

    public class PdfReportBuilder : IReportBuilder
    {
        private Report report = new Report();
        public void SetHeader(string header)
        {
            report.Header = header + "\n";
        }
        public void SetContent(string content)
        {
            report.Content = content + "\n";
        }
        public void SetFooter(string footer)
        {
            report.Footer = footer + "\n";
        }
        public void AddSection(string sectionName, string sectionContent)
        {
            report.Sections.Add($"{sectionName}:\n{sectionContent}\n");
        }
        public void SetStyle(ReportStyle style)
        {

        }
        public Report GetReport()
        {
            return report;
        }

        public void ExportToPdf(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                doc.Add(new Paragraph(report.Header));
                doc.Add(new Paragraph(report.Content));

                foreach (var section in report.Sections)
                {
                    doc.Add(new Paragraph(section));
                }

                doc.Add(new Paragraph(report.Footer));
                doc.Close();
                writer.Close();
            }
        }
    }

    public class JsonReportBuilder : IReportBuilder
    {
        private Report report = new Report();

        public void SetHeader(string header)
        {
            report.Header = header;
        }

        public void SetContent(string content)
        {
            report.Content = content;
        }

        public void SetFooter(string footer)
        {
            report.Footer = footer;
        }

        public void AddSection(string sectionName, string sectionContent)
        {
            report.Sections.Add($"{sectionName}: {sectionContent}");
        }

        public void SetStyle(ReportStyle style)
        {
            report.Style = style;
        }

        public Report GetReport()
        {
            return report;
        }

        public void ExportToJson(string filePath)
        {
            var reportData = new
            {
                Header = report.Header,
                Content = report.Content,
                Footer = report.Footer,
                Sections = report.Sections,
                Style = new
                {
                    BackgroundColor = report.Style?.BackgroundColor,
                    FontColor = report.Style?.FontColor,
                    FontSize = report.Style?.FontSize
                }
            };

            string json = JsonConvert.SerializeObject(reportData, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);
        }

    }

    public class ReportStyle
    {
        public string BackgroundColor { get; set; }
        public string FontColor { get; set; }
        public int FontSize { get; set; }
    }

    public class Report
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }
        public List<string> Sections { get; set; } = new List<string>();
        public ReportStyle Style { get; set; }
        public void Export() { }

        public void Export(string fileName, Format format, IReportBuilder builder)
        {
            switch (format)
            {
                case Format.Text:
                    File.WriteAllText(fileName, $"{Header}\n{Content}\n{string.Join("\n", Sections)}\n{Footer}");
                    break;

                case Format.Html:
                    File.WriteAllText(fileName, $"<html><head><title>{Header}</title><style>body {{ background-color: {Style.BackgroundColor}; color: {Style.FontColor}; font-size: {Style.FontSize}px; }}</style></head><body><h1>{Header}</h1><p>{Content}</p>{string.Join("<br>", Sections)}<footer>{Footer}</footer></body></html>");
                    break;

                case Format.Pdf:
                    if (builder is PdfReportBuilder pdfBuilder)
                    {
                        pdfBuilder.ExportToPdf(fileName);
                    }
                    break;

                case Format.Json:
                    if (builder is JsonReportBuilder jsonBuilder)
                    {
                        jsonBuilder.ExportToJson(fileName);
                    }
                    break;

                default:
                    throw new ArgumentException("Unsupported format");
            }
        }
    }
    public class ReportDirector
    {
        private IReportBuilder _reportBuilder;

        public ReportDirector(IReportBuilder reportBuilder)
        {
            _reportBuilder = reportBuilder;
        }

        public void BuildReport(string header, string content, string footer, ReportStyle style, List<(string sectionName, string sectionContent)> sections)
        {
            _reportBuilder.SetHeader(header);
            _reportBuilder.SetContent(content);
            _reportBuilder.SetFooter(footer);
            _reportBuilder.SetStyle(style);

            foreach (var section in sections)
            {
                _reportBuilder.AddSection(section.sectionName, section.sectionContent);
            }
        }

        public Report GetReport()
        {
            return _reportBuilder.GetReport();
        }
    }
    internal class Builder
    {
        //Builder pattern
    }
}
