using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using SeeMoreInventory.Models;

namespace SeeMoreInventory.Services
{
    public static class PdfGenerator
    {
        private static int box_small_width = 50;
        private static int box_small_height = 50;
        private static int box_bounding_width = 240;
        private static int box_bounding_height = -160;
        private static int circleRadius = 15;

        static BoxDisplayInfo[] boundingBoxLocations = new BoxDisplayInfo[8]
        {
            //Box 1
            new BoxDisplayInfo(
                new BoundingLocation() { X = 45, Y = 760}, new SphereColorLocation() { X = 70, Y = 735}, 
                new MaterialLocation() { X = 180, Y = 730}, new AntiReflectiveLocation() { X = 70, Y = 730}, 
                new TransitionsLocation() {X = 70, Y = 690 }, new SphereLocation() { X = 180, Y = 700}, 
                new ProductLabelLocation() { X = 170, Y = 610}, new BarcodeLocation() { X = 125, Y = 610}),
            //Box 2
            new BoxDisplayInfo(
                new BoundingLocation() { X = 325, Y = 760 }, new SphereColorLocation() { X = 350, Y = 735}, 
                new MaterialLocation() { X = 460, Y = 730}, new AntiReflectiveLocation() { X = 350, Y = 730},
                new TransitionsLocation() {X = 350, Y = 690 }, new SphereLocation() { X = 460, Y = 700}, 
                new ProductLabelLocation() { X = 460, Y = 610},  new BarcodeLocation() { X = 415, Y = 610}),
            //Box 3
            new BoxDisplayInfo(
                new BoundingLocation() { X = 45, Y = 570 }, new SphereColorLocation() { X = 70, Y = 545},
                new MaterialLocation() { X = 180, Y = 540}, new AntiReflectiveLocation() { X = 70, Y = 540},
                new TransitionsLocation() {X = 70, Y = 500 }, new SphereLocation() { X = 180, Y = 510}, 
                new ProductLabelLocation() { X = 170, Y = 420}, new BarcodeLocation() { X = 125, Y = 420}),
            //Box 4
            new BoxDisplayInfo(
                new BoundingLocation() { X = 325, Y = 570 }, new SphereColorLocation() { X = 350, Y = 545}, 
                new MaterialLocation() { X = 460, Y = 540 }, new AntiReflectiveLocation() { X = 350, Y = 540},
                new TransitionsLocation() {X = 350, Y = 500 }, new SphereLocation() { X = 460, Y = 510}, 
                new ProductLabelLocation() { X = 460, Y = 420}, new BarcodeLocation() { X = 415, Y = 420}),
            //Box 5
            new BoxDisplayInfo(
                new BoundingLocation() { X = 45, Y = 380 }, new SphereColorLocation() { X = 70, Y = 355}, 
                new MaterialLocation() { X = 180, Y = 350 }, new AntiReflectiveLocation() { X = 70, Y = 350},
                new TransitionsLocation() {X = 70, Y = 305 }, new SphereLocation() { X = 180, Y = 320}, 
                new ProductLabelLocation() { X = 170, Y = 230},  new BarcodeLocation() { X = 125, Y = 230}),
            //Box 6
            new BoxDisplayInfo(
                new BoundingLocation() { X = 325, Y = 380 }, new SphereColorLocation() { X = 350, Y = 355}, 
                new MaterialLocation() { X = 460, Y = 350 }, new AntiReflectiveLocation() { X = 350, Y = 350},
                new TransitionsLocation() {X = 350, Y = 305 }, new SphereLocation() { X = 460, Y = 320}, 
                new ProductLabelLocation() { X = 460, Y = 230}, new BarcodeLocation() { X = 415, Y = 230}),
            //Box 7
            new BoxDisplayInfo(
                new BoundingLocation() { X = 45, Y = 190 }, new SphereColorLocation() { X = 70, Y = 165}, 
                new MaterialLocation() { X = 180, Y = 160 }, new AntiReflectiveLocation() { X = 70, Y = 160}, 
                new TransitionsLocation() {X = 70, Y = 120 }, new SphereLocation() { X = 180, Y = 130}, 
                new ProductLabelLocation() { X = 170, Y = 40}, new BarcodeLocation() { X = 125, Y = 40}),
            //Box 8
            new BoxDisplayInfo(
                new BoundingLocation() { X = 325, Y = 190 }, new SphereColorLocation() { X = 350, Y = 165}, 
                new MaterialLocation() { X = 460, Y = 160 }, new AntiReflectiveLocation() { X = 350, Y = 160}, 
                new TransitionsLocation() {X = 350, Y = 120 }, new SphereLocation() { X = 460, Y = 130}, 
                new ProductLabelLocation() { X = 460, Y = 40}, new BarcodeLocation() { X = 415, Y = 40})
        };

        public static string GenerateReport(Box[] boxes)
        {
            string fileName = @"wwwroot\pdf\" + DateTime.Now.ToString("MMddyyyyhhmm") + ".pdf";
            var report = CreateReport(boxes, fileName);
            return fileName;
        }

        public static Document CreateReport(Box[] boxInfo, string fileName)
        {
            var pdfdoc = new Document(PageSize.Letter);
            var pdfFilePath = fileName;
            var fileStream = new FileStream(pdfFilePath, FileMode.Create);

            PdfWriter writer = PdfWriter.GetInstance(pdfdoc, fileStream);
            Barcode128 barcode = new Barcode128();

            BaseFont bf_helvBold = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);

            pdfdoc.Open();

            PdfContentByte under = writer.DirectContentUnder;
            PdfContentByte canvas = writer.DirectContent;


            for (int i = 0; i < boxInfo.Length; i++)
            {
                if (boxInfo[i].IsSelected)
                {
                    under.Rectangle(boundingBoxLocations[i].BoundingLocation.X, boundingBoxLocations[i].BoundingLocation.Y, box_bounding_width, box_bounding_height);
                    under.Rectangle(boundingBoxLocations[i].BoundingLocation.X, boundingBoxLocations[i].BoundingLocation.Y - box_small_height, box_small_width, box_small_height);
                    under.SetLineWidth(1);
                    under.Stroke();

                    under.Circle(boundingBoxLocations[i].SphereColorLocation.X, boundingBoxLocations[i].SphereColorLocation.Y, circleRadius);
                    if (boxInfo[i].LensInfo.Sphere >= 0)
                    {
                        under.SetRgbColorFill(230, 50, 0);
                    }
                    else
                    {
                        under.SetRgbColorFill(138, 182, 252);

                    }
                    under.FillStroke();

                    if (boxInfo[i].LensInfo.AntiReflectiveCoating)
                    {
                        canvas.BeginText();
                        canvas.SetFontAndSize(bf_helvBold, 12);
                        canvas.ShowTextAligned(Element.ALIGN_CENTER, "AR", boundingBoxLocations[i].AntiReflectiveLocation.X, boundingBoxLocations[i].AntiReflectiveLocation.Y, 0);
                        canvas.EndText();
                    }

                    if (boxInfo[i].LensInfo.Transitions)
                    {
                        canvas.BeginText();
                        canvas.SetFontAndSize(bf_helvBold, 16);
                        canvas.ShowTextAligned(Element.ALIGN_CENTER, "T", boundingBoxLocations[i].TransitionsLocation.X, boundingBoxLocations[i].TransitionsLocation.Y, 0);
                        canvas.EndText();
                    }

                    //MATERIAL
                    canvas.BeginText();
                    canvas.SetFontAndSize(bf_helvBold, 12);
                    canvas.ShowTextAligned(Element.ALIGN_CENTER, boxInfo[i].LensInfo.Material.Name.ToString().ToUpper(), boundingBoxLocations[i].MaterialLocation.X, boundingBoxLocations[i].MaterialLocation.Y, 0);
                    canvas.EndText();


                    //POWER SPHERE
                    canvas.BeginText();
                    canvas.SetFontAndSize(bf_helvBold, 12);
                    if (boxInfo[i].LensInfo.Sphere > 0.00m)
                    {
                        canvas.ShowTextAligned(Element.ALIGN_CENTER, "+" + boxInfo[i].LensInfo.Sphere.ToString().ToUpper() + " / " + boxInfo[i].LensInfo.Cylinder.ToString().ToUpper(), boundingBoxLocations[i].SphereLocation.X, boundingBoxLocations[i].SphereLocation.Y, 0);
                    }
                    else
                    {
                        canvas.ShowTextAligned(Element.ALIGN_CENTER, boxInfo[i].LensInfo.Sphere.ToString().ToUpper() + " / " + boxInfo[i].LensInfo.Cylinder.ToString().ToUpper(), boundingBoxLocations[i].SphereLocation.X, boundingBoxLocations[i].SphereLocation.Y, 0);
                    }
                    canvas.EndText();

                    //Barcode
                    barcode.Code = boxInfo[i].LensInfo.ProductLabel;
                    barcode.Size = 10;

                    Image code128Image = barcode.CreateImageWithBarcode(canvas, BaseColor.Black, BaseColor.Black);
                    code128Image.ScalePercent(120);
                    code128Image.Alignment = Element.ALIGN_CENTER;
                    code128Image.SetAbsolutePosition(((box_bounding_width - code128Image.ScaledWidth) / 2) + boundingBoxLocations[i].BoundingLocation.X, boundingBoxLocations[i].BarcodeLocation.Y);
                    pdfdoc.Add(code128Image);
                }
            }

            pdfdoc.Close();
            fileStream.Dispose();

            return pdfdoc;
        }
    }

    public class Box
    {
        public int BoxId { get; set; }

        public bool IsSelected { get; set; }

        public Lens LensInfo { get; set; }
    }

    public class BoxDisplayInfo
    {
        public BoundingLocation BoundingLocation { get; set; }
        public SphereColorLocation SphereColorLocation { get; set; }
        public MaterialLocation MaterialLocation { get; set; }
        public AntiReflectiveLocation AntiReflectiveLocation { get; set; }
        public TransitionsLocation TransitionsLocation { get; set; }
        public SphereLocation SphereLocation { get; set; }
        public ProductLabelLocation ProductLabelLocation { get; set; }
        public BarcodeLocation BarcodeLocation { get; set; }

        public BoxDisplayInfo(BoundingLocation boundingLocation, SphereColorLocation sphereColorLocation, MaterialLocation materialLocation, AntiReflectiveLocation antiReflectiveLocation, TransitionsLocation transitionsLocation, SphereLocation sphereLocation, ProductLabelLocation productLabelLocation, BarcodeLocation barcodeLocation)
        {
            BoundingLocation = boundingLocation;
            SphereColorLocation = sphereColorLocation;
            MaterialLocation = materialLocation;
            AntiReflectiveLocation = antiReflectiveLocation;
            TransitionsLocation = transitionsLocation;
            SphereLocation = sphereLocation;
            ProductLabelLocation = productLabelLocation;
            BarcodeLocation = barcodeLocation;

        }
    }

    public class BoundingLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class SphereColorLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class MaterialLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class AntiReflectiveLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class TransitionsLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class SphereLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class ProductLabelLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class BarcodeLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}