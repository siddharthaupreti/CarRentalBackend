﻿using Dapper;
using EMusic.Models;
using EMusic.Models.APIModels.AddAttachment;
using EMusic.Models.APIModels.AdminUpdateUsers;
using EMusic.Models.APIModels.ChangePassword;
using EMusic.Models.APIModels.CreateCar;
using EMusic.Models.APIModels.GetAllCars;
using EMusic.Models.APIModels.GetCarById;
using EMusic.Models.APIModels.GetUserDetailsByID;
using EMusic.Models.APIModels.Login;
using EMusic.Models.APIModels.Registration;
using EMusic.Models.APIModels.UpdateCarDetails;
using EMusic.Models.APIModels.UpdateCarStatus;
using EMusic.Models.APIModels.ViewAttachmentByID;
using EMusic.Models.APIModels.ViewUsersAdmin;
using HajurKoCarRental.Models.APIModels.ChangeReturnStatusRentHistory;
using HajurKoCarRental.Models.APIModels.CreateApproval;
using HajurKoCarRental.Models.APIModels.CreateDamageLog;
using HajurKoCarRental.Models.APIModels.CreateNotification;
using HajurKoCarRental.Models.APIModels.CreatePayment;
using HajurKoCarRental.Models.APIModels.CreateRentHistory;
using HajurKoCarRental.Models.APIModels.DamageLogSetPayed;
using HajurKoCarRental.Models.APIModels.DeleteApprovalRequests;
using HajurKoCarRental.Models.APIModels.DeleteCarRecord;
using HajurKoCarRental.Models.APIModels.DeleteNotificationByID;
using HajurKoCarRental.Models.APIModels.GetAllApproval;
using HajurKoCarRental.Models.APIModels.GetAllRentHistory;
using HajurKoCarRental.Models.APIModels.GetDamageLogByUserID;
using HajurKoCarRental.Models.APIModels.GetNotificationByID;
using HajurKoCarRental.Models.APIModels.GetPaymentByID;
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
        public List<CreateCarResponse> CreateCar(CreateCarRequest viewAttachmentByIDRequest);
        public List<GetAllCarsResponse> GetAllCars(GetAllCarsRequest getAllCarsRequest);
        public List<UpdateCarStatusResponse> UpdateCarStatus(UpdateCarStatusRequest getAllCarsRequest);
        public List<UpdateCarDetailsResponse> UpdateCarDetails(UpdateCarDetailsRequest getAllCarsRequest);
        public List<GetUserDetailsByIDResponse> GetUserById(GetUserDetailsByIDRequest getAllCarsRequest);
        public List<GetCarByIdResponse> GetCarById(GetCarByIdRequest getCarByIdRequest);
        public List<CreateRentHistoryResponse> CreateRentHistory(CreateRentHistoryRequest createRentHistoryRequest);
        public List<GetAllRentHistoryResponse> GetAllRentHistory(GetAllRentHistoryRequest getAllRentHistoryRequest);
        public List<GetAllRentHistoryResponse> GetRentHistoryByUserID(GetAllRentHistoryRequest getAllRentHistoryRequest);
        public List<ChangeReturnStatusRentHistoryResponse> ChangeReturnStatusRentHistory(ChangeReturnStatusRentHistoryRequest getAllRentHistoryRequest);
        public List<CreateDamageLogResponse> CreateDamageLog(CreateDamageLogRequest createDamageLogRequest);
        public List<GetDamageLogByUserIDResponse> GetDamageLogByUserID(GetDamageLogByUserIDRequest getDamageLogByUserID);
        public List<DamageLogSetPayedResponse> DamageLogSetPayed(DamageLogSetPayedRequest damageLogSetPayedRequest);
        public List<DeleteCarResponse> DeleteCarRecord(DeleteCarRecordRequest deleteCarRecordRequest);
        public List<CreateApprovalResponse> CreateApprovalRequest(CreateApprovalRequest createApprovalRequest);
        public List<CreatePaymentResponse> CreatePayment(CreatePaymentRequest createPaymentRequest);
        public List<GetAllApprovalResponse> GetAllApprovalRequests(GetAllApprovalRequest getAllApprovalRequest);
        public List<DeleteApprovalResponse> DeleteApprovalRequests(DeleteApprovalRequest deleteApprovalRequest);
        public List<GetPaymentByIDResponse> GetPaymentByID(GetPaymentByIDRequest getPaymentByIDRequest);
        public List<CreateNotificationResponse> CreateNotification(CreateNotificationRequest createNotificationRequest);
        public List<GetNotificationByIDResponse> GetNotificationByID(GetNotificationByIDRequest getNotificationByIDRequest);
        public List<DeleteNotificationByIDResponse> DeleteNotificationByID(DeleteNotificationByIDRequest deleteNotificationByIDRequest);

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


        public List<CreateCarResponse> CreateCar(CreateCarRequest changePasswordRequest)
        {
            List<CreateCarResponse> viewLessonsResponseModel = new List<CreateCarResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<CreateCarResponse>("CreateCar", changePasswordRequest, commandType: CommandType.StoredProcedure).ToList();
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



        public List<GetAllCarsResponse> GetAllCars(GetAllCarsRequest changePasswordRequest)
        {
            List<GetAllCarsResponse> viewLessonsResponseModel = new List<GetAllCarsResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<GetAllCarsResponse>("GetAllCars", changePasswordRequest, commandType: CommandType.StoredProcedure).ToList();
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

        public List<UpdateCarStatusResponse> UpdateCarStatus(UpdateCarStatusRequest changePasswordRequest)
        {
            List<UpdateCarStatusResponse> viewLessonsResponseModel = new List<UpdateCarStatusResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<UpdateCarStatusResponse>("UpdateCarStatus", changePasswordRequest, commandType: CommandType.StoredProcedure).ToList();
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

        public List<UpdateCarDetailsResponse> UpdateCarDetails(UpdateCarDetailsRequest changePasswordRequest)
        {
            List<UpdateCarDetailsResponse> viewLessonsResponseModel = new List<UpdateCarDetailsResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<UpdateCarDetailsResponse>("UpdateCarDetails", changePasswordRequest, commandType: CommandType.StoredProcedure).ToList();
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


        public List<GetUserDetailsByIDResponse> GetUserById(GetUserDetailsByIDRequest changePasswordRequest)
        {
            List<GetUserDetailsByIDResponse> viewLessonsResponseModel = new List<GetUserDetailsByIDResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<GetUserDetailsByIDResponse>("GetUserById", changePasswordRequest, commandType: CommandType.StoredProcedure).ToList();
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


        public List<GetCarByIdResponse> GetCarById(GetCarByIdRequest getCarByIdRequest)
        {
            List<GetCarByIdResponse> getCarByIdResponseModel = new List<GetCarByIdResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    getCarByIdResponseModel = dbConnection.Query<GetCarByIdResponse>("GetCarById", getCarByIdRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return getCarByIdResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return getCarByIdResponseModel;
            }
        }


        public List<CreateRentHistoryResponse> CreateRentHistory(CreateRentHistoryRequest createRentHistoryRequest)
        {
            List<CreateRentHistoryResponse> createRentHistoryResponses = new List<CreateRentHistoryResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    createRentHistoryResponses = dbConnection.Query<CreateRentHistoryResponse>("CreateRentHistory", createRentHistoryRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return createRentHistoryResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return createRentHistoryResponses;
            }
        }


        public List<GetAllRentHistoryResponse> GetAllRentHistory(GetAllRentHistoryRequest getAllRentHistoryRequest)
        {
            List<GetAllRentHistoryResponse> getAllRentHistoryResponses = new List<GetAllRentHistoryResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    getAllRentHistoryResponses = dbConnection.Query<GetAllRentHistoryResponse>("GetAllRentHistory", getAllRentHistoryRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return getAllRentHistoryResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return getAllRentHistoryResponses;
            }
        }

        public List<GetAllRentHistoryResponse> GetRentHistoryByUserID(GetAllRentHistoryRequest getAllRentHistoryRequest)
        {
            List<GetAllRentHistoryResponse> getAllRentHistoryResponses = new List<GetAllRentHistoryResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    getAllRentHistoryResponses = dbConnection.Query<GetAllRentHistoryResponse>("GetRentHistoryByUserID", getAllRentHistoryRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return getAllRentHistoryResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return getAllRentHistoryResponses;
            }
        }

        public List<ChangeReturnStatusRentHistoryResponse> ChangeReturnStatusRentHistory(ChangeReturnStatusRentHistoryRequest getAllRentHistoryRequest)
        {
            List<ChangeReturnStatusRentHistoryResponse> changeReturnStatusRentHistoryResponses = new List<ChangeReturnStatusRentHistoryResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    changeReturnStatusRentHistoryResponses = dbConnection.Query<ChangeReturnStatusRentHistoryResponse>("ChangeReturnStatusRentHistory", getAllRentHistoryRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return changeReturnStatusRentHistoryResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return changeReturnStatusRentHistoryResponses;
            }
        }

        public List<CreateDamageLogResponse> CreateDamageLog(CreateDamageLogRequest createDamageLogRequest)
        {
            List<CreateDamageLogResponse> createDamageLogResponses = new List<CreateDamageLogResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    createDamageLogResponses = dbConnection.Query<CreateDamageLogResponse>("CreateDamageLog", createDamageLogRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return createDamageLogResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return createDamageLogResponses;
            }
        }

        public List<GetDamageLogByUserIDResponse> GetDamageLogByUserID(GetDamageLogByUserIDRequest getDamageLogByUserID)
        {
            List<GetDamageLogByUserIDResponse> getDamageLogByUserIDResponses = new List<GetDamageLogByUserIDResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    getDamageLogByUserIDResponses = dbConnection.Query<GetDamageLogByUserIDResponse>("GetDamageLogByUserID", getDamageLogByUserID, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return getDamageLogByUserIDResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return getDamageLogByUserIDResponses;
            }
        }

        public List<DamageLogSetPayedResponse> DamageLogSetPayed(DamageLogSetPayedRequest damageLogSetPayedRequest)
        {
            List<DamageLogSetPayedResponse> damageLogSetPayedResponses = new List<DamageLogSetPayedResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    damageLogSetPayedResponses = dbConnection.Query<DamageLogSetPayedResponse>("DamageLogSetPayed", damageLogSetPayedRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return damageLogSetPayedResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return damageLogSetPayedResponses;
            }
        }

        public List<DeleteCarResponse> DeleteCarRecord(DeleteCarRecordRequest deleteCarRecordRequest)
        {
            List<DeleteCarResponse> deleteCarResponses = new List<DeleteCarResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    deleteCarResponses = dbConnection.Query<DeleteCarResponse>("DeleteCarRecord", deleteCarRecordRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return deleteCarResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return deleteCarResponses;
            }
        }


        public List<CreateApprovalResponse> CreateApprovalRequest(CreateApprovalRequest createApprovalRequest)
        {
            List<CreateApprovalResponse> createApprovalResponses = new List<CreateApprovalResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    createApprovalResponses = dbConnection.Query<CreateApprovalResponse>("CreateApprovalRequest", createApprovalRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return createApprovalResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return createApprovalResponses;
            }
        }

        public List<CreatePaymentResponse> CreatePayment(CreatePaymentRequest createPaymentRequest)
        {
            List<CreatePaymentResponse> createApprovalResponses = new List<CreatePaymentResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    createApprovalResponses = dbConnection.Query<CreatePaymentResponse>("CreatePayment", createPaymentRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return createApprovalResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return createApprovalResponses;
            }
        }
        public List<GetAllApprovalResponse> GetAllApprovalRequests(GetAllApprovalRequest getAllApprovalRequest)
        {
            List<GetAllApprovalResponse> getAllApprovalResponses = new List<GetAllApprovalResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    getAllApprovalResponses = dbConnection.Query<GetAllApprovalResponse>("GetAllApprovalRequests", getAllApprovalRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return getAllApprovalResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return getAllApprovalResponses;
            }
        }
        public List<DeleteApprovalResponse> DeleteApprovalRequests(DeleteApprovalRequest deleteApprovalRequest)
        {
            List<DeleteApprovalResponse> deleteApprovalResponses = new List<DeleteApprovalResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    deleteApprovalResponses = dbConnection.Query<DeleteApprovalResponse>("DeleteApprovalRequests", deleteApprovalRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return deleteApprovalResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return deleteApprovalResponses;
            }
        }

        public List<GetPaymentByIDResponse> GetPaymentByID(GetPaymentByIDRequest getPaymentByIDRequest)
        {
            List<GetPaymentByIDResponse> getPaymentByIDResponses = new List<GetPaymentByIDResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    getPaymentByIDResponses = dbConnection.Query<GetPaymentByIDResponse>("GetPaymentByID", getPaymentByIDRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return getPaymentByIDResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return getPaymentByIDResponses;
            }
        }


        public List<CreateNotificationResponse> CreateNotification(CreateNotificationRequest createNotificationRequest)
        {
            List<CreateNotificationResponse> getPaymentByIDResponses = new List<CreateNotificationResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    getPaymentByIDResponses = dbConnection.Query<CreateNotificationResponse>("CreateNotification", createNotificationRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return getPaymentByIDResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return getPaymentByIDResponses;
            }
        }

        public List<GetNotificationByIDResponse> GetNotificationByID(GetNotificationByIDRequest getNotificationByIDRequest)
        {
            List<GetNotificationByIDResponse> getNotificationByIDResponses = new List<GetNotificationByIDResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    getNotificationByIDResponses = dbConnection.Query<GetNotificationByIDResponse>("GetNotificationByID", getNotificationByIDRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return getNotificationByIDResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return getNotificationByIDResponses;
            }
        }

        public List<DeleteNotificationByIDResponse> DeleteNotificationByID(DeleteNotificationByIDRequest deleteNotificationByIDRequest)
        {
            List<DeleteNotificationByIDResponse> deleteNotificationByIDResponses = new List<DeleteNotificationByIDResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    deleteNotificationByIDResponses = dbConnection.Query<DeleteNotificationByIDResponse>("DeleteNotificationByID", deleteNotificationByIDRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return deleteNotificationByIDResponses;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return deleteNotificationByIDResponses;
            }
        }

    }
}
