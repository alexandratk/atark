using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class AdministratorController: ControllerBase 
    {
        private readonly IAdministratorService administratorService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;
        private string backupDBName = "PersonalityID";
        private string backupDir = "Backup";

        public AdministratorController(MyDataContext context,
         IAdministratorService administratorService,
         IMapper mapper) {
             this.context = context;
             this.administratorService = administratorService;
             this.mapper = mapper;
         }

        [Authorize(Roles = "Administrator, SuperAdministrator")]
        [HttpPost("addadmin")]
        public async Task<IActionResult> RegisterAdministrator([FromBody] AdministratorDto administratorDto)
        {
            EducationalInstitution timeEducationalInstitution = context.EducationalInstitution.Where(c => c.Id == administratorDto.EducationalInstitutionId).FirstOrDefault();
            Administrator newAdministrator = mapper.Map<Administrator>(administratorDto);
            newAdministrator.EducationalInstitution = timeEducationalInstitution;
            newAdministrator = await administratorService.AddAdministrator(newAdministrator);
            return Ok(newAdministrator);
        }

        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetEducInstAdministrator(int id)
        {
            Console.WriteLine(id);
            Administrator timeEducationalInstitution = await administratorService.GetEducInst(id);
            return Ok(timeEducationalInstitution.EducationalInstitution.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrator(int id)
        {
            await administratorService.DeleteAdministrator(id);
            return Ok(new
            {
                Response = "Administrator is deleted successfully"
            });
        }




        [HttpGet("backup")]
        public async Task<IActionResult> Backup()
        {
            string basePath = Directory.GetCurrentDirectory();


            string backupName = string.Format($"{backupDBName}Z{DateTime.Now.Ticks}");

            var query = @$"BACKUP DATABASE {backupDBName} TO DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\{backupName}.bak'";
            string connectionString = GetConnectionString(basePath);
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            return Ok(new { Message = "Database is backed up" });
        }

        [Authorize(Roles = "SuperAdministrator")]
        [HttpGet("listadmin/{id}")]
        public async Task<IActionResult> WriteListAdmin(int id)
        {
            Console.WriteLine(id);
            var list = await administratorService.ListAdmin(id);
            return Ok(list);
        }

        [HttpGet("restore/{backupId}")]
        public async Task<IActionResult> Restore(long backupId)
        {
            string backupBaseName = backupDBName;
            string basePath = Directory.GetCurrentDirectory();
            string backupName = $"{backupBaseName}Z{backupId}";
            string name = @$"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\{backupName}.bak";
            if (System.IO.File.Exists(name))
            {
                string mdf_name = "PersonalityID";
                string ldf_name = "PersonalityID_log";

                LoadDB(mdf_name, ldf_name, "tempBD", backupName);
                return Ok(new { Message = "Database is restored" });
            }
            else
            {
                return BadRequest(new { Message = "Backup is not found" });
            }
        }


        [HttpGet("allRestorations")]
        public async Task<IActionResult> GetAllRestorations()
        {
            string basePath = Directory.GetCurrentDirectory();
            List<string> restorationIds = new List<string>();
       //     string[] allRestorationFileNames = Directory.GetFiles(@"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup")
        //                            .Select(p => Path.GetFileName(p)+".bak").ToArray();
            string[] allRestorationFileNames = Directory.GetFiles(@"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup", "*.bak");
            string regexString = "^(.+)Z(.+)\\.bak$";
            Regex regex = new Regex(regexString);
            foreach (string filename in allRestorationFileNames)
            {
                Match m = regex.Match(filename);
                if (m.Success)
                {
                    System.Text.RegularExpressions.Group g = m.Groups[2];
                    CaptureCollection c = g.Captures;
                    var id = c[0].ToString();
                    restorationIds.Add(id);
                }
            }
            return Ok(restorationIds);
        }


        [HttpDelete("deleteRestoration/{backupId}")]
        public async Task<IActionResult> DeleteRestoration(string backupId)
        {
            string basePath = Directory.GetCurrentDirectory();
            string backupBaseName = backupDBName;
            string backupName = @$"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\{backupBaseName}Z{backupId}.bak";
            if (System.IO.File.Exists(backupName))
            {
                System.IO.File.Delete(backupName);
                return Ok(new { Message = "Backup is deleted" });
            }

            return BadRequest(new { Message = "Can't delete the file" });
        }
        


        private string GetConnectionString(string basePath)
        {
            var builder = new ConfigurationBuilder()
          .SetBasePath(basePath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("PersonalIdConString");
            return connectionString;
        }
        

        private bool LoadDB(string orig_mdf, string orig_ldf, string new_database_name, string fileNameToRestore)
        {
            //use RESTORE FILELISTONLY FROM DISK = 'D:\nure\ATARK\FireSaver\FireSaverApi\Backup\FireSaverDbFinalTRefactored1.bak' to see restoring mdf and ldf

            string basePath = Directory.GetCurrentDirectory();
            string connectionString = GetConnectionString(basePath);

            var database_dir = @"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\";

            var temp_mdf = $"{database_dir}{new_database_name}.mdf";
            var temp_ldf = $"{database_dir}{new_database_name}.ldf";
            var query = @$"RESTORE DATABASE {new_database_name} FROM DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\{fileNameToRestore}.bak' WITH MOVE '{orig_mdf}' TO '{temp_mdf}', MOVE '{orig_ldf}' TO '{temp_ldf}', REPLACE;";

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }

            return true;
        }
    }
}