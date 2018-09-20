using TinySoldiers.Models;
using TinySoldiers.Data;
using TinySoldiers.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TinySoldiers.Models.DTOs;

namespace TinySoldiers.Controllers
{
    
    [Route("api/models")]
    public class ModelController : Controller
    {  
        // GET api/models 
        
        [HttpGet]
        [Route("")]
        public IActionResult GetAllModels([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {

            var lang = Request.Headers["Accept-Language"];
            
            if(lang != "de-DE")
            {
                lang = "en-US";
            }

            var list = DataContext.Models.ToLightWeight(lang);
            list.ForEach(m => m.Links.AddReference("self", $"http://localhost:5000/api/models/{m.Id}"));
            
            var envelope = new Envelope<ModelDTO>()
            {
                Items = list,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

             return Ok(envelope);
        }

    
        //GET api/models/11 should give me status 404 not found

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetByID(int id)
        {
            var lang = Request.Headers["Accept-Language"];

            if(lang != "de-DE")
            {
                lang = "en-US";
            } 
            
            //in ListExtensions, the Accept-Language header is set to en-US by default 
            //so if the header is invalid or not either de-DE or en-US then it's set to en-US
            var model = DataContext.Models.ToDetails(lang).FirstOrDefault(m => m.Id == id);
            
            model.Links.AddReference("self", $"http://localhost:5000/api/models/{model.Id}");
        
            return Ok(model);
        }
    }
} 


