using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Generator.Logic;
using Generator.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratorController : ControllerBase
    {
        //Alex: Doc here...
        //https://code-maze.com/create-pdf-dotnetcore/

        private IConverter _converter;

        public GeneratorController(IConverter converter)
        {
            _converter = converter;
        }

        [HttpGet]
        public IActionResult PaxList()
        {
            //var cssPath = Path.Combine(Environment.CurrentDirectory.ToString(), "wwwroot", "Assets", "styles.css");
            var cssPath = Path.Combine(@"C:\Users\Alex\source\repos\Generator\","Assets", "styles.css");
            var templatePath = Path.Combine(@"C:\Users\Alex\source\repos\Generator\", "Assets", "Templates", "Reports");

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 0, Bottom = 10, Left = 0, Right = 0 },
                DocumentTitle = "PDF Report",
                //Out = @"C:\Users\Alex\source\repos\Generator\PaxList.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,

                HtmlContent = TemplateGenerator.GetHTMLString(),
                //WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "styles.css") },
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = cssPath },

                //WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = cssPath },
                //HeaderSettings = { FontName = "Roboto", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                HeaderSettings = {
                    Spacing=0,
                    FontName = "Roboto Regular",
                    FontSize = 12,
                    //Right = "Passenger Name List",
                    Line = false ,
                },
                //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" },
                FooterSettings = {  Spacing=3, FontName = "Arial", FontSize = 8, Line = false, Left = string.Format("            © {0} All rights reserved.", DateTime.Now.Year), Right = "Page [page] of [toPage]                  " },
                
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            //_converter.Convert(pdf);

            //CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
            //context.LoadUnmanagedLibrary(@"C:\Users\Alex\source\repos\Generator\libwkhtmltox.dll");
            //Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll")

            var converter = new SynchronizedConverter(new PdfTools());

            //return Ok("Successfully created PDF document.");
            var file = _converter.Convert(pdf);
            //Alex: To Download the file
            //return File(file, "application/pdf", "PaxList.pdf");
            return File(file, "application/pdf");
        }

        [HttpGet]
        [Route("hotelmaretraite/reservationconfirmation")]
        public IActionResult HotelMaretraiteReservationConfirmation() {
            var cssPath = Path.Combine(@"C:\Users\Alex\source\repos\Generator\", "Assets", "Styles", "HotelMaretraiteReservationConfirmation.css");
            var templatePath = Path.Combine(@"C:\Users\Alex\source\repos\Generator\", "Assets", "Templates", "Reports");

            AccommodationReservation accommodationReservation = DataSource.GetAccommodationReservation();

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 0, Bottom = 10, Left = 0, Right = 0 },
                DocumentTitle = "Hotel Maretraite Reservation Confirmation",
                //Out = @"C:\Users\Alex\source\repos\Generator\PaxList.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,

                HtmlContent = TemplateGenerator.GetHTMLForHotelMaretraiteReservationConfirmation(accommodationReservation),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = cssPath },

                HeaderSettings = {
                    Spacing=0,
                    FontName = "Roboto Regular",
                    FontSize = 12,
                    //Right = "Passenger Name List",
                    Line = false ,
                },
                //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" },
                FooterSettings = { Spacing = 3, FontName = "Roboto", FontSize = 8, Line = false, Left = string.Format("            © {0} All rights reserved.", DateTime.Now.Year), Right = "Page [page] of [toPage]                  " },

            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            //_converter.Convert(pdf);

            //CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
            //context.LoadUnmanagedLibrary(@"C:\Users\Alex\source\repos\Generator\libwkhtmltox.dll");
            //Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll")

            var converter = new SynchronizedConverter(new PdfTools());

            //return Ok("Successfully created PDF document.");
            var file = _converter.Convert(pdf);
            //Alex: To Download the file
            //return File(file, "application/pdf", "PaxList.pdf");
            return File(file, "application/pdf");
        }
    }
}