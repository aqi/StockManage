<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListPager.ascx.cs" Inherits="Web0204.BM.WebView.ListPager" %>
<div style="font-size: 12px">
    <asp:Button ID="btnFirst" runat="server" CausesValidation="False" CssClass="Btn_bse"
        OnClick="btnFirst_Click" Text="首页" Font-Size="12px" />
    &nbsp;
    <asp:Button ID="btnPrevious" runat="server" CausesValidation="False" OnClick="btnPrevious_Click"
        Text="上一页" Font-Size="12px" />
    &nbsp;<asp:Button ID="btnNext" runat="server" CausesValidation="False" CssClass="Btn_bse"
        OnClick="btnNext_Click" Text="下一页" Font-Size="12px" />
    &nbsp;<asp:Button ID="btnLast" runat="server" CausesValidation="False" CssClass="Btn_bse"
        OnClick="btnLast_Click" Text="尾页" Font-Size="12px" />
    &nbsp;当前是第
    <asp:Label ID="lblCurrent" runat="server" Font-Bold="True" Font-Underline="True"
        Text="1"></asp:Label>页/共<asp:Label ID="lblTotal" runat="server" Font-Bold="True"
            Font-Underline="True" Text="1"></asp:Label>页 &nbsp; 跳转至第<asp:TextBox ID="txtIndex"
                runat="server" CssClass="input" Width="30px" Font-Size="12px">1</asp:TextBox>页&nbsp;<asp:Button ID="btnGo"
                    runat="server" CausesValidation="False" CssClass="Btn_bse37" OnClick="btnGo_Click"
                    Text="跳转" Font-Size="12px" />
    &nbsp;
</div>
