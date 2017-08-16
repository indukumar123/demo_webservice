using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using webservice.api.Model;

namespace webservice.api
{
    /// <summary>
    /// Summary description for DataService
    /// </summary>
    [WebService()]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DataService : System.Web.Services.WebService
    {
        private regoEntities _objregoEntities = new regoEntities();

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public LoginViewModel Login(Login model)
        {

            var loginModel = new LoginViewModel();
            loginModel.Message = "error";  //can be override..
            loginModel.Status = false;
            try
            {
                mst_0010 userDetails = checkUser(model);  //get user either exists or not..

                if (userDetails != null)
                {
                    loginModel.Message = "Success"; //can be override..
                    loginModel.Status = true;
                    loginModel.result = new User()
                    {
                        Mail = userDetails.MST_MAIL,
                        Mobile = userDetails.MST_MOBI,
                        User_code = userDetails.MST_CODE,

                    };
                    return loginModel;
                }
                return loginModel;
            }
            catch (Exception ex)
            {
                return loginModel;
            }
            return loginModel;
        }



        private mst_0010 checkUser(Login model)
        {
            var userdata = _objregoEntities.mst_0010.Where(x => x.MST_MAIL == model.Mail && x.FLD_BLCK == true).FirstOrDefault();
            return userdata;
        }
    }
}
