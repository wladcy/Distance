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
        private Dictionary<int, string> months;
        public PdfController()
        {
            months = new Dictionary<int, string>();
            months.Add(1, "Styczeń");
            months.Add(2, "Luty");
            months.Add(3, "Marzec");
            months.Add(4, "Kwiecień");
            months.Add(5, "Maj");
            months.Add(6, "Czerwiec");
            months.Add(7, "Lipiec");
            months.Add(8, "Sierpień");
            months.Add(9, "Wrzesień");
            months.Add(10, "Październik");
            months.Add(11, "Listopad");
            months.Add(12, "Grudzień");
        }
        public MemoryStream CreateDistanceReportByCarId(int id, int monthNumber, int year)
        {
            MemoryStream retval = new MemoryStream();
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, retval).CloseStream = false;
            DatabaseControler dc = new DatabaseControler();
            ReportDataModel rdm = dc.GetReportData(id, monthNumber,year);
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
            cellf1.AddElement(new Paragraph("Nazwa firmy", f));
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
            celle4.AddElement(new Paragraph(rdm.CarData.EngineCapacity.ToString() + " [cm3]", f));
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
            Paragraph month = new Paragraph("za miesiąc " + months[monthNumber], fparagrafBold);
            month.Alignment = Element.ALIGN_CENTER;
            Paragraph empty2 = new Paragraph(" ", fHeader);
            document.Add(month);
            document.Add(empty2);
            PdfPTable travelsTable = new PdfPTable(9);
            travelsTable.PaddingTop = 50;
            travelsTable.WidthPercentage = 100.0f;
            PdfPCell cellNr = new PdfPCell();
            cellNr.AddElement(new Paragraph("Nr kolejny wpisu", f));
            travelsTable.AddCell(cellNr);
            PdfPCell cellDate = new PdfPCell();
            cellDate.AddElement(new Paragraph("Data wyjazdu", f));
            travelsTable.AddCell(cellDate);
            PdfPCell cellDesc = new PdfPCell();
            cellDesc.AddElement(new Paragraph("Opis trasy wyjazdu (skąd-dokąd)", f));
            travelsTable.AddCell(cellDesc);
            PdfPCell cellPurpose = new PdfPCell();
            cellPurpose.AddElement(new Paragraph("Cel wyjazdu", f));
            travelsTable.AddCell(cellPurpose);
            PdfPCell cellKmCount = new PdfPCell();
            cellKmCount.AddElement(new Paragraph("Liczba faktycznie przejechanych kilometrów", f));
            travelsTable.AddCell(cellKmCount);
            PdfPCell cellOneKm = new PdfPCell();
            cellOneKm.AddElement(new Paragraph("Stawka za 1 km przebiegu", f));
            travelsTable.AddCell(cellOneKm);
            PdfPCell cellMoney = new PdfPCell();
            cellMoney.AddElement(new Paragraph("Wartość", f));
            travelsTable.AddCell(cellMoney);
            PdfPCell cellSignature = new PdfPCell();
            cellSignature.AddElement(new Paragraph("Podpis podatnika", f));
            travelsTable.AddCell(cellSignature);
            PdfPCell cellNotes = new PdfPCell();
            cellNotes.AddElement(new Paragraph("Uwagi", f));
            travelsTable.AddCell(cellNotes);
            float oneMoney = rdm.CarData.EngineCapacity <= 900 ? 0.5214f : 0.8358f;
            int travelNr = 1;
            int sumDistance = 0;
            float sumMoney = 0;
            foreach (TravelViewModels travel in rdm.TravelsData)
            {
                PdfPCell cellNrFor = new PdfPCell();
                cellNrFor.AddElement(new Paragraph(travelNr.ToString(), f));
                travelNr++;
                travelsTable.AddCell(cellNrFor);
                PdfPCell cellDateFor = new PdfPCell();
                cellDateFor.AddElement(new Paragraph(travel.TravelDate.ToShortDateString(), f));
                travelsTable.AddCell(cellDateFor);
                PdfPCell cellDescFor = new PdfPCell();
                cellDescFor.AddElement(new Paragraph(travel.From+"-"+travel.To, f));
                travelsTable.AddCell(cellDescFor);
                PdfPCell cellPurposeFor = new PdfPCell();
                cellPurposeFor.AddElement(new Paragraph(travel.Purpose, f));
                travelsTable.AddCell(cellPurposeFor);
                PdfPCell cellKmCountFor = new PdfPCell();
                int distance = int.Parse(travel.StopKm) - int.Parse(travel.StartKm);
                sumDistance += distance;
                cellKmCountFor.AddElement(new Paragraph(distance.ToString(), f));
                travelsTable.AddCell(cellKmCountFor);
                PdfPCell cellOneKmFor = new PdfPCell();
                cellOneKmFor.AddElement(new Paragraph(oneMoney.ToString(), f));
                travelsTable.AddCell(cellOneKmFor);
                PdfPCell cellMoneyFor = new PdfPCell();
                float money = distance * oneMoney;
                sumMoney += money;
                cellMoneyFor.AddElement(new Paragraph(Math.Round(money,2,MidpointRounding.AwayFromZero).ToString(), f));
                travelsTable.AddCell(cellMoneyFor);
                PdfPCell cellSignatureFor = new PdfPCell();
                cellSignatureFor.AddElement(new Paragraph(" ", f));
                travelsTable.AddCell(cellSignatureFor);
                PdfPCell cellNotesFor = new PdfPCell();
                cellNotesFor.AddElement(new Paragraph(travel.Notes, f));
                travelsTable.AddCell(cellNotesFor);
            }
            PdfPCell sum = new PdfPCell();
            Paragraph sumParagaph = new Paragraph("Razem     ", f);
            sumParagaph.Alignment = Element.ALIGN_RIGHT;
            sum.AddElement(sumParagaph);
            sum.HorizontalAlignment = Element.ALIGN_RIGHT;
            sum.Colspan = 4;
            travelsTable.AddCell(sum);
            PdfPCell sumKm = new PdfPCell();
            sumKm.AddElement(new Paragraph(sumDistance.ToString(), f));
            travelsTable.AddCell(sumKm);
            PdfPCell emptyGray = new PdfPCell();
            emptyGray.AddElement(new Paragraph(" ", f));
            emptyGray.BackgroundColor = BaseColor.GRAY;
            travelsTable.AddCell(emptyGray);
            PdfPCell sumMoneyCell = new PdfPCell();
            sumMoneyCell.AddElement(new Paragraph(Math.Round(sumMoney, 2, MidpointRounding.AwayFromZero).ToString(), f));
            travelsTable.AddCell(sumMoneyCell);
            travelsTable.AddCell(emptyGray);
            travelsTable.AddCell(emptyGray);

            document.Add(travelsTable);
            document.AddTitle("Kilometrówka " + rdm.CarData.CarPlate.ToUpper() + " - " + months[monthNumber]);
            document.Close();

            byte[] byteInfo = retval.ToArray();
            retval.Write(byteInfo, 0, byteInfo.Length);
            retval.Position = 0;
            return retval;
        }

        public string getAddress(IAddressViewModel Model)
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