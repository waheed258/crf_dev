using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;

public partial class AdminForms_ActivityLogList : System.Web.UI.Page
{
    CommanClass _objComman = new CommanClass();
    ActivitylogBL activitylogBL = new ActivitylogBL();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            string strPreviousPage = "";
            if (Request.UrlReferrer != null)
            {
                strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                if (Session["AdvisorID"] == null || Session["AdvisorID"].ToString() == "")
                {
                    Response.Redirect("../AdminLogin.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        _objComman.getRecordsPerPage(DropPage);
                        GetActivityLog(); 
                    }
                }
            }

            if (strPreviousPage == "")
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
        }
        catch
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    private void GetActivityLog() 
    {
        try
        {
            DataSet ds = new DataSet();
            ds = activitylogBL.GetActivitylog();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvActivityLog.DataSource = ds;
                search.Visible = true;
                ActivityLogList.Visible = true;

            }
            else
            {
                search.Visible = false;
                ActivityLogList.Visible = false;
            }
            gvActivityLog.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvActivityLog.DataBind();
        }
        catch
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetActivityLog();
    }

    protected void gvActivityLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvActivityLog.PageIndex = e.NewPageIndex;
            GetActivityLog();
        }
        catch
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void gvActivityLog_RowDataBound(object sender, GridViewRowEventArgs e) 
    {
        try
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                e.Row.Cells[0].Text = "" + ((((GridView)sender).PageIndex * ((GridView)sender).PageSize) + (e.Row.RowIndex + 1));
            }
        }
        catch
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}