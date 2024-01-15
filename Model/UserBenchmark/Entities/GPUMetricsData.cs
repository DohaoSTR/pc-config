using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.UserBenchmark.Entities
{
    [Table("gpu_metrics_data")]
    public class GPUMetricsData
    {
        [Key]
        public int Id { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [Column("effective_3d_gaming_speed")]
        public double Effective3DGamingSpeed { get; set; }

        [Column("avg_locally_deformable_prt")]
        public double AvgLocallyDeformablePrt { get; set; }

        [Column("avg_high_dynamic_range_lighting")]
        public double AvgHighDynamicRangeLighting { get; set; }

        [Column("avg_render_target_array_gshader")]
        public double AvgRenderTargetArrayGShader { get; set; }

        [Column("avg_nbody_particle_system")]
        public double AvgNBodyParticleSystem { get; set; }

        [Column("locally_deformable_prt")]
        public double LocallyDeformablePrt { get; set; }

        [Column("high_dynamic_range_lighting")]
        public double HighDynamicRangeLighting { get; set; }

        [Column("render_target_array_gshader")]
        public double RenderTargetArrayGShader { get; set; }

        [Column("nbody_particle_system")]
        public double NBodyParticleSystem { get; set; }

        [Column("parallax_occlusion_mapping")]
        public double ParallaxOcclusionMapping { get; set; }

        [Column("force_splatted_flocking")]
        public double ForceSplattedFlocking { get; set; }

        [Column("avg_parallax_occlusion_mapping")]
        public double AvgParallaxOcclusionMapping { get; set; }

        [Column("avg_force_splatted_flocking")]
        public double AvgForceSplattedFlocking { get; set; }
    }

}
