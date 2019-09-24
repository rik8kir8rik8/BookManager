@ModelType BookManager.Controllers.SearchListViewModel

@Code
    ViewBag.Title = "Index"
    ViewData("Title") = "Create"
End Code

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>ΣBM</title>
</head>
<body>
    <div class="row">
        <div class="grid-example col s0 m0 l3 layout">
            <div class="layoutIn">
                <div class="box hide-on-med-and-down"></div>
                <div class="grid-example col s12 m12 l12">
                    <h4>Search</h4>
                    <div class="card-panel  contentsbase">
                        @Using (Html.BeginForm(New With {.ReturnUrl = ViewBag.ReturnUrl}))
                            @<text>
                                <form id="listForm" runat="server" name="test" method="POST" class="buttonlist">
                                    <div class=" row">
                                        <ul>
                                            <li>
                                                <div Class="input-field grid-example col s4 m4 l11">
                                                    <i class="material-icons prefix">title</i>
                                                    @Html.TextBoxFor(Function(m) m.title)
                                                    <label for="search">search title</label>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="input-field  col s4 m4 l12">
                                                    <ul>
                                                        <li><i class="material-icons prefix">face</i></li>
                                                        <li>
                                                            @Html.DropDownListFor(Function(model) model.author, DirectCast(ViewBag.model1, IEnumerable(Of SelectListItem)), "SELECT", New With {.class = "browser-default selectwrapper"})
                                                        </li>
                                                    </ul>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="input-field  col s4 m4 l12">
                                                    <input : id="SearchButton" type="submit" class="btn waves-effect waves-light buttonWrapper right" onclick="Selecter()" value="Search" />
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                            </text>
                        End Using
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div class="col s12 m12 l9">
        <div class="content">
            <h4>List of Books</h4>
            <p class="check">You can borrow books for two weeks.</p>
            <div class="card-panel  panelbase">
                <form id="listForm" runat="server" name="test" method="POST" class="buttonlist">
                    <div class="row">
                        <div class="grid-example col s12 m12 l11">
                            <div id="book-list">
                                <table cellpadding="1" class="table table-hover highlight striped" id="myTable">
                                    <thead id="header">
                                        <tr v-for="header in headers">
                                            <th class="listbutton"></th>
                                            <th>{{header.title}}</th>
                                            <th>{{header.name}}</th>
                                            <th>{{header.isbn}}</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for="(book,index) in sortedbooks" :id="'list' + index">
                                            <td id="app">
                                                <p v-if="book.borrow_flg" :id="'button' + index"><input id="book" type="button" class="btn waves-effect waves-light btn-small buttonWrapper disabled" value="book" /></p>
                                                <p v-else><input :id="'button' + index" type="button" class="btn waves-effect waves-light btn-small buttonWrapper" :onclick="'return booklist.jumpPage(' + index + ')'" value="book" /></p>
                                            </td>
                                            <td :id="'name' + index">{{book.name}}</td>
                                            <td :id="'author' + index">{{book.author}}</td>
                                            <td :id="'isbn' + index">{{book.isbn}}</td>
                                        </tr>
                                    </tbody>
                                </table>
                                <ul class="pagination">
                                    <li class="disabled"><a href="#!" onclick="return booklist.prevPage();"><i class="material-icons">chevron_left</i></a></li>
                                    <li v-for="index in sortedbooks.length" class="waves-effect" :id="index" :onclick="'return booklist.jumpPage(' + index + ')'"><a href="#!">{{index}}</a></li>
                                    <li class="waves-effect"><a href="#!" onclick="return booklist.nextPage();"><i class="material-icons">chevron_right</i></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
            <span class="left" id="total_reg"></span>
        </div>
        <script src="~/Scripts/booklist.js"></script>
    </div>
</div>

</body>
</html>