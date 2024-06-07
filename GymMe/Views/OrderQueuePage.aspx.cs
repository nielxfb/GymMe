using GymMe.Controllers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
	public partial class OrderQueuePage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
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
				RefreshOrderQueue();
			}
		}

		private void RefreshOrderQueue()
		{
			Response<List<TransactionHeader>> response = TransactionController.GetAllHeaders();

			if (response.Success)
			{
				GVOrders.DataSource = response.Data;
				GVOrders.DataBind();
			}
		}

		protected void GVOrders_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName.Equals("Handle"))
			{
				Control sourceControl = e.CommandSource as Control;
				GridViewRow row = sourceControl.NamingContainer as GridViewRow;
				int index = row.RowIndex;
				int id = int.Parse(GVOrders.Rows[index].Cells[0].Text);

				Response<TransactionHeader> response = TransactionController.UpdateTransactionStatus(id, "Handled");

				LblError.Text = response.Message;
				LblError.ForeColor = (response.Success) ? System.Drawing.Color.Blue : System.Drawing.Color.Red;

				RefreshOrderQueue();
			}
		}
	}
}