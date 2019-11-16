namespace Application.Services
{
    using Application.Dto;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMedicationService
    {
        Task<IEnumerable<Medication>> GetAll();

        Task CreateAsync(Dto.Medication medication);

        Task DeleteAsync(Guid id);
    }
}