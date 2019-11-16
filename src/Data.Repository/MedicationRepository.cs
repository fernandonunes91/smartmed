namespace Data.Repository
{
    using Data.Model;
    using Data.Repository.Context;
    using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Medication>> GetAll()
        {
            return await this.context.Medication.AsQueryable().ToListAsync().ConfigureAwait(false);
        }
    }
}