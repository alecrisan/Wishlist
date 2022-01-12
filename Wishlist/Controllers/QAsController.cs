using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Services;

namespace Wishlist.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QAsController : ControllerBase
    {
        private readonly IQAsService _QAsService;

        public QAsController(IQAsService QAsService)
        {
            _QAsService = QAsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAllQAsByCategoryAsync(int id)
        {
            var qas = await _QAsService.GetAllQAsByCategoryAsync(id);
            return Ok(qas);
        }
    }
} 
