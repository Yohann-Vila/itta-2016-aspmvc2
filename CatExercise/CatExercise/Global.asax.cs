using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CatExercise
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            if (Dao.DAOFactory.getInstanceOfUser().FindByLogin("test_user") == null) {
                Dao.DAOFactory.getInstanceOfUser().Insert(new Models.UserView() {
                    Banish = false,
                    Creationdate = DateTime.Now,
                    Login = "test_user",
                    Password = "test_user",
                    Seclevel = 0
                });
            }
            if (Dao.DAOFactory.getInstanceOfUser().FindByLogin("test_admin") == null) {
                Dao.DAOFactory.getInstanceOfUser().Insert(new Models.UserView() {
                    Banish = false,
                    Creationdate = DateTime.Now,
                    Login = "test_admin",
                    Password = "test_admin",
                    Seclevel = 100
                });
            }
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e) {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];            
            if (authCookie == null || authCookie.Value == "" )
                return;

            FormsAuthenticationTicket authTicket;
            try {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            } catch {
                return;
            }

            // retrieve roles from UserData
            string[] roles = authTicket.UserData.Split(';');

            if (Context.User != null)
                Context.User = new GenericPrincipal(Context.User.Identity, roles);
        }
    }
}