using System.Collections.Generic;
using FurnitureStore.ViewModels;

namespace FurnitureStore.Interfaces.Services {

    public interface IService {
        
    }

    public interface IService<T, in Key> : IService {

        
    }
}