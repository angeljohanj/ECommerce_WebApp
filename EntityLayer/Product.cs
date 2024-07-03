using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace EntityLayer
{
 /*   create table tb_Product(ProductId int primary key identity, Name varchar(500), 
Description varchar(500), BrandId int references tb_Brand(BrandId),
CategoryId int references tb_Category(CatId), price decimal (10,2) default 0,
Stock int, Image varchar(100), ImageName varchar(100), Edited_at datetime,
Deleted_at datetime, Active bit default 1, Created_at datetime default getdate()
)*/
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Brand OBrand { get; set; }
        public Category OCategory { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public string ImageName { get; set; }
        public bool Active { get; set; }


    }
}
