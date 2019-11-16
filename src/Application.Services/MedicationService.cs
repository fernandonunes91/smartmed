namespace Application.Services
{
    using Application.Services.Mapper;
    using Data.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Dto = Application.Dto;

    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository medicationRepository;

        public MedicationService(IMedicationRepository medicationRepository)
        {
            this.medicationRepository = medicationRepository;
        }

        public async Task<IEnumerable<Dto.Medication>> GetAll()
        {
            var modelResult = await medicationRepository.GetAllAsync().ConfigureAwait(false);
            return modelResult.Select(x => x.ToDto());
        }

        public async Task CreateAsync(Dto.Medication medication)
        {
            if (medication.Quantity < 1)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }

            var repoMedication = await medicationRepository.GetByNameOrIdAsync(medication.Name, medication.Id).ConfigureAwait(false);
            if (repoMedication != null)
            {
                throw new ArgumentException("Medication already exists");
            }

            await medicationRepository.CreateAsync(medication.ToModel()).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var repoMedication = await medicationRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (repoMedication == null)
            {
                throw new ArgumentException("Medication doesnt exists");
            }

            await medicationRepository.DeleteAsync(repoMedication).ConfigureAwait(false);
        }
    }
}