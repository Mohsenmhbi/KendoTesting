using Kendo.Mvc.UI;
using KendoTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Collections;
using NPOI.HSSF.UserModel;
using System.IO;

namespace KendoTesting.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var p = db.Product1s.ToList();
            List<ViewModel.ProductViewModel> model = new List<ViewModel.ProductViewModel>();
            foreach (var item in p)
            {
                model.Add(new ViewModel.ProductViewModel() { Id = item.Id, Name = item.Name, GroupId = item.Group.Name, imageName = item.Name.Substring(0, item.Name.Length - 4).ToString(), RangGroupName=item.RangGroup.Name });
            }
            return Json(model.ToDataSourceResult(request));
        }

        public FileResult Export([DataSourceRequest]DataSourceRequest request)
        {
            //Get the data representing the current grid state - page, sort and filter
            IEnumerable products = db.Product1s.ToDataSourceResult(request).Data;

            //Create new Excel workbook
            var workbook = new HSSFWorkbook();

            //Create new Excel sheet
            var sheet = workbook.CreateSheet();

            //(Optional) set the width of the columns
            sheet.SetColumnWidth(0, 10 * 256);
            sheet.SetColumnWidth(1, 50 * 256);


            //Create a header row
            var headerRow = sheet.CreateRow(0);

            //Set the column names in the header row
            headerRow.CreateCell(0).SetCellValue("شماره محصول");
            headerRow.CreateCell(1).SetCellValue("نام محصول");


            //(Optional) freeze the header row so it is not scrolled
            sheet.CreateFreezePane(0, 1);

            int rowNumber = 1;

            //Populate the sheet with values from the grid data
            foreach (Product1 product in products)
            {
                //Create a new row
                var row = sheet.CreateRow(rowNumber++);

                //Set values for the cells
                row.CreateCell(0).SetCellValue(product.Id);
                row.CreateCell(1).SetCellValue(product.Name);

            }

            //Write the workbook to a memory stream
            MemoryStream output = new MemoryStream();
            workbook.Write(output);

            //Return the result to the end user

            return File(output.ToArray(),   //The binary data of the XLS file
                "application/vnd.ms-excel", //MIME type of Excel files
                "GridExcelExport.xls");     //Suggested file name in the "Save as" dialog which will be displayed to the end user

        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}