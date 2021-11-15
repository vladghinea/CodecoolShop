using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Codecool.CodecoolShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            SetupInMemoryDatabases();
        }

        private void SetupInMemoryDatabases()
        {
            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();
            IUserDao userDataStore = UserDaoMemory.GetInstance();


            Supplier amazon = new Supplier{Name = "Amazon", Description = "Digital content and services"};
            supplierDataStore.Add(amazon);
            Supplier lenovo = new Supplier{Name = "Lenovo", Description = "Computers"};
            supplierDataStore.Add(lenovo);
            Supplier asus = new Supplier { Name = "Asus", Description = "Computers" };
            supplierDataStore.Add(asus);
            Supplier dell = new Supplier { Name = "Dell", Description = "Computers" };
            supplierDataStore.Add(dell);
            Supplier samsung = new Supplier { Name = "Samsung", Description = "Devices" };
            supplierDataStore.Add(samsung);
            Supplier apple = new Supplier { Name = "Apple", Description = "Devices" };
            supplierDataStore.Add(apple);
            Supplier nikon = new Supplier { Name = "Nikon", Description = "Cameras" };
            supplierDataStore.Add(nikon);
            Supplier gopro = new Supplier { Name = "GoPro", Description = "Cameras" };
            supplierDataStore.Add(gopro);

            //laptop
            ProductCategory laptop = new ProductCategory { Name = "Laptop", Department = "Hardware", Description = "A laptop, laptop computer, or notebook computer is a small, portable personal computer (PC) with a screen and alphanumeric keyboard." };
            productCategoryDataStore.Add(laptop);

            productDataStore.Add(new Product { Name = "Apple MacBook Air MD760LLA 13.3-Inch", DefaultPrice = 329.0m, Currency = "USD", Description = "Physically this laptop is light and versatile allowing you to bring your work where ever you go.", ProductCategory = laptop, Supplier = apple });
            productDataStore.Add(new Product { Name = "2021 ASUS ROG Zephyrus G14", DefaultPrice = 1159.9m, Currency = "USD", Description = "Capacity:16GB RAM|512GB PCIe SSD 14\" Full HD display The 1920 x 1080 resolution boasts impressive color and clarity.", ProductCategory = laptop, Supplier = asus });
            productDataStore.Add(new Product { Name = "Lenovo Legion Y540 15.6", DefaultPrice = 1099.9m, Currency = "USD", Description = "LAPTOP GAMING, FURTHER REFINED. This sleek, portable 15.6\" laptop pushes gaming performance to a new level.", ProductCategory = laptop, Supplier = lenovo });
            productDataStore.Add(new Product { Name = "2021 Newest Dell Inspiron 15 3000", DefaultPrice = 799.9m, Currency = "USD", Description = "Capacity:16GB RAM, 512GB SSD  |  Style:Core 10th i5.", ProductCategory = laptop, Supplier = dell });

            //tv
            ProductCategory tv = new ProductCategory { Name = "Tv", Department = "Hardware", Description = "Television, sometimes shortened to TV, is a telecommunication medium used for transmitting moving images in monochrome, or in color, and in two or three dimensions and sound." };
            productCategoryDataStore.Add(tv);

            productDataStore.Add(new Product { Name = "TV Samsung 43AU8072", DefaultPrice = 405.0m, Currency = "USD", Description = "Take your Smart TV viewing to amazing new heights in Crystal UHD with the super slim, minimalistic Samsung 43-inch AU8000 Crystal UHD 4K HDR Smart TV with 3 HDMI Ports", ProductCategory = tv, Supplier = samsung });
            productDataStore.Add(new Product { Name = "TV Samsung QN32LS03TBFXZA", DefaultPrice = 455.0m, Currency = "USD", Description = "Artwork, television, movies, and memories - The Frame TV showcases it all on a beautiful QLED screen. Every piece of content is displayed in stunning 4K resolution and accented by a customizable, stylish bezel that seamlessly compliments your home’s decor. ", ProductCategory = tv, Supplier = samsung });

            //camera
            ProductCategory camera = new ProductCategory { Name = "Camera", Department = "Hardware", Description = "A camera is an optical instrument that captures a visual image." };
            productCategoryDataStore.Add(camera);

            productDataStore.Add(new Product { Name = "Nikon Z6 Full Frame Mirrorless Camera Body", DefaultPrice = 1596.9m, Currency = "USD", Description = "The all-around camera for those seeking an ideal balance between resolution, speed and low-light performance. 12 fps 12-bit RAW or JPEG shooting. 4K Ultra HD video with full pixel readout.", ProductCategory = camera, Supplier = nikon });
            productDataStore.Add(new Product { Name = "GoPro HERO10 Black", DefaultPrice = 499.9m, Currency = "USD", Description = "GoPro HERO10 Black - Waterproof Action Camera with Front LCD and Touch Rear Screens, 5.3K60 Ultra HD Video, 23MP Photos, 1080p Live Streaming, Webcam, Stabilization.", ProductCategory = camera, Supplier = gopro });

            //phone
            ProductCategory phone = new ProductCategory { Name = "Phone", Department = "Hardware", Description = "A mobile phone, cell or just phone, is a portable telephone that can make and receive calls over a radio frequency link while the user is moving within a telephone service area." };
            productCategoryDataStore.Add(phone);

            productDataStore.Add(new Product { Name = "Apple iPhone 11", DefaultPrice = 459.0m, Currency = "USD", Description = "Just the right amount of everything. A new dual‑lens rear system captures more of what you see and love. The fastest chip ever in a smartphone and all‑day battery life let you do more and charge less. And the highest‑quality video in a smartphone, so your memories look better than ever.", ProductCategory = phone, Supplier = apple });
            productDataStore.Add(new Product { Name = "Galaxy Z Flip 3 5G", DefaultPrice = 999.9m, Currency = "USD", Description = "Galaxy Z Flip 3 5G Factory Unlocked Android Cell Phone US Version Smartphone Flex Mode Intuitive Camera Compact 128GB Storage US Warranty, Green.", ProductCategory = phone, Supplier = samsung });


            // tablets
            ProductCategory tablet = new ProductCategory {Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            productCategoryDataStore.Add(tablet);
            productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = tablet, Supplier = lenovo });
            productDataStore.Add(new Product { Name = "Apple iPad 9.7inch", DefaultPrice = 198.9m, Currency = "USD", Description = "Processor: 1.65 GHz None RAM: 32 GB DDR4 Graphics Coprocessor: M9 Wireless Type : 802.11 a/b/g/n/ac", ProductCategory = tablet, Supplier = apple });
            productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });

            // user
            User john = new User("John", "Doe", "040760368517", "john.doe@gmai.com", "New York", "5'th Avenue", "51B", "Avangard", "A", "25", "99");
            userDataStore.Add(john);




        }
    }
}
