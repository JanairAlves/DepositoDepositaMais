using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/StorageLocation")]
    public class StorageLocationController : ControllerBase
    {
        private readonly IStorageLocationService _StorageLocationService;
        public StorageLocationController(IStorageLocationService StorageLocationService)
        {
            _StorageLocationService = StorageLocationService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var StorageLocationHouse = _StorageLocationService.GetAll(query);
            return Ok(StorageLocationHouse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var StorageLocation = _StorageLocationService.GetById(id);
            if(StorageLocation == null)
                return NotFound();

            return Ok(StorageLocation);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewStorageLocationInputModel inputModel)
        {
            var id = _StorageLocationService.CreateNewStorageLocation(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}/activate")]
        public IActionResult Put(int id, [FromBody] UpdateStorageLocationViewModel inputModel)
        {
            _StorageLocationService.UpdateStorageLocation(inputModel);
            return BadRequest();
        }
    }
}
