using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritePermissionController : ControllerBase
    {
        private readonly ILogger<ReadPermissionController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public WritePermissionController(IUnitOfWork unitOfWork, ILogger<ReadPermissionController> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        // POST api/<WritePermissionController>
        [HttpPost]
        public ActionResult<Permissions> Post([FromBody] Permissions value)
        {
            try
            {
                _logger.LogDebug("Dentro Post Permissions");
                _logger.LogDebug($"Request: {JsonConvert.SerializeObject(value)}");

                _unitOfWork.Permissions.Add(value);

                var result = _unitOfWork.Save();
                if (result <= 0)
                {
                    var err = BadRequest("Ocurrió un error al guardar.");
                    _logger.LogError(null, err);
                    return err;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(null, ex.Message);
                return BadRequest("Ocurrió un error al guardar.");
            }

            return Ok(value);
        }

        // PUT api/<WritePermissionController>/5
        [HttpPut("{id}")]
        public ActionResult<Permissions> Put(int id, [FromBody] Permissions value)
        {
            try
            {
                _logger.LogDebug("Dentro Put Permissions");
                _logger.LogDebug($"Request: {id}, {JsonConvert.SerializeObject(value)}");

                if (value.Id <= 1)
                {
                    var err = BadRequest("El Id no es válido.");
                    _logger.LogError(null, err);
                    return err;
                }
                _unitOfWork.Permissions.Update(value);

                var result = _unitOfWork.Save();
                if (result <= 0)
                {
                    var err = BadRequest("Ocurrió un error al actualizar.");
                    _logger.LogError(null, err);
                    return err;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(null, ex.Message);
                return BadRequest("Ocurrió un error al actualizar.");
            }

            return Ok(value);
        }

        // DELETE api/<WritePermissionController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _logger.LogDebug("Dentro Delete Permissions");
                _logger.LogDebug($"Request: {id}");

                if (id <= 1)
                {
                    var err = BadRequest("El Id no es válido.");
                    _logger.LogError(null, err);
                    return err;
                }
                _unitOfWork.Permissions.Remove(new Permissions { Id = id });

                var result = _unitOfWork.Save();
                if (result <= 0)
                {
                    var err = BadRequest("Ocurrió un error al actualizar.");
                    _logger.LogError(null, err);
                    return err;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(null, ex.Message);
                return BadRequest("Ocurrió un error al actualizar.");
            }
            return Ok(id);
        }
    }
}
