using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interfile.Framework.Image.BLL
{
    public class ImageBLL
    {

        public void imageToPdf(string namepdf, string namesImg)
        {

            try
            {
                string regexPattern = @"([^\s]+(\.(?i)(jpg|png|gif|bmp))$)";

                if (!namepdf.EndsWith(".pdf"))
                {
                    throw new Exception("O arquivo deve conter .pdf");
                }

                if (!Regex.IsMatch(namesImg, regexPattern))
                {
                    throw new Exception("O arquivo deve conter umas das extensões .jpg .png .gif .bmp");
                }

                string[] arrImagens = namesImg.Split(';');

                using (FileStream fs = new FileStream(namepdf, FileMode.Create, FileAccess.Write, FileShare.None))
                {

                    using (Document doc = new Document())
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                        {

                            doc.Open();

                            foreach (var nameimg in arrImagens)
                            {

                                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(nameimg);
                                image.SetDpi(40, 40);
                                image.SetAbsolutePosition(0, 0);
                                doc.SetPageSize(new Rectangle(0, 0, image.Width, image.Height, 0));

                                doc.NewPage();

                                writer.DirectContent.AddImage(image, false);


                            }

                            doc.Close();
                        }

                    }
                }


            }
            catch (Exception ex)
            {


            }
        }

    }
}
    

