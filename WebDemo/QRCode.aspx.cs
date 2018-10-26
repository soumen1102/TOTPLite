using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
//using QRCoder;
using TOTPLite.TOTPLite;

namespace QRCode_Demo
{
    public partial class QRCode : System.Web.UI.Page
    {
       

        protected void btnGenerate_Click_lib(object sender, EventArgs e)
        {
            SeedTotp register = new SeedTotp("Aristocrat Inc");
            string sharedSecret = null;
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 250;
            imgBarCode.Width = 250;

            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(register.GenerateQRCode(txtUsername.Text, txtEmail.Text, out sharedSecret));
            lblSharedSecret.Text = sharedSecret;
            PlaceHolder1.Controls.Add(imgBarCode);

        }

        protected void cmdOtpVerify_Click(object sender, EventArgs e)
        {
            ValiadteTotp valiadteTotp = new ValiadteTotp();
            long timeStep = 0;
            System.Web.UI.WebControls.Label lblOTPResult = new System.Web.UI.WebControls.Label();

            if (valiadteTotp.Verify(lblSharedSecret.Text,txtOTP.Text,out timeStep))
            {
                lblOTPResult.ForeColor = Color.Green;
                lblOTPResult.Text = "OTP Verification PASSED " + timeStep.ToString();

            }
            else
            {
                lblOTPResult.ForeColor = Color.Red;
                lblOTPResult.Text = "OTP Verification FAILED" + timeStep.ToString();
            }
            PlaceHolder1.Controls.Add(lblOTPResult);
        }     

       
    }
}