using Microsoft.AspNetCore.Mvc;
using test_projekt.Services.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;

namespace test_projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService fileService;
        private readonly string xmlFilePath = "import/data.xml";

        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }
        [Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("import")]
        public IActionResult ImportXml()
        {
            try
            {
                fileService.ImportXml();
                return Ok("File imported successfully.");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("importjson")]
        public IActionResult ImportJson()
        {
            try
            {
                Console.WriteLine("poczatek");
                fileService.ImportJson();
                return Ok("File imported successfully.");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPost("export")]
        public IActionResult ExportXml()
        {
            try
            {
                Console.WriteLine("1");
                fileService.SaveDataAsXml();
                return Ok("File exported successfully.");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPost("exportjson")]
        public IActionResult ExportJson()
        {
            try
            {
                Console.WriteLine("111");
                fileService.ExportJson();
                return Ok("File exported successfully.");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("dane/{id}")]
        public IActionResult Deletefromdata(int id)
        {
            try
            {
                if (fileService.DeleteFromData(id))
                {
                    Console.WriteLine("Usunieto");
                    return Ok("Usunięto zasób!");
                }
                else
                {
                    return StatusCode(500, "Failed to delete resource.");
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("importcsv")]
        public IActionResult ImportCsvToDB()
        {
            try
            {
                Console.WriteLine("test");
                fileService.ImportCsvToDB();
                Console.WriteLine("imported");
                return Ok("Dane zaimportowane do bazy!");
            }
            catch
            {
                Console.WriteLine("error");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPost("exportdb")]
        public IActionResult ExportfromDB()
        {
            try
            {
                Console.WriteLine("test");
                fileService.ExportDataToCsv();
                Console.WriteLine("exported");
                return Ok("Dane wyexportowane z bazy!");
            }
            catch
            {
                Console.WriteLine("error");
                return StatusCode(500, "Internal server error");
            }
        }
        [Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("getxml")]
        public IActionResult getxml()
        {
            string json = JsonConvert.SerializeXmlNode(fileService.GetDocument());
            return Ok(json);
        }
        
        [HttpPost("getjson")]
        [Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult getjson()
        {
            Console.WriteLine("1");
            return Ok(fileService.get_mieszkancy());
        }
        [Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("getdata")]
        public IActionResult getdata()
        {
            return Ok(fileService.GetTableDataAsJson());
        }
        


    }
}
