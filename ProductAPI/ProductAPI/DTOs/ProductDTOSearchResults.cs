﻿namespace ProductAPI.DTOs
{
    public class ProductDTOSearchResults
    {
        public int? ProductId { get; set; }

        public string? ProductName { get; set; }

        public decimal? Price { get; set; }

        public string? CategoryName { get; set; }
    }
}
