using BoletosBusApp.Api.Dtos.Configuration.Bus;
using BoletosBusApp.Data.Base;
using BoletosBusApp.Data.Entities.Configuration;
using BoletosBusApp.Data.Interfaces;
using BoletosBusApp.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoletosBusApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusRepository _busRepository;

        public BusController(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        [HttpGet("GetBuses")]
        public async Task<IActionResult> Get()
        {
            var result = await _busRepository.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetBusById")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest(new { Success = false, Message = "El id del bus es inválido" });

            var result = await _busRepository.GetEntityBy(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("SaveBus")]
        public async Task<IActionResult> Post([FromBody] BusSaveOrUpdateDto busSaveOrUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var busToInsert = new Bus
            {
                CapacidadPiso1 = busSaveOrUpdateDto.CapacidadPiso1,
                CapacidadPiso2 = busSaveOrUpdateDto.CapacidadPiso2,
                Disponible = busSaveOrUpdateDto.Disponible,
                FechaCreacion = busSaveOrUpdateDto.FechaCambio,
                Nombre = busSaveOrUpdateDto.Nombre,
                NumeroPlaca = busSaveOrUpdateDto.NumeroPlaca,
                UsuarioModificacion = busSaveOrUpdateDto.UsuarioId
            };

            var result = await _busRepository.Save(busToInsert);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("UpdateBus")]
        public async Task<IActionResult> Put([FromBody] BusSaveOrUpdateDto busSaveOrUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var busToUpdate = new Bus
            {
                Id = busSaveOrUpdateDto.BusId,
                CapacidadPiso1 = busSaveOrUpdateDto.CapacidadPiso1,
                CapacidadPiso2 = busSaveOrUpdateDto.CapacidadPiso2,
                Disponible = busSaveOrUpdateDto.Disponible,
                Nombre = busSaveOrUpdateDto.Nombre,
                NumeroPlaca = busSaveOrUpdateDto.NumeroPlaca,
                UsuarioModificacion = busSaveOrUpdateDto.UsuarioId,
                FechaModificacion = busSaveOrUpdateDto.FechaCambio
            };

            var result = await _busRepository.Update(busToUpdate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("ActiveBus")]
        public async Task<IActionResult> Delete([FromBody] BusDisableOrEnableDto busDisableOrEnableDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var busToUpdate = new Bus
            {
                Id = busDisableOrEnableDto.BusId,
                UsuarioModificacion = busDisableOrEnableDto.UsuarioId,
                FechaModificacion = busDisableOrEnableDto.FechaCambio,
                Estatus = busDisableOrEnableDto.Status
            };

            var result = await _busRepository.Remove(busToUpdate);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
