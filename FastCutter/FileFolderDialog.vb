Imports System.Text
Imports System.IO


Public Class FileFolderDialog
    Inherits CommonDialog
    Private m_dialog As New OpenFileDialog()

    Public Property Dialog() As OpenFileDialog
        Get
            Return m_dialog
        End Get
        Set(value As OpenFileDialog)
            m_dialog = value
        End Set
    End Property

    Public Shadows Function ShowDialog() As DialogResult
        Return Me.ShowDialog(Nothing)
    End Function

    Public Shadows Function ShowDialog(owner As IWin32Window) As DialogResult
        m_dialog.ValidateNames = False
        m_dialog.CheckFileExists = False
        m_dialog.CheckPathExists = True

        Try
            If m_dialog.FileName IsNot Nothing AndAlso m_dialog.FileName <> "" Then
                If Directory.Exists(m_dialog.FileName) Then
                    m_dialog.InitialDirectory = m_dialog.FileName
                Else
                    m_dialog.InitialDirectory = Path.GetDirectoryName(m_dialog.FileName)
                End If
            End If
        Catch ex As Exception
        End Try

        m_dialog.FileName = "Folder Selection"

        If owner Is Nothing Then
            Return m_dialog.ShowDialog()
        Else
            Return m_dialog.ShowDialog(owner)
        End If
    End Function


    Public Property SelectedPath() As String
        Get
            Try
                If m_dialog.FileName IsNot Nothing AndAlso (m_dialog.FileName.EndsWith("Folder Selection.") OrElse Not File.Exists(m_dialog.FileName)) AndAlso Not Directory.Exists(m_dialog.FileName) Then
                    Return Path.GetDirectoryName(m_dialog.FileName)
                Else
                    Return m_dialog.FileName
                End If
            Catch ex As Exception
                Return m_dialog.FileName
            End Try
        End Get
        Set(value As String)
            If value IsNot Nothing AndAlso value <> "" Then
                m_dialog.FileName = value
            End If
        End Set
    End Property


    Public ReadOnly Property SelectedPaths() As String
        Get
            If m_dialog.FileNames IsNot Nothing AndAlso m_dialog.FileNames.Length > 1 Then
                Dim sb As New StringBuilder()
                For Each fileName As String In m_dialog.FileNames
                    Try
                        If File.Exists(fileName) Then
                            sb.Append(fileName & Convert.ToString(";"))
                        End If
                    Catch ex As Exception
                    End Try
                Next
                Return sb.ToString()
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Overrides Sub Reset()
        m_dialog.Reset()
    End Sub

    Protected Overrides Function RunDialog(hwndOwner As IntPtr) As Boolean
        Return True
    End Function
End Class


