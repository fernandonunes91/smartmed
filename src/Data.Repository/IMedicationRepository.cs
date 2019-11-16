namespace Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Model;

    public interface IMedicationRepository
    {
        Task<IEnumerable<Medication>> GetAllAsync();

        Task CreateAsync(Medication medication);

        Task DeleteAsync(Medication medication);

        Task<Medication> GetByNameOrIdAsync(string name, Guid id);

        Task<Medication> GetByIdAsync(Guid id);
    }
}