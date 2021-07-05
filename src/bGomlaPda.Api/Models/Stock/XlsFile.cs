using OfficeOpenXml;

namespace PdaHub.Api.Models.Stock
{
    public record XlsFile
    {
        public string FileName { get; set; }
        public ExcelPackage FileData { get; set; } = new ExcelPackage();
    }
}