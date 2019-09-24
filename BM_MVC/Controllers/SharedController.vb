Imports System.ComponentModel.DataAnnotations
Imports System.Threading.Tasks
Imports System.Web.Http
Imports Newtonsoft.Json
Namespace BookManager.Controllers
    Public Class SharedController
        Inherits Controller

        ' GET: Shared
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: Shared/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function



        ' GET: Shared/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Shared/Edit/5
        <HttpPost>
        Public Function Selecter(model As SearchListViewModel, form As FormCollection)
            Dim value = Request.Form("author-list").ToString()
            Return View(model)
        End Function


        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Shared/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Shared/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class

End Namespace