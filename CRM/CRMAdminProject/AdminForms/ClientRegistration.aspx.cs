using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using EntityManager;
public partial class AdminForms_ClientRegistration : System.Web.UI.Page
{
    NewClientRegistrationBL newClientRegistrationBL = new NewClientRegistrationBL();
    ClientRegistrationEntity clientRegEntity = new ClientRegistrationEntity();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "alert('You Registered Successfully. One of our Avisors will contact you soon!');", true);
                Clear();
            }
            else
            {

                Clear();
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
}