using EMusic.Models;
using EMusic.Models.APIModels;
using EMusic.Models.APIModels.AddCourses;
using EMusic.Models.APIModels.AddLessons;
using EMusic.Models.APIModels.AddTeachers;
using EMusic.Models.APIModels.InstituteTeachers;
using EMusic.Models.APIModels.Login;
using EMusic.Models.APIModels.NotTeachersInstitute;
using EMusic.Models.APIModels.Registration;
using EMusic.Models.APIModels.StudentEnrolledCourses;
using EMusic.Models.APIModels.StudentEnrollmentApplication;
using EMusic.Models.APIModels.StudentTeachers;
using EMusic.Models.APIModels.TeacherCourses;
using EMusic.Models.APIModels.TeacherImageUpload;
using EMusic.Models.APIModels.TeacherProfile;
using EMusic.Models.APIModels.TeachersApplication;
using EMusic.Models.APIModels.TeachersInstitute;
using EMusic.Models.APIModels.TestVideo;
using EMusic.Models.APIModels.ViewInstitutesStudent;
using EMusic.Models.APIModels.ViewLessons;
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


        //api for Viewing Course
        [HttpGet]
        public IActionResult ViewCourse()
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<Course> courseResponseModel = _authenticationService.ViewCourse();
                    
                        responseModel = new ResponseModel()
                        {
                            data = courseResponseModel,
                            status = HttpStatusCode.OK
                        };
                    
                    //else
                    //{
                    //    responseModel = new ResponseModel() { data = registrationResponseModel, message = registrationResponseModel.Message, status = HttpStatusCode.NotFound };
                    //}
                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //api for Viewing Course
        [HttpGet]
        public IActionResult ViewInstitute()
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<Institute> courseResponseModel = _authenticationService.ViewInstitute();

                    responseModel = new ResponseModel()
                    {
                        data = courseResponseModel,
                        status = HttpStatusCode.OK
                    };

                    //else
                    //{
                    //    responseModel = new ResponseModel() { data = registrationResponseModel, message = registrationResponseModel.Message, status = HttpStatusCode.NotFound };
                    //}
                    return Ok(responseModel);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        //api for Viewing Teacher's institute
        [HttpPost]
        public IActionResult ViewTeachersInstitute([FromBody] TeachersInstituteRequest teachersInstituteRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<TeachersInstituteResponse> teachersInstituteResponseModel = _authenticationService.ViewTeachersInstitute(teachersInstituteRequest);
                   
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

        //api for Viewing not Teacher's institute
        [HttpPost]
        public IActionResult NotTeachersInstitute([FromBody] NotTeachersInstituteRequest notteachersInstituteRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<NotTeachersInstituteResponse> notteachersInstituteResponseModel = _authenticationService.NotTeachersInstitute(notteachersInstituteRequest);

                    responseModel = new ResponseModel()
                    {
                        data = notteachersInstituteResponseModel,
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


        //api for Uploading Teacher's application
        [HttpPost]
        public IActionResult TeachersApplication([FromBody] TeachersApplicationRequest teachersApplicationRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<TeachersApplicationResponse> teachersApplicationResponseModel = _authenticationService.TeachersApplication(teachersApplicationRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teachersApplicationResponseModel,
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

        //api for Testing Video
        [HttpPost]
        public IActionResult TestVideo([FromBody] TestVideoRequest testVideoRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<TestVideoResponse> testVideoResponseModel = _authenticationService.TestVideo(testVideoRequest);

                    responseModel = new ResponseModel()
                    {
                        data = testVideoResponseModel,
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

        //api for Teacher Courses
        [HttpPost]
        public IActionResult TeacherCourses([FromBody] TeacherCoursesRequest teacherCoursesRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<TeacherCoursesResponse> teacherCoursesResponseModel = _authenticationService.TeacherCourses(teacherCoursesRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teacherCoursesResponseModel,
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

        //api for Add Courses
        [HttpPost]
        public IActionResult AddCourses([FromBody] AddCoursesRequest addCoursesRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<AddCoursesResponse> addCoursesResponseModel = _authenticationService.AddCourses(addCoursesRequest);

                    responseModel = new ResponseModel()
                    {
                        data = addCoursesResponseModel,
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

        //api for View Lessons
        [HttpPost]
        public IActionResult ViewLessons([FromBody] ViewLessonsRequest viewLessonsRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<ViewLessonsResponse> viewLessonsResponseModel = _authenticationService.ViewLessons(viewLessonsRequest);

                    responseModel = new ResponseModel()
                    {
                        data = viewLessonsResponseModel,
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

        //api for View Lessons
        [HttpPost]
        public IActionResult AddLessons([FromBody] AddLessonsRequest addLessonsRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<AddLessonsResponse> addLessonsResponseModel = _authenticationService.AddLessons(addLessonsRequest);

                    responseModel = new ResponseModel()
                    {
                        data = addLessonsResponseModel,
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

        //api for Teacher Profile
        [HttpPost]
        public IActionResult TeacherProfile([FromBody] TeacherProfileRequest teacherProfileRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<TeacherProfileResponse> teacherProfileResponseModel = _authenticationService.TeacherProfile(teacherProfileRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teacherProfileResponseModel,
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


        //api for Teacher Image Upload
        [HttpPost]
        public IActionResult TeacherImageUpload([FromBody] TeacherImageUploadRequest teacherImageUploadRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<TeacherImageResponse> teacherImageUploadResponseModel = _authenticationService.TeacherImageUpload(teacherImageUploadRequest);

                    responseModel = new ResponseModel()
                    {
                        data = teacherImageUploadResponseModel,
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


        //api for Student Teachers
        [HttpPost]
        public IActionResult StudentTeachers([FromBody] StudentTeachersRequest studentTeachersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<StudentTeachersResponse> studentTeachersResponseModel = _authenticationService.StudentTeachers(studentTeachersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = studentTeachersResponseModel,
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


        //api for ViewInstitutesStudent
        [HttpPost]
        public IActionResult ViewInstitutesStudent([FromBody] ViewInstitutesStudentRequest viewInstitutesStudentRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<ViewInstitutesStudentResponse> viewInstitutesStudentResponseModel = _authenticationService.ViewInstitutesStudent(viewInstitutesStudentRequest);

                    responseModel = new ResponseModel()
                    {
                        data = viewInstitutesStudentResponseModel,
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
        public IActionResult InstituteTeachers([FromBody] InstituteTeachersRequest instituteTeachersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<InstituteTeachersResponse> instituteTeachersResponseModel = _authenticationService.InstituteTeachers(instituteTeachersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = instituteTeachersResponseModel,
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
        public IActionResult AddTeachers([FromBody] AddTeachersRequest addTeachersRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<AddTeachersResponse> addTeachersResponseModel = _authenticationService.AddTeachers(addTeachersRequest);

                    responseModel = new ResponseModel()
                    {
                        data = addTeachersResponseModel,
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
        public IActionResult StudentEnrolledCourses([FromBody] StudentEnrolledCoursesRequest studentEnrolledCoursesRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<StudentEnrolledCoursesResponse> studentEnrolledCoursesResponseModel = _authenticationService.StudentEnrolledCourses(studentEnrolledCoursesRequest);

                    responseModel = new ResponseModel()
                    {
                        data = studentEnrolledCoursesResponseModel,
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
        public IActionResult StudentUnenrolledCourses([FromBody] StudentEnrolledCoursesRequest studentUnenrolledCoursesRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<StudentEnrolledCoursesResponse> studentUnenrolledCoursesResponseModel = _authenticationService.StudentUnenrolledCourses(studentUnenrolledCoursesRequest);

                    responseModel = new ResponseModel()
                    {
                        data = studentUnenrolledCoursesResponseModel,
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

        //api for Student Profile
        [HttpPost]
        public IActionResult StudentProfile([FromBody] TeacherProfileRequest studentProfileRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<TeacherProfileResponse> studentProfileResponseModel = _authenticationService.StudentProfile(studentProfileRequest);

                    responseModel = new ResponseModel()
                    {
                        data = studentProfileResponseModel,
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

        //api for Student Image Upload
        [HttpPost]
        public IActionResult StudentImageUpload([FromBody] TeacherImageUploadRequest studentImageUploadRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<TeacherImageResponse> studentImageUploadResponseModel = _authenticationService.StudentImageUpload(studentImageUploadRequest);

                    responseModel = new ResponseModel()
                    {
                        data = studentImageUploadResponseModel,
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

        //api for Student Enrollment Application
        [HttpPost]
        public IActionResult StudentEnrollmentApplication([FromBody] StudentEnrollmentApplicationRequest studentEnrollmentApplicationRequest)
        {
            ResponseModel responseModel = new ResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    List<StudentEnrollmentApplicationResponse> studentEnrollmentApplicationResponseModel = _authenticationService.StudentEnrollmentApplication(studentEnrollmentApplicationRequest);

                    responseModel = new ResponseModel()
                    {
                        data = studentEnrollmentApplicationResponseModel,
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
