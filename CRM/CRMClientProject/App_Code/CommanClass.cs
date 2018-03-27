﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Net.Mail;
using System.Globalization;
using BusinessLogic;

public class CommanClass
{
    DataSet ds = new DataSet();
    public void GetCountry(DropDownList ddlCountry)
    {
        try
        {
            ds =new  ClientProfileBL().GetCountry();
            ddlCountry.DataSource = ds;
            ddlCountry.DataTextField = "Country";
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select Country--", "-1"));
        }
        catch
        {

        }
    }
    public void GetProvince(DropDownList ddlProvince)
    {
        try
        {
            ds =new  ClientProfileBL().GetProvince();
            ddlProvince.DataSource = ds;
            ddlProvince.DataTextField = "Province";
            ddlProvince.DataValueField = "ProvinceID";
            ddlProvince.DataBind();
            ddlProvince.Items.Insert(0, new ListItem("--Select Province--", "-1"));
        }
        catch
        {

        }
    }
    public void GetCity(DropDownList ddlCity)
    {
        try
        {
            ds =new ClientProfileBL().GetCity();
            ddlCity.DataSource = ds;
            ddlCity.DataTextField = "City";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--Select City--", "-1"));
        }
        catch
        {

        }
    }
    public void GetAccountType(DropDownList ddlAccountType)
    {
        try
        {
            ds =new  ClientProfileBL().GetAccountType();
            ddlAccountType.DataSource = ds;
            ddlAccountType.DataTextField = "AccountType";
            ddlAccountType.DataValueField = "AccountTypeID";
            ddlAccountType.DataBind();
            ddlAccountType.Items.Insert(0, new ListItem("--Select Account Type--", "-1"));
        }
        catch (Exception ex)
        {

        }
    }
    public static bool SendEmail(string SmtpHost, int SmtpPort, string MailFrom, string DisplayNameFrom, string FromPassword, string MailTo, string DisplayNameTo, string MailCc, string mailCc2, string mailCc3, string mailCc4, string DisplayNameCc, string MailBcc, string Subject, string MailText, string Attachment)
    {
        MailMessage myMessage = new MailMessage();
        bool IsSucces = false;
        try
        {
            myMessage.From = new MailAddress(MailFrom, DisplayNameFrom);
            if (MailTo != "")
                myMessage.To.Add(new MailAddress(MailTo, DisplayNameTo));
            if (MailCc != "")
                myMessage.CC.Add(new MailAddress(MailCc, DisplayNameCc));
            if (mailCc2 != "")
                myMessage.CC.Add(new MailAddress(mailCc2, DisplayNameCc));
            if (mailCc3 != "")
                myMessage.CC.Add(new MailAddress(mailCc3, DisplayNameCc));
            if (mailCc4 != "")
                myMessage.CC.Add(new MailAddress(mailCc4, DisplayNameCc));

            if (MailBcc != "")
                myMessage.Bcc.Add(MailBcc);

            myMessage.Subject = Subject;
            myMessage.IsBodyHtml = true;
            myMessage.Body = MailText;

            //create Alrternative HTML view
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(MailText, null, "text/html");

            //Add Image
            string image = System.Web.HttpContext.Current.Server.MapPath("/Admin") + "\\sign.jpg";
            LinkedResource theEmailImage = new LinkedResource(image);
            theEmailImage.ContentId = "myImageID";


            //Add the Image to the Alternate view
            htmlView.LinkedResources.Add(theEmailImage);

            //Add view to the Email Message
            myMessage.AlternateViews.Add(htmlView);

            if (Attachment != "")
            {
                Attachment a = new Attachment(Attachment);
                myMessage.Attachments.Add(a);
            }
            SmtpClient mySmtpClient = new SmtpClient(SmtpHost, SmtpPort);
            mySmtpClient.Credentials = new System.Net.NetworkCredential(MailFrom, FromPassword);
            mySmtpClient.EnableSsl = true;
            mySmtpClient.Send(myMessage);
            IsSucces = true;
        }
        catch
        {
            IsSucces = false;
        }
        finally
        {
            myMessage = null;
        }
        return IsSucces;
    }


    public static bool UpdateMail(string SmtpHost, int SmtpPort, string MailFrom, string DisplayNameFrom, string FromPassword, string MailTo, string DisplayNameTo, string MailCc, string mailCc2, string mailCc3, string mailCc4, string DisplayNameCc, string MailBcc, string Subject, string MailText, string Attachment)
    {
        MailMessage myMessage = new MailMessage();
        bool IsSucces = false;
        try
        {
            myMessage.From = new MailAddress(MailFrom, DisplayNameFrom);
            if (MailTo != "")
                myMessage.To.Add(new MailAddress(MailTo, DisplayNameTo));
            if (MailCc != "")
                myMessage.CC.Add(new MailAddress(MailCc, DisplayNameCc));
            if (mailCc2 != "")
                myMessage.CC.Add(new MailAddress(mailCc2, DisplayNameCc));
            if (mailCc3 != "")
                myMessage.CC.Add(new MailAddress(mailCc3, DisplayNameCc));
            if (mailCc4 != "")
                myMessage.CC.Add(new MailAddress(mailCc4, DisplayNameCc));

            if (MailBcc != "")
                myMessage.Bcc.Add(MailBcc);

            myMessage.Subject = Subject;
            myMessage.IsBodyHtml = true;
            myMessage.Body = MailText;

            //create Alrternative HTML view
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(MailText, null, "text/html");



            //Add view to the Email Message
            myMessage.AlternateViews.Add(htmlView);

            if (Attachment != "")
            {
                Attachment a = new Attachment(Attachment);
                myMessage.Attachments.Add(a);
            }
            SmtpClient mySmtpClient = new SmtpClient(SmtpHost, SmtpPort);
            mySmtpClient.Credentials = new System.Net.NetworkCredential(MailFrom, FromPassword);
            mySmtpClient.EnableSsl = true;
            mySmtpClient.Send(myMessage);
            IsSucces = true;
        }
        catch
        {
            IsSucces = false;
        }
        finally
        {
            myMessage = null;
        }
        return IsSucces;
    }

}