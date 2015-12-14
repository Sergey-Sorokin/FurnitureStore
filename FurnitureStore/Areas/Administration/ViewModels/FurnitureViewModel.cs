using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureStore.Models;

namespace FurnitureStore.Areas.Administration.ViewModels {
    public class FurnitureViewModel : Furniture {

        public FurnitureViewModel(IEnumerable<Producer> producers) {
            Producers = producers;
        }

        public FurnitureViewModel() {

        }

        public Image DisplayImage {
            get {
                return (Images.Count > 0) ? Images.First() : new Image { URL = "no-image.png" };
            }
        }

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