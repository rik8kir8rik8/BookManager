@ModelType BookManager.Controllers.SearchListViewModel

@Code
    ViewData("Title") = "BorrowBooks"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div id="book-list" class="row ">
    <div class="grid-example col s0 m0 l3 layout">
        <div class="layoutIn">
            <div class="box hide-on-med-and-down"></div>
            <div class="grid-example col s12 m12 l12">
                <h4>Info</h4>
                <div class="card-panel  contentsbase">
                    @Using (Html.BeginForm(New With {.ReturnUrl = ViewBag.ReturnUrl}))
                        @<text>
                                <div class=" row">
                                    <ul>
                                        <li>
                                            @(User.Identity.Name)さんは現在、
                                        </li>
                                        <li>
                                            <h7>{{sortedbooks.length}}冊</h7>　貸し出し中。
                                        </li>
                                    </ul>
                                </div>
                    </text>
                    End Using
            </div>
        </div>
    </div>
</div>
<div class="col s12 m12 l9">
    <div class="content">
        <ul>
            <li>
                <h4>List of Borrowed Books</h4>
                <p class="check">You can borrow books for two weeks.</p>
                <div class="card-panel  panelbase">
                    <form id="listForm" runat="server" name="test" method="POST" class="buttonlist">
                        <div class="row">
                            <div class="grid-example col s12 m12 l11">
                                <div>
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
                                                <td :id="'button' + index"><input id="book_index" type="button" class="btn waves-effect waves-light btn-small buttonWrapper" value="return" /></td>
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
            </li>

            <li>
                <h4>History of Borrowed Books</h4>
                <p class="check">Open to see my history</p>
                <div class="card-panel  panelbase">
                    <form id="listForm" runat="server" name="test" method="POST" class="buttonlist">
                        <div class="row">
                            <div class="grid-example col s12 m12 l11">
                                <div id="book-his">
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
                                            <tr v-for="(his,index) in sortedbooks" :id="'list' + index">
                                                <td :id="'Hbutton' + index"></td>
                                                <td :id="'Hname' + index">{{his.name}}</td>
                                                <td :id="'Hauthor' + index">{{his.author}}</td>
                                                <td :id="'Hisbn' + index">{{his.isbn}}</td>
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
            </li>
        </ul>
    </div>
    </div>
    </div>
    <script src="~/Scripts/borrowbooks.js"></script>

