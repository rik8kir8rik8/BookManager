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
        today: null,
        currentSort: 'name',
        currentSortDir: 'asc',
        pageSize: 10,
        currentPage: 1
    },
    created: function () {
        axios.get("/api/BM/borrowbooks/").then(response => (this.books = JSON.parse(response.data)));
        this.today = new Date().toJSON();
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



//booklistのtablebodyにデータを設定
var bookhistory = new Vue({
    el: '#book-his',
    data: {
        books: [],
        currentSort: 'name',
        currentSortDir: 'asc',
        pageSize: 10,
        currentPage: 1
    },
    created: function () {
        axios.get("/api/BM/history/").then(response => (this.books = JSON.parse(response.data)));
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
