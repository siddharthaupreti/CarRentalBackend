using Dapper;
using EMusic.Models;
using EMusic.Models.APIModels.AdminUpdateUsers;
using EMusic.Models.APIModels.Login;
using EMusic.Models.APIModels.Registration;
using EMusic.Models.APIModels.ViewUsersAdmin;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Data;

namespace EMusic.Services
{
    public interface IAuthenticationService {
        public LoginResponseModel LoginUser(LoginRequestModel loginRequestModel);
        public RegistrationResponseModel RegisterUser(RegistrationRequestModel registrationRequestModel);
        public List<ViewUsersAdminResponse> ViewUsersAdmin(ViewUsersAdminRequest viewUsersAdminRequest);
        public List<AdminUpdateUsersResponse> AdminUpdateUsers(AdminUpdateUsersRequest adminUpdateUsersRequest);
    }

    public class AuthenticationServices: IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public string ConnectionString { get; }
        public string providerName { get; }
        public AuthenticationServices(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("HajurKoCarRentalDB3");
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
                    loginResponseModel = dbConnection.Query<LoginResponseModel>("Login", loginRequestModel, commandType: CommandType.StoredProcedure).First();
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
                    registrationResponseModel = dbConnection.Query<RegistrationResponseModel>("Registration", registrationRequestModel, commandType: CommandType.StoredProcedure).First();
                    dbConnection.Close();
                    return registrationResponseModel;
                }
            }catch(Exception ex)
            {
                string errormsg = ex.Message;
                return registrationResponseModel;
            }
        }

        public List<ViewUsersAdminResponse> ViewUsersAdmin(ViewUsersAdminRequest viewUsersAdminRequest)
        {
            List<ViewUsersAdminResponse> viewLessonsResponseModel = new List<ViewUsersAdminResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<ViewUsersAdminResponse>("ViewUsersAdmin", viewUsersAdminRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return viewLessonsResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return viewLessonsResponseModel;
            }
        }


        public List<AdminUpdateUsersResponse> AdminUpdateUsers(AdminUpdateUsersRequest adminUpdateUsersRequest)
        {
            List<AdminUpdateUsersResponse> viewLessonsResponseModel = new List<AdminUpdateUsersResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<AdminUpdateUsersResponse>("AdminUpdateUsers", adminUpdateUsersRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return viewLessonsResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return viewLessonsResponseModel;
            }
        }
    }
}
