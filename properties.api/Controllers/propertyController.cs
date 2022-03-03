using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using properties.core.interfaces;
using properties.core.entities;
using properties.core.DTO;
using System.Linq;
using AutoMapper;
using properties.api.Response;
using properties.core.QueryFilters;
using System.Net;
using Newtonsoft.Json;
using properties.infraestructure.Services;
using Microsoft.AspNetCore.Authorization;

namespace properties.api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class propertyController : ControllerBase
    {

        private readonly IPropertyService _propertyService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

       public propertyController(IPropertyService propertyService, IMapper mapper, IUriService uriService) {
            _propertyService = propertyService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Return all properties
        /// </summary>
        /// <param name="filters">Filters to apply </param>
        /// <returns></returns>
        [HttpGet(Name = nameof(getPorperties))]
        [ProducesResponseType((int)HttpStatusCode.OK,Type = typeof(Responses<IEnumerable<PropertyDto>>))]
        public  IActionResult getPorperties([FromQuery]PropertyQueryFilters filters)
        {
            var properties =  _propertyService.getProperties(filters);
            var propertiesDto = _mapper.Map<IEnumerable<PropertyDto>>(properties); 
            var metadata = new MetaData
            {
                TotalCount = properties.TotalCount,
                PageSize = properties.PageSize,
                currentPage = properties.currentPage,
                TotalPages = properties.TotalPages,
                NextPage = properties.NextPage,
                PreviousPage = properties.PreviousPage,
                NextPageUrl = _uriService.getPropertyPaginationUri(filters, Url.RouteUrl(nameof(getPorperties))).ToString(),
                PrevioustPageUrl = _uriService.getPropertyPaginationUri(filters, Url.RouteUrl(nameof(getPorperties))).ToString()
            };
            var response = new Responses<IEnumerable<PropertyDto>>(propertiesDto)
            {
                MetaData = metadata
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata)); 
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getPorperty(int id)
        {
            var property = await _propertyService.getProperty(id);
            var propertyDto = _mapper.Map<PropertyDto>(property);
            var response = new Responses<PropertyDto>(propertyDto);
            return Ok(propertyDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostPorperty(PropertyDto PropertyDto )
        {
            var property = _mapper.Map<Property>(PropertyDto);
            await _propertyService.postProperty(property);
            var propertydto = _mapper.Map<PropertyDto>(property);
            var response = new Responses<PropertyDto>(propertydto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPorperty(int id, PropertyDto PropertyDto)
        {
            var property = _mapper.Map<Property>(PropertyDto);
            property.id = id;
            var result = await _propertyService.PutPorperty(property);
            var response = new Responses<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePorperty(int id)
        { 
            var result = await _propertyService.deletePorperty(id);
            var response = new Responses<bool>(result);
            return Ok(response);
        }

    }
}
