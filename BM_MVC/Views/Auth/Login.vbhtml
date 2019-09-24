@ModelType BookManager.Controllers.LoginViewModel

@Code
    Layout = Nothing
    ViewBag.Title = "Login"

End Code

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>ΣBM</title>
    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="~/Content/login.css" />
    <link href="https://fonts.googleapis.com/css?family=Josefin+Sans:300&display=swap" rel="stylesheet" />
    <script src="https://unpkg.com/vue"></script>
</head>
<body>
    <div class="row over">
        <div class="grid-example col s12 m12 l6 right backDiv hide-on-med-and-down loginbox z-depth-2">
            <div class="center-align backDivLarge">
                <div class='wave -one'></div>
                <div class='wave -two'></div>
                <div class='wave -three'></div>
                <div class='title'><h1>BookManager</h1></div>
            </div>
        </div>
        <nav class="hide-on-large-only backDivSmall">
            <div class="nav-wrapper">
                <a href="#" class="left brand-logo"><h5>BookManager</h5></a>
                <ul id="nav-mobile" class="right">
                    <li><a href="sass.html"><i class="material-icons prefix">search</i></a></li>
                    <li><a href="badges.html"><i class="material-icons prefix">refresh</i></a></li>
                    <li><a href="collapsible.html"><i class="material-icons prefix">menu</i></a></li>
                </ul>
            </div>
        </nav>
        <div class="grid-example col s12 m12 l6 layout">
            <div class="layoutIn">
                <div class="grid-example col s12 m12 l12 ">
                    @Using (Html.BeginForm(New With {.ReturnUrl = ViewBag.ReturnUrl}))
                        @<text>
                        <div Class="row">
                            <div Class="input-field col s12 m12 l12  center-align">
                                <h4> sign In</h4>
                                <p class="blue-text text-darken-2">@Html.ValidationSummary(True)</p>
                            </div>
                        </div>
                        <div Class="row">
                            <div Class="input-field col s12 m12 l12">
                                <i Class="material-icons prefix">account_circle</i>
                                @Html.TextBoxFor(Function(m) m.UserName)
                                <Label for="icon_prefix">First Name</Label>
                                <p>@Html.ValidationMessageFor(Function(m) m.UserName)</p>
                    </div>
                        </div>
                        <div Class="row">
                            <div Class="input-field col s12 m12 l12">
                                <i Class="material-icons prefix">lock</i>
                                @Html.PasswordFor(Function(m) m.PassWord)
                                <Label for="icon_lock">Pass Word</Label>
                                <p>@Html.ValidationMessageFor(Function(m) m.PassWord)</p>
                    </div>
                </div>
                <div Class="row">
                    <div Class="grid-example col s6 m6 l6">
                        <input id = "submit" type="submit" value="Sign in" Class="btn waves-effect waves-light btn-small buttonWrapper"/>
                        <a href = "~/Home/Index" > create New account.</a>
                    </div>
                </div>
                            </text>
                    End Using


                </div>
            </div>
        </div>
    </div>
</body>
</html>
