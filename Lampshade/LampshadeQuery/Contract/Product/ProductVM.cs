﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampshadeQuery.Contract.Product
{
    public class ProductQueryVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public int DiscountRate { get; set; }
        public string Price { get; set; }
        public string PriceWithDiscount { get; set; }
        public bool HasDiscount { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public string Slug { get; set; }
        public string DiscountExpired { get; set; }
    }
}