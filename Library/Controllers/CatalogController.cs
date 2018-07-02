using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CatalogController :Controller
    {
        //handle all the data back from database and push them to a perticuler view model to display them
        //MVC model is defer from the models define in data layer
        //Models in datalayer are called entity models and map derectly to object in database tables 
        //Models in MVC layers are more like view models they just represent data that we show to the user inside of a view 
        private ILibraryAsset _asset;
        public CatalogController(ILibraryAsset asset) {
            _asset = asset;
        }
        //first controller action


    }
}
