//Headerの設定
var headers = new Vue({
    el: '#header',
    data: {
        headers: [
            { button: "", title: "Title", name: "Name", isbn: "ISBN" }
        ]
    }
});

//booklistのtablebodyにデータを設定
var booklist = new Vue({
    el: '#book-list',
    data: {
        books: [],
        currentSort: 'name',
        currentSortDir: 'asc',
        pageSize: 10,
        currentPage: 1
    },
    created: function () {
        //var t = getQueryVariable("title");
        //var a = getQueryVariable("author");
        var query = getQuery();
        axios.get("/api/BM/booklist" + query).then(response => (this.books = JSON.parse(response.data)));
    },
    methods: {
        sort: function (s) {
            //if s == current sort, reverse
            if (s === this.currentSort) {
                this.currentSortDir = this.currentSortDir === 'asc' ? 'desc' : 'asc';
            }
            this.currentSort = s;
        },
        nextPage: function () {
            if ((this.currentPage * this.pageSize) < this.books.length) this.currentPage++;
            return false;
        },
        prevPage: function () {
            if (this.currentPage !== 1) this.currentPage--;
            return false;
        },
        jumpPage: function (page) {
            this.currentPage = page;
            return false;
        }
    },
    computed: {
        sortedbooks: function () {
            return this.books.sort((a, b) => {
                let modifier = 1;
                if (this.currentSortDir === 'desc') modifier = -1;
                if (a[this.currentSort] < b[this.currentSort]) return -1 * modifier;
                if (a[this.currentSort] > b[this.currentSort]) return 1 * modifier;
                return 0;
            }).filter((row, index) => {
                let start = (this.currentPage - 1) * this.pageSize;
                let end = this.currentPage * this.pageSize;
                if (index >= start && index < end) return true;
            });
        }
    }
});

var app = new Vue({
    el: '#app',
    data: {
        display: false
    }
});

//booklistのtablebodyにデータを設定
var author = new Vue({
    el: '#author-list',
    data: {
        authors: [],
    },
    created: function () {
        axios.get("/api/BM/booklistAuthor/").then(response => (this.authors = JSON.parse(response.data)));
    }
});


function getQuery() {
    var query = window.location.search.substring(1);
    if (query === null) {
        return ""
    }
    else {
        return "?" + query
    }
}