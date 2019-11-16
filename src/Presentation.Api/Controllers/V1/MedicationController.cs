namespace Presentation.Api.Controllers.V1
{
    using Application.Dto;
    using Application.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("v1/Medication")]
    public class MedicationController : ControllerBase
    {
        private readonly IMedicationService medicationService;

        public MedicationController(IMedicationService medicationService)
        {
            this.medicationService = medicationService;
        }

        /// <summary>
        /// Get all medications
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Medication>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await medicationService.GetAll().ConfigureAwait(false);
            return base.Ok(result);
        }
    }
}