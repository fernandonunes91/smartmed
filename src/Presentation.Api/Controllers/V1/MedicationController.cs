namespace Presentation.Api.Controllers.V1
{
    using Application.Dto;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    [ApiController]
    [Route("v1/Medication")]
    public class MedicationController : ControllerBase
    {
        /// <summary>
        /// Get all medications
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Medication>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return this.Ok(Enumerable.Empty<Medication>());
        }
    }
}