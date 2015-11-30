using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models {
    public class Producer {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Страна")]
        public String Country { get; set; }

        [StringLength(150)]
        [Display(Name = "Название")]
        public String Name { get; set; }

        public virtual ICollection<Furniture> Furnitures { get; set; }

        [Display(Name = "Производитель")]
        public String FullName {
            get {
                return String.Format("{0} ({1})", Name, Country);
            }
        }
    }
}