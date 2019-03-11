using System;
using System.Collections.Generic;
using IBM.Data.DB2.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ExtJsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            List<Citizen> citizens = new List<Citizen>();
            try
            {
                DB2DataReader rd;
                using (DB2Connection conn = new DB2Connection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();

                    using (DB2Command cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from citizen";
                        rd = cmd.ExecuteReader();
                        rd.Read();
                        do
                        {
                            if (rd.HasRows)
                            {
                                citizens.Add(new Citizen
                                {
                                    Id = (int)rd[0],
                                    Surname = rd[1].ToString(),
                                    Name = rd[2].ToString(),
                                    Patronymic = rd[3].ToString(),
                                    BirthDate = DateTime.Parse(rd[4].ToString())
                                });
                            }

                        } while (rd.Read());

                    }
                }
            }
            catch (DB2Exception exc)
            {
                Console.WriteLine("Error Message: {0}", exc.Message);
                foreach (DB2Error error in exc.Errors)
                    Console.WriteLine("Error: ({1}): {0}", error.Message,
                    error.NativeError);
            }
            //return Redirect("~/CitizenStore/index.html");
            return new JsonResult(citizens);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
