using EMusic.Models;
using EMusic.Models.APIModels;
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
using EMusic.Services;
using HajurKoCarRental.Models.APIModels.ChangeReturnStatusRentHistory;
using HajurKoCarRental.Models.APIModels.CreateApproval;
using HajurKoCarRental.Models.APIModels.CreateDamageLog;
using HajurKoCarRental.Models.APIModels.CreatePayment;
using HajurKoCarRental.Models.APIModels.CreateRentHistory;
using HajurKoCarRental.Models.APIModels.DamageLogSetPayed;
using HajurKoCarRental.Models.APIModels.DeleteApprovalRequests;
using HajurKoCarRental.Models.APIModels.DeleteCarRecord;
using HajurKoCarRental.Models.APIModels.GetAllApproval;
using HajurKoCarRental.Models.APIModels.GetAllRentHistory;
using HajurKoCarRental.Models.APIModels.GetDamageLogByUserID;
using HajurKoCarRental.Models.APIModels.GetPaymentByID;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMusic.Controllers.Authentication
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IConfiguration configuration, IAuthenticationService authenticationService)
        {
            _configuration= configuration;
            _authenticationService= authenticationService;
        }

        //api for log in
        [HttpPost]
        public IActionResult LoginUser([FromBody] LoginRequestModel loginRequestModel)
        {
            ResponseModel response = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                 {
                    LoginResponseModel loginResponseModel= _authenticationService.LoginUser(loginRequestModel);

                    if (loginResponseModel.Status == "Success")
                    {
                        loginResponseModel.UserToken = TokenManager.GenerateToken(loginResponseModel.PhoneNumber);

                        response = new ResponseModel() {
                            data = loginResponseModel, message = loginResponseModel.Message, status = HttpStatusCode.OK };
                    } else
                    {
                        response = new ResponseModel() { data = loginResponseModel, message = loginResponseModel.Message, status = HttpStatusCode.NotFound };                 
                    }
                    return Ok(response);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //api for registration
        [HttpPost]
        public  IActionResult Registration([FromBody] RegistrationRequestModel registrationRequestModel)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    RegistrationResponseModel registrationResponseModel = _authenticationService.RegisterUser(registrationRequestModel);
                    if(registrationResponseModel.Status == "Success")
                    {
                        responseModel = new ResponseModel() {
                        data=registrationResponseModel, message=registrationResponseModel.Message, status=HttpStatusCode.OK
                        };
                    } else
                    {
                        responseModel = new ResponseModel() { data = registrationResponseModel, message = registrationResponseModel.Message, status = HttpStatusCode.NotFound };
                    }
                    return Ok(responseModel);
                }catch(Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //api for Viewing Users by admin
        [HttpPost]
        public IActionResult ViewUsersAdmin([FromBody] ViewUsersAdminRequest viewUsersAdminRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<ViewUsersAdminResponse> teachersInstituteResponseModel = _authenticationService.ViewUsersAdmin(viewUsersAdminRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersInstituteResponseModel,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        //api for updating users details
        [HttpPost]
        public IActionResult AdminUpdateUsers([FromBody] AdminUpdateUsersRequest adminUpdateUsersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<AdminUpdateUsersResponse> teachersInstituteResponseModel = _authenticationService.AdminUpdateUsers(adminUpdateUsersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersInstituteResponseModel,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //api for changing user's password
        [HttpPost]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest adminUpdateUsersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<ChangePasswordResponse> teachersInstituteResponseModel = _authenticationService.ChangePassword(adminUpdateUsersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersInstituteResponseModel,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //api for adding user's attachment

        [HttpPost]
        public IActionResult AddAttachment([FromBody] AddAttachmentRequest adminUpdateUsersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<AddAttachmentResponse> teachersInstituteResponseModel = _authenticationService.AddAttachment(adminUpdateUsersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersInstituteResponseModel,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        //api for adding user's attachment

        [HttpPost]
        public IActionResult ViewAttachmentByID([FromBody] ViewAttachmentByIDRequest adminUpdateUsersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<ViewAttachmentByIDResponse> teachersInstituteResponseModel = _authenticationService.ViewAttachmentByID(adminUpdateUsersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersInstituteResponseModel,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //api for Creating Car

        [HttpPost]
        public IActionResult CreateCar([FromBody] CreateCarRequest adminUpdateUsersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<CreateCarResponse> teachersInstituteResponseModel = _authenticationService.CreateCar(adminUpdateUsersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersInstituteResponseModel,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //api for getting all Cars

        [HttpPost]
        public IActionResult GetAllCars([FromBody] GetAllCarsRequest adminUpdateUsersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<GetAllCarsResponse> teachersInstituteResponseModel = _authenticationService.GetAllCars(adminUpdateUsersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersInstituteResponseModel,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        //api for updating car's status

        [HttpPost]
        public IActionResult UpdateCarStatus([FromBody] UpdateCarStatusRequest adminUpdateUsersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<UpdateCarStatusResponse> teachersInstituteResponseModel = _authenticationService.UpdateCarStatus(adminUpdateUsersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersInstituteResponseModel,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult UpdateCarDetails([FromBody] UpdateCarDetailsRequest adminUpdateUsersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<UpdateCarDetailsResponse> teachersInstituteResponseModel = _authenticationService.UpdateCarDetails(adminUpdateUsersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersInstituteResponseModel,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult GetUserById([FromBody] GetUserDetailsByIDRequest adminUpdateUsersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<GetUserDetailsByIDResponse> teachersInstituteResponseModel = _authenticationService.GetUserById(adminUpdateUsersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersInstituteResponseModel,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult GetCarById([FromBody] GetCarByIdRequest getCarByIdRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<GetCarByIdResponse> getCarByIdResponses = _authenticationService.GetCarById(getCarByIdRequest);

                    responseModel = new ResponseModel()
                    {
                        data = getCarByIdResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult CreateRentHistory([FromBody] CreateRentHistoryRequest createRentHistoryRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<CreateRentHistoryResponse> createRentHistoryResponses = _authenticationService.CreateRentHistory(createRentHistoryRequest);

                    responseModel = new ResponseModel()
                    {
                        data = createRentHistoryResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult GetAllRentHistory([FromBody] GetAllRentHistoryRequest getAllRentHistoryRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<GetAllRentHistoryResponse> getAllRentHistoryResponses = _authenticationService.GetAllRentHistory(getAllRentHistoryRequest);

                    responseModel = new ResponseModel()
                    {
                        data = getAllRentHistoryResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }



        [HttpPost]
        public IActionResult GetRentHistoryByUserID([FromBody] GetAllRentHistoryRequest getAllRentHistoryRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<GetAllRentHistoryResponse> getAllRentHistoryResponses = _authenticationService.GetRentHistoryByUserID(getAllRentHistoryRequest);

                    responseModel = new ResponseModel()
                    {
                        data = getAllRentHistoryResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult ChangeReturnStatusRentHistory([FromBody] ChangeReturnStatusRentHistoryRequest changeReturnStatusRentHistoryRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<ChangeReturnStatusRentHistoryResponse> changeReturnStatusRentHistoryResponses = _authenticationService.ChangeReturnStatusRentHistory(changeReturnStatusRentHistoryRequest);

                    responseModel = new ResponseModel()
                    {
                        data = changeReturnStatusRentHistoryResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateDamageLog([FromBody] CreateDamageLogRequest createDamageLogRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<CreateDamageLogResponse> createDamageLogResponses = _authenticationService.CreateDamageLog(createDamageLogRequest);

                    responseModel = new ResponseModel()
                    {
                        data = createDamageLogResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult GetDamageLogByUserID([FromBody] GetDamageLogByUserIDRequest getDamageLogByUserIDRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<GetDamageLogByUserIDResponse> getDamageLogByUserIDResponses = _authenticationService.GetDamageLogByUserID(getDamageLogByUserIDRequest);

                    responseModel = new ResponseModel()
                    {
                        data = getDamageLogByUserIDResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult DamageLogSetPayed([FromBody] DamageLogSetPayedRequest damageLogSetPayedRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<DamageLogSetPayedResponse> damageLogSetPayedResponses = _authenticationService.DamageLogSetPayed(damageLogSetPayedRequest);

                    responseModel = new ResponseModel()
                    {
                        data = damageLogSetPayedResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }



        [HttpPost]
        public IActionResult DeleteCarRecord([FromBody] DeleteCarRecordRequest deleteCarRecordRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<DeleteCarResponse> deleteCarResponses = _authenticationService.DeleteCarRecord(deleteCarRecordRequest);

                    responseModel = new ResponseModel()
                    {
                        data = deleteCarResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateApprovalRequest([FromBody] CreateApprovalRequest createApprovalRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<CreateApprovalResponse> createApprovalResponses = _authenticationService.CreateApprovalRequest(createApprovalRequest);

                    responseModel = new ResponseModel()
                    {
                        data = createApprovalResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult CreatePayment([FromBody] CreatePaymentRequest createPaymentRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<CreatePaymentResponse> createPaymentResponses = _authenticationService.CreatePayment(createPaymentRequest);

                    responseModel = new ResponseModel()
                    {
                        data = createPaymentResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult GetAllApprovalRequests([FromBody] GetAllApprovalRequest getAllApprovalRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<GetAllApprovalResponse> getAllApprovalResponses = _authenticationService.GetAllApprovalRequests(getAllApprovalRequest);

                    responseModel = new ResponseModel()
                    {
                        data = getAllApprovalResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult DeleteApprovalRequests([FromBody] DeleteApprovalRequest deleteApprovalRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<DeleteApprovalResponse> deleteApprovalResponses = _authenticationService.DeleteApprovalRequests(deleteApprovalRequest);

                    responseModel = new ResponseModel()
                    {
                        data = deleteApprovalResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult GetPaymentByID([FromBody] GetPaymentByIDRequest getPaymentByIDRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<GetPaymentByIDResponse> getPaymentByIDResponses = _authenticationService.GetPaymentByID(getPaymentByIDRequest);

                    responseModel = new ResponseModel()
                    {
                        data = getPaymentByIDResponses,
                        status = HttpStatusCode.OK
                    };

                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }





    }
}
