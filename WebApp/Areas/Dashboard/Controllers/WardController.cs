﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace WebApp.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class WardController : BaseController
    {
        public WardController(SiteProvider provider) : base(provider)
        {

        }
        [HttpPost]
        public IActionResult Detail(int id)
        {
            return Json(provider.Ward.GetWardById(id));
        }
        public IActionResult Search(String term)
        {
            return Json(provider.Ward.SearchWard(term));
        }
        public IActionResult Index()
        {
            return View(provider.Ward.GetWards());
        }
        public IActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Import(IFormFile f)
        {
            if (f != null)
            {
                IWorkbook workbook = new XSSFWorkbook(f.OpenReadStream());
                ISheet sheet = workbook.GetSheetAt(0);
                List<Ward> list = new List<Ward>();
                for (int i = 1; i < sheet.LastRowNum; i++)
                {
                    IRow item = sheet.GetRow(i);
                    Ward ward = new Ward
                    {
                        WardId = Convert.ToInt32(item.GetCell(7).NumericCellValue),
                        DistrictId = Convert.ToInt16(item.GetCell(5).NumericCellValue),
                        WardName = item.GetCell(8).StringCellValue,
                        WardType = item.GetCell(9).StringCellValue,
                    };
                    list.Add(ward);
                }
                provider.Ward.Add(list);
                return Redirect("/dashboard/Ward");
                //return View("index", list);
            }
            return View();
        }
    }
}
