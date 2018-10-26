<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QRCode.aspx.cs" Inherits="QRCode_Demo.QRCode" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Oasis TOTP Lite Framework</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>TOTP Generation and Validation</h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">                       
                        <div class="form-group">
                           <label>Enter Username</label>
                            <br>
                             <div class="input-group">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                                 </div>
                            <br>
                        </div>
                        <div class="form-group">
                              <label>Enter Email</label>
                            <br>
                             <div class="input-group">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                 </div>
                        </div>
                         <div class="input-group">
                            <div class="form-group">
                               
                                 <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary" Text="Generate QR Code" OnClick="btnGenerate_Click_lib" />
                                 <br>
                                <br>
                                <asp:Label ID="lblSharedSecret" runat="server" Font-Bold="True" ForeColor="#0033CC"></asp:Label> 
                                 <br>
                                <br>
                            </div>
                            </div>
                        
                    </div>
                </div>
            </div>
            <br>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br>
            <br>
            <br>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <br>
                        <label>Enter OTP</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtOTP" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="input-group-prepend">
                                <asp:Button ID="cmdValidateOTP" runat="server" CssClass="btn btn-secondary" Text="Validate" OnClick="cmdOtpVerify_Click" />
                            </div>
                        </div>
                    <br />
                        </div>
                    </div>
                </div>            
        </div>
    </form>
</body>
</html>
