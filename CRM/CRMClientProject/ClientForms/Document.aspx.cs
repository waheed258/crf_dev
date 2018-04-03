using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientForms_Document : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    private int InsertDocument()
    {
        int res=0;
        DocumentBL _objDoc = new DocumentBL();
        if (fuDoc.HasFile)
        {
            List<HttpPostedFile> lst = fuDoc.PostedFiles.ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                HttpPostedFile uploadfile = lst[i];
                string inFilename = fuDoc.PostedFiles[i].FileName;
                string strfile = Path.GetExtension(fuDoc.PostedFile.FileName);
                string date = DateTime.Now.ToString("yyyyMMddmmssfff");
                var folder = Server.MapPath("~/Documents/" + txtSAID.Text);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string fileName = date + strfile;
                fuDoc.SaveAs(Path.Combine(folder,fileName));
                res = _objDoc.DocumentManager(txtSAID.Text, fileName,'i');
            }
        }
        return res;
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
           int result= InsertDocument();
            if(result>0)
            {
                lblMessage.Text = "Saved Successfully !!";
            }
        }
        catch
        {
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}