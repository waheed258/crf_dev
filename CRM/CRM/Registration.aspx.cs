using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using EntityManager;

public partial class Registration : System.Web.UI.Page
{
    NewClientRegistrationBL newClientRegistrationBL = new NewClientRegistrationBL();
    ClientRegistrationEntity clientRegEntity = new ClientRegistrationEntity();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegistration_Click(object sender, EventArgs e)
    {
        try
        {
            int res = newClientRegistrationBL.CheckClient(txtEmailId.Text, txtSAID.Text);
            if (res == 1)
            {
                lblMessage.Text = "Client already exists. Please Login with existing credentials!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
            }
            else
            {
                clientRegEntity.FirstName = txtFirstName.Text;
                clientRegEntity.LastName = txtLastName.Text;
                clientRegEntity.MobileNumber = txtMobile.Text;
                clientRegEntity.SAID = txtSAID.Text;
                clientRegEntity.Title = ddlTitle.SelectedItem.Text;
                clientRegEntity.EmailID = txtEmailId.Text;
                clientRegEntity.CompanyName = txtCompanyName.Text;
                clientRegEntity.CompanyRegNo = txtComRegNum.Text;
                clientRegEntity.TrustName = txtTrust.Text;
                clientRegEntity.TrustRegNo = txtTrustNum.Text;

                int result = newClientRegistrationBL.CUDclientinfo(clientRegEntity, 'i');
                if (result == 1)
                {
                    
                    lblMessage.Text = "You Registered Successfully. One of our Avisors will contact you soon!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Clear();
                }
                else
                {

                    Clear();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void Clear()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMobile.Text = "";
        txtSAID.Text = "";
        txtEmailId.Text = "";
        ddlTitle.SelectedValue = "-1";
        txtCompanyName.Text = "";
        txtComRegNum.Text = "";
        txtTrust.Text = "";
        txtTrustNum.Text = "";
    }
    protected void btnegistrationCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
}