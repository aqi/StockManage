<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodPage.aspx.cs" Inherits="Web0204.BM.WebView.GoodPage" %>

<%@ Register Src="Manager.ascx" TagName="Manager" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>产品资料管理</title>
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
    <td style="line-height:9px; background-image:url(images/main_04.gif); height: 9px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
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
        &nbsp;<asp:Label ID="lbl_Color" runat="server" Text="产品颜色："></asp:Label>
        <asp:TextBox ID="txt_Color" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Color"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
        &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;<br />
        &nbsp;<asp:Label ID="lbl_Code" runat="server" Text="产品代码："></asp:Label>
        <asp:TextBox ID="txt_Code" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Code"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator><br />
        &nbsp;<asp:Label ID="lbl_Description" runat="server" Text="产品描述："></asp:Label>
        <asp:TextBox ID="txt_Description" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Description"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator><br />
        &nbsp;<asp:Label ID="lbl_Up" runat="server" Text="上传图片："></asp:Label>&nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" Font-Size="12px" />
        <asp:Button ID="btn_Up" runat="server" Text="上 传" OnClick="btn_Up_Click" /><br />
        &nbsp;<asp:Label ID="lbl_Image" runat="server" Text="产品图片"></asp:Label>&nbsp;
        <asp:Image ID="Image1" runat="server" Height="30px" Width="30px" /><br />
        &nbsp;<asp:Label ID="lbl_name" runat="server" Text="产品名称："></asp:Label>
        <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_Name"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>&nbsp;<br />
        &nbsp;<asp:Label ID="lbl_BrandName" runat="server" Text="品牌名称："></asp:Label>&nbsp;
        <asp:DropDownList ID="ddl_BrandName" runat="server" DataTextField="brand_name" DataValueField="brand_id">
        </asp:DropDownList><br />
        &nbsp;<asp:Label ID="lbl_Num" runat="server" Text="产品编号："></asp:Label>
        <asp:TextBox ID="txt_Num" runat="server" MaxLength="5"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Num"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_Num"
            ErrorMessage="编号为五位数字！" ValidationExpression="\d{5}"></asp:RegularExpressionValidator><br />
        &nbsp;<asp:Label ID="lbl_Price" runat="server" Text="产品买价："></asp:Label>
        <asp:TextBox ID="txt_Price" runat="server" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_Price"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
        &nbsp;<br />
        &nbsp;<asp:Label ID="lbl_SellingPrice" runat="server" Text="产品卖价："></asp:Label>
        <asp:TextBox ID="txt_SellingPrice" runat="server" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_SellingPrice"
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
        &nbsp;<br />
        &nbsp;<asp:Label ID="lbl_Unit" runat="server" Text="产品单位："></asp:Label>&nbsp;
        <asp:DropDownList ID="ddl_Unit" runat="server" DataTextField="unit_name" DataValueField="unit_id">
        </asp:DropDownList><br />
        &nbsp;<asp:Label ID="lbl_Product" runat="server" Text="产品类别："></asp:Label>&nbsp;
        <asp:DropDownList ID="ddl_Product" runat="server" DataTextField="product_name" DataValueField="product_id">
        </asp:DropDownList>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp;&nbsp;
        <br />
        &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="btn_sure" runat="server" Font-Size="12px"
            OnClick="btn_sure_Click" Text="保 存" />
        &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btn_Cancel" runat="server" OnClick="btn_Cancel_Click" Text="重 置" />
        &nbsp;
        <asp:Button ID="btn_manager" runat="server" OnClick="btn_manager_Click" Text="返回管理页面" /></td>
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
