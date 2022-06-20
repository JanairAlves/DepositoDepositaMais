using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.InputModels;
using DepositoDepositaMais.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DepositoDepositaMais.API.Controllers
{
    [Route("api/storage")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;
        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var StorageHouse = _storageService.GetAll(query);
            return Ok(StorageHouse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var storage = _storageService.GetById(id);
            if(storage == null)
                return NotFound();

            return Ok(storage);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewStorageInputModel inputModel)
        {
            var id = _storageService.CreateNewStorage(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateStorageViewModel inputModel)
        {
            _storageService.UpdateStorage(inputModel);
            return BadRequest();
        }
    }
}
