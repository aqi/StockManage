<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersPage.aspx.cs" Inherits="Web0204.BM.WebView.UsersPage" %>

<%@ Register Src="Manager.ascx" TagName="Manager" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户信息管理</title>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
.STYLE1 {
	color: #43860c;
	font-size: 12px;
}
-->
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" style="table-layout:fixed">
  <tr>
    <td><table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout:fixed;">
  <tr>
    <td height="9" style="line-height:9px; background-image:url(images/main_04.gif)"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="97" height="9" background="images/main_01.gif">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="47" background="images/main_09.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="38" height="47" background="images/main_06.gif">&nbsp;</td>
        <td width="59"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="29" background="images/main_07.gif">&nbsp;</td>
          </tr>
          <tr>
            <td height="18" background="images/main_14.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout:fixed;">
              <tr>
                <td  style="width:1px;">&nbsp;</td>
                <td ><span class="STYLE1"><asp:Label ID="account" runat="server"></asp:Label></span></td>
              </tr>
            </table></td>
          </tr>
        </table></td>
        <td width="155" background="images/main_08.gif">&nbsp;</td>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="23" valign="bottom">&nbsp;</td>
          </tr>
		 <!--获取系统的当前时间--> 
        </table></td>
        <td width="200" background="images/main_11.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="11%" height="23">&nbsp;</td>
            <td width="89%" valign="bottom"><span class="STYLE1">日期：<asp:Label ID="datetime" runat="server" Text="Label"></asp:Label></span></td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="5" style="line-height:5px; background-image:url(images/main_18.gif)"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="180" background="images/main_16.gif"  style="line-height:5px;">&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table></td>
  </tr>
  <tr>
    <td><table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" style="table-layout:fixed">
  <tr>
    <td background="images/main_40.gif" style="width:3px; height: 184px;">&nbsp;</td>
    <td  style="border-right:solid 1px #9ad452; height: 184px; width: 100px;" valign="top">
        &nbsp;
        <uc1:Manager ID="Manager1" runat="server" />
    </td>
    <td style="width: 516px; height: 184px; font-size: 12px;" valign="top">
        <asp:Label ID="lbl_Name" runat="server" Text="用户名称："></asp:Label>
        <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_name"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
        &nbsp;
        <br />
        <asp:Label ID="lbl_phone" runat="server" Text="电话："></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="txt_phone" runat="server" MaxLength="13"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_phone"
            ErrorMessage="电话号码格式为‘0000-00000000’！" ValidationExpression="\d{4}-?\d{8}"></asp:RegularExpressionValidator>
        &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<br />
        <asp:Label ID="lbl_fax" runat="server" Text="传真："></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="txt_fax" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_pass"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txt_fax"
            ErrorMessage="传真地址格式为‘000-000000000’！" ValidationExpression="(\(\d{3}\)|\d{3}-)?\d{9}"></asp:RegularExpressionValidator>
        &nbsp;
        <br />
        <asp:Label ID="lbl_email" runat="server" Text="邮件："></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_name"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txt_email"
            ErrorMessage="电子邮件格式为‘xxx@xx.com’！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        <asp:Label ID="lbl_account" runat="server" Text="登录帐号："></asp:Label>
        <asp:TextBox ID="txt_account" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_name"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
        &nbsp;
        <br />
        <asp:Label ID="lbl_pass" runat="server" Text="登录密码："></asp:Label>
        <asp:TextBox ID="txt_pass" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_name"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
        &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;<br />
        <asp:Label ID="lbl_roleName" runat="server" Text="角色名称:"></asp:Label>
        &nbsp; &nbsp;
        <asp:DropDownList ID="ddl_roleName" runat="server">
            <asp:ListItem Value="1">管理员</asp:ListItem>
            <asp:ListItem Value="2">采购员</asp:ListItem>
            <asp:ListItem Value="3">销售员</asp:ListItem>
            <asp:ListItem Value="4">仓库员</asp:ListItem>
        </asp:DropDownList>&nbsp;<br />
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btn_sure" runat="server"
            Font-Size="12px" OnClick="btn_sure_Click" Text="保 存" />
        &nbsp;&nbsp;
        <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="重 置" Font-Size="12px" />
        &nbsp;
        <asp:Button ID="btn_manager" runat="server" OnClick="btn_manager_Click" Text="返回管理页面" Font-Size="12px" /></td>
    <td background="images/main_42.gif" style="width:3px; height: 184px;">&nbsp;</td>
  </tr>
</table></td>
  </tr>
  <tr>
    <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="24" background="images/main_47.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="29" height="24"><img src="images/main_45.gif" width="29" height="24" /></td>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="369"><span class="STYLE1">版本 2005V1.0 </span></td>
            <td width="814" class="STYLE1">&nbsp;</td>
            <td width="185" nowrap="nowrap" class="STYLE1"><div align="center"><img src="images/main_51.gif" width="12" height="12" /> 如有疑问请与技术人员联系</div></td>
          </tr>
        </table></td>
        <td width="14"><img src="images/main_49.gif" width="14" height="24" /></td>
      </tr>
    </table></td>
  </tr>
</table></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
