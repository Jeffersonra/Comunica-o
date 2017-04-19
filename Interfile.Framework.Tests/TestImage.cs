using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfile.Framework.Image.BLL;

namespace Interfile.Framework.Tests
{
    [TestClass]
    public class TestImage
    {
        [TestMethod]
        public void ImageToPdf()
        {
            ImageBLL imageBLL = new ImageBLL();
            imageBLL.imageToPdf("C:\\temp\\testeimage\\teste.pdf", "C:\\temp\\testeimage\\image1.tif;C:\\temp\\testeimage\\image2.tif");
        }
    }
}
