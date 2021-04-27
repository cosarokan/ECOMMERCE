using ECOMMERCE.CORE.Entities;
using ECOMMERCE.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ECOMMERCE.CORE.Repositories;
using ECOMMERCE.DATA.Repositories;
using ECOMMERCE.CORE.BusinessServices;
using ECOMMERCE.CORE.BusinessServices.Implementation;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ApplicationDbContext context = new ApplicationDbContext(@"data source=DESKTOP-GB56GRD\OKAN;initial catalog=ECOMMERCE;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

            //List<BrandModels> brandModels = context.BrandModels.Include(x => x.Products).Include(x => x.Brand).Include(x => x.ProductType).ToList();
            //List<City> city = context.Cities.Include(x => x.Districts).ToList();
            ////List<ProductTypes> productTypes = context.ProductTypes.ToList();
            //IBrandRepository brandRepository = new BrandRepository(context);
            //IBrandBusinessService brandBusinessService = new BrandBusinessService(brandRepository);
            //var a = brandBusinessService.GetAll();
        }
    }
}
