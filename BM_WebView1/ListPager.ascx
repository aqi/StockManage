<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListPager.ascx.cs" Inherits="Web0204.BM.WebView.ListPager" %>
<div style="font-size: 12px">
    <asp:Button ID="btnFirst" runat="server" CausesValidation="False" CssClass="Btn_bse"
        OnClick="btnFirst_Click" Text="��ҳ" Font-Size="12px" />
    &nbsp;
    <asp:Button ID="btnPrevious" runat="server" CausesValidation="False" OnClick="btnPrevious_Click"
        Text="��һҳ" Font-Size="12px" />
    &nbsp;<asp:Button ID="btnNext" runat="server" CausesValidation="False" CssClass="Btn_bse"
        OnClick="btnNext_Click" Text="��һҳ" Font-Size="12px" />
    &nbsp;<asp:Button ID="btnLast" runat="server" CausesValidation="False" CssClass="Btn_bse"
        OnClick="btnLast_Click" Text="βҳ" Font-Size="12px" />
    &nbsp;��ǰ�ǵ�
    <asp:Label ID="lblCurrent" runat="server" Font-Bold="True" Font-Underline="True"
        Text="1"></asp:Label>ҳ/��<asp:Label ID="lblTotal" runat="server" Font-Bold="True"
            Font-Underline="True" Text="1"></asp:Label>ҳ &nbsp; ��ת����<asp:TextBox ID="txtIndex"
                runat="server" CssClass="input" Width="30px" Font-Size="12px">1</asp:TextBox>ҳ&nbsp;<asp:Button ID="btnGo"
                    runat="server" CausesValidation="False" CssClass="Btn_bse37" OnClick="btnGo_Click"
                    Text="��ת" Font-Size="12px" />
    &nbsp;
</div>
