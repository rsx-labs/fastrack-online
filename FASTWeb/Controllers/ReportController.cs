using FASTService.Process;
using FASTWeb.Models.Employee;
using FASTService.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using FASTService;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.end;

namespace FASTWeb.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Reports/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EmployeeReport()
        {
            ReportsProcess reportsProcess = new ReportsProcess();
            int employeeStatus = (int)EmployeeStatus.Active;
            var employeeList = reportsProcess.GetEmployeeList(employeeStatus).ToList();

            DepartmentProcess department = new DepartmentProcess();
            PositionProcess position = new PositionProcess();
            ViewBag.Departments = department.GetDepartments().ToList();
            ViewBag.Positions = position.GetPositions().ToList();

            return View(employeeList);
        }

        [HttpPost]
        public void EmployeeReport(vwEmployeeList emp)
        {
            DepartmentProcess department = new DepartmentProcess();
            PositionProcess position = new PositionProcess();
            ViewBag.Departments = department.GetDepartments().ToList();
            ViewBag.Positions = position.GetPositions().ToList();

            ReportsProcess reportsProcess = new ReportsProcess();
            int employeeStatus = (int)EmployeeStatus.Active;

            List<vwEmployeeList> sourcefile = new List<vwEmployeeList>();

            if (emp.DepartmentID != 0 && emp.PositionID != 0)
            {
                sourcefile=(reportsProcess.GetEmployeeListByDepartmentIDPositionID(employeeStatus, emp.DepartmentID, emp.PositionID));
            }
            else if (emp.DepartmentID > 0 && emp.PositionID == 0)
            {
                sourcefile = (reportsProcess.GetEmployeeListByDepartmentID(employeeStatus, emp.DepartmentID));
            }
            else if (emp.PositionID > 0 && emp.DepartmentID == 0)
            {
                sourcefile = (reportsProcess.GetEmployeeListByPositionID(employeeStatus, emp.PositionID));
            }
            else
            {
                sourcefile = (reportsProcess.GetEmployeeList(employeeStatus));
            }

            WebGrid grid = new WebGrid(source: sourcefile, canPage: false, canSort: false);
            string gridHtml = grid.GetHtml(
                                     tableStyle: "table table-striped table-hover",
                //mode: WebGridPagerModes.All,
                //firstText: "First",
                //previousText: "Prev",
                //nextText: "Next",
                //lastText: "Last",
                //htmlAttributes: new
                //{
                //    id = "grid"
                //},
                                columns: grid.Columns(
                                 grid.Column("EmployeeID", "Employee ID"),
                                 grid.Column("FullName", "Full Name"),
                                 grid.Column("FirstName", "First Name"),
                                 grid.Column("MiddleName", "Middle Name"),
                                 grid.Column("LastName", "Last Name"),
                                 grid.Column("ManagerID", "Manager ID"),
                                 grid.Column("Gender", "Gender"),
                                 grid.Column("EmailAddress", "Email"),
                                 grid.Column("PhoneNumber", "Phone #"),
                                 grid.Column("DepartmentName", "Department"),
                                 grid.Column("GroupName", "Group"),
                                 grid.Column("Description", "Position"),
                                 grid.Column("Status", "Status")
                                 )
                            ).ToString();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=ListOfEmployees.xls");
            Response.ContentType = "application/excel";
            Response.Write(gridHtml);
            Response.End();

        }

        //[HttpPost]
        //public void GetPDF(vwEmployeeList employee)
        //{
        //    ReportsProcess reportsProcess = new ReportsProcess();
        //    int employeeStatus = (int)EmployeeStatus.Active;

        //    var all = reportsProcess.GetEmployeeList(employeeStatus);

        //    WebGrid grid = new WebGrid(source: all, canPage: false, canSort: false);
        //    string gridHtml = grid.GetHtml(
        //                             tableStyle: "table table-striped table-hover",
        //                        //mode: WebGridPagerModes.All,
        //                        //firstText: "First",
        //                        //previousText: "Prev",
        //                        //nextText: "Next",
        //                        //lastText: "Last",
        //                        //htmlAttributes: new
        //                        //{
        //                        //    id = "grid"
        //                        //},
        //                        columns: grid.Columns(
        //                         grid.Column("EmployeeID", "Employee ID"),
        //                         grid.Column("FullName", "Full Name"),
        //                         grid.Column("Gender", "Gender"),
        //                         grid.Column("EmailAddress", "Email"),
        //                         grid.Column("PhoneNumber", "Phone #"),
        //                         grid.Column("DepartmentName", "Department"),
        //                         grid.Column("GroupName", "Group"),
        //                         grid.Column("Description", "Position")
        //                         )
        //                    ).ToString();
        //    //string exportData = String.Format("<html><head>{0}</head><body>{1}</body></html>","<style>table { border-spacing:5px; border:thick; }</style>", gridHtml);
        //    //var bytes = Encoding.UTF8.GetBytes(exportData);
        //    //using (var input = new MemoryStream(bytes))
        //    //{
        //    //    var output = new MemoryStream();
        //    //    var document = new Document(PageSize.A4, 5, 5, 5, 5);
        //    //    var writer = PdfWriter.GetInstance(document, output);
        //    //    writer.CloseStream = false;
        //    //    document.Open();

        //    //    var xmlWorker = XMLWorkerHelper.GetInstance();
        //    //    xmlWorker.ParseXHtml(writer, document, input, Encoding.UTF8);
        //    //    document.Close();
        //    //    output.Position = 0;

        //    //    return new FileStreamResult(output, "application/pdf");

        //    //}

        //    Response.ClearContent();
        //    Response.AddHeader("content-disposition", "attachment; filename=Employees.xls");
        //    Response.ContentType = "application/excel";
        //    Response.Write(gridHtml);
        //    Response.End();

        //    //byte[] bytesArray = null;
        //    //using (var ms = new MemoryStream())
        //    //{
        //    //    using (var document = new Document())
        //    //    {
        //    //        using (PdfWriter writer = PdfWriter.GetInstance(document, ms))
        //    //        {
        //    //            document.Open();
        //    //            using (var strReader = new StringReader(exportData))
        //    //            {
        //    //                //Set factories
        //    //                HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
        //    //                htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
        //    //                //Set css
        //    //                ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
        //    //                cssResolver.AddCssFile(System.Web.HttpContext.Current.Server.MapPath("~/Content/bootstrap.min.css"), true);
        //    //                //Export
        //    //                IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
        //    //                var worker = new XMLWorker(pipeline, true);
        //    //                var xmlParse = new XMLParser(true, worker);
        //    //                xmlParse.Parse(strReader);
        //    //                xmlParse.Flush();
        //    //            }
        //    //            document.Close();
        //    //        }
        //    //    }
        //    //    bytesArray = ms.ToArray();
        //    //    return new FileStreamResult(ms, "application/pdf");
        //    //}
            
        //}

        [HttpGet]
        public ActionResult FixAssetReport()
        {
            ReportsProcess reportsProcess = new ReportsProcess();
            var assetList = reportsProcess.GetFixAssetList().ToList();

            IssuerProcess issuerProcess = new IssuerProcess();
            LocationProcess locationProcess = new LocationProcess();
            FixAssetManagementProcess assetClass = new FixAssetManagementProcess();
            FixAssetManagementProcess assetType = new FixAssetManagementProcess();
            FixAssetManagementProcess assetStatus = new FixAssetManagementProcess();

            ViewBag.Issuers = issuerProcess.GetIssuers().ToList();
            ViewBag.Locations = locationProcess.GetLocations().ToList();
            ViewBag.AssetClass = assetClass.GetAssetClasses().ToList();
            ViewBag.AssetType = assetType.GetAssetTypes().ToList();
            ViewBag.AssetStatus = assetStatus.GetAssetStatus().ToList();

            return View(assetList);
        }

        [HttpPost]
        public void FixAssetReport(vwFixAssetList fixAsset)
        {
            ReportsProcess reportsProcess = new ReportsProcess();
            List<vwFixAssetList> AssetLists = new List<vwFixAssetList>();

            AssetLists = reportsProcess.GetFixAssetListByClassTypeStatus(fixAsset);

            WebGrid grid = new WebGrid(source: AssetLists, canPage: false, canSort: false);
            string gridHtml = grid.GetHtml(
                //     tableStyle: "table table-striped table-hover",
                //mode: WebGridPagerModes.All,
                //firstText: "First",
                //previousText: "Prev",
                //nextText: "Next",
                //lastText: "Last",
                //htmlAttributes: new
                //{
                //    id = "grid"
                //},
                                    columns: grid.Columns(
                                          grid.Column("FixAssetID", "Fix Asset ID"),
                                          grid.Column("Model", "Model"),
                                          grid.Column("SerialNumber", "Serial #"),
                                          grid.Column("AssetTag", "Asset Tag"),
                                          grid.Column("Brand", "Brand"),
                                          grid.Column("Remarks", "Remarks"),
                                               grid.Column("AcquisitionDate", "Acquisition Date"),
                                               grid.Column("ExpiryDate", "Expiry Date"),
                                               grid.Column("IssuerName", "Issuer Name"),
                                               grid.Column("IssuerType", "Issuer Type"),
                                               grid.Column("LocationName", "Location"),
                                               grid.Column("Country", "Country"),
                                               grid.Column("TypeDescription", "Type"),
                                               grid.Column("ClassDescription", "Class"),
                                               grid.Column("StatusDescription", "Asset Status")

                                     )
                                ).ToString();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=ListOfAssets.xls");
            Response.ContentType = "application/xls";
            Response.Write(gridHtml);
            Response.End();

        }
    }
}