using Admin.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Admin.api.Controllers.Achivos
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileRecorController : ControllerBase
    {
        private readonly IManejadorDeArchivosLocal _manejadorArchivos;
        private readonly IFileRecordService _fileRecordService;

        public FileRecorController(IManejadorDeArchivosLocal manejadorArchivos, IFileRecordService fileRecordService)
        {
            _manejadorArchivos = manejadorArchivos;
            _fileRecordService = fileRecordService; 
        }

        [HttpPost("subir")]
        public async Task<IActionResult> UploadFileEmpleado(string idenficadorEmpleado, int contentType, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No se ha proporcionado un archivo válido.");
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var contenido = ms.ToArray();

            var filedto =  _manejadorArchivos.GuardarArchivo( file.FileName,  "documentos" , idenficadorEmpleado, contentType);
            await _fileRecordService.UploadFile(filedto);
            await _manejadorArchivos.GuardarFile(filedto.Ruta, contenido);
            return Ok(new { filedto.Guid });
        }

        [HttpGet("ObtenerArchivoBase64/{ruta}")]

        public async Task<IActionResult> GetArchivoBase64(string ruta)
        {
            var base64 = await _manejadorArchivos.ObtenerArchivoEnBase64(ruta, "documentos");
            return Ok(new { base64 });
        }

        //[HttpPost("upload")]
        //public async Task<IActionResult> Upload(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return BadRequest("No se ha subido un archivo.");

        //    var clientes = new List<Cliente>();

        //    using (var stream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(stream);
        //        stream.Position = 0;
        //        using (var document = SpreadsheetDocument.Open(stream, false))
        //        {
        //            var workbookPart = document.WorkbookPart;
        //            var sheet = workbookPart.Workbook.Sheets.Elements<Sheet>().FirstOrDefault();

        //            if (sheet == null)
        //                return BadRequest("El archivo no contiene hojas.");

        //            var worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);
        //            var rows = worksheetPart.Worksheet.Descendants<Row>().Skip(1);

        //            foreach (var row in rows)
        //            {
        //                var cliente = new Cliente
        //                {
        //                    Nombres = GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(0)),
        //                    Documento = GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(1)),
        //                    Telefono = int.Parse(GetCellValue(workbookPart, row.Elements<Cell>().ElementAt(2)))
        //                };
        //                clientes.Add(cliente);
        //            }
        //        }
        //    }

        //    return Ok(clientes);
        //}

        //[HttpPost("export")]
        //public IActionResult Export([FromBody] List<Cliente> clientes)
        //{
        //    if (clientes == null || clientes.Count == 0)
        //        return BadRequest("No se han proporcionado datos para exportar.");

        //    using (var stream = new MemoryStream())
        //    {
        //        using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
        //        {
        //            var workbookPart = document.AddWorkbookPart();
        //            workbookPart.Workbook = new Workbook();

        //            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
        //            worksheetPart.Worksheet = new Worksheet(new SheetData());

        //            var sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
        //            var sheet = new Sheet()
        //            {
        //                Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
        //                SheetId = 1,
        //                Name = "Clientes"
        //            };
        //            sheets.Append(sheet);

        //            var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

        //            var headerRow = new Row();
        //            headerRow.Append(
        //                new Cell() { CellValue = new CellValue("Nombres"), DataType = CellValues.String },
        //                new Cell() { CellValue = new CellValue("Documento"), DataType = CellValues.String },
        //                new Cell() { CellValue = new CellValue("Telefono"), DataType = CellValues.String }
        //            );
        //            sheetData.Append(headerRow);

        //            foreach (var persona in clientes)
        //            {
        //                var row = new Row();
        //                row.Append(
        //                    new Cell() { CellValue = new CellValue(persona.Nombres), DataType = CellValues.String },
        //                    new Cell() { CellValue = new CellValue(persona.Documento), DataType = CellValues.String },
        //                    new Cell() { CellValue = new CellValue(persona.Telefono.ToString()), DataType = CellValues.Number }
        //                );
        //                sheetData.Append(row);
        //            }
        //        }

        //        stream.Position = 0;
        //        var fileName = "report.xlsx";
        //        var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        //        return File(stream.ToArray(), contentType, fileName);
        //    }
        //}

        private string GetCellValue(WorkbookPart workbookPart, Cell cell)
        {
            var value = cell.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                var stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
            }
            return value;
        }
    }
}
