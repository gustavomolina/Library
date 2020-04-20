using Library.Models.Catalog;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAsset _assets;
        //Construtor
        public CatalogController(ILibraryAsset assets)
        {
            _assets = assets;
        }

        //Ação do controller para www.site.com.br/Catalog/Index
        //Deve retornar uma lista inteira do catalogo

        public IActionResult Index()
        {
            //Consulta feita na base
            var assetModels = _assets.GetAll();

            //Filtrar o que será visualizado na View
            var ListingResult = assetModels.Select(result => new AssetIndexListingModel
            {
                //Passar para o construtor os parâmetros que queremos ver na View
                Id = result.Id,
                ImageUrl = result.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirector(result.Id),
                DeweyCallNumber = _assets.GetDewayIndex(result.Id),
                Title = result.Title,
                Type = _assets.GetType(result.Id)

            }); ;

            //Cria o modelo, baseado nos dados que foram consultados
            var model = new AssetIndexModel(){ Assets = ListingResult };

            //retorna o modelo criado para a View Catalog
            return View(model);
        }



        //Necessário passar o id para o controller: www.site.com/Catalog/Detail/id
        public IActionResult Detail(int id)
        {   //Consulta feit a base, que retornara dados usados para construir o model e posteriormente retornar à View
            var asset = _assets.GetById(id);




            //Variavel do model, será construida com os dados da base:
            var model = new AssetDetailModel
            {
                AssetId = id,
                Tittle = asset.Title,
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirector(id),
                CurrentLocation = _assets.CurrentLocation(id).Name,
            }
        }





    }


}
