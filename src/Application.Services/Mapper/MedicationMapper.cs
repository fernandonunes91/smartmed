namespace Application.Services.Mapper
{
    using Dto = Application.Dto;
    using Model = Data.Model;

    public static class MedicationMapper
    {
        public static Dto.Medication ToDto(this Model.Medication medication)
        {
            return new Dto.Medication
            {
                CreateDate = medication.CreateDate,
                Id = medication.Id,
                Name = medication.Name,
                Quantity = medication.Quantity
            };
        }

        public static Model.Medication ToModel(this Dto.Medication medication)
        {
            return new Model.Medication
            {
                CreateDate = medication.CreateDate,
                Id = medication.Id,
                Name = medication.Name,
                Quantity = medication.Quantity
            };
        }
    }
}