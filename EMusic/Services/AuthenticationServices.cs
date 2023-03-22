using Dapper;
using EMusic.Models;
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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Data;

namespace EMusic.Services
{
    public interface IAuthenticationService {
        public LoginResponseModel LoginUser(LoginRequestModel loginRequestModel);
        public RegistrationResponseModel RegisterUser(RegistrationRequestModel registrationRequestModel);
        public List<Course> ViewCourse();
        public List<Institute> ViewInstitute();
        public List<TeachersInstituteResponse> ViewTeachersInstitute(TeachersInstituteRequest teachersInstituteRequestModel);
        public List<NotTeachersInstituteResponse> NotTeachersInstitute(NotTeachersInstituteRequest notteachersInstituteRequestModel);
        public List<TeachersApplicationResponse> TeachersApplication(TeachersApplicationRequest teachersApplicationRequestModel);
        public List<TestVideoResponse> TestVideo(TestVideoRequest testVideoRequestModel);
        public List<TeacherCoursesResponse> TeacherCourses(TeacherCoursesRequest teacherCoursesRequestModel);
        public List<AddCoursesResponse> AddCourses(AddCoursesRequest addCoursesRequest);
        public List<ViewLessonsResponse> ViewLessons(ViewLessonsRequest viewLessonsRequestModel);
        public List<AddLessonsResponse> AddLessons(AddLessonsRequest addLessonsRequestModel);
        public List<TeacherProfileResponse> TeacherProfile(TeacherProfileRequest teacherProfileRequest);
        public List<TeacherImageResponse> TeacherImageUpload(TeacherImageUploadRequest teacherImageUploadRequest);
        public List<StudentTeachersResponse> StudentTeachers(StudentTeachersRequest studentTeachersRequest);
        public List<ViewInstitutesStudentResponse> ViewInstitutesStudent(ViewInstitutesStudentRequest viewInstitutesStudentRequest);
        public List<InstituteTeachersResponse> InstituteTeachers(InstituteTeachersRequest instituteTeachersRequest);
        public List<AddTeachersResponse> AddTeachers(AddTeachersRequest addTeachersRequest);
        public List<StudentEnrolledCoursesResponse> StudentEnrolledCourses(StudentEnrolledCoursesRequest studentEnrolledCoursesRequest);
        public List<StudentEnrolledCoursesResponse> StudentUnenrolledCourses(StudentEnrolledCoursesRequest studentEnrolledCoursesRequest);
        public List<TeacherProfileResponse> StudentProfile(TeacherProfileRequest teacherProfileRequest);
        public List<TeacherImageResponse> StudentImageUpload(TeacherImageUploadRequest teacherImageUploadRequest);
        public List<StudentEnrollmentApplicationResponse> StudentEnrollmentApplication(StudentEnrollmentApplicationRequest studentEnrollmentApplicationRequest);
        public List<TeacherProfileResponse> InstituteProfile(TeacherProfileRequest teacherProfileRequest);
        public List<TeacherImageResponse> InstituteImageUpload(TeacherImageUploadRequest teacherImageUploadRequest);

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
        public List<Course> ViewCourse()
        {
            List<Course> courseResponse = new List<Course>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    courseResponse = dbConnection.Query<Course>("ViewCourse", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return courseResponse;

                }
            }
            catch (Exception ex)
            {

                string errormsg = ex.Message;
                return courseResponse;
            }


        }

        public List<Institute> ViewInstitute()
        {
            List<Institute> instituteResponse = new List<Institute>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    instituteResponse = dbConnection.Query<Institute>("ViewInstitutes", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return instituteResponse;

                }
            }
            catch (Exception ex)
            {

                string errormsg = ex.Message;
                return instituteResponse;
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


        public List<TeachersInstituteResponse> ViewTeachersInstitute(TeachersInstituteRequest teachersInstituteRequestModel)
        {
            List<TeachersInstituteResponse> teacherInstituteResponseModel = new List<TeachersInstituteResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    teacherInstituteResponseModel = dbConnection.Query<TeachersInstituteResponse>("TeachersInstitute", teachersInstituteRequestModel, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return teacherInstituteResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return teacherInstituteResponseModel;
            }
        }

        public List<NotTeachersInstituteResponse> NotTeachersInstitute(NotTeachersInstituteRequest notteachersInstituteRequestModel)
        {
            List<NotTeachersInstituteResponse> notteacherInstituteResponseModel = new List<NotTeachersInstituteResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    notteacherInstituteResponseModel = dbConnection.Query<NotTeachersInstituteResponse>("NotTeachersInstitute", notteachersInstituteRequestModel, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return notteacherInstituteResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return notteacherInstituteResponseModel;
            }
        }

        public List<TeachersApplicationResponse> TeachersApplication(TeachersApplicationRequest teachersApplicationRequestModel)
        {
            List<TeachersApplicationResponse> teachersApplicationResponseModel = new List<TeachersApplicationResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    teachersApplicationResponseModel = dbConnection.Query<TeachersApplicationResponse>("TeachersApplication", teachersApplicationRequestModel, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return teachersApplicationResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return teachersApplicationResponseModel;
            }
        }

        public List<TestVideoResponse> TestVideo(TestVideoRequest testVideoRequestModel)
        {
            List<TestVideoResponse> testVideoResponseModel = new List<TestVideoResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    testVideoResponseModel = dbConnection.Query<TestVideoResponse>("TestVideo", testVideoRequestModel, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return testVideoResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return testVideoResponseModel;
            }
        }

        public List<TeacherCoursesResponse> TeacherCourses(TeacherCoursesRequest teacherCoursesRequest)
        {
            List<TeacherCoursesResponse> teacherCoursesResponseModel = new List<TeacherCoursesResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    teacherCoursesResponseModel = dbConnection.Query<TeacherCoursesResponse>("TeacherCourses", teacherCoursesRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return teacherCoursesResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return teacherCoursesResponseModel;
            }
        }


        public List<AddCoursesResponse> AddCourses(AddCoursesRequest addCoursesRequest)
        {
            List<AddCoursesResponse> addCoursesResponseModel = new List<AddCoursesResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    addCoursesResponseModel = dbConnection.Query<AddCoursesResponse>("AddCourses", addCoursesRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return addCoursesResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return addCoursesResponseModel;
            }
        }

        public List<ViewLessonsResponse> ViewLessons(ViewLessonsRequest viewLessonsRequest)
        {
            List<ViewLessonsResponse> viewLessonsResponseModel = new List<ViewLessonsResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewLessonsResponseModel = dbConnection.Query<ViewLessonsResponse>("ViewLessons", viewLessonsRequest, commandType: CommandType.StoredProcedure).ToList();
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

        public List<AddLessonsResponse> AddLessons(AddLessonsRequest addLessonsRequest)
        {
            List<AddLessonsResponse> addLessonsResponseModel = new List<AddLessonsResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    addLessonsResponseModel = dbConnection.Query<AddLessonsResponse>("AddLessons", addLessonsRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return addLessonsResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return addLessonsResponseModel;
            }
        }

        public List<TeacherProfileResponse> TeacherProfile(TeacherProfileRequest teacherProfileRequest)
        {
            List<TeacherProfileResponse> teacherProfileResponseModel = new List<TeacherProfileResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    teacherProfileResponseModel = dbConnection.Query<TeacherProfileResponse>("TeacherProfile", teacherProfileRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return teacherProfileResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return teacherProfileResponseModel;
            }
        }

        public List<TeacherImageResponse> TeacherImageUpload(TeacherImageUploadRequest teacherImageUploadRequest)
        {
            List<TeacherImageResponse> teacherImageUploadResponseModel = new List<TeacherImageResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    teacherImageUploadResponseModel = dbConnection.Query<TeacherImageResponse>("TeacherImageUpload", teacherImageUploadRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return teacherImageUploadResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return teacherImageUploadResponseModel;
            }
        }

        public List<StudentTeachersResponse> StudentTeachers(StudentTeachersRequest studentTeachersRequest)
        {
            List<StudentTeachersResponse> studentTeachersResponseModel = new List<StudentTeachersResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    studentTeachersResponseModel = dbConnection.Query<StudentTeachersResponse>("StudentTeachers", studentTeachersRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return studentTeachersResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return studentTeachersResponseModel;
            }
        }

        public List<ViewInstitutesStudentResponse> ViewInstitutesStudent(ViewInstitutesStudentRequest viewInstitutesStudentRequest)
        {
            List<ViewInstitutesStudentResponse> viewInstitutesStudentResponseModel = new List<ViewInstitutesStudentResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    viewInstitutesStudentResponseModel = dbConnection.Query<ViewInstitutesStudentResponse>("ViewInstitutesStudent", viewInstitutesStudentRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return viewInstitutesStudentResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return viewInstitutesStudentResponseModel;
            }
        }

        public List<InstituteTeachersResponse> InstituteTeachers(InstituteTeachersRequest instituteTeachersRequest)
        {
            List<InstituteTeachersResponse> instituteTeachersResponseModel = new List<InstituteTeachersResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    instituteTeachersResponseModel = dbConnection.Query<InstituteTeachersResponse>("InstituteTeachers", instituteTeachersRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return instituteTeachersResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return instituteTeachersResponseModel;
            }
        }

        public List<AddTeachersResponse> AddTeachers(AddTeachersRequest addTeachersRequest)
        {
            List<AddTeachersResponse> addTeachersResponseModel = new List<AddTeachersResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    addTeachersResponseModel = dbConnection.Query<AddTeachersResponse>("AddTeachers", addTeachersRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return addTeachersResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return addTeachersResponseModel;
            }
        }

        public List<StudentEnrolledCoursesResponse> StudentEnrolledCourses(StudentEnrolledCoursesRequest studentEnrolledCoursesRequest)
        {
            List<StudentEnrolledCoursesResponse> studentEnrolledCoursesResponseModel = new List<StudentEnrolledCoursesResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    studentEnrolledCoursesResponseModel = dbConnection.Query<StudentEnrolledCoursesResponse>("StudentEnrolledCourses", studentEnrolledCoursesRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return studentEnrolledCoursesResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return studentEnrolledCoursesResponseModel;
            }
        }

        public List<StudentEnrolledCoursesResponse> StudentUnenrolledCourses(StudentEnrolledCoursesRequest studentEnrolledCoursesRequest)
        {
            List<StudentEnrolledCoursesResponse> studentUnenrolledCoursesResponseModel = new List<StudentEnrolledCoursesResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    studentUnenrolledCoursesResponseModel = dbConnection.Query<StudentEnrolledCoursesResponse>("StudentUnenrolledCourses", studentEnrolledCoursesRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return studentUnenrolledCoursesResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return studentUnenrolledCoursesResponseModel;
            }
        }


        public List<TeacherProfileResponse> StudentProfile(TeacherProfileRequest studentProfileRequest)
        {
            List<TeacherProfileResponse> studentProfileResponseModel = new List<TeacherProfileResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    studentProfileResponseModel = dbConnection.Query<TeacherProfileResponse>("StudentProfile", studentProfileRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return studentProfileResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return studentProfileResponseModel;
            }
        }

        public List<TeacherImageResponse> StudentImageUpload(TeacherImageUploadRequest studentImageUploadRequest)
        {
            List<TeacherImageResponse> studentImageUploadResponseModel = new List<TeacherImageResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    studentImageUploadResponseModel = dbConnection.Query<TeacherImageResponse>("StudentImageUpload", studentImageUploadRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return studentImageUploadResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return studentImageUploadResponseModel;
            }
        }

        public List<StudentEnrollmentApplicationResponse> StudentEnrollmentApplication(StudentEnrollmentApplicationRequest studentEnrollmentApplicationRequest)
        {
            List<StudentEnrollmentApplicationResponse> studentEnrollmentApplicationResponseModel = new List<StudentEnrollmentApplicationResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    studentEnrollmentApplicationResponseModel = dbConnection.Query<StudentEnrollmentApplicationResponse>("StudentEnrollmentApplication", studentEnrollmentApplicationRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return studentEnrollmentApplicationResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return studentEnrollmentApplicationResponseModel;
            }
        }

        public List<TeacherProfileResponse> InstituteProfile(TeacherProfileRequest instituteProfileRequest)
        {
            List<TeacherProfileResponse> instituteProfileResponseModel = new List<TeacherProfileResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    instituteProfileResponseModel = dbConnection.Query<TeacherProfileResponse>("InstituteProfile", instituteProfileRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return instituteProfileResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return instituteProfileResponseModel;
            }
        }

        public List<TeacherImageResponse> InstituteImageUpload(TeacherImageUploadRequest studentImageUploadRequest)
        {
            List<TeacherImageResponse> studentImageUploadResponseModel = new List<TeacherImageResponse>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    studentImageUploadResponseModel = dbConnection.Query<TeacherImageResponse>("InstituteImageUpload", studentImageUploadRequest, commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return studentImageUploadResponseModel;
                }
            }
            catch (Exception ex)
            {
                string errormsg = ex.Message;
                return studentImageUploadResponseModel;
            }
        }






    }
}
