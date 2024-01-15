namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class MotherboardShortViewData : PartViewData
    {
        public string? FormFactor { get; set; }

        public string? Chipset { get; set; }

        public int? MemorySlots { get; set; }

        public string? MemoryType { get; set; }

        public string? Socket { get; set; }

        public int? PcieX16Slots { get; set; }

        public override IEnumerable<ShortSpecification> GetSpecificationList()
        {
            var values = new List<ShortSpecification>
            {
                new ShortSpecification
                {
                    Name = "Форм-фактор",
                    Value = FormFactor
                },
                new ShortSpecification
                {
                    Name = "Чипсет",
                    Value = Chipset
                },
                new ShortSpecification
                {
                    Name = "Количество слотов памяти",
                    Value = MemorySlots,
                },
                new ShortSpecification
                {
                    Name = "Тип поддерживаемой памяти",
                    Value = MemoryType
                },
                new ShortSpecification
                {
                    Name = "Количество слотов PCI-E x16",
                    Value = PcieX16Slots
                },
                new ShortSpecification
                {
                    Name = "Сокет",
                    Value = Socket
                },
            };

            return values;
        }
    }
}
