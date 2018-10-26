using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using QRCoder;

namespace TOTPLite.TOTPLite
{
    /// <summary>
    /// Class for facilitating the generation of Bar Code for registering the OTP generator on the device.
    /// </summary>
    public class SeedTotp
    {
        /// <summary>
        /// The Key URI Format as defined by Google
        /// Secret keys may be encoded in QR codes as a URI with the following format:
        /// otpauth://TYPE/LABEL?PARAMETERS
        /// https://github.com/google/google-authenticator/wiki/Key-Uri-Format
        /// </summary>
        const string  KEY_URI_FORMAT = @"otpauth://totp/{USERNAME}:{EMAIL}?secret={SECRET}&issuer={ISSUER}&algorithm=SHA1&digits=6&period=30";
      
        private string _qrCodeData;

        /// <summary>
        /// Constructore , it initializes the Bar Code generator with the issuer information.
        /// </summary>
        /// <param name="issuer">The Organization name for the issuer</param>
        public SeedTotp(string issuer)
        {
             _qrCodeData = KEY_URI_FORMAT.Replace("{ISSUER}", Uri.EscapeUriString(issuer));

        }
        /// <summary>
        /// Generates the QR code with the following details
        /// The label is used to identify which account a key is associated with.It contains an account name, which is a URI-encoded string, optionally prefixed by an issuer string identifying the provider or service managing that account.
        /// This issuer prefix can be used to prevent collisions between different accounts with different providers that might be identified using the same account name, e.g.the user's email address. The issuer prefix and account name should be separated by a literal or url-encoded colon,
        /// and optional spaces may precede the account name.Neither issuer nor account name may themselves contain a colon.Represented in ABNF according to RFC 5234:
        /// label = accountname / issuer(“:” / “% 3A”) *”%20” accountname Valid values might include Example:alice @gmail.com, Provider1:Alice%20Smith or Big%20Corporation%3A%20alice%40bigco.com.
        /// We recommend using both an issuer label prefix and an issuer parameter.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="sharedSecret"></param>
        /// <returns></returns>
        public byte[] GenerateQRCode(string username, string email, out string sharedSecret)
        {
            byte[] byteImage = null;
            byte[] secret = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(secret);
            sharedSecret = Helpers.BytesToBase32(secret);
            _qrCodeData = _qrCodeData.Replace("{USERNAME}", username);
            _qrCodeData = _qrCodeData.Replace("{EMAIL}", email);
            _qrCodeData = _qrCodeData.Replace("{SECRET}",sharedSecret);


            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCode qRCode = new QRCode();
            qRCode.SetQRCodeData(qrGenerator.CreateQrCode(_qrCodeData, QRCodeGenerator.ECCLevel.Q));
           

            using (Bitmap bitMap = qRCode.GetGraphic(40))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byteImage = ms.ToArray();
                }
            }
            return byteImage;
        }

       

    }
}
