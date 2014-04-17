﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FabricSales.aspx.cs" Inherits="Web0204.BM.WebView.FabricSales" %>

<%@ Register Src="Manager.ascx" TagName="Manager" TagPrefix="uc1" %>
<%@ Register Src="ListPager.ascx" TagName="ListPager" TagPrefix="uc2" %>

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
        <br />
        <asp:Label ID="lbl_BrandName" runat="server" Text="品牌名称："></asp:Label>&nbsp;<asp:DropDownList
            ID="ddl_BrandName" runat="server" DataTextField="brand_name" DataValueField="brand_id" AutoPostBack="true"
            OnSelectedIndexChanged="ddl_BrandName_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="lbl_unit" runat="server" Text="产品单位："></asp:Label>&nbsp;<asp:DropDownList
            ID="ddl_Unit" runat="server" DataTextField="unit_name" DataValueField="unit_id" AutoPostBack="true"
            OnSelectedIndexChanged="ddl_Unit_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;
        <asp:Label ID="lbl_Name" runat="server" Text="根据产品名称查询:"></asp:Label>
        <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
        <asp:Button ID="btn_Result" runat="server" OnClick="btn_Result_Click" Text="查 询" />
        &nbsp;&nbsp; &nbsp;&nbsp;<br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="good_id" ForeColor="#333333" GridLines="None" Width="100%">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
               <asp:BoundField DataField="good_name" HeaderText="产品名称" />
                <asp:BoundField DataField="good_code" HeaderText="产品代码" />
                <asp:BoundField DataField="brand_name" HeaderText="品牌名称" />
                <asp:BoundField DataField="good_color" HeaderText="产品颜色" />
                <asp:BoundField DataField="unit_name" HeaderText="产品单位" />
                <asp:BoundField DataField="good_description" HeaderText="产品描述" />
                <asp:TemplateField HeaderText="产品图片">
                    <ItemTemplate>
                        <asp:Image ID="Image1" Height="25px" Width="25px" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "good_img")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="product_name" HeaderText="产品类别" />   
                <asp:BoundField DataField="good_num" HeaderText="产品编号" />
                <asp:BoundField DataField="good_price" HeaderText="产品买价" />
                <asp:BoundField DataField="good_selling_price" HeaderText="产品卖价" />  
                <asp:TemplateField HeaderText="数量">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_number" runat="server" Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        &nbsp;&nbsp;<asp:Button ID="btn_add" runat="server" Text="添加" OnClick="btn_add_Click" />
        <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="返回管理页面" />
        &nbsp;
        &nbsp; &nbsp; 
        <uc2:ListPager ID="ListPager1" runat="server" />
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="shop_id" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
            OnRowDeleting="GridView1_RowDeleting">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="good_name" HeaderText="产品名称" />
                <asp:BoundField DataField="shop_jointime" HeaderText="加入时间" />
                <asp:BoundField DataField="good_color" HeaderText="产品颜色" />
                <asp:BoundField DataField="good_code" HeaderText="产品代码" />
                <asp:BoundField DataField="order_num" HeaderText="订单号" />
                <asp:BoundField DataField="shop_num" HeaderText="商品数量" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <uc2:ListPager ID="ListPager2" runat="server" />
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
