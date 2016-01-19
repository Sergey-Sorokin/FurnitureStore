using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureStore.Models {
    public class Furniture {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Название")]
        [Required()]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Дата публикации")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime PublishDate { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public String Description { get; set; }

        [MaxLength(20)]
        [Display(Name = "Артикул")]
        public String ArticleNo { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:#,##0 KZT}")]
        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Display(Name = "Размер")]
        public String Size { get; set; }

        [Display(Name = "Цвет")]
        public String Color { get; set; }

        [Display(Name = "Рейтинг")]
        public int? Rating { get; set; }

        [Display(Name = "Изображения")]
        public virtual ICollection<Image> Images { get; set; }

        [Display(Name = "Производитель")]
        public virtual Producer Producer { get; set; }
        public int? ProducerID { get; set; }

        public String CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public String UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }

        [NotMapped]
        public Image DisplayImage {
            get {
                return (Images != null && Images.Count > 0) ? new List<Image>(Images)[0] : new Image { URL = "no-image.png" };
            }
        }
    }
}