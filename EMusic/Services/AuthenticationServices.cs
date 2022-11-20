using Dapper;
using EMusic.Models.APIModels.Login;
using EMusic.Models.APIModels.Registration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EMusic.Services
{
    public interface IAuthenticationService {
        public LoginResponseModel LoginUser(LoginRequestModel loginRequestModel);
        public RegistrationResponseModel RegisterUser(RegistrationRequestModel registrationRequestModel);
    }

    public class AuthenticationServices: IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public string ConnectionString { get; }
        public string providerName { get; }
        public AuthenticationServices(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("EMusic");
            providerName = "System.Data.SqlClient";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        public LoginResponseModel LoginUser(LoginRequestModel loginRequestModel)
        {
            LoginResponseModel loginResponseModel = new LoginResponseModel();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    loginResponseModel = dbConnection.Query<LoginResponseModel>("Login_sp", loginRequestModel, commandType: CommandType.StoredProcedure).First();
                    dbConnection.Close();
                    return loginResponseModel;

                }
            }
            catch (Exception ex)
            {

                string errormsg = ex.Message;
                return loginResponseModel;
            }
            
        }

        public RegistrationResponseModel RegisterUser(RegistrationRequestModel registrationRequestModel)
        {
            RegistrationResponseModel registrationResponseModel = new RegistrationResponseModel();
            try
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    registrationResponseModel = dbConnection.Query<RegistrationResponseModel>("Register_sp", registrationRequestModel, commandType: CommandType.StoredProcedure).First();
                    dbConnection.Close();
                    return registrationResponseModel;
                }
            }catch(Exception ex)
            {
                string errormsg = ex.Message;
                return registrationResponseModel;
            }
        }
    }


   
}
