using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductTaskPro.Models;
using System.Threading.Tasks;
using System;
using ProductTaskPro.IRepo;

namespace ProductTaskPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        // Create A Dependency Injection Object :
        public IUserRepo IUserRef;

        // Cerate A Constructor :
        public UserAPIController(IUserRepo _IUserRef)
        {
            IUserRef = _IUserRef;
        }

        [HttpPost]
        [Route("InsertUser")]
        public async Task<IActionResult> InsertUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var count = await IUserRef.InsertUser(user);
                    if (count > 0)
                    {
                        return Ok(count + "Record Inserted Successfully...!");
                    }
                    else
                    {
                        return BadRequest("The Record Not Inserted...!");
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry For Inconviniance.\nWe Will Solve This Issue Soon.\n" + ex.Message);
            }
        }

        [HttpGet]
        [Route("UserByEmailAndPassword")]
        public async Task<IActionResult> UserByEmailAndPassword(string Email, string Password)
        {
            try
            {
                var User = await IUserRef.UserByEmailAndPassword(Email, Password);
                if (User != null)
                {
                    return Ok(User);
                }
                else
                {
                    return NotFound(" There Is No Data Available With Email = " + Email + " and Password = " + Password + " In User Table...!");

                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry For Inconviniance.\nWe Will Solve This Issue Soon.\n" + ex.Message);
            }
        }

        [HttpGet]
        [Route("AllUsers")]
        public async Task<IActionResult> AllUsers()
        {
            try
            {
                var ListUser = await IUserRef.AllUsers();
                if (ListUser.Count > 0)
                {
                    return Ok(ListUser);
                }
                else
                {
                    return NotFound(" There Is No Data Available In User Table...!");

                }
            }
            catch (Exception ex)
            {
                // Write a Logic For Error Log...!
                return BadRequest("Sorry For Inconviniance.\nWe Will Solve This Issue Soon.\n" + ex.Message);
            }

        }
    }
}
