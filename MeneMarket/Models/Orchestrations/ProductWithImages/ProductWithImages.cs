﻿using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Models.Orchestrations.ProductWithImages
{
    public class ProductWithImages
    {
        public Product Product { get; set; }
        public List<IFormFile> Images { get; set; }
        public List<string> ImageFilePaths { get; set; }
    }
}