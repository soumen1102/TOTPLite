using System;
using System.Collections.Generic;
using System.Text;

namespace TOTPLite.TOTPLite
{
    /// <summary>
    /// Class for Validating the OTP against the given secret.
    /// </summary>
    public class ValiadteTotp
    {
        /// <summary>
        /// Method for Verification of Entered OTP using TOTP Algorithm as per the RFC6238 https://tools.ietf.org/html/rfc6238
        /// </summary>
        /// <param name="sharedSecret">Secret use for Key Generation</param>
        /// <param name="otp">OTP Entered by user</param>
        /// <param name="timeStep">This is an out type parameter and gives the tickcount aginst the validated OTP</param>
        /// <returns></returns>
        public bool Verify(string sharedSecret, string otp, out long timeStep)
        {
            OtpNet.Totp totp = new OtpNet.Totp(Helpers.Base32ToBytes(sharedSecret), 30, OtpNet.OtpHashMode.Sha1, 6, null);
            return totp.VerifyTotp(otp, out timeStep, null);
        }

       

    }
}
