
//combobox
document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.dropdown-trigger');
    var instances = M.Dropdown.init(elems, "closeOnClick");
});


//searchOpen
document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.sidenav');
    var instances = M.Sidenav.init(elems, "onOpenStart");
});

//combobox
document.addEventListener('DOMContentLoaded', function () {
    var elems = document.querySelectorAll('.select');
    var instances = M.Dropdown.init(elems, "closeOnClick");
});