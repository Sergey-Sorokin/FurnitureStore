using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureStore.Models;

namespace FurnitureStore.ViewModels {
    public class FurnitureViewModel {

        public Furniture Furniture { get; set; }

        public IEnumerable<Producer> Producers { get; set; }

        public IEnumerable<SelectListItem> ProducerItems {
            get {
                return Producers.Select(p => new SelectListItem {
                    Value = p.ID.ToString(),
                    Text = p.FullName,
                });
            }
        }

        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public IEnumerable<int> CheckedImages { get; set; }


    }
}