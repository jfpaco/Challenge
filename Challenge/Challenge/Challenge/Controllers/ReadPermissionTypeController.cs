using Domain.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadPermissionTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReadPermissionTypeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<ReadPermissionTypeController>
        [HttpGet]
        public IEnumerable<PermissionTypes> Get()
        {
            return _unitOfWork.PermissionTypes.GetAll();
        }

        // GET api/<ReadPermissionTypeController>/5
        [HttpGet("{id}")]
        public PermissionTypes Get(int id)
        {
            return _unitOfWork.PermissionTypes.GetById(id);
        }

    }
}
