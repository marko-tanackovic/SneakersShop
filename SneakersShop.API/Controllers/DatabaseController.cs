using Microsoft.AspNetCore.Mvc;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SneakersShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private SneakersShopContext _context;

        public DatabaseController(SneakersShopContext context)
        {
            this._context = context;
        }
        // POST api/<TestController>
        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                var colors = new List<Color>
                {
                    new Color{Name="white"},
                    new Color{Name="black"},
                    new Color{Name="red"},
                    new Color{Name="blue"},
                    new Color{Name="green"},
                    new Color{Name="brown"},
                    new Color{Name="pink"},
                    new Color{Name="silver"},
                    new Color{Name="gray"},
                    new Color{Name="aqua"},
                    new Color{Name="purple"},
                    new Color{Name="olive"},
                    new Color{Name="wheat"},
                    new Color{Name="yellow"},
                    new Color{Name="orange"},
                };
                var brands = new List<Brand>
                {
                    new Brand{Name="Nike"},
                    new Brand{Name="Jordan"},
                    new Brand{Name="Adidas"},
                    new Brand{Name="Reebok"},
                    new Brand{Name="Converse"},
                    new Brand{Name="New Balance"},
                    new Brand{Name="Asics"},
                    new Brand{Name="Vans"},
                    new Brand{Name="Puma"},
                    new Brand{Name="Under Armour"},
                };
                var images = new List<File>
                {
                    new File{Path="image1.jpg", Size=100},
                    new File{Path="image2.jpg", Size=1000},
                    new File{Path="image3.jpg", Size=1200},
                    new File{Path="image4.jpg", Size=400},
                    new File{Path="image5.jpg", Size=600},
                    new File{Path="image6.jpg", Size=1200},
                    new File{Path="image7.jpg", Size=620},
                    new File{Path="image8.jpg", Size=200},
                    new File{Path="image9.jpg", Size=500},
                    new File{Path="image10.jpg", Size=600},
                    new File{Path="image11.jpg", Size=780},
                    new File{Path="image12.jpg", Size=150},
                    new File{Path="image13.jpg", Size=1300},
                    new File{Path="image14.jpg", Size=2000},
                    new File{Path="image15.jpg", Size=100},
                    new File{Path="image16.jpg", Size=120},
                    new File{Path="image17.jpg", Size=150},
                    new File{Path="image18.jpg", Size=160},
                    new File{Path="image19.jpg", Size=400},
                    new File{Path="image20.jpg", Size=300},
                    new File{Path="image21.jpg", Size=200},
                    new File{Path="image22.jpg", Size=150},
                    new File{Path="image23.jpg", Size=250},
                    new File{Path="image24.jpg", Size=330},
                    new File{Path="image25.jpg", Size=1300},
                    new File{Path="image26.jpg", Size=2200},
                    new File{Path="image27.jpg", Size=1200},
                    new File{Path="image28.jpg", Size=700},
                    new File{Path="image29.jpg", Size=600},
                    new File{Path="image30.jpg", Size=660},
                    new File{Path="image31.jpg", Size=610},
                    new File{Path="image32.jpg", Size=120},
                    new File{Path="image33.jpg", Size=400},
                    new File{Path="image34.jpg", Size=550},
                    new File{Path="image35.jpg", Size=520},
                    new File{Path="image36.jpg", Size=410},
                    new File{Path="image37.jpg", Size=430},
                    new File{Path="image38.jpg", Size=720},
                    new File{Path="image39.jpg", Size=600},
                    new File{Path="image40.jpg", Size=320},
                    new File{Path="image41.jpg", Size=330},
                    new File{Path="image42.jpg", Size=1000},
                    new File{Path="image43.jpg", Size=1200},
                    new File{Path="image44.jpg", Size=750},
                    new File{Path="image45.jpg", Size=250},
                    new File{Path="profile1.jpg", Size=120},//45
                    new File{Path="profile2.jpg", Size=120},//46
                    new File{Path="profile3.jpg", Size=420},//47
                    new File{Path="profile4.jpg", Size=520},//48
                };
                var products = new List<Product>
                {
                    new Product{Name="EXO-FIT HI Stranger Things",Code="CN2282",ReleaseDate=new System.DateTime(2017, 10, 25),Price=100,Brand=brands.ElementAt(3),Image=images.ElementAt(0)},
                    new Product{Name="Zoom Fly SP",Code="AA3172-100",ReleaseDate=new System.DateTime(2017, 6, 8),Price=100,Brand=brands.ElementAt(0),Image=images.ElementAt(1)},
                    new Product{Name="JUST DON 2",Code="717170-405",ReleaseDate=new System.DateTime(2015, 1, 31),Price=350,Brand=brands.ElementAt(1),Image=images.ElementAt(2)},
                    new Product{Name="Hyperadapt",Code="843871-001",ReleaseDate=new System.DateTime(2016, 12, 1),Price=350,Brand=brands.ElementAt(0),Image=images.ElementAt(3)},
                    new Product{Name="Air Max 97 Skepta Ultra 17",Code="AJ1988-900",ReleaseDate=new System.DateTime(2017, 9, 2),Price=180,Brand=brands.ElementAt(0),Image=images.ElementAt(4)},
                    new Product{Name="1 Retro High Rust Pink",Code="861428-101",ReleaseDate=new System.DateTime(2017, 11, 1),Price=160,Brand=brands.ElementAt(1),Image=images.ElementAt(5)},
                    new Product{Name="Air Max 98 Supreme",Code="844694-600",ReleaseDate=new System.DateTime(2016, 4, 28),Price=390,Brand=brands.ElementAt(0),Image=images.ElementAt(6)},
                    new Product{Name="Air Max Lunar 90 SP",Code="700098-007",ReleaseDate=new System.DateTime(2014, 7, 20),Price=700,Brand=brands.ElementAt(0),Image=images.ElementAt(7)},
                    new Product{Name="Chuck Taylor All-Star Vulcanized Hi",Code="162204C",ReleaseDate=new System.DateTime(2018, 5, 12),Price=2100,Brand=brands.ElementAt(4),Image=images.ElementAt(8)},
                    new Product{Name="Air Fear Of God 1 Light Bone",Code="AR4237-002",ReleaseDate=new System.DateTime(2019, 1, 19),Price=395,Brand=brands.ElementAt(0),Image=images.ElementAt(9)},
                    new Product{Name="13 Retro Ray Allen PE",Code="414571-125",ReleaseDate=new System.DateTime(2011, 7, 23),Price=175,Brand=brands.ElementAt(1),Image=images.ElementAt(10)},
                    new Product{Name="Dunk SB High Cheech & Chong",Code="305050-100",ReleaseDate=new System.DateTime(2011, 4, 20),Price=895,Brand=brands.ElementAt(0),Image=images.ElementAt(11)},
                    new Product{Name="MT580 West NYC Alpine Guide",Code="MT580WST",ReleaseDate=new System.DateTime(2012, 9, 22),Price=450,Brand=brands.ElementAt(5),Image=images.ElementAt(12)},
                    new Product{Name="Kamikaze II Packer Shoes Remember the Alamo",Code="V53621",ReleaseDate=new System.DateTime(2013, 8, 2),Price=250,Brand=brands.ElementAt(3),Image=images.ElementAt(13)},
                    new Product{Name="Human Race NMD Pharrell x Chanel",Code="D97921",ReleaseDate=new System.DateTime(2017, 11, 21),Price=500,Brand=brands.ElementAt(2),Image=images.ElementAt(14)},
                    new Product{Name="Sock Dart Fragment",Code="728748-401",ReleaseDate=new System.DateTime(2015, 2, 26),Price=240,Brand=brands.ElementAt(0),Image=images.ElementAt(15)},
                    new Product{Name="Air Max 90 Atmos Duck Camo",Code="333888-025",ReleaseDate=new System.DateTime(2013, 10, 5),Price=680,Brand=brands.ElementAt(0),Image=images.ElementAt(16)},
                    new Product{Name="Gel-Lyte III Saint Alfred Olive Birch",Code="H33LK-8016",ReleaseDate=new System.DateTime(2013, 6, 15),Price=250,Brand=brands.ElementAt(6),Image=images.ElementAt(17)},
                    new Product{Name="3 Retro Doernbecher",Code="437536-600",ReleaseDate=new System.DateTime(2013, 7, 20),Price=600,Brand=brands.ElementAt(1),Image=images.ElementAt(18)},
                    new Product{Name="Old Skool Pro Golf Wang",Code="VN0QHMF5F",ReleaseDate=new System.DateTime(2014, 7, 19),Price=400,Brand=brands.ElementAt(7),Image=images.ElementAt(19)},
                    new Product{Name="Air Max 180 Comme des Garcons",Code="AO4641-601",ReleaseDate=new System.DateTime(2018, 2, 1),Price=260,Brand=brands.ElementAt(0),Image=images.ElementAt(20)},
                    new Product{Name="990v3 JJJJound",Code="M990JJ3",ReleaseDate=new System.DateTime(2018, 11, 23),Price=250,Brand=brands.ElementAt(5),Image=images.ElementAt(21)},
                    new Product{Name="NMD R1 Pharrell",Code="BB3070",ReleaseDate=new System.DateTime(2016, 9, 29),Price=240,Brand=brands.ElementAt(2),Image=images.ElementAt(22)},
                    new Product{Name="Yeezy Boost 750",Code="B35309",ReleaseDate=new System.DateTime(2015, 2, 14),Price=350,Brand=brands.ElementAt(2),Image=images.ElementAt(23)},
                    new Product{Name="Gel-Burz 1 Kiko Kostadinov Limeade",Code="T8E3N-8989",ReleaseDate=new System.DateTime(2018, 1, 4),Price=305,Brand=brands.ElementAt(6),Image=images.ElementAt(24)},
                    new Product{Name="Air Max 90 Hyperfuse Independence Day",Code="613841-110",ReleaseDate=new System.DateTime(2013, 6, 29),Price=1000,Brand=brands.ElementAt(0),Image=images.ElementAt(25)},
                    new Product{Name="Kobe 1 Prelude 81 Points",Code="640221-001",ReleaseDate=new System.DateTime(2013, 12, 7),Price=200,Brand=brands.ElementAt(0),Image=images.ElementAt(26)},
                    new Product{Name="1 Retro High Travis Scott",Code="CD4487-100",ReleaseDate=new System.DateTime(2019, 5, 11),Price=800,Brand=brands.ElementAt(1),Image=images.ElementAt(27)},
                    new Product{Name="Yeezy Boost 350 V2",Code="CP9652",ReleaseDate=new System.DateTime(2017, 2, 11),Price=370,Brand=brands.ElementAt(2),Image=images.ElementAt(28)},
                    new Product{Name="React Element 87 Undercover",Code="BQ2718-400",ReleaseDate=new System.DateTime(2018, 9, 13),Price=190,Brand=brands.ElementAt(0),Image=images.ElementAt(29)},
                    new Product{Name="LD Waffle sacai Multi",Code="BV0073-400",ReleaseDate=new System.DateTime(2019, 5, 30),Price=155,Brand=brands.ElementAt(0),Image=images.ElementAt(30)},
                    new Product{Name="Curry 1 Championship Pack",Code="1287487-100",ReleaseDate=new System.DateTime(2015, 10, 20),Price=300,Brand=brands.ElementAt(9),Image=images.ElementAt(31)},
                    new Product{Name="Futurecraft 4D Black Neon",Code="GZ8626",ReleaseDate=new System.DateTime(2018, 1, 18),Price=250,Brand=brands.ElementAt(2),Image=images.ElementAt(32)},
                    new Product{Name="Kobe 9 Elite Masterpiece",Code="630847-001",ReleaseDate=new System.DateTime(2014, 2, 8),Price=220,Brand=brands.ElementAt(0),Image=images.ElementAt(33)},
                    new Product{Name="Air Max 1/97 Sean Wotherspoon",Code="AJ4219-400",ReleaseDate=new System.DateTime(2018, 3, 26),Price=650,Brand=brands.ElementAt(0),Image=images.ElementAt(34)},
                    new Product{Name="Air Foamposite One NRG Galaxy",Code="521286-800",ReleaseDate=new System.DateTime(2012, 2, 24),Price=800,Brand=brands.ElementAt(0),Image=images.ElementAt(35)},
                    new Product{Name="Ultra Boost 1.0 Cream White",Code="BB7802",ReleaseDate=new System.DateTime(2018, 10, 3),Price=200,Brand=brands.ElementAt(2),Image=images.ElementAt(36)},
                    new Product{Name="Air Max 1 Anniversary Red",Code="908375-103",ReleaseDate=new System.DateTime(2017, 9, 21),Price=340,Brand=brands.ElementAt(0),Image=images.ElementAt(37)},
                    new Product{Name="Air Force 1 Low '07 Black Black",Code="315122-001",ReleaseDate=new System.DateTime(2017, 9, 22),Price=100,Brand=brands.ElementAt(0),Image=images.ElementAt(38)},
                    new Product{Name="MB.01 LaMelo Ball Queen City",Code="377237-10",ReleaseDate=new System.DateTime(2019, 3, 13),Price=125,Brand=brands.ElementAt(8),Image=images.ElementAt(39)},
                    new Product{Name="RS X3 Sega Sonic the Hedgehog",Code="373429-01",ReleaseDate=new System.DateTime(2019, 11, 21),Price=220,Brand=brands.ElementAt(8),Image=images.ElementAt(40)},
                };
                var productColors = new List<ProductColor>
                {
                    new ProductColor{Product=products.ElementAt(0),Color=colors.ElementAt(0)},

                    new ProductColor{Product=products.ElementAt(1),Color=colors.ElementAt(0)},
                    new ProductColor{Product=products.ElementAt(1),Color=colors.ElementAt(2)},

                    new ProductColor{Product=products.ElementAt(2),Color=colors.ElementAt(3)},

                    new ProductColor{Product=products.ElementAt(3),Color=colors.ElementAt(0)},
                    new ProductColor{Product=products.ElementAt(3),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(3),Color=colors.ElementAt(3)},

                    new ProductColor{Product=products.ElementAt(4),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(4),Color=colors.ElementAt(5)},

                    new ProductColor{Product=products.ElementAt(5),Color=colors.ElementAt(0)},
                    new ProductColor{Product=products.ElementAt(5),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(5),Color=colors.ElementAt(6)},

                    new ProductColor{Product=products.ElementAt(6),Color=colors.ElementAt(2)},
                    new ProductColor{Product=products.ElementAt(6),Color=colors.ElementAt(7)},

                    new ProductColor{Product=products.ElementAt(7),Color=colors.ElementAt(7)},

                    new ProductColor{Product=products.ElementAt(8),Color=colors.ElementAt(0)},

                    new ProductColor{Product=products.ElementAt(9),Color=colors.ElementAt(8)},

                    new ProductColor{Product=products.ElementAt(10),Color=colors.ElementAt(0)},
                    new ProductColor{Product=products.ElementAt(10),Color=colors.ElementAt(4)},

                    new ProductColor{Product=products.ElementAt(11),Color=colors.ElementAt(0)},
                    new ProductColor{Product=products.ElementAt(11),Color=colors.ElementAt(2)},

                    new ProductColor{Product=products.ElementAt(12),Color=colors.ElementAt(8)},
                    new ProductColor{Product=products.ElementAt(12),Color=colors.ElementAt(9)},
                    new ProductColor{Product=products.ElementAt(12),Color=colors.ElementAt(10)},

                    new ProductColor{Product=products.ElementAt(13),Color=colors.ElementAt(8)},
                    new ProductColor{Product=products.ElementAt(13),Color=colors.ElementAt(9)},

                    new ProductColor{Product=products.ElementAt(14),Color=colors.ElementAt(1)},

                    new ProductColor{Product=products.ElementAt(15),Color=colors.ElementAt(0)},
                    new ProductColor{Product=products.ElementAt(15),Color=colors.ElementAt(3)},

                    new ProductColor{Product=products.ElementAt(16),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(16),Color=colors.ElementAt(2)},
                    new ProductColor{Product=products.ElementAt(16),Color=colors.ElementAt(4)},

                    new ProductColor{Product=products.ElementAt(17),Color=colors.ElementAt(11)},

                    new ProductColor{Product=products.ElementAt(18),Color=colors.ElementAt(2)},
                    new ProductColor{Product=products.ElementAt(18),Color=colors.ElementAt(7)},

                    new ProductColor{Product=products.ElementAt(19),Color=colors.ElementAt(6)},
                    new ProductColor{Product=products.ElementAt(19),Color=colors.ElementAt(12)},

                    new ProductColor{Product=products.ElementAt(20),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(20),Color=colors.ElementAt(6)},

                    new ProductColor{Product=products.ElementAt(21),Color=colors.ElementAt(12)},

                    new ProductColor{Product=products.ElementAt(22),Color=colors.ElementAt(13)},

                    new ProductColor{Product=products.ElementAt(23),Color=colors.ElementAt(5)},

                    new ProductColor{Product=products.ElementAt(24),Color=colors.ElementAt(13)},

                    new ProductColor{Product=products.ElementAt(25),Color=colors.ElementAt(0)},

                    new ProductColor{Product=products.ElementAt(26),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(26),Color=colors.ElementAt(8)},

                    new ProductColor{Product=products.ElementAt(27),Color=colors.ElementAt(0)},
                    new ProductColor{Product=products.ElementAt(27),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(27),Color=colors.ElementAt(5)},

                    new ProductColor{Product=products.ElementAt(28),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(28),Color=colors.ElementAt(2)},

                    new ProductColor{Product=products.ElementAt(29),Color=colors.ElementAt(3)},
                    new ProductColor{Product=products.ElementAt(29),Color=colors.ElementAt(4)},
                    new ProductColor{Product=products.ElementAt(29),Color=colors.ElementAt(13)},

                    new ProductColor{Product=products.ElementAt(30),Color=colors.ElementAt(2)},
                    new ProductColor{Product=products.ElementAt(30),Color=colors.ElementAt(3)},

                    new ProductColor{Product=products.ElementAt(31),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(31),Color=colors.ElementAt(13)},

                    new ProductColor{Product=products.ElementAt(32),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(32),Color=colors.ElementAt(4)},
                    new ProductColor{Product=products.ElementAt(32),Color=colors.ElementAt(9)},

                    new ProductColor{Product=products.ElementAt(33),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(33),Color=colors.ElementAt(7)},
                    new ProductColor{Product=products.ElementAt(33),Color=colors.ElementAt(13)},
                    new ProductColor{Product=products.ElementAt(33),Color=colors.ElementAt(14)},

                    new ProductColor{Product=products.ElementAt(34),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(34),Color=colors.ElementAt(3)},
                    new ProductColor{Product=products.ElementAt(34),Color=colors.ElementAt(4)},
                    new ProductColor{Product=products.ElementAt(34),Color=colors.ElementAt(13)},

                    new ProductColor{Product=products.ElementAt(35),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(35),Color=colors.ElementAt(10)},

                    new ProductColor{Product=products.ElementAt(36),Color=colors.ElementAt(0)},
                    new ProductColor{Product=products.ElementAt(36),Color=colors.ElementAt(8)},

                    new ProductColor{Product=products.ElementAt(37),Color=colors.ElementAt(0)},
                    new ProductColor{Product=products.ElementAt(37),Color=colors.ElementAt(2)},
                    new ProductColor{Product=products.ElementAt(37),Color=colors.ElementAt(8)},

                    new ProductColor{Product=products.ElementAt(38),Color=colors.ElementAt(1)},

                    new ProductColor{Product=products.ElementAt(39),Color=colors.ElementAt(9)},
                    new ProductColor{Product=products.ElementAt(39),Color=colors.ElementAt(10)},

                    new ProductColor{Product=products.ElementAt(40),Color=colors.ElementAt(1)},
                    new ProductColor{Product=products.ElementAt(40),Color=colors.ElementAt(2)},
                    new ProductColor{Product=products.ElementAt(40),Color=colors.ElementAt(3)},
                };
                var sizeCategories = new List<SizeCategory>
                {
                    new SizeCategory{Name="Toddler"},
                    new SizeCategory{Name="Little Kids"},
                    new SizeCategory{Name="Big Kids"},
                    new SizeCategory{Name="Women"},
                    new SizeCategory{Name="Men"},
                };
                var sizes = new List<Size>
                {
                    new Size{Number=16.0m,Detail="9cm",SizeCategory=sizeCategories.ElementAt(0)},
                    new Size{Number=17.0m,Detail="10cm",SizeCategory=sizeCategories.ElementAt(0)},
                    new Size{Number=18.5m,Detail="11cm",SizeCategory=sizeCategories.ElementAt(0)},
                    new Size{Number=19.5m,Detail="11.6cm",SizeCategory=sizeCategories.ElementAt(0)},
                    new Size{Number=21.0m,Detail="12.5cm",SizeCategory=sizeCategories.ElementAt(0)},
                    new Size{Number=22.0m,Detail="13.3cm",SizeCategory=sizeCategories.ElementAt(0)},
                    new Size{Number=23.5m,Detail="14cm",SizeCategory=sizeCategories.ElementAt(0)},
                    new Size{Number=25.0m,Detail="15cm",SizeCategory=sizeCategories.ElementAt(0)},
                    new Size{Number=26.0m,Detail="16cm",SizeCategory=sizeCategories.ElementAt(0)},
                    new Size{Number=27.0m,Detail="16.7cm",SizeCategory=sizeCategories.ElementAt(0)},
                    new Size{Number=27.5m,Detail="17cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=28.0m,Detail="17.6cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=28.5m,Detail="18cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=29.5m,Detail="18.4cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=30.0m,Detail="18.8cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=31.0m,Detail="19cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=31.5m,Detail="19.7cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=32.0m,Detail="20.1cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=33.0m,Detail="20.5cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=33.5m,Detail="21cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=34.0m,Detail="21.4cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=35.0m,Detail="21.8cm",SizeCategory=sizeCategories.ElementAt(1)},
                    new Size{Number=35.5m,Detail="22.2cm",SizeCategory=sizeCategories.ElementAt(2)},
                    new Size{Number=36.0m,Detail="22.4cm",SizeCategory=sizeCategories.ElementAt(2)},
                    new Size{Number=36.5m,Detail="22.7cm",SizeCategory=sizeCategories.ElementAt(2)},
                    new Size{Number=37.5m,Detail="23.1cm",SizeCategory=sizeCategories.ElementAt(2)},
                    new Size{Number=38.0m,Detail="23.5cm",SizeCategory=sizeCategories.ElementAt(2)},
                    new Size{Number=38.5m,Detail="23.8cm",SizeCategory=sizeCategories.ElementAt(2)},
                    new Size{Number=39.0m,Detail="24.2cm",SizeCategory=sizeCategories.ElementAt(2)},
                    new Size{Number=40.0m,Detail="24.6cm",SizeCategory=sizeCategories.ElementAt(2)},
                    new Size{Number=34.5m,Detail="21cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=35.0m,Detail="21.5cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=35.5m,Detail="22cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=36.0m,Detail="22.5cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=36.5m,Detail="23cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=37.5m,Detail="23.5cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=38.0m,Detail="24cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=38.5m,Detail="24.5cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=39.0m,Detail="25cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=40.0m,Detail="25.5cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=41.0m,Detail="26.5cm",SizeCategory=sizeCategories.ElementAt(3)},
                    new Size{Number=41.0m,Detail="26cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=42.0m,Detail="26.5cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=42.5m,Detail="27cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=43.0m,Detail="27.5cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=44.0m,Detail="28cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=44.5m,Detail="28.5cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=45.0m,Detail="29cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=45.5m,Detail="29.5cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=46.0m,Detail="30cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=47.0m,Detail="30.5cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=48.0m,Detail="31.5cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=49.0m,Detail="32.5cm",SizeCategory=sizeCategories.ElementAt(4)},
                    new Size{Number=50.0m,Detail="33.5cm",SizeCategory=sizeCategories.ElementAt(4)},
                };
                var productSizes = new List<ProductSize>
                {
                    new ProductSize{Product=products.ElementAt(38),Size=sizes.ElementAt(46)},//0
                    new ProductSize{Product=products.ElementAt(27),Size=sizes.ElementAt(40)},//1
                    new ProductSize{Product=products.ElementAt(28),Size=sizes.ElementAt(26)},//2
                    new ProductSize{Product=products.ElementAt(31),Size=sizes.ElementAt(20)},//3
                    new ProductSize{Product=products.ElementAt(38),Size=sizes.ElementAt(8)},//4
                    new ProductSize{Product=products.ElementAt(0),Size=sizes.ElementAt(42)},//5
                    new ProductSize{Product=products.ElementAt(6),Size=sizes.ElementAt(44)},//6
                    new ProductSize{Product=products.ElementAt(10),Size=sizes.ElementAt(50)},//7
                    new ProductSize{Product=products.ElementAt(16),Size=sizes.ElementAt(5)},//8
                    new ProductSize{Product=products.ElementAt(37),Size=sizes.ElementAt(29)},//9
                    new ProductSize{Product=products.ElementAt(1),Size=sizes.ElementAt(36)},//10
                    new ProductSize{Product=products.ElementAt(12),Size=sizes.ElementAt(24)},//11
                    new ProductSize{Product=products.ElementAt(19),Size=sizes.ElementAt(43)},//12
                    new ProductSize{Product=products.ElementAt(23),Size=sizes.ElementAt(39)},//13
                    new ProductSize{Product=products.ElementAt(36),Size=sizes.ElementAt(18)},//14
                    new ProductSize{Product=products.ElementAt(39),Size=sizes.ElementAt(53)},//15
                    new ProductSize{Product=products.ElementAt(18),Size=sizes.ElementAt(46)},//16
                    new ProductSize{Product=products.ElementAt(15),Size=sizes.ElementAt(30)},//17
                    new ProductSize{Product=products.ElementAt(24),Size=sizes.ElementAt(31)},//18
                    new ProductSize{Product=products.ElementAt(34),Size=sizes.ElementAt(42)},//19
                    new ProductSize{Product=products.ElementAt(8),Size=sizes.ElementAt(36)},//20
                    new ProductSize{Product=products.ElementAt(11),Size=sizes.ElementAt(33)},//21
                    new ProductSize{Product=products.ElementAt(6),Size=sizes.ElementAt(20)},//22
                    new ProductSize{Product=products.ElementAt(5),Size=sizes.ElementAt(46)},//23
                    new ProductSize{Product=products.ElementAt(20),Size=sizes.ElementAt(1)},//24
                    new ProductSize{Product=products.ElementAt(40),Size=sizes.ElementAt(18)},//25
                    new ProductSize{Product=products.ElementAt(27),Size=sizes.ElementAt(46)},//26
                    new ProductSize{Product=products.ElementAt(33),Size=sizes.ElementAt(49)},//27
                    new ProductSize{Product=products.ElementAt(9),Size=sizes.ElementAt(3)},//28
                    new ProductSize{Product=products.ElementAt(16),Size=sizes.ElementAt(44)},//29
                    new ProductSize{Product=products.ElementAt(25),Size=sizes.ElementAt(46)},//30
                    new ProductSize{Product=products.ElementAt(7),Size=sizes.ElementAt(36)},//31
                    new ProductSize{Product=products.ElementAt(28),Size=sizes.ElementAt(46)},//32
                    new ProductSize{Product=products.ElementAt(20),Size=sizes.ElementAt(46)},//33
                    new ProductSize{Product=products.ElementAt(32),Size=sizes.ElementAt(34)},//34
                    new ProductSize{Product=products.ElementAt(11),Size=sizes.ElementAt(46)},//35
                    new ProductSize{Product=products.ElementAt(30),Size=sizes.ElementAt(46)},//36
                };
                var cities = new List<City>
                {
                    new City{Name="Beograd",ZipCode="11000"},
                    new City{Name="Novi Sad",ZipCode="21000"},
                    new City{Name="Nis",ZipCode="18000"}
                };
                var stores = new List<Store>
                {
                    new Store{Name="Sport Vision",Address="Bulevar Kralja Aleksandra 1",Phone="0666666666",City=cities.ElementAt(0)},
                    new Store{Name="Retail Store",Address="Bulevar Kralja Aleksandra 111",Phone="0622222222",City=cities.ElementAt(0)}
                };
                var storeProductSizes = new List<StoreProductSize>
                {
                    new StoreProductSize{Product=productSizes.ElementAt(0),Store=stores.First(),Quantity=21},
                    new StoreProductSize{Product=productSizes.ElementAt(0),Store=stores.Last(),Quantity=0},
                    new StoreProductSize{Product=productSizes.ElementAt(1),Store=stores.First(),Quantity=1},
                    new StoreProductSize{Product=productSizes.ElementAt(1),Store=stores.Last(),Quantity=2},
                    new StoreProductSize{Product=productSizes.ElementAt(2),Store=stores.First(),Quantity=30},
                    new StoreProductSize{Product=productSizes.ElementAt(2),Store=stores.Last(),Quantity=20},
                    new StoreProductSize{Product=productSizes.ElementAt(3),Store=stores.First(),Quantity=15},
                    new StoreProductSize{Product=productSizes.ElementAt(3),Store=stores.Last(),Quantity=14},
                    new StoreProductSize{Product=productSizes.ElementAt(4),Store=stores.First(),Quantity=22},
                    new StoreProductSize{Product=productSizes.ElementAt(4),Store=stores.Last(),Quantity=27},
                    new StoreProductSize{Product=productSizes.ElementAt(5),Store=stores.First(),Quantity=6},
                    new StoreProductSize{Product=productSizes.ElementAt(5),Store=stores.Last(),Quantity=7},
                    new StoreProductSize{Product=productSizes.ElementAt(6),Store=stores.First(),Quantity=8},
                    new StoreProductSize{Product=productSizes.ElementAt(6),Store=stores.Last(),Quantity=19},
                    new StoreProductSize{Product=productSizes.ElementAt(7),Store=stores.First(),Quantity=15},
                    new StoreProductSize{Product=productSizes.ElementAt(7),Store=stores.Last(),Quantity=11},
                    new StoreProductSize{Product=productSizes.ElementAt(8),Store=stores.First(),Quantity=3},
                    new StoreProductSize{Product=productSizes.ElementAt(8),Store=stores.Last(),Quantity=0},
                    new StoreProductSize{Product=productSizes.ElementAt(9),Store=stores.First(),Quantity=1},
                    new StoreProductSize{Product=productSizes.ElementAt(9),Store=stores.Last(),Quantity=33},
                    new StoreProductSize{Product=productSizes.ElementAt(10),Store=stores.First(),Quantity=21},
                    new StoreProductSize{Product=productSizes.ElementAt(10),Store=stores.Last(),Quantity=7},
                    new StoreProductSize{Product=productSizes.ElementAt(11),Store=stores.First(),Quantity=3},
                    new StoreProductSize{Product=productSizes.ElementAt(11),Store=stores.Last(),Quantity=4},
                    new StoreProductSize{Product=productSizes.ElementAt(12),Store=stores.First(),Quantity=14},
                    new StoreProductSize{Product=productSizes.ElementAt(12),Store=stores.Last(),Quantity=17},
                    new StoreProductSize{Product=productSizes.ElementAt(13),Store=stores.First(),Quantity=2},
                    new StoreProductSize{Product=productSizes.ElementAt(13),Store=stores.Last(),Quantity=11},
                    new StoreProductSize{Product=productSizes.ElementAt(14),Store=stores.First(),Quantity=13},
                    new StoreProductSize{Product=productSizes.ElementAt(14),Store=stores.Last(),Quantity=0},
                    new StoreProductSize{Product=productSizes.ElementAt(15),Store=stores.First(),Quantity=4},
                    new StoreProductSize{Product=productSizes.ElementAt(15),Store=stores.Last(),Quantity=7},
                    new StoreProductSize{Product=productSizes.ElementAt(16),Store=stores.First(),Quantity=8},
                    new StoreProductSize{Product=productSizes.ElementAt(16),Store=stores.Last(),Quantity=20},
                    new StoreProductSize{Product=productSizes.ElementAt(17),Store=stores.First(),Quantity=21},
                    new StoreProductSize{Product=productSizes.ElementAt(17),Store=stores.Last(),Quantity=25},
                    new StoreProductSize{Product=productSizes.ElementAt(18),Store=stores.First(),Quantity=6},
                    new StoreProductSize{Product=productSizes.ElementAt(18),Store=stores.Last(),Quantity=7},
                    new StoreProductSize{Product=productSizes.ElementAt(19),Store=stores.First(),Quantity=1},
                    new StoreProductSize{Product=productSizes.ElementAt(19),Store=stores.Last(),Quantity=1},
                    new StoreProductSize{Product=productSizes.ElementAt(20),Store=stores.First(),Quantity=22},
                    new StoreProductSize{Product=productSizes.ElementAt(20),Store=stores.Last(),Quantity=4},
                    new StoreProductSize{Product=productSizes.ElementAt(21),Store=stores.First(),Quantity=6},
                    new StoreProductSize{Product=productSizes.ElementAt(21),Store=stores.Last(),Quantity=12},
                    new StoreProductSize{Product=productSizes.ElementAt(22),Store=stores.First(),Quantity=15},
                    new StoreProductSize{Product=productSizes.ElementAt(22),Store=stores.Last(),Quantity=1},
                    new StoreProductSize{Product=productSizes.ElementAt(23),Store=stores.First(),Quantity=0},
                    new StoreProductSize{Product=productSizes.ElementAt(23),Store=stores.Last(),Quantity=12},
                    new StoreProductSize{Product=productSizes.ElementAt(24),Store=stores.First(),Quantity=17},
                    new StoreProductSize{Product=productSizes.ElementAt(24),Store=stores.Last(),Quantity=7},
                    new StoreProductSize{Product=productSizes.ElementAt(25),Store=stores.First(),Quantity=7},
                    new StoreProductSize{Product=productSizes.ElementAt(25),Store=stores.Last(),Quantity=18},
                    new StoreProductSize{Product=productSizes.ElementAt(26),Store=stores.First(),Quantity=2},
                    new StoreProductSize{Product=productSizes.ElementAt(26),Store=stores.Last(),Quantity=9},
                    new StoreProductSize{Product=productSizes.ElementAt(27),Store=stores.First(),Quantity=3},
                    new StoreProductSize{Product=productSizes.ElementAt(27),Store=stores.Last(),Quantity=4},
                    new StoreProductSize{Product=productSizes.ElementAt(28),Store=stores.First(),Quantity=11},
                    new StoreProductSize{Product=productSizes.ElementAt(28),Store=stores.Last(),Quantity=10},
                    new StoreProductSize{Product=productSizes.ElementAt(29),Store=stores.First(),Quantity=20},
                    new StoreProductSize{Product=productSizes.ElementAt(29),Store=stores.Last(),Quantity=21},
                    new StoreProductSize{Product=productSizes.ElementAt(30),Store=stores.First(),Quantity=24},
                    new StoreProductSize{Product=productSizes.ElementAt(30),Store=stores.Last(),Quantity=6},
                    new StoreProductSize{Product=productSizes.ElementAt(31),Store=stores.First(),Quantity=17},
                    new StoreProductSize{Product=productSizes.ElementAt(31),Store=stores.Last(),Quantity=9},
                    new StoreProductSize{Product=productSizes.ElementAt(32),Store=stores.First(),Quantity=21},
                    new StoreProductSize{Product=productSizes.ElementAt(32),Store=stores.Last(),Quantity=19},
                    new StoreProductSize{Product=productSizes.ElementAt(33),Store=stores.First(),Quantity=1},
                    new StoreProductSize{Product=productSizes.ElementAt(33),Store=stores.Last(),Quantity=1},
                    new StoreProductSize{Product=productSizes.ElementAt(34),Store=stores.First(),Quantity=14},
                    new StoreProductSize{Product=productSizes.ElementAt(34),Store=stores.Last(),Quantity=2},
                    new StoreProductSize{Product=productSizes.ElementAt(35),Store=stores.First(),Quantity=0},
                    new StoreProductSize{Product=productSizes.ElementAt(35),Store=stores.Last(),Quantity=4},
                    new StoreProductSize{Product=productSizes.ElementAt(36),Store=stores.First(),Quantity=4},
                    new StoreProductSize{Product=productSizes.ElementAt(36),Store=stores.Last(),Quantity=5},
                };
                var roles = new List<Role>
                {
                    new Role{Name="User", IsDefault=true},
                    new Role{Name="Admin"}
                };
                var users = new List<User>
                {
                    new User{FirstName="Marko",LastName="Gobeljic",Username="markogobeljic1",Email="marko@gmail.com",Password=BCrypt.Net.BCrypt.HashPassword("sifra1"),Address="Adresa 1",BirthDate=new System.DateTime(2002,6,28),Phone="0655555555",City=cities.ElementAt(0),Role=roles.First(),ProfileImage=images.ElementAt(45)},
                    new User{FirstName="Milan",LastName="Borjan",Username="milanborjan1",Email="milan@gmail.com",Password=BCrypt.Net.BCrypt.HashPassword("sifra1"),Address="Adresa 2",BirthDate=new System.DateTime(1995,5,24),Phone="0641112222",City=cities.ElementAt(0),Role=roles.First(),ProfileImage=images.ElementAt(46)},
                    new User{FirstName="Aleksandar",LastName="Katai",Username="aleksandarkatai1",Email="aleksandar@gmail.com",Password=BCrypt.Net.BCrypt.HashPassword("sifra1"),Address="Adresa 3",BirthDate=new System.DateTime(2003,2,10),Phone="0633337777",City=cities.ElementAt(0),Role=roles.First(),ProfileImage=images.ElementAt(47)},
                    new User{FirstName="Nemanja",LastName="Milunovic",Username="nemanjamilunovic1",Email="nemanja@gmail.com",Password=BCrypt.Net.BCrypt.HashPassword("sifra1"),Address="Adresa 4",BirthDate=new System.DateTime(1993,2,10),Phone="0635553333",City=cities.ElementAt(0),Role=roles.First(),ProfileImage=images.ElementAt(46)},
                    new User{FirstName="Stefan",LastName="Mitrovic",Username="stefanmitrovic1",Email="stefan@gmail.com",Password=BCrypt.Net.BCrypt.HashPassword("sifra1"),Address="Adresa 5",BirthDate=new System.DateTime(1997,7,25),Phone="0633337777",City=cities.ElementAt(0),Role=roles.First(),ProfileImage=images.ElementAt(47)},
                    new User{FirstName="Nenad",LastName="Krsticic",Username="nenadkrsticic1",Email="nenad@gmail.com",Password=BCrypt.Net.BCrypt.HashPassword("sifra1"),Address="Adresa 6",BirthDate=new System.DateTime(2005,9,9),Phone="0677771188",City=cities.ElementAt(0),Role=roles.First(),ProfileImage=images.ElementAt(48)},
                    new User{FirstName="Usman",LastName="Bukari",Username="usmanbukari1",Email="usman@gmail.com",Password=BCrypt.Net.BCrypt.HashPassword("sifra1"),Address="Adresa 7",BirthDate=new System.DateTime(2005,9,9),Phone="0611111199",City=cities.ElementAt(0),Role=roles.First(),ProfileImage=images.ElementAt(48)},
                    new User{FirstName="Srdjan",LastName="Mijailovic",Username="srdjanmijailovic1",Email="srdjan@gmail.com",Password=BCrypt.Net.BCrypt.HashPassword("sifra1"),Address="Adresa 8",BirthDate=new System.DateTime(2005,9,9),Phone="0698881188",City=cities.ElementAt(0),Role=roles.First(),ProfileImage=images.ElementAt(48)},
                    new User{FirstName="Mirko",LastName="Ivanic",Username="mirkoivanic1",Email="mirko@gmail.com",Password=BCrypt.Net.BCrypt.HashPassword("sifra1"),Address="Adresa 9",BirthDate=new System.DateTime(2003,8,16),Phone="0644448888",City=cities.ElementAt(0),Role=roles.Last(),ProfileImage=images.ElementAt(48)},
                    new User{FirstName="Lazar",LastName="Nikolic",Username="lazarnikolic1",Email="lazar@gmail.com",Password=BCrypt.Net.BCrypt.HashPassword("sifra1"),Address="Adresa 10",BirthDate=new System.DateTime(1995,2,13),Phone="0644228866",City=cities.ElementAt(0),Role=roles.Last(),ProfileImage=images.ElementAt(45)},
                };
                var orders = new List<Order>
                {
                    new Order{User=users.ElementAt(0),PaymentType=PaymentType.Card,Total=1000,OrderDate=new System.DateTime(2020,12,17),PromisedDate=new System.DateTime(2020,12,17),ReceivedDate=new System.DateTime(2020,12,16),Status=OrderStatus.Completed,Store=stores.Last()},
                    new Order{User=users.ElementAt(1),PaymentType=PaymentType.COD,Total=1200,OrderDate=new System.DateTime(2021,6,7),PromisedDate=new System.DateTime(2021,6,12),ReceivedDate=new System.DateTime(2021,6,10),Status=OrderStatus.Completed,Store=stores.First()},
                    new Order{User=users.ElementAt(7),PaymentType=PaymentType.Card,Total=700,OrderDate=new System.DateTime(2022,1,1),PromisedDate=new System.DateTime(2022,1,6),ReceivedDate=new System.DateTime(2022,1,5),Status=OrderStatus.Completed,Store=stores.Last()},
                    new Order{User=users.ElementAt(0),PaymentType=PaymentType.Card,Total=500,OrderDate=new System.DateTime(2022,2,17),PromisedDate=new System.DateTime(2022,2,22),ReceivedDate=new System.DateTime(2020,2,20),Status=OrderStatus.Completed,Store=stores.First()},
                    new Order{User=users.ElementAt(3),PaymentType=PaymentType.COD,Total=920,OrderDate=new System.DateTime(2022,3,14),PromisedDate=new System.DateTime(2022,3,20),ReceivedDate=new System.DateTime(2022,3,18),Status=OrderStatus.Completed,Store=stores.Last()},
                    new Order{User=users.ElementAt(2),PaymentType=PaymentType.Card,Total=920,OrderDate=new System.DateTime(2022,4,1),PromisedDate=new System.DateTime(2022,4,7),ReceivedDate=new System.DateTime(2022,4,6),Status=OrderStatus.Completed,Store=stores.Last()},
                    new Order{User=users.ElementAt(5),PaymentType=PaymentType.Card,Total=960,OrderDate=new System.DateTime(2022,5,13),PromisedDate=new System.DateTime(2022,5,20),ReceivedDate=new System.DateTime(2022,5,18),Status=OrderStatus.Completed,Store=stores.First()},
                    new Order{User=users.ElementAt(0),PaymentType=PaymentType.Card,Total=700,OrderDate=new System.DateTime(2022,6,20),PromisedDate=new System.DateTime(2022,6,27),Status=OrderStatus.Cancelled,Store=stores.Last()},
                    new Order{User=users.ElementAt(5),PaymentType=PaymentType.Card,Total=200,OrderDate=new System.DateTime(2022,7,7),PromisedDate=new System.DateTime(2022,7,14),ReceivedDate=new System.DateTime(2022,7,13),Status=OrderStatus.Completed,Store=stores.First()},
                    new Order{User=users.ElementAt(5),PaymentType=PaymentType.COD,Total=960,OrderDate=new System.DateTime(2022,5,13),PromisedDate=new System.DateTime(2022,5,20),ReceivedDate=new System.DateTime(2022,5,18),Status=OrderStatus.Completed,Store=stores.First()},
                    new Order{User=users.ElementAt(7),PaymentType=PaymentType.Card,Total=200,OrderDate=new System.DateTime(2022,8,1),PromisedDate=new System.DateTime(2022,8,7),ReceivedDate=new System.DateTime(2022,8,6),Status=OrderStatus.Completed,Store=stores.First()},
                    new Order{User=users.ElementAt(4),PaymentType=PaymentType.COD,Total=2100,OrderDate=new System.DateTime(2022,8,8),PromisedDate=new System.DateTime(2022,8,14),ReceivedDate=new System.DateTime(2022,8,13),Status=OrderStatus.Completed,Store=stores.Last()},
                    new Order{User=users.ElementAt(6),PaymentType=PaymentType.Card,Total=250,OrderDate=new System.DateTime(2022,9,2),PromisedDate=new System.DateTime(2022,9,9),ReceivedDate=new System.DateTime(2022,9,6),Status=OrderStatus.Completed,Store=stores.First()},
                    new Order{User=users.ElementAt(0),PaymentType=PaymentType.Card,Total=850,OrderDate=new System.DateTime(2023,1,13),PromisedDate=new System.DateTime(2023,1,20),ReceivedDate=new System.DateTime(2023,1,18),Status=OrderStatus.Completed,Store=stores.Last()},
                    new Order{User=users.ElementAt(4),PaymentType=PaymentType.COD,Total=220,OrderDate=new System.DateTime(2023,3,10),PromisedDate=new System.DateTime(2023,3,15),ReceivedDate=new System.DateTime(2023,3,14),Status=OrderStatus.Completed,Store=stores.Last()},
                    new Order{User=users.ElementAt(1),PaymentType=PaymentType.COD,Total=160,OrderDate=new System.DateTime(2023,5,21),PromisedDate=new System.DateTime(2023,5,25),ReceivedDate=new System.DateTime(2023,5,24),Status=OrderStatus.Completed,Store=stores.Last()},
                    new Order{User=users.ElementAt(5),PaymentType=PaymentType.Card,Total=1000,OrderDate=new System.DateTime(2023,5,23),PromisedDate=new System.DateTime(2023,5,28),Status=OrderStatus.Cancelled,Store=stores.First()},
                    new Order{User=users.ElementAt(2),PaymentType=PaymentType.Card,Total=350,OrderDate=new System.DateTime(2023,5,31),PromisedDate=new System.DateTime(2023,6,4),ReceivedDate=new System.DateTime(2023,6,3),Status=OrderStatus.Completed,Store=stores.Last()},
                    new Order{User=users.ElementAt(7),PaymentType=PaymentType.Card,Total=250,OrderDate=new System.DateTime(2023,6,1),PromisedDate=new System.DateTime(2023,6,6),ReceivedDate=new System.DateTime(2023,6,5),Status=OrderStatus.Completed,Store=stores.First()},
                    new Order{User=users.ElementAt(2),PaymentType=PaymentType.Card,Total=960,OrderDate=new System.DateTime(2023,6,4),PromisedDate=new System.DateTime(2023,6,10),ReceivedDate=new System.DateTime(2023,6,9),Status=OrderStatus.Shipped,Store=stores.Last()},
                    new Order{User=users.ElementAt(5),PaymentType=PaymentType.Card,Total=960,OrderDate=new System.DateTime(2023,6,8),PromisedDate=new System.DateTime(2023,6,13),ReceivedDate=new System.DateTime(2023,6,11),Status=OrderStatus.Shipped,Store=stores.First()},
                };
                var orderItems = new List<OrderItem>
                {
                    new OrderItem{Product=productSizes.ElementAt(0),Order=orders.ElementAt(0),Price=100,Quantity=2},
                    new OrderItem{Product=productSizes.ElementAt(1),Order=orders.ElementAt(0),Price=800,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(30),Order=orders.ElementAt(1),Price=1000,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(14),Order=orders.ElementAt(1),Price=200,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(31),Order=orders.ElementAt(2),Price=700,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(4),Order=orders.ElementAt(3),Price=100,Quantity=5},
                    new OrderItem{Product=productSizes.ElementAt(17),Order=orders.ElementAt(4),Price=240,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(29),Order=orders.ElementAt(4),Price=680,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(0),Order=orders.ElementAt(5),Price=100,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(23),Order=orders.ElementAt(6),Price=160,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(26),Order=orders.ElementAt(6),Price=800,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(10),Order=orders.ElementAt(7),Price=100,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(16),Order=orders.ElementAt(7),Price=600,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(5),Order=orders.ElementAt(8),Price=100,Quantity=2},
                    new OrderItem{Product=productSizes.ElementAt(3),Order=orders.ElementAt(9),Price=300,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(1),Order=orders.ElementAt(9),Price=800,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(14),Order=orders.ElementAt(10),Price=200,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(20),Order=orders.ElementAt(11),Price=2100,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(15),Order=orders.ElementAt(12),Price=125,Quantity=2},
                    new OrderItem{Product=productSizes.ElementAt(11),Order=orders.ElementAt(13),Price=450,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(12),Order=orders.ElementAt(13),Price=400,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(27),Order=orders.ElementAt(14),Price=220,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(23),Order=orders.ElementAt(15),Price=160,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(32),Order=orders.ElementAt(16),Price=370,Quantity=2},
                    new OrderItem{Product=productSizes.ElementAt(33),Order=orders.ElementAt(16),Price=260,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(7),Order=orders.ElementAt(17),Price=175,Quantity=2},
                    new OrderItem{Product=productSizes.ElementAt(34),Order=orders.ElementAt(18),Price=250,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(3),Order=orders.ElementAt(19),Price=300,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(35),Order=orders.ElementAt(20),Price=895,Quantity=1},
                    new OrderItem{Product=productSizes.ElementAt(36),Order=orders.ElementAt(20),Price=155,Quantity=1},
                };
                var parentReviews = new List<Review>
                {
                    new Review{User=users.ElementAt(2),Stars=4,Text="Good product",Product=products.ElementAt(38)},
                    new Review{User=users.ElementAt(4),Stars=5,Text="Nice",Product=products.ElementAt(1)},
                    new Review{User=users.ElementAt(5),Stars=1,Text="Very bad quality",Product=products.ElementAt(23)},
                    new Review{User=users.ElementAt(7),Stars=3,Text="Good but expensive",Product=products.ElementAt(8)},
                    new Review{User=users.ElementAt(0),Stars=4,Text="Very good product",Product=products.ElementAt(39)},
                    new Review{User=users.ElementAt(2),Stars=2,Text="Not too bad",Product=products.ElementAt(8)},
                    new Review{User=users.ElementAt(1),Stars=4,Text="Nice",Product=products.ElementAt(25)},
                    new Review{User=users.ElementAt(0),Stars=5,Text="The best sneakers",Product=products.ElementAt(25)},
                    new Review{User=users.ElementAt(3),Stars=4,Text="One of the classics",Product=products.ElementAt(37)},
                    new Review{User=users.ElementAt(1),Stars=1,Text="Expensive",Product=products.ElementAt(8)},
                    new Review{User=users.ElementAt(2),Stars=4,Text="Good",Product=products.ElementAt(20)},
                    new Review{User=users.ElementAt(2),Stars=4,Text="Good",Product=products.ElementAt(18)},
                    new Review{User=users.ElementAt(7),Stars=3,Text="Decent",Product=products.ElementAt(14)},
                    new Review{User=users.ElementAt(0),Stars=2,Text="Dont like them",Product=products.ElementAt(8)},
                    new Review{User=users.ElementAt(4),Stars=2,Text="Bad",Product=products.ElementAt(31)},
                    new Review{User=users.ElementAt(3),Stars=5,Text="Love them",Product=products.ElementAt(6)},
                };
                var childReviews = new List<Review>
                {
                    new Review{User=users.ElementAt(3),Text="True",Product=products.ElementAt(8),ParentReview=parentReviews.ElementAt(9)},
                    new Review{User=users.ElementAt(7),Text="Dont buy them then",Product=products.ElementAt(8),ParentReview=parentReviews.ElementAt(9)},
                    new Review{User=users.ElementAt(4),Text="Why",Product=products.ElementAt(23),ParentReview=parentReviews.ElementAt(2)},
                    new Review{User=users.ElementAt(1),Text="Yeah",Product=products.ElementAt(37),ParentReview=parentReviews.ElementAt(8)},
                    new Review{User=users.ElementAt(7),Text="Why",Product=products.ElementAt(8),ParentReview=parentReviews.ElementAt(13)},
                    new Review{User=users.ElementAt(3),Text="I agree",Product=products.ElementAt(38),ParentReview=parentReviews.ElementAt(0)},
                    new Review{User=users.ElementAt(1),Text="You are lying",Product=products.ElementAt(39),ParentReview=parentReviews.ElementAt(4)},
                };
                var childChildReviews = new List<Review>
                {
                    new Review{User=users.ElementAt(1),Text="DDIRL",Product=products.ElementAt(8),ParentReview=childReviews.ElementAt(1)},
                    new Review{User=users.ElementAt(5),Text="Because they are bad",Product=products.ElementAt(23),ParentReview=childReviews.ElementAt(2)},
                };
                var roleUseCases = new List<RoleUseCase>
                {
                    new RoleUseCase{Role=roles.Last(),UseCaseId=1},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=2},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=3},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=4},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=5},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=6},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=7},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=8},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=9},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=10},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=11},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=12},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=13},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=14},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=15},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=16},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=17},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=18},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=19},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=20},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=21},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=22},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=23},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=24},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=25},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=26},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=27},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=28},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=29},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=30},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=31},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=32},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=33},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=34},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=35},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=36},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=37},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=38},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=39},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=40},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=41},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=42},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=43},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=44},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=45},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=46},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=47},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=48},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=49},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=50},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=51},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=52},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=53},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=54},
                    new RoleUseCase{Role=roles.Last(),UseCaseId=55},
                    new RoleUseCase{Role=roles.First(),UseCaseId=45},
                    new RoleUseCase{Role=roles.First(),UseCaseId=5},
                    new RoleUseCase{Role=roles.First(),UseCaseId=47},
                    new RoleUseCase{Role=roles.First(),UseCaseId=8},
                    new RoleUseCase{Role=roles.First(),UseCaseId=16},
                    new RoleUseCase{Role=roles.First(),UseCaseId=4},
                    new RoleUseCase{Role=roles.First(),UseCaseId=37},
                    new RoleUseCase{Role=roles.First(),UseCaseId=21},
                    new RoleUseCase{Role=roles.First(),UseCaseId=25},
                    new RoleUseCase{Role=roles.First(),UseCaseId=12},
                    new RoleUseCase{Role=roles.First(),UseCaseId=42},
                    new RoleUseCase{Role=roles.First(),UseCaseId=3},
                    new RoleUseCase{Role=roles.First(),UseCaseId=46},
                    new RoleUseCase{Role=roles.First(),UseCaseId=7},
                    new RoleUseCase{Role=roles.First(),UseCaseId=15},
                    new RoleUseCase{Role=roles.First(),UseCaseId=36},
                    new RoleUseCase{Role=roles.First(),UseCaseId=20},
                    new RoleUseCase{Role=roles.First(),UseCaseId=24},
                    new RoleUseCase{Role=roles.First(),UseCaseId=11},
                    new RoleUseCase{Role=roles.First(),UseCaseId=41},
                    new RoleUseCase{Role=roles.First(),UseCaseId=1},
                    new RoleUseCase{Role=roles.First(),UseCaseId=33},
                    new RoleUseCase{Role=roles.First(),UseCaseId=39},
                };

                _context.Colors.AddRange(colors);
                _context.Brands.AddRange(brands);
                _context.Files.AddRange(images);
                _context.Products.AddRange(products);
                _context.ProductColors.AddRange(productColors);
                _context.SizeCategories.AddRange(sizeCategories);
                _context.Sizes.AddRange(sizes);
                _context.ProductSizes.AddRange(productSizes);
                _context.Cities.AddRange(cities);
                _context.Stores.AddRange(stores);
                _context.StoreProductSizes.AddRange(storeProductSizes);
                _context.Roles.AddRange(roles);
                _context.Users.AddRange(users);
                _context.Orders.AddRange(orders);
                _context.OrderItems.AddRange(orderItems);
                _context.Reviews.AddRange(parentReviews);
                _context.Reviews.AddRange(childReviews);
                _context.Reviews.AddRange(childChildReviews);
                _context.RoleUseCases.AddRange(roleUseCases);

                _context.SaveChanges();

                return NoContent();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "There was an error");
            }
        }
    }
}
