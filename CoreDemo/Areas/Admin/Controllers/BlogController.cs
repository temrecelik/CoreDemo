using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [AllowAnonymous]

    [Area("Admin")]
    public class BlogController : Controller
    {

        //Blog Listesini Excele Dönüştürüp indirme işlemi yapılı



        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2; //ilk satırda başlıklar tutulur

                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;

                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }

            List<BlogModel2> BlogTitleList()
            {

                List<BlogModel2> bm2 = new List<BlogModel2>();
                using (var c = new Context())
                {
                    bm2 = c.Blogs.Select(x => new BlogModel2
                    {
                        Id = x.BlogID,
                        BlogName = x.BlogTitle
                    }).ToList();
                }
                return bm2;
            }
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
