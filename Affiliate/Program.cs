using Mono.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Affiliate
{
    class Program
    {
        static void Main(string[] args)
        {
            var URLPATH = "https://www.flipkart.com/diary-domestic-diva/p/itmeyysv57grjbpq?pid=9780143440017&srno=b_1_1&otracker=nmenu_sub_Sports%2C%20Books%20and%20More_0_Books%20on%20Pre-Order&lid=LSTBOK9780143440017TXPQLG&fm=neo/merchandising&iid=9d29106c-5a2d-45fd-8741-00154a642987.9780143440017.SEARCH&ppt=Store%20Browse&ppn=Search%20Page&ssid=dehpzcm1800000001516501454719";
            Uri myUri = new Uri(URLPATH);
            string param = HttpUtility.ParseQueryString(myUri.Query).Get("pid");

            WebClient wc = new WebClient();
            wc.Headers.Add("Fk-Affiliate-Id", "Aravindia");
            wc.Headers.Add("Fk-Affiliate-Token", "5637a7b680eb42b19b16fe33edff7209");
            string jsonString = wc.DownloadString("https://affiliate-api.flipkart.net/affiliate/1.0/product.json?id="+param);
            RootObject account = JsonConvert.DeserializeObject<RootObject>(jsonString);
            var productURL = account.productBaseInfoV1.productUrl;
            var productPRICE = account.productBaseInfoV1.flipkartSellingPrice.amount;
            var productSPLPRICE = account.productBaseInfoV1.flipkartSpecialPrice.amount;
            var categoies = account.productBaseInfoV1.categoryPath.ToString();
        }
    }

    public class ImageUrls
    {
        public string __invalid_name__400x400 { get; set; }
        public string __invalid_name__200x200 { get; set; }
        public string unknown { get; set; }
        public string __invalid_name__800x800 { get; set; }
    }

    public class MaximumRetailPrice
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class FlipkartSellingPrice
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class FlipkartSpecialPrice
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class Attributes
    {
        public string size { get; set; }
        public string color { get; set; }
        public string storage { get; set; }
        public string sizeUnit { get; set; }
        public string displaySize { get; set; }
    }

    public class ProductBaseInfoV1
    {
        public string productId { get; set; }
        public string title { get; set; }
        public string productDescription { get; set; }
        public ImageUrls imageUrls { get; set; }
        public List<string> productFamily { get; set; }
        public MaximumRetailPrice maximumRetailPrice { get; set; }
        public FlipkartSellingPrice flipkartSellingPrice { get; set; }
        public FlipkartSpecialPrice flipkartSpecialPrice { get; set; }
        public string productUrl { get; set; }
        public string productBrand { get; set; }
        public object inStock { get; set; }
        public bool codAvailable { get; set; }
        public string discountPercentage { get; set; }
        public List<object> offers { get; set; }
        public string categoryPath { get; set; }
        public object styleCode { get; set; }
        public Attributes attributes { get; set; }
    }

    public class ShippingCharges
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class ProductShippingInfoV1
    {
        public ShippingCharges shippingCharges { get; set; }
        public string sellerName { get; set; }
        public double sellerAverageRating { get; set; }
        public int sellerNoOfRatings { get; set; }
        public int sellerNoOfReviews { get; set; }
    }

    public class Value
    {
        public string key { get; set; }
        public List<string> value { get; set; }
    }

    public class SpecificationList
    {
        public string key { get; set; }
        public List<Value> values { get; set; }
    }

    public class BooksInfo
    {
        public object language { get; set; }
        public object binding { get; set; }
        public object pages { get; set; }
        public object publisher { get; set; }
        public int year { get; set; }
        public List<object> authors { get; set; }
    }

    public class LifeStyleInfo
    {
        public object sleeve { get; set; }
        public object neck { get; set; }
        public object idealFor { get; set; }
    }

    public class CategorySpecificInfoV1
    {
        public List<string> keySpecs { get; set; }
        public List<string> detailedSpecs { get; set; }
        public List<SpecificationList> specificationList { get; set; }
        public BooksInfo booksInfo { get; set; }
        public LifeStyleInfo lifeStyleInfo { get; set; }
    }

    public class RootObject
    {
        public ProductBaseInfoV1 productBaseInfoV1 { get; set; }
        public ProductShippingInfoV1 productShippingInfoV1 { get; set; }
        public CategorySpecificInfoV1 categorySpecificInfoV1 { get; set; }
    }



}
   