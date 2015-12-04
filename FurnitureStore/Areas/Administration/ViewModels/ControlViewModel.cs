using System;

namespace FurnitureStore.Areas.Administration.ViewModels {

    [Flags]
    public enum Actions {
        None = 0,
        Edit = 1,
        View = 2,
        Delete = 4,
    }

    public class ControlViewModel {



        public Actions Actions { get; set; }

        public int ID { get; set; }
    }
}