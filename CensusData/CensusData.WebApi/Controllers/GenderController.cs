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
    public class GenderController : Controller
    {
        private readonly IGenderLogic _genderLogic;
        private readonly IMapper _mapper;

        public GenderController(IGenderLogic genderLogic, IMapper mapper)
        {
            _genderLogic = genderLogic;
            _mapper = mapper;
        }

        [Route("/genders")]
        [HttpGet]
        public ActionResult<DTO.GenderResult> GetAll()
        {
            GenderResult genderResult = _genderLogic.GetAll();
            DTO.GenderResult genderResultDTO = _mapper.Map<DTO.GenderResult>(genderResult);

            return Ok(genderResultDTO);
        }

        [HttpGet("/districts/{IdDistrict}/males-females")]
        public ActionResult<DTO.GenderResult> GetMaleFemaleByDistrict(int IdDistrict)
        {
            GenderResult genderResult = _genderLogic.GetMaleFemaleByDistrict(IdDistrict);
            DTO.GenderResult genderResultDTO = _mapper.Map<DTO.GenderResult>(genderResult);

            return Ok(genderResultDTO);
        }

    }
}