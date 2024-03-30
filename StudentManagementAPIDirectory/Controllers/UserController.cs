using BAL.Models;
using BAL.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static BAL.Models.CommonModel;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        private readonly ISemesterService _semesterService;
        public UserController(IUserService userService, IDepartmentService departmentService, ISemesterService semesterService)
        {
            _userService = userService;
            _departmentService = departmentService;
            _semesterService = semesterService;
        }


        //[HttpPost]
        //[Route("UserRegistration")]
        //public IActionResult RegisterUser(UserLoginModel login)
        //{
        //    return Ok(_userService.UserRegistration(login));
        //}

        [HttpPost]
        [Route("UserRegistration")]
        public async Task<IActionResult> RegisterUser(UserLoginModel login)
        {
            try
            {
                var result = await _userService.UserRegistration(login);

                if (result)
                {
                    return Ok("User registered successfully.");
                }
                else
                {
                    return BadRequest("Failed to register user. Check your input and try again.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred during user registration. Please try again later.");
            }
        }



        //[HttpPost]
        //[Route("LoginUser")]
        //public IActionResult UserLoginInfo(UserLoginModel login)
        //{
        //  return Ok(_userService.UserLoginInfo(login));
        //}

        [HttpPost]
        [Route("LoginUser")]
        public IActionResult UserLoginInfo(UserLoginModel login)
        {
            try
            {
                var result = _userService.UserLoginInfo(login);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Invalid login credentials. Please check your username and password.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred during user login. Please try again later.");
            }
        }





        //[HttpGet]
        //[Route( "GetAllDepartment")]
        //public IActionResult GetAllDepartment()
        //{
        //    return Ok(_departmentService.GetAllDepartment());
        //}

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> AddDepartment(DepartmentModel department)
        {
            try
            {
                bool result = await _departmentService.AddDepartment(department);

                if (result)
                {
                    return Ok(new { message = "Department added successfully." });
                }
                else
                {
                    return BadRequest(new { message = "Failed to add department. Check your input and try again." });

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred during department addition. Please try again later.");
            }
        }


        [HttpGet]
        [Route("GetAllDepartment")]
        public IActionResult GetAllDepartment()
        {
            try
            {
                var departments = _departmentService.GetAllDepartment();

                if (departments != null)
                {
                    return Ok(departments);
                }
                else
                {
                    return NotFound("No departments found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during department update. Please try again later." });
            }
        }


        //[HttpDelete]
        //[Route("DeleteDepartment")]

        //public IActionResult DeleteDepartment(int departmentId)
        //{
        //    return Ok (_departmentService.DeleteDepartment(departmentId));
        //}


        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int departmentId)
        {
            try
            {
                bool result = await _departmentService.DeleteDepartment(departmentId);

                if (result)
                {
                    return Ok(new { message = "Department deleted successfullyy ." });
                }
                else
                {
                    return NotFound(new { message = "Department not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during department update. Please try again later." });
            }
        }

        //[HttpPut]
        //[Route("UpdateDepartment")]

        //public IActionResult UpdateDepartment(DepartmentModel department)
        //{
        //    return Ok(_departmentService.UpdateDepartment(department));
        //}


        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(DepartmentModel department)
        {
            try
            {
                var result = await _departmentService.UpdateDepartment(department);

                if (result)
                {
                    return Ok(new { message = "Department updated successfully." });
                }
                else
                {
                    return NotFound(new { message = "Department not found or update failed." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during department update. Please try again later." });
            }
        }


        [HttpGet]
        [Route("GetAllSemester")]

        public IActionResult GetAllSemester()
        {
            return Ok(_semesterService.GetAllSemester());
        }

        [HttpPut]
        [Route("EditSemester")]
        public IActionResult EditSemester(SemesterModel semester)
        {
            return Ok(_semesterService.EditSemester(semester));
        }


        //[HttpPost]
        //[Route("AddSemester")]

        //public IActionResult AddSemester(SemesterModel semester)
        //{
        //    return Ok (_semesterService.AddSemester(semester));
        //}


        [HttpPost]
        [Route("AddSemester")]
        public async Task<IActionResult> AddSemester(SemesterModel semester)
        {
            try
            {
                bool result = await _semesterService.AddSemester(semester);

                if (result)
                {
                    return Ok(new { message = "Semester added successfully." });
                }
                else
                {
                    return BadRequest(new { message = "Failed to add semester. Check your input and try again." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred during department addition. Please try again later.");
            }
        }


        //[HttpPost]
        //[Route("DeleteSemester")]

        //public IActionResult DeleteSemester(int id)
        //{
        //    return Ok (_semesterService.DeleteSemester(id));
        //}


        [HttpDelete]
        [Route("DeleteSemester")]
        public async Task<IActionResult> DeleteSemester(int id)
        {
            try
            {
                bool result = await _semesterService.DeleteSemester(id);

                if (result)
                {
                    return Ok(new { message = "Semester deleted successfullyy ." });
                }
                else
                {
                    return NotFound(new { message = "Semester not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during department update. Please try again later." });
            }
        }


    }

}
