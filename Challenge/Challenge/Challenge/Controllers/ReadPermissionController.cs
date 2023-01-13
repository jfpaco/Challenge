using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadPermissionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReadPermissionController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: api/<ReadPermissionsController>
        [HttpGet]
        public IEnumerable<Permissions> Get()
        {
            return _unitOfWork.Permissions.GetAll();
        }

        // GET api/<ReadPermissionsController>/5
        [HttpGet("{id}")]
        public Permissions Get(int id)
        {
            return _unitOfWork.Permissions.GetById(id);
        }

    }
}
