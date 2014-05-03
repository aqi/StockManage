<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricSalesPage.aspx.cs" Inherits="Web0204.BM.WebView.FabricSalesPage" %>

<%@ Register Src="Manager.ascx" TagName="Manager" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>面料销售</title>
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
    <td background="images/main_40.gif" style="width:3px;">&nbsp;</td>
    <td  style="border-right:solid 1px #9ad452; width: 100px;" valign="top">
        &nbsp;
        <uc1:Manager ID="Manager1" runat="server" />
    </td>
    <td style="width: 516px; font-size: 12px;" valign="top">
        <asp:Label ID="lbl_num" runat="server" Text="订单号："></asp:Label>
        <asp:TextBox ID="txt_num" runat="server" Enabled="False"></asp:TextBox>&nbsp;
        <br />
        <asp:Label ID="lbl_name" runat="server" Text="公司名："></asp:Label>&nbsp;<asp:DropDownList
            ID="ddl_customers" runat="server" DataTextField="customers_name" DataValueField="customers_id">
        </asp:DropDownList><br />
        <asp:Label ID="lbl_purpose" runat="server" Text="发料用途："></asp:Label>
        <asp:TextBox ID="txt_purpose" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_purpose"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lbl_send" runat="server" Text="寄件方式："></asp:Label>
        <asp:DropDownList ID="ddl_send" runat="server" DataTextField="send_name" DataValueField="send_id">
        </asp:DropDownList><br />
        <asp:Label ID="lbl_acceptadd" runat="server" Text="收货地址："></asp:Label>
        <asp:TextBox ID="txt_acceptadd" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_acceptadd"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lbl_whether_charges" runat="server" Text="料件是否要收费："></asp:Label>
        <asp:DropDownList ID="ddl_whether_charges" runat="server">
            <asp:ListItem>是</asp:ListItem>
            <asp:ListItem>否</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="lbl_freight" runat="server" Text="运费付汇方式："></asp:Label>
        <asp:DropDownList ID="ddl_freight" runat="server" DataTextField="freight_name" DataValueField="freight_id">
        </asp:DropDownList><br />
        <asp:Label ID="lbl_mark" runat="server" Text="备注："></asp:Label>
        <asp:TextBox ID="txt_mark" runat="server" TextMode="MultiLine"></asp:TextBox><br />
        &nbsp;<br />
        &nbsp; &nbsp;<asp:Button ID="btn_result" runat="server" OnClick="btn_result_Click"
            Text="保 存" />
        &nbsp; &nbsp;&nbsp;<asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click"
            Text="返 回" />&nbsp;
    </td>
    <td background="images/main_42.gif" style="width:3px;">&nbsp;</td>
  </tr>
</table></td>
  </tr>
  <tr>
    <td style="height: 63px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
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
