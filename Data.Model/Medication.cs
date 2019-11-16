namespace Data.Model
{
    using System;

    public class Medication
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public DateTime CreateDate { get; set; }
    }
}