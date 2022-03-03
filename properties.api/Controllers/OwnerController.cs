using Microsoft.AspNetCore.Mvc;
using properties.core.interfaces;
using System.Threading.Tasks;

namespace properties.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _OwnerRepository;

        public OwnerController(IOwnerRepository OwnerRepository) {

            _OwnerRepository = OwnerRepository;
        }

        [HttpGet]
        public async  Task<IActionResult> getOwners() {
            var Owners = await _OwnerRepository.getOwners();
            return Ok(Owners);
        }
    }
}
