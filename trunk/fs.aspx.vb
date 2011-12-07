Imports System.IO
Imports System.Data
Partial Class fs
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Request("Name") <> "book" Then
            Response.Redirect("Login.aaspx")
        End If
        If Not Page.IsPostBack Then
            '紀錄目前位置
            txtPhysicalApplicationPath.Text = Request.PhysicalApplicationPath
            txtPhysicalApplicationPath.Attributes.Add("onkeydown", "if(event.keyCode==13){document.forms[0]." + btnMove.ClientID + ".click();event.keyCode=9}")
            show()
        End If

    End Sub

    Sub show()
        '宣告目錄物件
        Dim Maindi As New DirectoryInfo(txtPhysicalApplicationPath.Text)
        '取得目錄物件裡的子目錄
        Dim dis As DirectoryInfo() = Maindi.GetDirectories
        '建立Table
        Dim FileTable As New DataTable
        FileTable.Columns.Add("Type", GetType(Integer))
        FileTable.Columns.Add("Name", GetType(String))
        '回上一層
        If txtPhysicalApplicationPath.Text.Length > 3 Then '是否為根目錄
            Dim ParentRow As DataRow = FileTable.NewRow
            ParentRow("Type") = 0
            ParentRow("Name") = Maindi.Parent.FullName
            FileTable.Rows.Add(ParentRow)
        End If


        '加入目錄資料
        For Each di As DirectoryInfo In dis
            Dim rowdi As DataRow = FileTable.NewRow
            rowdi("Type") = 0
            rowdi("Name") = di.FullName
            FileTable.Rows.Add(rowdi)
        Next
        '加入檔案資料
        Dim fis() As FileInfo = Maindi.GetFiles
        For Each fi As FileInfo In fis
            Dim rowfi As DataRow = FileTable.NewRow
            rowfi("Type") = 1
            rowfi("Name") = fi.FullName
            FileTable.Rows.Add(rowfi)
        Next
        dgFileSystem.DataSource = FileTable
        dgFileSystem.DataBind()

        If txtPhysicalApplicationPath.Text.Length > 3 Then '是否為根目錄
            Dim lbtn As LinkButton = CType(dgFileSystem.Items(0).FindControl("LinkButton1"), LinkButton)
            lbtn.Text = ".."
        End If

    End Sub

    Private Sub dgFileSystem_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgFileSystem.EditCommand
        Dim imgType As System.Web.UI.WebControls.Image = CType(dgFileSystem.Items(e.Item.ItemIndex).Cells(0).FindControl("Image1"), System.Web.UI.WebControls.Image)
        If imgType.ImageUrl = "images/folder.gif" Then '目錄時的處理
            If dgFileSystem.DataKeys(e.Item.ItemIndex).ToString.Length > 3 Then
                txtPhysicalApplicationPath.Text = dgFileSystem.DataKeys(e.Item.ItemIndex) & "\"
            Else
                txtPhysicalApplicationPath.Text = dgFileSystem.DataKeys(e.Item.ItemIndex)
            End If
            show()
        Else '下載檔案
            Dim lbtn As LinkButton = CType(dgFileSystem.Items(e.Item.ItemIndex).FindControl("LinkButton1"), LinkButton)
            Response.AddHeader("content-disposition", "attachment; filename=" & lbtn.Text)
            Response.WriteFile(dgFileSystem.DataKeys(e.Item.ItemIndex))
            Response.End()
        End If

    End Sub

    Private Sub btnUpdateFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateFile.Click
        If Me.txtPersonFile.PostedFile.FileName = "" Then
            Me.lblUpdateFileErr.Text = "沒有上傳檔案"
            Exit Sub
        End If

        Dim strSplit() As String = Split(Me.txtPersonFile.PostedFile.FileName, "\")
        '取得真正檔名
        Dim fileName As String = strSplit(strSplit.Length - 1)

        'Try
        txtPersonFile.PostedFile.SaveAs(txtPhysicalApplicationPath.Text & fileName)
        show()
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        show()
    End Sub
End Class
