﻿namespace PCConfig.Model.PcPartPicker.ShortViewData
{
    public class CaseShortResult : PartViewData
    {
        public string? HasPowerSupply { get; set; }

        public string? Type { get; set; }

        public double? MaximumVideoCardLengthWith { get; set; }

        public string? FrontUSBs { get; set; }

        public override IEnumerable<ShortSpecification> GetSpecificationList()
        {
            var values = new List<ShortSpecification>
            {
                new ShortSpecification
                {
                    Name = "Типоразмер корпуса",
                    Value = Type
                },
                new ShortSpecification
                {
                    Name = "Встроенный БП",
                    Value = HasPowerSupply,
                },
                new ShortSpecification
                {
                    Name = "Максимальная длина устанавливаемой видеокарты",
                    Value = MaximumVideoCardLengthWith,
                    Measure = "мм"
                },
                new ShortSpecification
                {
                    Name = "USB разъем",
                    Value = FrontUSBs
                }
            };

            return values;
        }
    }
}
