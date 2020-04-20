using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Tudo aqui (neste model, será exibido na view, chamada pelo controller CatalogController)
namespace Library.Models.Catalog
{
    //Model responsavel por prover os detalhes do asset
    public class AssetDetailModel
    {
        public int AssetId { get; set; }
        public string Tittle { get; set; }
        public string AuthorOrDirector { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string ISBN { get; set; }
        public string DeweyCallNumber { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public string CurrentLocation { get; set; }
        public string ImageUrl { get; set; }
        public string PatronName { get; set; }
        public Checkout LatestCheckout { get; set; }
        //Coleção de Historicos
        public IEnumerable<CheckoutHistory> checkoutHistories { get; set; }
        //Coleção de reservas atuais
        public IEnumerable<AssetHoldModel> CurrentHolds { get; set; }

        public static implicit operator AssetDetailModel(AssetDetailModel v)
        {
            throw new NotImplementedException();
        }
    }

    public class AssetHoldModel
    {
        public string PatronName { get; set; }
        //O momento que foi feita a reserva
        public DateTime HoldPlace { get; set; }

    }
}
