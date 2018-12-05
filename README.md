# TOTPLite
Light WeightTOTP Library

The proposed solution uses the Google Authenticator as the mobile application where the OTP generation from the mobile token takes place and the server side supports the initial registration of token on the mobile device using the QR code . The secure algorithm to generate and validated the OTP is based on the RFC6238 https://tools.ietf.org/html/rfc6238 .

I have a setup a demo app on Azure for use , the steps that you can follow as outlined below.

1.	Install Google Authenticator from Play Store or App Store depending on your phone ( supported in both IOS and Android )
2.	Goto to the URL http://atioasistotplitedemo.azurewebsites.net/qrcode.aspx , enter some text information in the two text boxes . These are required to give some label information to the token which gets generated and runs on the Google Authenticator ( in real world these can be picked up from the user account ) like the example shown below the username entered is idsadmin and email is my email id. In real world these are picked up from the user account information .

 
3.	Once done Hit Generate QR Code button , this will give you a QR code on the page itself.
4.	Scan this using the Google Authenticator ( There will be an option to Add a token , followed by Scan a Bar Code ,you need to use it )
5.	Once the scan is done you should see the token on the Google Authenticator.

