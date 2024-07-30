using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog Id";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2; //ilk satırda başlıklar tutulur

                foreach (var item in GetBloglist())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.Id;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application / vnd.openxmlformats - officedocument.spreadsheetml.sheet" ,"Calisma1.xlsx");
                }

            }
          
        }

        public List<BlogModel> GetBloglist()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{Id=1,BlogName="sfdlkfnasdl"},
                 new BlogModel{Id=2,BlogName="sfdlkfnasdl"},
                  new BlogModel{Id=3,BlogName="sfdlkfnasdl"},
            };
            return bm;
        }


        public IActionResult BlogListExcel()
        {

            return View();
        }
        
    }
}
