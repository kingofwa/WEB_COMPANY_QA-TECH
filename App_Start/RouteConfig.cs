using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace Web_congty
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Về chúng tôi
            routes.MapRoute(
               url: "ve-chung-toi-qua-trinh-hinh-thanh-va-phat-trien-html",
               name: "Về chúng tôi",
               defaults: new { controller = "About", action = "About" }
           );
            //tin tức
            routes.MapRoute(
               url: "tin-tuc",
               name: "News_post",
               defaults: new { controller = "Blog", action = "Index" }
           );
            //phần mềm
            routes.MapRoute(
               url: "Phan-mem-cong-ty-co-phan-cong-nghe-va-thiet-bi-quoc-anh",
               name: "Software",
               defaults: new { controller = "SoftWareHome", action = "Index"}
           );
            //Kỹ thuật
            routes.MapRoute(
               url: "Danh-sach-du-an-ky-thuat-cty-quoc-anh",
               name: "System_list",
               defaults: new { controller = "System", action = "Index"}
           );
            //Vì sao lại chọn chúng tôi
            routes.MapRoute(
                url: "vi-sao-lai-nen-chon-san-pham-cua-chung-toi-{nameintro}",
                name: "vi sao nen chọn chúng tôi",
                defaults: new { controller = "Because_choose", action = "BecauChoose" }
            ); 
            //trang đăng ký sử dụng phần mềm
            routes.MapRoute(
                url: "Dang-ky-dung-phan-mem/{idpvc}",
                name: "Register now software",
                defaults: new { controller = "Register_Software", action = "Choose"}
            );
            //chi tiet phần mềm
            routes.MapRoute(
                url: "chi-tiet-phan-mem-{title}-{tenphanmem}-{id}",
                name: "detail now software",
                defaults: new { controller = "Details_SW_", action = "Index", id = UrlParameter.Optional }
            );
            //trang chủ
            routes.MapRoute(
                url: "Cong-ty-co-phan-cong-nghe-va-thiet-bi-quoc-anh",
                name: "Homepage",
                defaults: new { controller = "Home", action = "Index"}
            );
            //danh mục
            routes.MapRoute(
                url: "danh-muc-{dmcha}-{dmc}-{id}",
                name: "danh-muc-home",
                defaults: new { controller = "ListOfBlog", action = "Index" }
            );
            //đăng ký tài khoản
            routes.MapRoute(
                url: "dang-ky-tai-khoan",
                name: "Dangkytaikhoan",
                defaults: new { controller = "Register", action = "Dangky" }
            );
            //chi tiet bài viết
            routes.MapRoute(
                url: "chi-tiet-bai-viet-{id}",
                name: "Chitieitbaivietblog",
                defaults: new { controller = "Blog_details", action = "Detals_News" }
            );
            //chi tiet phần mềm
            routes.MapRoute(
                url: "chi-tiet-phan-mem-{name}-{note}-{id}",
                name: "Chitietphanmem",
                defaults: new { controller = "Details_SW_", action = "Index" }
            );
            //trang cá nhân khách website
            routes.MapRoute(
                url: "thong-tin-ca-nhan-{name}-{id}",
                name: "trang cá nhân",
                defaults: new { controller = "Profile_User", action = "Profile" }
            );
            //Đăng bài viết từ trang cá nhân
            routes.MapRoute(
                url: "dang-bai-viet-moi-{id}",
                name: "Đăng bài viết từ trang cá nhân",
                defaults: new { controller = "Up_Post__", action = "Up_Post__" }
            );
            //Phần mềm đang triển khai và đã hoàn thành
            routes.MapRoute(
                url: "danh-sach-phan-mem-dang-trien-khai-va-da-hoan-thanh",
                name: "Phần mềm đang triển khai và đã hoàn thành",
                defaults: new { controller = "SoftWareHome", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
