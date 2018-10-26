using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOTPLite;

namespace TOTPLite.TOTPLite.WinDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            SeedTotp register = new SeedTotp("Aristocrat Inc");
            string sharedSecret = null;
            pictureBox1.Image = ByteToImage(register.GenerateQRCode(txtxUserName.Text, txtxEmail.Text, out sharedSecret));
            txtxSharedSecret.Text = sharedSecret;
            textBox1.ForeColor = Color.Black;
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();            
            return bm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValiadteTotp valiadteTotp = new ValiadteTotp();
            long timeStep = 0;


            if (valiadteTotp.Verify(txtxSharedSecret.Text, textBox1.Text, out timeStep))
            {
                MessageBox.Show("OTP Verification PASSED " + timeStep.ToString(), "TOTP Lite Framework", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.ForeColor = Color.Green;
            }
            else
            {
                MessageBox.Show("OTP Verification FAILED " + timeStep.ToString(), "TOTP Lite Framework", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.ForeColor = Color.Red;
            }

        }
    }
}
