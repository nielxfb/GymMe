using GymMe.Controllers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
	public partial class UpdateSupplement : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LblError.ForeColor = System.Drawing.Color.Red;

			if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
			{
				Response.Redirect("~/Views/LoginPage.aspx");
				return;
			}

			if (Session["user"] == null)
			{
				string cookie = Request.Cookies["user_cookie"].Value;
				Response<MsUser> response = UserController.LoginUserByCookie(cookie);

				if (!response.Success)
				{
					Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
					Response.Redirect("~/Views/LoginPage.aspx");
					return;
				}

				Session["user"] = response.Data;
			}

			MsUser currUser = Session["user"] as MsUser;

			if (currUser.UserRole.Equals("Customer"))
			{
				Response.Redirect("~/Views/HomePage.aspx");
				return;
			}

			if (!IsPostBack)
			{
				RefreshDropdown();

				int id = int.Parse(Request["Id"]);
				Response<MsSupplement> response = SupplementController.GetSupplementById(id);

				if (!response.Success)
				{
					LblError.Text = response.Message;
					return;
				}

				MsSupplement supplement = response.Data;
				TxtName.Text = supplement.SupplementName;
				TxtExpiry.Text = supplement.SupplementExpiryDate.ToShortDateString();
				TxtPrice.Text = supplement.SupplementPrice.ToString();
				DDLType.SelectedValue = supplement.SupplementTypeID.ToString();
			}
		}

		private void RefreshDropdown()
		{
			Response<List<MsSupplementType>> response = SupplementTypeController.GetAllTypes();

			if (response.Success)
			{
				DDLType.DataSource = response.Data;
				DDLType.DataTextField = "SupplementTypeName";
				DDLType.DataValueField = "SupplementTypeID";
				DDLType.DataBind();
			}
			else
			{
				LblError.Text = response.Message;
				LblError.ForeColor = System.Drawing.Color.Red;
			}
		}

		protected void LBBack_Click(object sender, EventArgs e)
		{

		}

		protected void BtnUpdate_Click(object sender, EventArgs e)
		{

		}
	}
}