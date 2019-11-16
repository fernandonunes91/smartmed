namespace Application.Services.Tests
{
    using Application.Dto;
    using Data.Repository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;
    using System.Threading.Tasks;

    [TestClass]
    public class MedicationServiceTests
    {
        private readonly Mock<IMedicationRepository> mockRepository;
        private readonly MedicationService service;

        public MedicationServiceTests()
        {
            this.mockRepository = new Mock<IMedicationRepository>();
            this.service = new MedicationService(mockRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CreateAsync_NameAlreadyExists_ThrowExecption()
        {
            // Arrange
            var name = "AlreadyExists";
            var id = Guid.NewGuid();
            var medication = new Medication
            {
                CreateDate = DateTime.UtcNow,
                Name = name,
                Id = id,
                Quantity = 1
            };

            mockRepository
                .Setup(x => x.GetByNameOrIdAsync(name, id))
                .ReturnsAsync(new Data.Model.Medication());

            // Act
            await service.CreateAsync(medication).ConfigureAwait(false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CreateAsync_IdAlreadyExists_ThrowExecption()
        {
            // Arrange
            var name = "AlreadyExists";
            var id = Guid.NewGuid();
            var medication = new Medication
            {
                CreateDate = DateTime.UtcNow,
                Name = name,
                Id = id,
                Quantity = 1
            };

            mockRepository
                .Setup(x => x.GetByNameOrIdAsync(name, id))
                .ReturnsAsync(new Data.Model.Medication());

            // Act
            await service.CreateAsync(medication).ConfigureAwait(false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CreateAsync_QuantityIsInvalid_Created()
        {
            // Arrange
            var name = "SomeMedication";
            var id = Guid.NewGuid();
            var medication = new Medication
            {
                CreateDate = DateTime.UtcNow,
                Name = name,
                Id = id,
                Quantity = 0
            };

            // Act
            await service.CreateAsync(medication).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task CreateAsync_CreatesNewMedication_Created()
        {
            // Arrange
            var name = "SomeMedication";
            var id = Guid.NewGuid();
            var medication = new Medication
            {
                CreateDate = DateTime.UtcNow,
                Name = name,
                Id = id,
                Quantity = 1
            };

            // Act
            await service.CreateAsync(medication).ConfigureAwait(false);

            // Assert
            mockRepository
                .Verify(x => x.GetByNameOrIdAsync(name, id), Times.Once);
        }
    }
}