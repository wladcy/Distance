using Distance.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Distance.Controllers
{
    public class PdfController
    {
        public MemoryStream CreateDistanceReportByCarId(int id)
        {
            MemoryStream retval = new MemoryStream();
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, retval).CloseStream = false;
            DatabaseControler dc = new DatabaseControler();
            ReportDataModel rdm = dc.GetReportData(id);
            Font f = new Font(BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", BaseFont.CP1250, true));
            Font fHeader = new Font(BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", BaseFont.CP1250, true));
            f.Size = 8;
            fHeader.Size = 11;
            Paragraph company = new Paragraph("Dane firmy", fHeader);
            PdfPTable tableBody = new PdfPTable(2);
            tableBody.PaddingTop = 30;
            tableBody.WidthPercentage = 100.0f;
            tableBody.DefaultCell.Border = Rectangle.NO_BORDER;
            PdfPTable table = new PdfPTable(2);
            table.PaddingTop = 30;
            table.WidthPercentage = 100.0f;
            table.SetWidths(new float[] { 1, 3 });
            PdfPCell cellf1 = new PdfPCell();
            cellf1.Border = Rectangle.NO_BORDER;
            cellf1.AddElement(new Paragraph("Nazwa firmy",f));
            PdfPCell cellf2 = new PdfPCell();
            cellf2.Border = Rectangle.NO_BORDER; 
            cellf2.AddElement(new Paragraph(rdm.CompanyData.CompanyName, f));
            PdfPCell cellf3 = new PdfPCell();
            cellf3.Border = Rectangle.NO_BORDER;
            cellf3.AddElement(new Paragraph("Adres", f));
            PdfPCell cellf4 = new PdfPCell();
            cellf4.Border = Rectangle.NO_BORDER;
            cellf4.AddElement(new Paragraph(getAddress(rdm.CompanyData), f));
            PdfPCell cellf5 = new PdfPCell();
            cellf5.Border = Rectangle.NO_BORDER;
            cellf5.AddElement(new Paragraph("Nip", f));
            PdfPCell cellf6 = new PdfPCell();
            cellf6.Border = Rectangle.NO_BORDER;
            cellf6.AddElement(new Paragraph(rdm.CompanyData.NIP, f));
            table.AddCell(cellf1);
            table.AddCell(cellf2);
            table.AddCell(cellf3);
            table.AddCell(cellf4);
            table.AddCell(cellf5);
            table.AddCell(cellf6);
            table.DefaultCell.Border = Rectangle.NO_BORDER;            
            table.HorizontalAlignment = Element.ALIGN_LEFT;           
            document.Open();
            
            PdfPCell right = new PdfPCell();
            right.AddElement(company);
            right.AddElement(table);
            right.Border = Rectangle.NO_BORDER;                       
            Paragraph empty = new Paragraph("", fHeader);
            right.AddElement(empty);
            Paragraph drivers = new Paragraph("Dane kierowców", fHeader);
            drivers.PaddingTop = 20;
            right.AddElement(drivers);
            foreach (DriverViewModels model in rdm.DriversData)
            {
                Paragraph dIndex = new Paragraph("--------------------------------------------------", f);
                dIndex.PaddingTop = 50;
                right.AddElement(dIndex);
                PdfPTable tabled = new PdfPTable(2);
                tabled.PaddingTop = 30;
                tabled.WidthPercentage = 100.0f;
                tabled.SetWidths(new float[] { 1, 3 });
                PdfPCell celld1 = new PdfPCell();
                celld1.Border = Rectangle.NO_BORDER;
                celld1.AddElement(new Paragraph("Imie i nazwisko", f));
                PdfPCell celld2 = new PdfPCell();
                celld2.Border = Rectangle.NO_BORDER;
                celld2.AddElement(new Paragraph(model.FirstName + " " + model.LastName, f));
                PdfPCell celld3 = new PdfPCell();
                celld3.Border = Rectangle.NO_BORDER;
                celld3.AddElement(new Paragraph("Adres", f));
                PdfPCell celld4 = new PdfPCell();
                celld4.Border = Rectangle.NO_BORDER;
                celld4.AddElement(new Paragraph(getAddress(model), f));
                tabled.AddCell(celld1);
                tabled.AddCell(celld2);
                tabled.AddCell(celld3);
                tabled.AddCell(celld4);
                tabled.DefaultCell.Border = Rectangle.NO_BORDER;
                tabled.HorizontalAlignment = Element.ALIGN_LEFT;
                right.AddElement(tabled);
            }
            tableBody.AddCell(right);
            PdfPCell left = new PdfPCell();
            left.Border = Rectangle.NO_BORDER;
            Paragraph cParagraf = new Paragraph("Dane samochodu", fHeader);
            cParagraf.PaddingTop = 20;
            left.AddElement(cParagraf);

            PdfPTable enginetable = new PdfPTable(2);
            enginetable.PaddingTop = 30;
            enginetable.WidthPercentage = 100.0f;
            PdfPCell celle1 = new PdfPCell();
            celle1.Border = Rectangle.NO_BORDER;
            celle1.AddElement(new Paragraph("Numer rejestracyjny", f));
            PdfPCell celle2 = new PdfPCell();
            celle2.Border = Rectangle.NO_BORDER;
            celle2.AddElement(new Paragraph(rdm.CarData.CarPlate.ToUpper(), f));
            PdfPCell celle3 = new PdfPCell();
            celle3.Border = Rectangle.NO_BORDER;
            celle3.AddElement(new Paragraph("Pojemność silnika", f));
            PdfPCell celle4 = new PdfPCell();
            celle4.Border = Rectangle.NO_BORDER;
            celle4.AddElement(new Paragraph(rdm.CarData.EngineCapacity.ToString()+" [cm3]", f));
            enginetable.AddCell(celle1);
            enginetable.AddCell(celle2);
            enginetable.AddCell(celle3);
            enginetable.AddCell(celle4);
            enginetable.DefaultCell.Border = Rectangle.NO_BORDER;
            enginetable.HorizontalAlignment = Element.ALIGN_LEFT;
            left.AddElement(enginetable);
            tableBody.AddCell(left);
            document.Add(tableBody);
            Font fHeaderBold = new Font(BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", BaseFont.CP1250, true));
            fHeaderBold.Size = 11;
            fHeaderBold.SetStyle(1);
            Paragraph header = new Paragraph("EWIDENCJA PRZEBIEGU POJAZDU", fHeaderBold);
            header.Alignment = Element.ALIGN_CENTER;
            document.Add(header);
            Font fparagrafBold = new Font(BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", BaseFont.CP1250, true));
            fparagrafBold.Size = 10;
            fparagrafBold.SetStyle(0);
            Paragraph month = new Paragraph("za miesiąc ", fparagrafBold);//TODO
            month.Alignment = Element.ALIGN_CENTER;
            document.Add(month);
            document.Close();

            byte[] byteInfo = retval.ToArray();
            retval.Write(byteInfo, 0, byteInfo.Length);
            retval.Position = 0;
            return retval;
        }

        private string getAddress(IAddressViewModel Model)
        {
            string retval = string.Empty;
            if (!string.IsNullOrEmpty(Model.FlatNumber) && !string.IsNullOrEmpty(Model.Street))
            {
                retval = Model.Street + " " + Model.HouseNumber + "/" + Model.FlatNumber + "\r\n" + Model.ZipCode + " " + Model.City;
            }
            else if (!string.IsNullOrEmpty(Model.FlatNumber))
            {
                retval = Model.HouseNumber + "/" + Model.FlatNumber + "\r\n" + Model.ZipCode + " " + Model.City;
            }
            else if (!string.IsNullOrEmpty(Model.Street))
            {
                retval = Model.Street + " " + Model.HouseNumber + "\r\n" + Model.ZipCode + " " + Model.City;
            }
            else
            {
                retval = Model.ZipCode + " " + Model.City + ", " + Model.HouseNumber;
            }
            return retval;
        }
    }
}