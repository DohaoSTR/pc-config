using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCConfig.Model.PcPartPicker.Entities
{
    [Table("image_data")]
    public class ImageData
    {
        [Key]
        public int Id { get; set; }

        [Column("image_data")]
        public byte[] ImageDataBytes { get; set; }

        [Column("image_link_data_id")]
        public int ImageLinkDataId { get; set; }

        [ForeignKey("ImageLinkDataId")]
        public ImageLink ImageLinkData { get; set; }
    }
}
