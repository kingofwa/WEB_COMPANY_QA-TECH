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
         
             //hỗ trợ
            routes.MapRoute(
               url: "ho-tro-giai-dap-thac-mac",
               name: "About_client",
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
            //trang đăng ký sử dụng phần mềm
            routes.MapRoute(
                url: "Dang-ky-dung-phan-mem/{idpvc}",
                name: "Register now software",
                defaults: new { controller = "Register_Software", action = "Choose"}
            );
            //chi tiet phần mềm
            routes.MapRoute(
                url: "chi-tiet-phan-mem/{id}",
                name: "detail now software",
                defaults: new { controller = "Details_SW_", action = "Index", id = UrlParameter.Optional }
            );
            //trang chủ
            routes.MapRoute(
                url: "Cong-ty-co-phan-cong-nghe-va-thiet-bi-quoc-anh",
                name: "Homepage",
                defaults: new { controller = "Home", action = "Index"}
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
