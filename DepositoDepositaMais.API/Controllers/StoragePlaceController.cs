using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/StoragePlace")]
    public class StoragePlaceController : ControllerBase
    {
        private readonly IStoragePlaceService _StoragePlaceService;
        public StoragePlaceController(IStoragePlaceService StoragePlaceService)
        {
            _StoragePlaceService = StoragePlaceService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var StoragePlaceHouse = _StoragePlaceService.GetAll(query);
            return Ok(StoragePlaceHouse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var StoragePlace = _StoragePlaceService.GetById(id);
            if(StoragePlace == null)
                return NotFound();

            return Ok(StoragePlace);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewStoragePlaceInputModel inputModel)
        {
            var id = _StoragePlaceService.CreateNewStoragePlace(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateStoragePlaceViewModel inputModel)
        {
            _StoragePlaceService.UpdateStoragePlace(inputModel);
            return BadRequest();
        }
    }
}
