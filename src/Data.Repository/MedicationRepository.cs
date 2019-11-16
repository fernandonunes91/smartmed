namespace Data.Repository
{
    using Data.Model;
    using Data.Repository.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MedicationRepository : IMedicationRepository
    {
        private readonly SmartMedContext context;

        public MedicationRepository(SmartMedContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Medication>> GetAllAsync()
        {
            return await this.context.Medication.AsQueryable().ToListAsync().ConfigureAwait(false);
        }

        public Task CreateAsync(Medication medication)
        {
            this.context.Medication.Add(medication);
            return this.context.SaveChangesAsync();
        }

        public Task DeleteAsync(Medication medication)
        {
            this.context.Medication.Remove(medication);
            return this.context.SaveChangesAsync();
        }

        public Task<Medication> GetByNameOrIdAsync(string name, Guid id)
        {
            return this.context.Medication.FirstOrDefaultAsync(x => x.Name.Equals(name) || x.Id == id);
        }

        public Task<Medication> GetByIdAsync(Guid id)
        {
            return this.context.Medication.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}