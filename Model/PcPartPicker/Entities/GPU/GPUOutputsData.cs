using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities.GPU
{
    [Table("gpu_outputs_data")]
    public class GPUOutputsData
    {
        [Key]
        public int Id { get; set; }

        [Column("hdmi_outputs")]
        public int? HDMIOutputs { get; set; }

        [Column("displayport_outputs")]
        public int? DisplayPortOutputs { get; set; }

        [Column("hdmi_2_1a_outputs")]
        public int? HDMI21aOutputs { get; set; }

        [Column("displayport_1_4_outputs")]
        public int? DisplayPort14Outputs { get; set; }

        [Column("displayport_1_4a_outputs")]
        public int? DisplayPort14aOutputs { get; set; }

        [Column("dvi_d_dual_link_outputs")]
        public int? DVIDDualLinkOutputs { get; set; }

        [Column("hdmi_2_1_outputs")]
        public int? HDMI21Outputs { get; set; }

        [Column("displayport_2_1_outputs")]
        public int? DisplayPort21Outputs { get; set; }

        [Column("displayport_2_0_outputs")]
        public int? DisplayPort20Outputs { get; set; }

        [Column("hdmi_2_0b_outputs")]
        public int? HDMI20bOutputs { get; set; }

        [Column("dvi_i_dual_link_outputs")]
        public int? DVII_DualLinkOutputs { get; set; }

        [Column("usb_type_c_outputs")]
        public int? USBTypeCOutputs { get; set; }

        [Column("vga_outputs")]
        public int? VGAOutputs { get; set; }

        [Column("virtuallink_outputs")]
        public int? VirtualLinkOutputs { get; set; }

        [Column("dvi_d_single_link_outputs")]
        public int? DVIDSingleLinkOutputs { get; set; }

        [Column("minidisplayport_2_1_outputs")]
        public int? MiniDisplayPort21Outputs { get; set; }

        [Column("hdmi_2_0_outputs")]
        public int? HDMI20Outputs { get; set; }

        [Column("dvi_outputs")]
        public int? DVIOutputs { get; set; }

        [Column("minidisplayport_outputs")]
        public int? MiniDisplayPortOutputs { get; set; }

        [Column("hdmi_1_4_outputs")]
        public int? HDMI14Outputs { get; set; }

        [Column("minidisplayport_1_4a_outputs")]
        public int? MiniDisplayPort14aOutputs { get; set; }

        [Column("minidisplayport_1_4_outputs")]
        public int? MiniDisplayPort14Outputs { get; set; }

        [Column("vhdci_outputs")]
        public int? VHDCIOutputs { get; set; }

        [Column("dvi_i_single_link_outputs")]
        public int? DVII_SingleLinkOutputs { get; set; }

        [Column("s_video_outputs")]
        public int? SVideoOutputs { get; set; }

        [Column("mini_hdmi_outputs")]
        public int? MiniHDMIOutputs { get; set; }

        [Column("displayport_1_3_outputs")]
        public int? DisplayPort13Outputs { get; set; }

        [Column("dvi_a_outputs")]
        public int? DVIAOutputs { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [ForeignKey("PartId")]
        public Part Part { get; set; }
    }
}
