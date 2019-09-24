@ModelType BookManager.Controllers.AddDataViewModel

@Code
    ViewData("Title") = "AddAfter"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div id="book-list" class="row ">
    <div class="grid-example col s0 m0 l3 layout hide-on-med-and-down">
        <div class="layoutIn">
            <div class="box"></div>
            <div class="grid-example col s12 m12 l12">
                <h4>Info</h4>
                <div class="card-panel  contentsbase">
                    you can add a new book from the form!
                </div>
            </div>
        </div>
    </div>
    <div class="col s12 m12 l9">
        <div class="content">
            <ul>
                <li>
                    <h4>Add the Book</h4>
                    <div class="card-panel  panelbase">
                        @Using (Html.BeginForm(New With {.ReturnUrl = ViewBag.ReturnUrl}))
                            @<text>
                                <div class="row">
                                    <div Class="grid-example col s0 m0 l2 hide-on-med-and-down">
                                        <div class=" row">
                                        </div>
                                    </div>
                                    <div class="grid-example col s12 m12 l10">
                                        <div class=" row">
                                            <p>以下の内容でよろしいですか。</p>
                                            <ul>
                                                <li>
                                                        <label for="search">title</label>
                                                </li>
                                                <li>
                                                    <p class="look">@Html.DisplayTextFor(Function(m) m.title)</p>
                                                </li>
                                                <li>
                                                        <label for="search">author</label>
                                                </li>
                                                <li>
                                                    <p class="look">@Html.DisplayTextFor(Function(m) m.author)</p>
                                                </li>
                                                <li>
                                                        <label for = "search">Isbn</label>
                                                </li>
                                                <li>
                                                    <p class="look">@Html.DisplayTextFor(Function(m) m.isbn)</p>
                                                </li>
                                                <li>
                        <div Class="input-field  col s12 m12 l11 right">
                                                        <input :   id="SearchButton" type="submit" class="btn waves-effect waves-light buttonWrapper " name="Back" value="Back" />
                                                        <input :   id="SearchButton" type="submit" class="btn waves-effect waves-light buttonWrapper " name="Submit" value="Submit" />
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                            </text>
                        End Using

                    </div>
                </div>
            </div>
            <span class="left" id="total_reg"></span>
        </li>
    </ul>
</div>
</div>
</div>