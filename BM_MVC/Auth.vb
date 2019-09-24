Imports Microsoft.AspNet.Identity
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks

Namespace BookManager
    Public Class User
        Implements IUser

        Private Id As String
        Public Property UserID As String Implements IUser(Of String).UserName
            Get
                Return Id
            End Get
            Set(value As String)
                Id = value
            End Set
        End Property

        Private Hashpass As String
        Public Property UserPass As String Implements IUser(Of String).Id
            Get
                Return Hashpass
            End Get
            Set(value As String)
                Hashpass = value
            End Set
        End Property

    End Class

    Public Class UserStore
        Implements IUserStore(Of User)
        Implements IUserPasswordStore(Of User)

        Dim ds As New Models.conectDB()
        Dim userlist As New BooksDataSet.usersDataTable
        Dim acount As New User

        Public Function SetPasswordHashAsync(user As User, passwordHash As String) As Task Implements IUserPasswordStore(Of User, String).SetPasswordHashAsync

            Return Task.Delay(0)
        End Function

        Public Function GetPasswordHashAsync(user As User) As Task(Of String) Implements IUserPasswordStore(Of User, String).GetPasswordHashAsync
            acount.UserID = user.UserID
            acount.UserPass = New PasswordHasher().HashPassword(user.UserPass)
            Return Task.FromResult(acount.UserPass)
        End Function

        Public Function HasPasswordAsync(user As User) As Task(Of Boolean) Implements IUserPasswordStore(Of User, String).HasPasswordAsync
            Return Task.FromResult(True)
        End Function

        Public Function CreateAsync(user As User) As Task Implements IUserStore(Of User, String).CreateAsync
            Return Task.FromResult(acount)
        End Function

        Public Async Function UpdateAsync(user As User) As Task Implements IUserStore(Of User, String).UpdateAsync
            Dim target = Await FindByNameAsync(user.UserID)
            If target Is Nothing Then
                Return
            End If
            target.UserID = user.UserID
        End Function

        Public Async Function DeleteAsync(user As User) As Task Implements IUserStore(Of User, String).DeleteAsync
            Dim target = Await FindByIdAsync(user.UserID)
            If target Is Nothing Then
                Return
            End If
            'delete
        End Function

        Public Function FindByIdAsync(user As String) As Task(Of User) Implements IUserStore(Of User, String).FindByIdAsync
            Return Task.Delay(0)
        End Function

        Public Function FindByNameAsync(userName As String) As Task(Of User) Implements IUserStore(Of User, String).FindByNameAsync
            Dim userlist = ds.Login()
            Dim user = userlist.Where(Function(x) x.id = userName).FirstOrDefault()
            acount.UserID = user.id
            acount.UserPass = user.password
            Return Task.FromResult(acount)
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' 重複する呼び出しを検出するには

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: マネージ状態を破棄します (マネージ オブジェクト)。
                End If

                ' TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下の Finalize() をオーバーライドします。
                ' TODO: 大きなフィールドを null に設定します。
            End If
            disposedValue = True
        End Sub

        ' TODO: 上の Dispose(disposing As Boolean) にアンマネージ リソースを解放するコードが含まれる場合にのみ Finalize() をオーバーライドします。
        'Protected Overrides Sub Finalize()
        '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
        Public Sub Dispose() Implements IDisposable.Dispose
            ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
            Dispose(True)
            ' TODO: 上の Finalize() がオーバーライドされている場合は、次の行のコメントを解除してください。
            ' GC.SuppressFinalize(Me)
        End Sub

#End Region


    End Class

End Namespace
