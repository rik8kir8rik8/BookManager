
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - BookManager</title>
</head>
<body>
    <header>
        <!-- Dropdown Structure -->
        <ul id='dropdown1' class='dropdown-content'>
            <li><a href="~/Home/index"><i class="material-icons">search</i>List</a></li>
            <li><a href="~/Home/Add"><i class="material-icons">add</i>Add</a></li>
            <li><a href="~/Home/BorrowBooks"><i class="material-icons">library_books</i>Return</a></li>
            <li><a href="login.aspx"><i class="material-icons">account_circle</i>Log out</a></li>
        </ul>
        <!-- Navbar goes here -->
        <nav class="backDivSmall">
            <div class="nav-wrapper">
                <a href="#" class="left brand-logo"><h2>BookManager</h2></a>
                <ul id="nav-mobile" class="right  hide-on-med-and-down">
                    <li><a href="~/Home/index"><i class="material-icons prefix">search</i></a></li>
                    <li><a href="~/Home/Add"><i class="material-icons prefix">add</i></a></li>
                    <li><a href="~/Home/BorrowBooks"><i class="material-icons prefix">library_books</i></a></li>
                    <li><a href="login.aspx"><i class="material-icons prefix">account_circle</i></a></li>
                </ul>
                <ul id="nav-mobile" class="right  hide-on-large-only">
                    <li> <a class='dropdown-trigger' href='#' data-target='dropdown1'><i class="material-icons prefix">menu</i></a></li>
                </ul>
            </div>
        </nav>
    </header>
    <main>
        <!-- Page Layout here -->
@RenderBody
    </main>
</body>
</html>
