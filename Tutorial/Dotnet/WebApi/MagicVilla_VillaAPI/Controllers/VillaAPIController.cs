using MagicVilla_VillaAPI.FakeDatabase;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MagicVilla_VillaAPI.Controllers
{
    // [Route("api/[controller]")]  - Can auto map controller name but whenever you change controller name you need to updates the API calls
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        #region Tut1: First End-Point (GetAll)       
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
            return FakeDB.villaList;    // Return status code OK as an ActionResult
        }
        #endregion


        #region Tut2: ActionResult & StatusCodes
        /*
           A controller action returns something called an action result. 
           An action result is what a controller action returns in response to a browser request.

           The ASP.NET MVC framework supports several types of action results including:
            1. ViewResult - Represents HTML and markup.
            2. EmptyResult - Represents no result.
            3. RedirectResult - Represents a redirection to a new URL.
            4. JsonResult - Represents a JavaScript Object Notation result that can be used in an AJAX application.
            5. JavaScriptResult - Represents a JavaScript script.
            6. ContentResult - Represents a text result.
            7. FileContentResult - Represents a downloadable file (with the binary content).
            8. FilePathResult - Represents a downloadable file (with a path).
            9. FileStreamResult - Represents a downloadable file (with a file stream).

           All of these action results inherit from the base ActionResult class.
       */
        [HttpGet("{id:int}", Name = "GetVilla")]    // Use Name to specify routing, check use case in Tut3
        //[HttpGet("{id:int}")]    This would also work, just no routing 
        /*
            ProducesResponseType helps us to document the possible results of the API.
            Run the program, check possible results at SwaggerUI.
         */
        [ProducesResponseType(StatusCodes.Status200OK)] // StatusCodes is simply a set of constants
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            /* 
                We can return different types of result, as they are all subclass of ActionResult.
                For examples, BadRequestResult, NotFoundResult & OkObjectResult.
            */
            if (id == 0) { return BadRequest(); }

            var v = FakeDB.villaList.FirstOrDefault(x => x.Id == id);

            if (v == null) { return NotFound(); }

            return Ok(v);
        }
        #endregion


        #region Tut3 - Post Method & Create at Route
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla_Route([FromBody] VillaDTO villaDTO)
        {
            if (villaDTO is null) { return BadRequest(villaDTO); }
            if (villaDTO.Id != 0) { return StatusCode(StatusCodes.Status500InternalServerError); }

            villaDTO.Id = FakeDB.villaList.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            FakeDB.villaList.Add(villaDTO);


            // Run the program and try this endpoint
            // At the Response header, you should be able to see the location of where do we store the Villa.
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id}, villaDTO);   // Link to Tut2 GetVilla Method

            //return Ok(villaDTO); <= This method is also OK
        }
        #endregion

    }
}