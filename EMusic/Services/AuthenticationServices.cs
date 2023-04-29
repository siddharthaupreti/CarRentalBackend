﻿using Dapper;
using EMusic.Models;
using EMusic.Models.APIModels.AddAttachment;
using EMusic.Models.APIModels.AdminUpdateUsers;
using EMusic.Models.APIModels.ChangePassword;
using EMusic.Models.APIModels.Login;
using EMusic.Models.APIModels.Registration;
using EMusic.Models.APIModels.ViewAttachmentByID;
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
        public List<ChangePasswordResponse> ChangePassword(ChangePasswordRequest changePasswordRequest);
        public List<AddAttachmentResponse> AddAttachment(AddAttachmentRequest addAttachmentRequest);
        public List<ViewAttachmentByIDResponse> ViewAttachmentByID(ViewAttachmentByIDRequest viewAttachmentByIDRequest);

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


        public List<ChangePasswordResponse> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            List<ChangePasswordResponse> viewLessonsResponseModel = new List<ChangePasswordResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<ChangePasswordResponse>("ChangePassword", changePasswordRequest, commandType: CommandType.StoredProcedure).ToList();
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

        public List<AddAttachmentResponse> AddAttachment(AddAttachmentRequest changePasswordRequest)
        {
            List<AddAttachmentResponse> viewLessonsResponseModel = new List<AddAttachmentResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<AddAttachmentResponse>("AddAttachement", changePasswordRequest, commandType: CommandType.StoredProcedure).ToList();
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

        public List<ViewAttachmentByIDResponse> ViewAttachmentByID(ViewAttachmentByIDRequest changePasswordRequest)
        {
            List<ViewAttachmentByIDResponse> viewLessonsResponseModel = new List<ViewAttachmentByIDResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<ViewAttachmentByIDResponse>("ViewAttachmentByID", changePasswordRequest, commandType: CommandType.StoredProcedure).ToList();
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
