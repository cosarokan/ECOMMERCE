using System.Collections.Generic;


namespace ECOMMERCE.WEBUI.Models.ViewModels
{
    public class PaymentViewModel
    {
        public List<CityModels> Cities { get; set; }
        public List<DistrictModel> Districts { get; set; }
    }
}