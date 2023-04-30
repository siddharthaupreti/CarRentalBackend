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


    }
}
