using System.Collections.Generic;
using FurnitureStore.Models;

namespace FurnitureStore.Areas.Administration.ViewModels {
    public class PaginaionViewModel {

        public IEnumerable<Furniture> Furnitures { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
        public bool HasMoreItems { get; set; }

        public PaginaionViewModel(IEnumerable<Furniture> furnitures, int itemsPerPage, int page, bool hasMoreItems) {
            Furnitures = furnitures;
            ItemsPerPage = itemsPerPage;
            Page = page;
            HasMoreItems = hasMoreItems;
        }
    }
}