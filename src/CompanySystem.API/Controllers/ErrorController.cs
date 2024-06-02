using Microsoft.AspNetCore.Mvc;

namespace CompanySystem.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ApiController
    {
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
