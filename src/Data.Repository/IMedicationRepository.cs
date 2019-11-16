namespace Data.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Model;

    public interface IMedicationRepository
    {
        Task<IEnumerable<Medication>> GetAll();
    }
}