﻿namespace Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(string name, int sales)
        {
            Name = name;
            Sales = sales;
        }

        public Product(int id, string name, int sales)
        {
            Id = id;
            Name = name;
            Sales = sales;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Sales { get; set; }
    }
}