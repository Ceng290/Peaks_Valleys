<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Peaks_Valleys.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aequilibrium | The Castle Company</title>
    <link href="css/StyleSheet1.css" rel="stylesheet" />
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <div>
        <h1>Aequilibrium | The Castle Company</h1>
      </div>
      <br />
      <div>Please enter the integers that represents the land height.  For example [6,1,4]: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="regexpName" runat="server" ErrorMessage="Only enter integers separated by commas." ControlToValidate="TextBox1" ValidationExpression="[0-9]+(,[0-9]+)*" />
      </div>
      <br />
      <div>
        <asp:Button ID="Button1" runat="server" Text="Submit Values" OnClick="Button1_Click" />
      </div>
      <br />
      <div>
          The total number of castles to be built are: <asp:Label ID="numCastles" runat="server"></asp:Label>
      </div>
    </div>
  </form>
</body>
</html>

