using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;

public partial class AdminForms_WorkInProcess : System.Web.UI.Page
{
    ServiceRequestBL serviceRequestBL = new ServiceRequestBL();
    DataSet dataset = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            GetGridData();
        }
    }
    protected void gvWorkInProcess_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GetGridData()
    {
        try
        {
            dataset = serviceRequestBL.GetWorkInProcess();
            gvWorkInProcess.DataSource = dataset;
            gvWorkInProcess.DataBind();
        }
        catch
        {

        }
    }
}