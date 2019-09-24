@ModelType BookManager.Controllers.AddDataViewModel

@Code
    ViewData("Title") = "Add"
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
                                        <div Class="grid-example col s0 m0 l3 hide-on-med-and-down">
                                            <div class=" row">
                                                <ul>
                                                    <li>
                                                        <div Class="input-field grid-example col s4 m4 l12">
                                                            <p class="hide-on-med-and-down center">@Html.ValidationMessageFor(Function(m) m.title)</p>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div class="input-field  col s4 m4 l12">
                                                            <p class="hide-on-med-and-down center">@Html.ValidationMessageFor(Function(m) m.author)</p>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div Class="input-field grid-example col s4 m4 l12">
                                                            <p class="hide-on-med-and-down">@Html.ValidationMessageFor(Function(m) m.isbn)</p>
                                                            <div class="hide-on-med-and-down center">@Html.ValidationSummary(True)</div>
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                            </div>
                                        <div class="grid-example col s12 m12 l9">
                                                        <div class=" row">
                                                            <ul>
                                                                <li>
                                                                        <div Class="input-field grid-example col s12 m12 l11">
                                                                            <i class="material-icons prefix">title</i>
                                                                            @Html.TextBoxFor(Function(m) m.title)
                                                                            <label for="search">title</label>
                                                                            <p class="hide-on-large-only">@Html.ValidationMessageFor(Function(m) m.title)</p>
                                                                        </div>
</li>
                                                                <li>
                                                                    <div class="input-field  col s12 m12 l11">
                                                                                <i class="material-icons prefix">face</i>
                                                                                @Html.TextBoxFor(Function(m) m.author)
                                                                                <label for="search">author</label>
                                                                        <p class="hide-on-large-only">@Html.ValidationMessageFor(Function(m) m.author)</p>
                                                                        </div>
                                                                </li>
                                                                <li>
                                                                    <div Class="input-field grid-example col s12 m12 l11">
                                                                        <i class="material-icons prefix">local_offer</i>
                                                                        @Html.TextBoxFor(Function(m) m.isbn)
                                                                        <label for="search">isbn</label>
                                                                        <p class="hide-on-large-only">@Html.ValidationMessageFor(Function(m) m.isbn)</p>
                                                                        <div class="hide-on-large-only">@Html.ValidationSummary(True)</div>
                                                                    </div>
                                                                </li>
                                                                <li>
                                                                    <div class="input-field  col s12 m12 l11">
                                                                        <input : id="SearchButton" name="Confirm" type="submit" class="btn waves-effect waves-light buttonWrapper right" value="Confirm" />
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