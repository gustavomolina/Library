using System;
using System.Collections.Generic;


namespace Library.Models.Catalog
{
    public class AssetIndexModel
    {
        //Guardará a coleção de AssetIndex   
        public IEnumerable<AssetIndexListingModel> Assets { get; set; }
    }
}
