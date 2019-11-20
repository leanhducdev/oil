using Microsoft.AspNetCore.Identity;
using OilCoreApp.Data.Entities;
using OilCoreApp.Data.Enums;
using OilCoreApp.Utilities.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilCoreApp.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            //Role
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top Manager"
                });

                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });

                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Top Customer"
                });
            }
            //User
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    Balance = 0
                }, "123654$");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            //Functions
            if (_context.Functions.Count() == 0)
            {
                _context.Functions.AddRange(new List<Functions>()
                {
                    new Functions(){Id="SYSTEM",Name="Hệ Thống",ParentId=null,SortOrder=1,Status=Status.Active,Urls="/",IconCss="fa-home"},
                    new Functions(){Id="ROLE",Name="Nhóm",ParentId="SYSTEM",SortOrder=1,Status=Status.Active,Urls="admin/role/index",IconCss="fa-home"},
                    new Functions(){Id="FUNCTION",Name="Chức Năng",ParentId="SYSTEM",SortOrder=1,Status=Status.Active,Urls="admin/function/index",IconCss="fa-home"},
                    new Functions(){Id="USER",Name="Người dùng",ParentId="SYSTEM",SortOrder=1,Status=Status.Active,Urls="admin/user/index",IconCss="fa-home"},
                    new Functions(){Id="ACTIVITY",Name="Nhật ký",ParentId="SYSTEM",SortOrder=1,Status=Status.Active,Urls="admin/activity/index",IconCss="fa-home"},
                    new Functions(){Id="ERROR",Name="Lỗi",ParentId="SYSTEM",SortOrder=1,Status=Status.Active,Urls="admin/error/index",IconCss="fa-home"},
                    new Functions(){Id="SETTING",Name="Cấu Hình",ParentId="SYSTEM",SortOrder=1,Status=Status.Active,Urls="admin/setting/index",IconCss="fa-home"},
                    new Functions(){Id="PRODUCT",Name="Sản Phẩm",ParentId=null,SortOrder=1,Status=Status.Active,Urls="admin/product/index",IconCss="fa-home"},
                    new Functions(){Id="PRODUCT_CATEGORY",Name="Danh Mục",ParentId="PRODUCT",SortOrder=1,Status=Status.Active,Urls="admin/productcategory/index",IconCss="fa-home"},
                    new Functions(){Id="PRODUCT_LIST",Name="Sản Phẩm",ParentId="PRODUCT",SortOrder=1,Status=Status.Active,Urls="admin/productlist/index",IconCss="fa-home"},
                    new Functions(){Id="BILL",Name="Hóa Đơn",ParentId="PRODUCT",SortOrder=1,Status=Status.Active,Urls="admin/bill/index",IconCss="fa-home"},
                    new Functions(){Id="CONTENT",Name="Nội Dung",ParentId="PRODUCT",SortOrder=1,Status=Status.Active,Urls="admin/content/index",IconCss="fa-home"},
                    new Functions(){Id="BLOG",Name="Bài Viết",ParentId="PRODUCT",SortOrder=1,Status=Status.Active,Urls="admin/blog/index",IconCss="fa-home"},
                    new Functions(){Id="UTILITY",Name="Tiện Ích",ParentId="UTILITY",SortOrder=1,Status=Status.Active,Urls="admin/blog/index",IconCss="fa-home"},
                    new Functions(){Id="FOOTER",Name="Footer",ParentId="FOOTER",SortOrder=1,Status=Status.Active,Urls="admin/footer/index",IconCss="fa-home"},
                    new Functions(){Id="FEEDBACK",Name="Phản hồi",ParentId="UTILITY",SortOrder=1,Status=Status.Active,Urls="admin/feedback/index",IconCss="fa-home"},
                    new Functions(){Id="ANNOUNCEMENT",Name="Thông báo",ParentId="UTILITY",SortOrder=1,Status=Status.Active,Urls="admin/announcement/index",IconCss="fa-home"},
                    new Functions(){Id="CONTACT",Name="Liên Hệ",ParentId="UTILITY",SortOrder=1,Status=Status.Active,Urls="admin/contact/index",IconCss="fa-home"},
                    new Functions(){Id="SLIDE",Name="Slides",ParentId="UTILITY",SortOrder=1,Status=Status.Active,Urls="admin/slide/index",IconCss="fa-home"},
                    new Functions(){Id="ADVERTISTMENT",Name="Quảng Cáo",ParentId="UTILITY",SortOrder=1,Status=Status.Active,Urls="admin/advertistment/index",IconCss="fa-home"},
                    new Functions(){Id="REPORT",Name="Báo Cáo",ParentId="REPORT",SortOrder=1,Status=Status.Active,Urls="admin/report/index",IconCss="fa-home"},
                    new Functions(){Id="REVENUES",Name="Báo Cáo Doanh Thu",ParentId="REPORT",SortOrder=1,Status=Status.Active,Urls="admin/revenues/index",IconCss="fa-home"},
                    new Functions(){Id="ACCESS",Name="Báo Cáo truy cập",ParentId="REPORT",SortOrder=1,Status=Status.Active,Urls="admin/access/index",IconCss="fa-home"},
                    new Functions(){Id="READER",Name="Báo Cáo Đọc Giả",ParentId="REPORT",SortOrder=1,Status=Status.Active,Urls="admin/reader/index",IconCss="fa-home"},
                });
            }
            //Footer
            if (_context.Footers.Count(x => x.Id == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "Footer";
                _context.Footers.Add(new Footer()
                {
                    Id = CommonConstants.DefaultFooterId,
                    Content = content
                });
                _context.SaveChanges();
            }
            //Color
            if (_context.Colors.Count() == 0)
            {
                List<Color> listColor = new List<Color>()
                {
                    new Color(){Name="Đen",Code="#000000"},
                    new Color(){Name="Trắng",Code="#ffffff"},
                    new Color(){Name="Đỏ",Code="#d6001c"},
                    new Color(){Name="Xanh",Code="#009cde"}
                };
                _context.Colors.AddRange(listColor);
            }
            //AdvertistmentPages
            if (_context.AdvertistmentPages.Count() == 0)
            {
                List<AdvertistmentPage> listAdvertistmentPage = new List<AdvertistmentPage>()
                {
                    new AdvertistmentPage(){Id="Home",Name="Trang-chu",AdvertistmentPositions=new List<AdvertistmentPosition>(){ new AdvertistmentPosition() {Id="Home-left",Name="Ben-trai"} } },
                    new AdvertistmentPage(){Id="Produc-cate",Name="Danh-muc-san-pham",AdvertistmentPositions=new List<AdvertistmentPosition>(){ new AdvertistmentPosition() {Id="product-cate-left",Name="Ben-trai"} } },
                    new AdvertistmentPage(){Id="product-detail",Name="Chi tiet san pham",AdvertistmentPositions=new List<AdvertistmentPosition>(){ new AdvertistmentPosition() {Id="product-detail-left",Name="Ben-trai"} } }
                };
                _context.AdvertistmentPages.AddRange(listAdvertistmentPage);
            }
            //Slide
            if (_context.Slides.Count() == 0)
            {
                List<Slide> listSlides = new List<Slide>()
                {
                    new Slide(){Name="Slide1",Image="client-side/images/slider/slide-1.jpg",Urls="#",DisplayOrder=0,GroupAlias="top",Status=true},
                    new Slide(){Name="Slide1",Image="client-side/images/slider/slide-2.jpg",Urls="#",DisplayOrder=1,GroupAlias="top",Status=true},
                    new Slide(){Name="Slide1",Image="client-side/images/slider/slide-3.jpg",Urls="#",DisplayOrder=2,GroupAlias="top",Status=true}
                };
                _context.Slides.AddRange(listSlides);
            }
            //Size
            if (_context.Sizes.Count() == 0)
            {
                List<Size> listSize = new List<Size>()
                {
                    new Size(){Name="XXL"},
                    new Size(){Name="XL"},
                    new Size(){Name="L"},
                    new Size(){Name="M"},
                    new Size(){Name="S"},
                    new Size(){Name="XS"}
                };
                _context.Sizes.AddRange(listSize);
            }
            //ProductCategory
            if (_context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory(){Name="Áo Nam",SeoAlias="ao-nam",ParentId=null,Status=Status.Active,SortOrder=1,
                        Products = new List<Product>()
                        {
                            new Product(){Name="Sản Phẩm 1",Image="client-side/images/products/product-1.jpg",SeoAlias="san-pham-1",Price=1000,PromotionPrice=800,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo quần nam đẹp"},
                            new Product(){Name="Sản Phẩm 2",Image="client-side/images/products/product-2.jpg",SeoAlias="san-pham-2",Price=2000,PromotionPrice=700,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo quần nam đẹp"},
                            new Product(){Name="Sản Phẩm 3",Image="client-side/images/products/product-3.jpg",SeoAlias="san-pham-3",Price=3000,PromotionPrice=800,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo quần nam đẹp"},
                            new Product(){Name="Sản Phẩm 4",Image="client-side/images/products/product-4.jpg",SeoAlias="san-pham-4",Price=4000,PromotionPrice=600,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo quần nam đẹp"}
                        }
                    },
                    new ProductCategory(){Name="Áo Nữ",SeoAlias="ao-nu",ParentId=null,Status=Status.Active,SortOrder=1,
                        Products = new List<Product>()
                        {
                            new Product(){Name="Sản Phẩm 5",Image="client-side/images/products/product-5.jpg",SeoAlias="san-pham-5",Price=1000,PromotionPrice=800,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo quần nữ đẹp"},
                            new Product(){Name="Sản Phẩm 6",Image="client-side/images/products/product-6.jpg",SeoAlias="san-pham-6",Price=2000,PromotionPrice=700,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo quần nữ đẹp"},
                            new Product(){Name="Sản Phẩm 7",Image="client-side/images/products/product-7.jpg",SeoAlias="san-pham-7",Price=3000,PromotionPrice=800,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo quần nữ đẹp"},
                            new Product(){Name="Sản Phẩm 8",Image="client-side/images/products/product-8.jpg",SeoAlias="san-pham-8",Price=4000,PromotionPrice=600,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo quần nữ đẹp"}
                        }
                    },
                    new ProductCategory(){Name="Giày Nữ",SeoAlias="giay-nu",ParentId=null,Status=Status.Active,SortOrder=1,
                        Products = new List<Product>()
                        {
                            new Product(){Name="Sản Phẩm 9",Image="client-side/images/products/product-9.jpg",SeoAlias="san-pham-9",Price=1000,PromotionPrice=800,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo giày nữ đẹp"},
                            new Product(){Name="Sản Phẩm 10",Image="client-side/images/products/product-10.jpg",SeoAlias="san-pham-10",Price=2000,PromotionPrice=700,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo giày nữ đẹp"},
                            new Product(){Name="Sản Phẩm 11",Image="client-side/images/products/product-11.jpg",SeoAlias="san-pham-11",Price=3000,PromotionPrice=800,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo giày nữ đẹp"},
                            new Product(){Name="Sản Phẩm 12",Image="client-side/images/products/product-12.jpg",SeoAlias="san-pham-12",Price=4000,PromotionPrice=600,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo giày nữ đẹp"}
                        }
                    },
                    new ProductCategory(){Name="Giày Nam",SeoAlias="giay-nam",ParentId=null,Status=Status.Active,SortOrder=1,
                        Products = new List<Product>()
                        {
                            new Product(){Name="Sản Phẩm 13",Image="client-side/images/products/product-13.jpg",SeoAlias="san-pham-13",Price=1000,PromotionPrice=800,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo giày nam đẹp"},
                            new Product(){Name="Sản Phẩm 14",Image="client-side/images/products/product-14.jpg",SeoAlias="san-pham-14",Price=2000,PromotionPrice=700,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo giày nam đẹp"},
                            new Product(){Name="Sản Phẩm 15",Image="client-side/images/products/product-15.jpg",SeoAlias="san-pham-15",Price=3000,PromotionPrice=800,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo giày nam đẹp"},
                            new Product(){Name="Sản Phẩm 16",Image="client-side/images/products/product-16.jpg",SeoAlias="san-pham-16",Price=4000,PromotionPrice=600,OrignalPrice=900,Status=Status.Active,Description="sản phẩm về áo giày nam đẹp"}
                        }
                    }
                };
                _context.ProductCategories.AddRange(listProductCategory);
            }
            //SystemConfigs
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeTitle"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeTitle",
                    Name = "Tiêu đề trang chủ",
                    Value1 = "Trang chủ Oil Shop",
                    Status = Status.Active
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaKeyWork"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaKeyWork",
                    Name = "Từ khóa trang chủ",
                    Value1 = "Trang chủ Oil Shop",
                    Status = Status.Active
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaDescription"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaDescription",
                    Name = "Mô tả trang chủ",
                    Value1 = "Trang chủ Oil Shop",
                    Status = Status.Active
                });
            }
        }
    }
}
