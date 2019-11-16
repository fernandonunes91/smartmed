namespace Application.Services
{
    using Dto = Application.Dto;
    using Data.Repository;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Application.Services.Mapper;

    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository medicationRepository;

        public MedicationService(IMedicationRepository medicationRepository)
        {
            this.medicationRepository = medicationRepository;
        }

        public async Task<IEnumerable<Dto.Medication>> GetAll()
        {
            var modelResult = await medicationRepository.GetAll().ConfigureAwait(false);
            return modelResult.Select(x => x.ToDto());
        }
    }
}