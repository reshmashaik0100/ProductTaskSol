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
    public class ProductAPIController : ControllerBase
    {
        // Create A Dependency Injection Object :
        public IProductRepo IPRef;

        // Cerate A Constructor :
        public ProductAPIController(IProductRepo _IPRef)
        {
            IPRef = _IPRef;
        }

        [HttpGet]
        [Route("AllProducts")]
        public async Task<IActionResult> AllProducts()
        {
            try
            {
                var ListPro = await IPRef.AllProducts();
                if (ListPro.Count > 0)
                {
                    return Ok(ListPro);
                }
                else
                {
                    return NotFound(" There Is No Data Available In Product Table...!");

                }
            }
            catch (Exception ex)
            {
                // Write a Logic For Error Log...!
                return BadRequest("Sorry For Inconviniance.\nWe Will Solve This Issue Soon.\n" + ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertProduct")]
        public async Task<IActionResult> InsertProduct([FromBody] Product Pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var count = await IPRef.InsertProduct(Pro);
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

        [HttpPut]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] int PId)
        {
            try
            {

                var count = await IPRef.DeleteProduct(PId);
                if (count > 0)
                {
                    return Ok(count + "Record Deleted Successfully...!");
                }
                else
                {
                    return BadRequest("The Record Not Deleted...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry For Inconviniance.\nWe Will Solve This Issue Soon.\n" + ex.Message);
            }
        }


        [HttpDelete]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product Pro)
        {
            try
            {

                var count = await IPRef.UpdateProduct(Pro);
                if (count > 0)
                {
                    return Ok(count + "Record Updated Successfully...!");
                }
                else
                {
                    return BadRequest("The Record Not Updated...!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry For Inconviniance.\nWe Will Solve This Issue Soon.\n" + ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchWithProName")]
        public async Task<IActionResult> SearchWithProName(string ProName)
        {
            try
            {
                var ListPro = await IPRef.SearchWithProName(ProName);
                if (ListPro.Count > 0)
                {
                    return Ok(ListPro);
                }
                else
                {
                    return NotFound(" There Is No Data Available In Product Table...!");

                }
            }
            catch (Exception ex)
            {
                // Write a Logic For Error Log...!
                return BadRequest("Sorry For Inconviniance.\nWe Will Solve This Issue Soon.\n" + ex.Message);
            }
        }

        [HttpGet]
        [Route("SearchWithCategory")]
        public async Task<IActionResult> SearchWithCategory(string CategoryName)
        {
            try
            {
                var ListPro = await IPRef.SearchWithProName(CategoryName);
                if (ListPro.Count > 0)
                {
                    return Ok(ListPro);
                }
                else
                {
                    return NotFound(" There Is No Data Available In Product Table...!");

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
