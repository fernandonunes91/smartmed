namespace Presentation.Api.Controllers.V1
{
    using Application.Dto;
    using Application.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    // this class should be tested as well
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
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await medicationService.GetAll().ConfigureAwait(false);
            return base.Ok(result);
        }

        /// <summary>
        /// Creates a medication
        /// </summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] Medication medication)
        {
            if (medication?.Name == null || medication.CreateDate == default(DateTime) || medication.Id == default)
            {
                base.BadRequest("Input medication invalid");
            }

            try
            {
                await medicationService.CreateAsync(medication).ConfigureAwait(false);
            }
            catch (ArgumentException ex)
            {
                base.BadRequest(ex.Message);
            }

            return base.StatusCode(201);
        }

        /// <summary>
        /// Deletes a medication
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if (id == default)
            {
                base.BadRequest("ID cant be default");
            }

            try
            {
                await medicationService.DeleteAsync(id).ConfigureAwait(false);
            }
            catch (ArgumentException ex)
            {
                base.BadRequest(ex.Message);
            }

            return base.Ok();
        }
    }
}