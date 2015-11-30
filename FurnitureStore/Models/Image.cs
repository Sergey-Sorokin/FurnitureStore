using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models {
    public class Image {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public String URL { get; set; }

        public virtual Furniture Furniture { get; set; }
        public int FurnitureID { get; set; }
    }
}