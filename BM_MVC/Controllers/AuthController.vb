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
     <AllowAnonymous>
    Public Class AuthController
        Inherits System.Web.Mvc.Controller

        Function Login(returnUrl As String) As ActionResult
            ViewBag.ReturnUrl = returnUrl
            Return View(New LoginViewModel())
        End Function

        <HttpPost>
        Public Async Function Login(ByVal model As LoginViewModel, returnUrl As String) As Task(Of ActionResult)

            If ModelState.IsValid = False Then
                ViewBag.ReturnUrl = returnUrl
                Return View(model)
            End If

            Dim pro = New Models.CustomMembershipProvider

            If pro.ValidateUser(model.UserName, model.PassWord) Then
                Dim userManager = New UserManager(Of User)(New UserStore())
                Dim user = Await userManager.FindAsync(model.UserName, model.PassWord)
                Dim identify = Await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie)
                Dim authEntication = HttpContext.GetOwinContext().Authentication
                authEntication.SignIn(identify)
                Return Redirect(returnUrl)
            Else
                ModelState.AddModelError("", "ユーザー名かパスワードが間違っています。")
                ViewBag.ReturnUrl = returnUrl
                Return View(model)
            End If

        End Function
    End Class

    Public Class LoginViewModel
        <Required(ErrorMessage:="ユーザー名を入れてください")>
        <Display(Name:="UserName")>
        Public Property UserName As String

        <Required(ErrorMessage:="パスワードを入れてください")>
        <Display(Name:="PassWord")>
        Public Property PassWord As String

    End Class

End Namespace