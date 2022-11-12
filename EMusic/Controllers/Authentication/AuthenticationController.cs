using EMusic.Models;
using EMusic.Models.APIModels;
using EMusic.Models.APIModels.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMusic.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private EMusicContext db = new EMusicContext();

        //api for log in
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequestModel loginRequestModel)
        {
            ResponseModel response = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    using(var command = db.Database.GetDbConnection().CreateCommand())
                    {
                        var parameters = new List<SqlParameter>();
                        command.CommandText = "Login_sp";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Email", loginRequestModel.Email));
                        command.Parameters.Add(new SqlParameter("@Password", loginRequestModel.Password));
                        command.Parameters.Add(new SqlParameter("@UserToken", loginRequestModel.UserToken));
                        command.Parameters.Add(new SqlParameter("@UserType", loginRequestModel.UserType));

                        db.Database.OpenConnection();

                        using(var result = command.ExecuteReader())
                        {
                            response = new ResponseModel { status = HttpStatusCode.OK, message = "Successfully logged in", data = result };
                            return Ok(result);
                        }
                    }
                    
                }
                catch (Exception e)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
