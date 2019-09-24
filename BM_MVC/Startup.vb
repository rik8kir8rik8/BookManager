Imports Microsoft.AspNet.Identity
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Owin

<Assembly: OwinStartup(GetType(BookManager.Startup))>
Namespace BookManager

    Public Class Startup
        Public Sub Configuration(app As IAppBuilder)
            app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .LoginPath = New PathString("/Auth/Login")})
        End Sub
    End Class

End Namespace