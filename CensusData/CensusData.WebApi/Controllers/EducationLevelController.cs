using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CensusData.Entities;
using CensusData.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CensusData.GetsApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class EducationLevelController : Controller
    {
        private readonly IEducationLevelLogic _educationLevelLogic;
        private readonly IMapper _mapper;

        public EducationLevelController(IEducationLevelLogic educationLevelLogic, IMapper mapper)
        {
            _educationLevelLogic = educationLevelLogic;
            _mapper = mapper;
        }

        [Route("/population/education-levels")]
        [HttpGet]
        public ActionResult<DTO.EducationLevelResult> GetAll()
        {
            EducationLevelResult educationLevelResult = _educationLevelLogic.GetAll();
            DTO.EducationLevelResult educationLevelResultDTO = _mapper.Map<DTO.EducationLevelResult>(educationLevelResult);

            return Ok(educationLevelResultDTO);
        }
    }
}