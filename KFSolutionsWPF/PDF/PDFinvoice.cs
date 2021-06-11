using KFSolutionsModel;
using KFSrepository_EF6;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsWPF.PDF
{
    public static class  PDFinvoice
    {

        private const string PATH_TO_INVOICES = @"accountancy\invoices\";

        //=============================================================================
        public static string Create(int aId_OrderOut , AppRepository<KfsContext> aAppDbRespository)
        {
           return Create(  aAppDbRespository.OrderOut.GetForInvoiceById(aId_OrderOut));
        }

        //=============================================================================
        public static string  Create(OrderOut aOrderOut)
        {
            if(aOrderOut == null)
            {
                throw new KeyNotFoundException("kan order niet vinden in DB");
            }

            string filename = PATH_TO_INVOICES + aOrderOut.Id.ToString("D8") + ".pdf";

            if (File.Exists(filename)) return filename;


            PdfDocument document = new PdfDocument();


            PdfPage page = document.AddPage();
            XGraphics g = XGraphics.FromPdfPage(page);

            XBrush zwart = XBrushes.Black;
            XFont font = new XFont("Arial", 10, XFontStyle.Bold);

            const string FONT_FAMILYNAME = "Arial";


            //write heading
            g.DrawString("Factuur ", font,zwart, 20, 20);

            const double X_EAN_LIJN = 40;
            const double X_BESCHRIJVING_LIJN = 130;
            const double X_AANTAL_LIJN = 290;
            const double X_EENHEIDSPRIJS_LIJN = 330;
            const double X_EXC_BTW_LIJN = 380;
            const double X_BTWpercent_LIJN = 430;
            const double X_BTW_LIJN = 460;
            const double X_INC_BTW_LIJN = 510;
        

            const double Y_TABEL = 320;
            const double Y_SPACE_BETWEEN_HEADER_AND_FIRST_ROW = 20;
            const double Y_SPACE_BETWEEN_ROWS = 15;

            const double RANDMARGE_IN_CELL = 3;

            XFont FONT_HEADER = new XFont(FONT_FAMILYNAME, 10, XFontStyle.Bold);
            XFont FONT_ROWS = new XFont(FONT_FAMILYNAME, 8);
            XFont FONT_CLIENT = new XFont(FONT_FAMILYNAME, 14);

            XTextFormatter textRechts = new XTextFormatter(g);
            textRechts.Alignment = XParagraphAlignment.Right;
            XTextFormatter textLinks = new XTextFormatter(g);
            textLinks.Alignment = XParagraphAlignment.Left;
            XTextFormatter textMidden = new XTextFormatter(g);
            textMidden.Alignment = XParagraphAlignment.Center;
            //================================================================================================================================

            //teken images
            XImage logo = XImage.FromFile(@"C:\Users\Tompie_HD2\source\repos\KFSolutions\KFSolutionsWPF\bin\Debug\images\PDFhoofding.jpg");
            g.DrawImage(logo, new XRect(0, 0, 600, 200));

            //teken klantgegevens
            textRechts.DrawString("KLANT:", FONT_CLIENT, XBrushes.DarkGreen, new XRect(0, 65,550,20));
            textRechts.DrawString(aOrderOut.Client.FirstName + " " + aOrderOut.Client.NameAddition + " " + aOrderOut.Client.LastName,
                FONT_CLIENT, XBrushes.DarkGreen, new XRect(0, 92, 550, 20));
            textRechts.DrawString(aOrderOut.Client.CltAddresss.ToList()[0].Street + " " + 
                aOrderOut.Client.CltAddresss.ToList()[0].HouseNumber + " " + 
                aOrderOut.Client.CltAddresss.ToList()[0].HouseNumberAddition,
                FONT_CLIENT, XBrushes.DarkGreen, new XRect(0, 115, 550, 20));
            textRechts.DrawString(aOrderOut.Client.CltAddresss.ToList()[0].Zipcode + " " +
                aOrderOut.Client.CltAddresss.ToList()[0].City ,
                FONT_CLIENT, XBrushes.DarkGreen, new XRect(0, 138, 550, 20));
            textRechts.DrawString(
                aOrderOut.Client.CltAddresss.ToList()[0].Country,
                FONT_CLIENT, XBrushes.DarkGreen, new XRect(0, 161, 550, 20));


            //factuur en nummer
            textMidden.DrawString("FAKTUUR: " + aOrderOut.Id.ToString("D8"),
                new XFont(FONT_FAMILYNAME, 18,XFontStyle.Bold), XBrushes.DarkGreen, new XRect(20, 250, 550, 20));


            //factuurdatum
            //------------
            textLinks.DrawString("Faktuurdatum:" + aOrderOut.InvoiceCreatedAt , FONT_HEADER, XBrushes.Black, new XRect(X_EAN_LIJN, Y_TABEL-19, 90, 0));


            //tabelhoofdings
            //--------------
            textMidden.DrawString("EAN", FONT_HEADER, XBrushes.Black, new XRect(X_EAN_LIJN, Y_TABEL, 90, 0));
            textMidden.DrawString("Omschrijving", FONT_HEADER, XBrushes.Black,  new XRect(X_BESCHRIJVING_LIJN, Y_TABEL, 160, 0));
            textMidden.DrawString("Aantal", FONT_HEADER, XBrushes.Black, new XRect(X_AANTAL_LIJN, Y_TABEL, 40, 0));
            textMidden.DrawString("Prijs/st", FONT_HEADER, XBrushes.Black, new XRect(X_EENHEIDSPRIJS_LIJN, Y_TABEL, 50, 0));
            textMidden.DrawString("Excl. Btw", FONT_HEADER, XBrushes.Black, new XRect(X_EXC_BTW_LIJN, Y_TABEL, 50, 0));
            textMidden.DrawString("%", FONT_HEADER, XBrushes.Black, new XRect(X_BTWpercent_LIJN, Y_TABEL, 30, 0));
            textMidden.DrawString("Btw", FONT_HEADER, XBrushes.Black, new XRect(X_BTW_LIJN, Y_TABEL, 50, 0));
            textMidden.DrawString("Incl. Btw", FONT_HEADER, XBrushes.Black, new XRect(X_INC_BTW_LIJN, Y_TABEL, 50, 0));

            //tabel tekenen
            //-------------

            double TTwithoutBTW = 0;
            double TTwithBTW = 0;

            double ypos = Y_TABEL + Y_SPACE_BETWEEN_HEADER_AND_FIRST_ROW;
            foreach (var item in aOrderOut.OrderLineOuts)
            {
                double lineWithoutBTW = item.NumberOfProducts * item.UnitPrice;
                double btwAdd = lineWithoutBTW / 100.0f * item.Product.BTWpercentage;
                double lineWithBTW = lineWithoutBTW + btwAdd;

                TTwithBTW += lineWithBTW;
                TTwithoutBTW += lineWithoutBTW;


                textLinks.DrawString(item.Product.EAN, 
                    FONT_ROWS, 
                    XBrushes.Black,
                    new XRect(X_EAN_LIJN + RANDMARGE_IN_CELL, ypos, 100, 0));

                textLinks.DrawString(item.Product.ProductTitle,
                    FONT_ROWS,
                    XBrushes.Black,
                    new XRect(X_BESCHRIJVING_LIJN + RANDMARGE_IN_CELL, ypos, 100, 0));

                textMidden.DrawString(item.NumberOfProducts.ToString(), FONT_ROWS, XBrushes.Black,
                    new XRect(X_AANTAL_LIJN, ypos, 40,0 ));

                textRechts.DrawString(String.Format("{0:0.00}", item.UnitPrice), FONT_ROWS, XBrushes.Black,
                    new XRect(X_EENHEIDSPRIJS_LIJN - RANDMARGE_IN_CELL, ypos, 50, 0));

                textRechts.DrawString(String.Format("{0:0.00}", lineWithoutBTW), FONT_ROWS, XBrushes.Black,
                    new XRect(X_EXC_BTW_LIJN - RANDMARGE_IN_CELL, ypos, 50, 0));

                textRechts.DrawString(String.Format("{0:0.00}", item.Product.BTWpercentage), FONT_ROWS, XBrushes.Black,
                    new XRect(X_BTWpercent_LIJN - RANDMARGE_IN_CELL, ypos, 30, 0));


                textRechts.DrawString(String.Format("{0:0.00}", btwAdd), FONT_ROWS, XBrushes.Black,
                    new XRect(X_BTW_LIJN - RANDMARGE_IN_CELL, ypos, 50, 0));

                textRechts.DrawString(String.Format("{0:0.00}", lineWithBTW), FONT_ROWS, XBrushes.Black,
                    new XRect(X_INC_BTW_LIJN - RANDMARGE_IN_CELL, ypos, 50, 0));

                ypos += Y_SPACE_BETWEEN_ROWS;
            }

            //----------------------------------------------------------
            //kader tekenen
            //----------------------------------------------------------
            XPen kaderPen = new XPen(XColors.Black, 1);
            double Y_CORRECTY_KADER_BEGIN = -5;
            double Y_CORRECTY_KADER_EIND = 0;
            double X_CORRECTY_KADER = 0;


            //vertikale lijnen
            g.DrawLine(kaderPen,  X_EAN_LIJN + X_CORRECTY_KADER, Y_TABEL + Y_CORRECTY_KADER_BEGIN, X_EAN_LIJN + X_CORRECTY_KADER, ypos + Y_CORRECTY_KADER_EIND);
            g.DrawLine(kaderPen, X_BESCHRIJVING_LIJN + X_CORRECTY_KADER, Y_TABEL + Y_CORRECTY_KADER_BEGIN, X_BESCHRIJVING_LIJN + X_CORRECTY_KADER, ypos + Y_CORRECTY_KADER_EIND);
            g.DrawLine(kaderPen, X_AANTAL_LIJN + X_CORRECTY_KADER, Y_TABEL + Y_CORRECTY_KADER_BEGIN, X_AANTAL_LIJN + X_CORRECTY_KADER, ypos + Y_CORRECTY_KADER_EIND);
            g.DrawLine(kaderPen, X_EENHEIDSPRIJS_LIJN + X_CORRECTY_KADER, Y_TABEL + Y_CORRECTY_KADER_BEGIN, X_EENHEIDSPRIJS_LIJN + X_CORRECTY_KADER, ypos + Y_CORRECTY_KADER_EIND);
            g.DrawLine(kaderPen, X_EXC_BTW_LIJN + X_CORRECTY_KADER, Y_TABEL + Y_CORRECTY_KADER_BEGIN, X_EXC_BTW_LIJN + X_CORRECTY_KADER, ypos + Y_CORRECTY_KADER_EIND);
            g.DrawLine(kaderPen, X_BTWpercent_LIJN + X_CORRECTY_KADER, Y_TABEL + Y_CORRECTY_KADER_BEGIN, X_BTWpercent_LIJN + X_CORRECTY_KADER, ypos + Y_CORRECTY_KADER_EIND);
            g.DrawLine(kaderPen, X_BTW_LIJN + X_CORRECTY_KADER, Y_TABEL + Y_CORRECTY_KADER_BEGIN, X_BTW_LIJN + X_CORRECTY_KADER, ypos + Y_CORRECTY_KADER_EIND);
            g.DrawLine(kaderPen, X_INC_BTW_LIJN + X_CORRECTY_KADER, Y_TABEL + Y_CORRECTY_KADER_BEGIN, X_INC_BTW_LIJN + X_CORRECTY_KADER, ypos + Y_CORRECTY_KADER_EIND);
            //laatste hor lijn
            g.DrawLine(kaderPen,50+ X_INC_BTW_LIJN + X_CORRECTY_KADER, Y_TABEL + Y_CORRECTY_KADER_BEGIN,50 + X_INC_BTW_LIJN + X_CORRECTY_KADER, ypos + Y_CORRECTY_KADER_EIND);


            //horizontale lijnen
            g.DrawLine(kaderPen, X_EAN_LIJN, Y_TABEL + Y_CORRECTY_KADER_BEGIN, 50 + X_INC_BTW_LIJN, Y_TABEL + Y_CORRECTY_KADER_BEGIN);

            double YhorLijn = Y_SPACE_BETWEEN_HEADER_AND_FIRST_ROW + Y_TABEL + Y_CORRECTY_KADER_BEGIN;
            g.DrawLine(kaderPen, X_EAN_LIJN, YhorLijn, 50 + X_INC_BTW_LIJN, YhorLijn);





            //ypos is de positie waar de vertikale lijnen stopte met tekenen
            g.DrawLine(kaderPen, X_EAN_LIJN, ypos, 50 + X_INC_BTW_LIJN, ypos);
            textLinks.DrawString("Order aangemaakt door: " + aOrderOut.SoldBy.FirstName + " " + aOrderOut.SoldBy.NameAddition + " " + aOrderOut.SoldBy.LastName,
    FONT_HEADER, XBrushes.Black, new XRect(X_EAN_LIJN, ypos+12, 600, 0));

            ypos += 10;
            g.DrawLine(kaderPen, X_EAN_LIJN, ypos, 50 + X_INC_BTW_LIJN, ypos);

            ypos += 6;
            textRechts.DrawString("Excl BTW:", FONT_ROWS, XBrushes.Black, new XRect(0, ypos, 480, 20));
            textRechts.DrawString(String.Format("{0:0.00}", TTwithoutBTW) + "€", FONT_ROWS, XBrushes.Black, new XRect(0, ypos, 560, 20));

            ypos += 11;
            textRechts.DrawString("BTW:", FONT_ROWS, XBrushes.Black, new XRect(0, ypos, 480, 20));
            textRechts.DrawString(String.Format("{0:0.00}",TTwithBTW-TTwithoutBTW) + "€", FONT_ROWS, XBrushes.Black, new XRect(0, ypos, 560, 20));


            ypos += 15;
            g.DrawLine(kaderPen, X_EAN_LIJN, ypos, 50 + X_INC_BTW_LIJN, ypos);

            ypos += 8;
            textRechts.DrawString("Totaal:", FONT_HEADER, XBrushes.Black, new XRect(0, ypos, 480, 20));
            textRechts.DrawString(String.Format("{0:0.00}", TTwithBTW) + "€", FONT_HEADER, XBrushes.Black, new XRect(0, ypos, 560, 20));

            ypos += 18;
            g.DrawLine(kaderPen, X_EAN_LIJN, ypos, 50 + X_INC_BTW_LIJN, ypos);


            //footer tekenen
            g.DrawLine(kaderPen, X_EAN_LIJN, 750, 50 + X_INC_BTW_LIJN, 750);
            g.DrawLine(kaderPen, X_EAN_LIJN, 800, 50 + X_INC_BTW_LIJN, 800);
            g.DrawLine(kaderPen, X_EAN_LIJN, 800, 50 + X_INC_BTW_LIJN, 800);



            document.Save(filename);
            return filename;



        }
    }
}
