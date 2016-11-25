<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ReportViewerWebForm.aspx.cs" Inherits="ReportViewerForMvc.ReportViewerWebForm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="ReportViewerForMvc" Name="ReportViewerForMvc.Scripts.PostMessage.js" />
                </Scripts>
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
        </div>
    </form>

    <br />
    <a title="Excel" alt="Word" onclick="$find('ReportViewer1').exportReport('WORDOPENXML');"
        href="javascript:void(0)" class="btn btn-link" style="z-index: 1000">Word</a>

    <a title="Excel" alt="Excel" onclick="$find('ReportViewer1').exportReport('EXCELOPENXML');"
        href="javascript:void(0)" class="btn btn-link" style="z-index: 1000">Excel</a>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script>
        document.getElementById("ReportViewer1_ctl09").style.overflow = "visible";
        document.getElementById("ReportViewer1_fixedTable").style.tableLayout = "auto";
        document.getElementById("ReportViewer1_fixedTable").style.height = "auto";

        $('#P69a3e064b45b460d86a289635bd9423d_1_oReportDiv > table').addClass('table table-border');

        $('.P0132321c67f340629564ca6a8fc4f739_1_r10').find('tr:last').remove();

        //console.log($('div#VisibleReportContentReportViewer1_ctl09 > div > table > tbody > tr:eq(0) > td:eq(0) > table > tbody > tr:eq(0) > td:eq(0) > table > tbody > tr:eq(3)'));//.remove();

        $('#ReportViewer1').css({ 'height': '100%', width: '100%' });

        console.log(document.getElementById('VisibleReportContentReportViewer1_ctl09'));
    </script>
</body>
</html>
