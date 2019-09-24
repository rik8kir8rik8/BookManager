Imports System.Net
Imports System.Web.Http
Imports Newtonsoft.Json
Imports System.Runtime
Imports System.Web.HttpResponse
Imports Microsoft.AspNet.Identity
Imports System.ComponentModel.DataAnnotations

Namespace BookManager.Controllers

    Public Class searchStrModel
        Dim t As String
        Public Property title As String
            Get
                Return t
            End Get
            Set(value As String)
                t = value
            End Set
        End Property

        Dim a As String
        Public Property author As String
            Get
                Return a
            End Get
            Set(value As String)
                a = value
            End Set
        End Property
    End Class
    Public Class BMController
        Inherits ApiController

        ' GET api/<controller>
        <Route("api/BM/booklist/")>
        Public Function GetBooksValues(<FromUri> val As searchStrModel)
            Dim json As String
            Dim con As New Models.conectDB()
            If val Is Nothing Then
                json = JsonConvert.SerializeObject(con.BookList)
            Else
                Dim title = If((val.title = "undefined" Or val.title = Nothing), "", val.title)
                Dim author = If((val.author = "undefined" Or val.author = Nothing), "", val.author)
                json = JsonConvert.SerializeObject(con.SearchBookList(title, author))
            End If
            Return json
        End Function

        ' GET api/<controller>
        <Route("api/BM/booklistAuthor/")>
        Public Function GetBooksauthorsValues()
            Dim con As New Models.conectDB()
            Dim data = con.BookList().Select(Function(x) x.author).Distinct()
            Dim json = JsonConvert.SerializeObject(data)
            Return json
        End Function

        ' GET api/<controller>
        <Route("api/BM/borrowbooks/")>
        Public Function GetHistoryValues()
            Dim json As String = vbEmpty
            If (User.Identity.IsAuthenticated) Then
                Dim id = User.Identity.GetUserName()
                Dim con As New Models.conectDB()
                json = JsonConvert.SerializeObject(con.BorrowBook(id))
            End If
            Return json
        End Function

        ' GET api/<controller>
        <Route("api/BM/history/")>
        Public Function GetBorrowValues()
            Dim json As String = vbEmpty
            If (User.Identity.IsAuthenticated) Then
                Dim id = User.Identity.GetUserName()
                Dim con As New Models.conectDB()
                json = JsonConvert.SerializeObject(con.History(id))
            End If
            Return json
        End Function

        ' POST api/<controller>
        Public Sub Post(<FromBody()> ByVal value As Dynamic.DynamicObject)

        End Sub

        ' PUT api/<controller>/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE api/<controller>/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace