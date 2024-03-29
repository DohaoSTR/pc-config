﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.InternalDrive
{
    [Table("hybrid_storage")]
    public class HybridStorage
    {
        [Key]
        public int Id { get; set; }

        [Column("capacity")]
        public double? Capacity { get; set; }

        [Column("capacity_measure")]
        public string? CapacityMeasure { get; set; }

        [Column("price")]
        public double? Price { get; set; }

        [Column("price_measure")]
        public string? PriceMeasure { get; set; }

        [Column("cache")]
        public double? Cache { get; set; }

        [Column("cache_measure")]
        public string? CacheMeasure { get; set; }

        [Column("hybrid_ssd_cache")]
        public double? HybridSSDCache { get; set; }

        [Column("hybrid_ssd_cache_measure")]
        public string? HybridSSDCacheMeasure { get; set; }

        [Column("form_factor")]
        public string? FormFactor { get; set; }

        [Column("interface")]
        public string? Interface { get; set; }

        [Column("model")]
        public string? Model { get; set; }

        [Column("power_loss_protection")]
        public string? PowerLossProtection { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
