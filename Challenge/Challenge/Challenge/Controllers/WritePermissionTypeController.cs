using Domain.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritePermissionTypeController : ControllerBase
    {
        private readonly ILogger<ReadPermissionController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public WritePermissionTypeController(IUnitOfWork unitOfWork, ILogger<ReadPermissionController> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        // POST api/<WritePermissionTypeController>
        [HttpPost]
        public ActionResult<PermissionTypes> Post([FromBody] PermissionTypes value)
        {
            try
            {
                _logger.LogDebug("Dentro Post PermissionTypes");
                _logger.LogDebug($"Request: {JsonConvert.SerializeObject(value)}");
                _unitOfWork.PermissionTypes.Add(value);

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

        // PUT api/<WritePermissionTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<PermissionTypes> Put(int id, [FromBody] PermissionTypes value)
        {
            try
            {
                _logger.LogDebug("Dentro Put PermissionTypes");
                _logger.LogDebug($"Request: {id}, {JsonConvert.SerializeObject(value)}");

                if (value.Id <= 1)
                {
                    var err = BadRequest("El Id no es válido.");
                    _logger.LogError(null, err);
                    return err;
                }

                _unitOfWork.PermissionTypes.Update(value);

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

        // DELETE api/<WritePermissionTypeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _logger.LogDebug("Dentro Delete PermissionTypes");
                _logger.LogDebug($"Request: {id}");

                if (id <= 1)
                {
                    var err = BadRequest("El Id no es válido.");
                    _logger.LogError(null, err);
                    return err;
                }
                _unitOfWork.PermissionTypes.Remove(new PermissionTypes { Id = id });

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
