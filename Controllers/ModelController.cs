using TinySoldiers.Models;
using TinySoldiers.Data;
using TinySoldiers.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace TinySoldiers.Controllers
{
    
    //[Route("api/models")]
    public class ModelController : Controller
    {  
        // GET api/models 
        
        [HttpGet("")]
        public IActionResult GetAllModels([FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 10)
        {

            /*
            The route GetAllModels() should be implemented like this:
            • It can receive two query parameters called: pageNumber (default 1) and pageSize
            (default 10)
            • It should use those query parameters to page the data and return an Envelope (it
            resides within the Models/ folder) of ModelDTO
            • The _links property found in HyperMediaModel should be properly filled out
             */


             return Ok(200);
        }

      
        
        //GET api/models/11 should give me status 404 not found
        [HttpGet("model/{id}")]
        public IActionResult GetByID(int id)
        {
            /*
            The route GetModelById() should be implemented like this:
            • It receives an id as URL parameter and it should be used to find the corresponding
            model based on that id
            • It should return an ModelDetailsDTO
            • The _links property found in HyperMediaModel should be properly filled out
            */

            return Ok(200);
        }
    }
} 

