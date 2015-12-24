using System.Collections.Generic;
using FurnitureStore.Models;

namespace FurnitureStore.ViewModels {

    public class PaginationViewModel {

        public IEnumerable<Furniture> Furnitures { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
        public bool HasMoreItems { get; set; }

        public PaginationViewModel(IEnumerable<Furniture> furnitures, int itemsPerPage, int page, bool hasMoreItems) {
            Furnitures = furnitures;
            ItemsPerPage = itemsPerPage;
            Page = page;
            HasMoreItems = hasMoreItems;
        }
    }
}