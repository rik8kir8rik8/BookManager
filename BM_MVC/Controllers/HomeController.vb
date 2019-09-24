Imports System.Web.Mvc
Imports System.Web
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Runtime.InteropServices
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports System.Net

Namespace BookManager.Controllers
    Public Class HomeController
        Inherits System.Web.Mvc.Controller

        ' GET: Shared/Create
        <HttpGet>
        Function Index() As ActionResult

            'dropdwon
            Dim search As New SearchListViewModel
            Dim con As New Models.conectDB()
            Dim list = con.BookList

            Dim authorlist = list.Select(Function(x) x.author).Distinct()
            ViewBag.model1 = New SelectList(authorlist, "Id", "author", search.author)
            ViewBag.model1 = list.Select(Function(m) New SelectListItem() With {
                            .Text = m.author,
                            .Value = m.author})
            Return View()
        End Function

        ' POST: Shared/Create
        <HttpPost()>
        Function index(ByVal search As SearchListViewModel, form As FormCollection) As ActionResult

            Try
                Dim con As New Models.conectDB()
                Dim b = New BMController
                Dim list = con.BookList
                Dim authorlist = list.Select(Function(x) x.author).Distinct()
                ViewBag.model1 = New SelectList(authorlist, "Id", "author", search.author)
                ViewBag.model1 = list.Select(Function(m) New SelectListItem() With {
                            .Text = m.author,
                            .Value = m.author})
                Response.Redirect("?title=" + search.title + "&author=" + search.author)
                Return View()
            Catch
                Return View()
            End Try
        End Function

        <HttpGet>
        Function BorrowBooks() As ActionResult
            Dim name = User.Identity.GetUserName
            ViewBag.name = name
            Return View()
        End Function

        <HttpGet>
        Function Add() As ActionResult
            Dim name = User.Identity.GetUserName
            ViewBag.name = name
            Return View()
        End Function

        <ConfirmAtr>
        <HttpPost>
        Public Async Function Add(ByVal model As AddDataViewModel, returnUrl As String) As Task(Of ActionResult)

            Dim con = New Models.conectDB()
            Dim list = con.BookList()
            Dim flg = False

            If list.Any(Function(x) x.isbn = model.isbn) Then
                ModelState.AddModelError(String.Empty, "既に登録されている値です")
                flg = True
            End If

            If ModelState.IsValid = False Or flg Then
                ViewBag.ReturnUrl = returnUrl
                Return View(model)
            End If

        End Function

        <HttpGet>
        Function AddAfter() As ActionResult
            Return View()
        End Function

    End Class

    Public Class ConfirmAtr
        Inherits ActionFilterAttribute

        Const back = "Back"
        Const confi = "Confirm"
        Const submit = "Submit"

        Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)

            Dim form = filterContext.HttpContext.Request.Form
            Dim tempData = filterContext.Controller.TempData
            Dim parameter = filterContext.ActionParameters.First()

            Dim viewName = filterContext.ActionDescriptor.ActionName
            Dim model = tempData.Peek(parameter.Key)

            If form(submit) IsNot Nothing Then
                tempData.Remove(parameter.Key)
                Dim con = New Models.conectDB
                con.bookAdd(model)
                viewName = "AddAfter"
                tempData(parameter.Key) = parameter.Value

            End If

            If form(confi) IsNot Nothing Then
                tempData.Remove(parameter.Key)


                If filterContext.Controller.ViewData.ModelState.IsValid = False Then
                    Return
                End If

                viewName = "AddBefore"
                tempData(parameter.Key) = parameter.Value

            End If

            Dim eng = filterContext.RouteData.Route
            filterContext.Result = New ViewResult With {
                .ViewName = viewName,
                .ViewData = New ViewDataDictionary(model),
                .TempData = tempData}

        End Sub

    End Class
    Public Class SearchListViewModel

        Dim t As String
        <Display(Name:="Title")>
        Public Property title As String
            Get
                Return t
            End Get
            Set(value As String)
                t = value
            End Set
        End Property

        Dim a As String
        <Display(Name:="author")>
        Public Property author As String
            Get
                Return a
            End Get
            Set(value As String)
                a = value
            End Set
        End Property

        Dim list As IEnumerable(Of String)
        Public Property authorlist As IEnumerable(Of String)
            Get
                Return list
            End Get
            Set(value As IEnumerable(Of String))
                list = value
            End Set
        End Property

    End Class

    Public Class AddDataViewModel

        Dim t As String
        <MaxLength(500, ErrorMessage:="500文字以内で入力してください")>
        <Required(ErrorMessage:="入力してください")>
        <Display(Name:="Title")>
        Public Property title As String
            Get
                Return t
            End Get
            Set(value As String)
                t = value
            End Set
        End Property


        Dim i As String
        <RegularExpression("^[0-9a-zA-Z]+$", ErrorMessage:="半角英数で入力してください")>
        <MaxLength(30, ErrorMessage:="30文字以内で入力してください")>
        <Required(ErrorMessage:="入力してください")>
        <Display(Name:="ISBN")>
        Public Property isbn As String
            Get
                Return i
            End Get
            Set(value As String)
                i = value
            End Set
        End Property

        Dim a As String
        <MaxLength(100, ErrorMessage:="100文字以内で入力してください")>
        <Required(ErrorMessage:="入力してください")>
        <Display(Name:="Author")>
        Public Property author As String
            Get
                Return a
            End Get
            Set(value As String)
                a = value
            End Set
        End Property

    End Class
End Namespace
