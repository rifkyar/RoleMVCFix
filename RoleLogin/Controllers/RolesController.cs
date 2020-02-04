﻿using Dapper;
using RoleLogin.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RoleLogin.Controllers
{
    public class RolesController : Controller
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        // GET: Roles
        public ActionResult Index()
        {
            return View(GetDataRole());
        }

        public async Task<ActionResult> GetDataRole()
        {
            var result = await sqlConnection.QueryAsync<RoleVM>("EXEC SP_Retrieve_Role");
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Create(RoleVM roleVM)
        {
            var affectedRows = await sqlConnection.ExecuteAsync("EXEC SP_Insert_Role @Name", new {Name = roleVM.Name});
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Details(int id)
        {
            var result = await sqlConnection.QueryAsync<RoleVM>("EXEC SP_Retrieve_By_Id @Id", new { Id = id });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Edit(RoleVM roleVM)
        {
            var affectedRows = await sqlConnection.ExecuteAsync("EXEC SP_Update_Role @Id, @Name", new { Name = roleVM.Name, Id = roleVM.Id });
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await sqlConnection.QueryAsync("EXEC SP_Delete_Role @Id", new { Id = id });
            return Json(new { data = affectedRows }, JsonRequestBehavior.AllowGet);
        }
    }
}