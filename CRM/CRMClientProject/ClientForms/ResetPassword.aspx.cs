using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientForms_ResetPassword : System.Web.UI.Page
{
    ResetPasswordBL resetPasswordBL = new ResetPasswordBL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            int result = resetPasswordBL.ResetPassword(txtOldPassword.Text, txtNewPassword.Text, Session["SAID"].ToString());
            if (result <= 0)
            {
                errormsg.Text = "Old password entered is invalid!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
            }
            else
            {
                message.Text = "Password has been changed successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
        catch
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void txtOldPassword_TextChanged(object sender, EventArgs e)
    {

    }
}