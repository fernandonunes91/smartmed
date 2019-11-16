
namespace Application.Dto
{
    using System;

    public class Medication
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset CreationDate { get; set; }
    }
}
