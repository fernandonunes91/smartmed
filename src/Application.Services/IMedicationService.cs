namespace Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Dto;

    public interface IMedicationService
    {
        Task<IEnumerable<Medication>> GetAll();
    }
}