﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseRecordManager.aspx.cs" Inherits="Web0204.BM.WebView.PurchaseRecordManager" %>

<%@ Register Src="ListPager.ascx" TagName="ListPager" TagPrefix="uc2" %>

<%@ Register Src="Manager.ascx" TagName="Manager" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>采购记录</title>
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
        <br />
        <asp:Label ID="lbl_Position" runat="server" Text="根据采购单号查询:"></asp:Label>
        <asp:TextBox ID="txt_Position" runat="server" Font-Size="12px"></asp:TextBox>
        <asp:Label ID="lbl_Yearmonth" runat="server" Text="根据月份查询:"></asp:Label>
        <asp:TextBox ID="txt_Yearmonth" runat="server" Font-Size="12px"></asp:TextBox>
        <asp:Button ID="btn_Result" runat="server" OnClick="btn_Result_Click" Text="查 询" Font-Size="12px" />
        &nbsp;
        <asp:Button ID="btn_add" runat="server" OnClick="btn_add_Click" Text="添加记录" Font-Size="12px" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_Position"
            ErrorMessage="采购单号格式为‘000000...’！" ValidationExpression="\d*"></asp:RegularExpressionValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_Yearmonth"
            ErrorMessage="月份格式为‘201301’！" ValidationExpression="\d\d\d\d\d\d"></asp:RegularExpressionValidator>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="Both" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" Width="100%">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="purchase_id" HeaderText="采购单号"/>
                <asp:BoundField DataField="good_id" HeaderText="商品编号" />
                <asp:BoundField DataField="good_name" HeaderText="商品名称" />
                <asp:BoundField DataField="purchase_price" HeaderText="单价" />
                <asp:BoundField DataField="purchase_num" HeaderText="数量" />
                <asp:BoundField DataField="sum" HeaderText="总价" />
                <asp:BoundField DataField="purchase_datetime" HeaderText="操作时间" />
                <asp:ButtonField CommandName="details" Text="详细信息" />
                <asp:CommandField ShowDeleteButton="True" />

            </Columns>
        </asp:GridView>
        &nbsp;
        <uc2:ListPager ID="ListPager1" runat="server" />
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
