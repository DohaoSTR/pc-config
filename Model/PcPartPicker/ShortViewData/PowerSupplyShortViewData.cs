namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class PowerSupplyShortViewData : PartViewData
    {
        public double? Wattage { get; set; }

        public int? SATAConnectors { get; set; }

        public int? PCIe62PinConnectors { get; set; }

        public int? EPS8PinConnectors { get; set; }

        public int? Molex4PinConnectors { get; set; }

        public string? Type { get; set; }

        public override IEnumerable<ShortSpecification> GetSpecificationList()
        {
            var values = new List<ShortSpecification>
            {
                new ShortSpecification
                {
                    Name = "Форм-фактор",
                    Value = Type
                },
                new ShortSpecification
                {
                    Name = "Мощность (номинал)",
                    Value = Wattage,
                    Measure = "Вт"
                },
                new ShortSpecification
                {
                    Name = "Количество разъемов 15-pin SATA",
                    Value = SATAConnectors,
                },
                new ShortSpecification
                {
                    Name = "Разъемы для питания видеокарты (PCI-E)",
                    Value = PCIe62PinConnectors
                },
                new ShortSpecification
                {
                    Name = "Количество разъемов 8-pin EPS",
                    Value = EPS8PinConnectors
                },
                new ShortSpecification
                {
                    Name = "Количество разъемов 4-pin Molex",
                    Value = Molex4PinConnectors
                },
            };

            return values;
        }
    }
}
