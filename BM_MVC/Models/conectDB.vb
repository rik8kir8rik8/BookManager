Imports System.Runtime.Serialization
Imports System.Web
Namespace BookManager.Models
    Public Class conectDB

        Function BookList() As BooksDataSet.booksDataTable
            Dim ds As New BooksDataSet()
            Using adp As New BooksDataSetTableAdapters.booksTableAdapter()
                adp.Fill(ds.books)
            End Using
            Return ds.books
        End Function
        Function SearchBookList(title As String, author As String) As BooksDataSet.booksDataTable
            Dim ds As New BooksDataSet()
            Using adp As New BooksDataSetTableAdapters.booksTableAdapter()
                adp.FillBy(ds.books, title, author)
            End Using
            Return ds.books
        End Function

        Function BorrowBook(id As String) As BooksDataSet.borrow_booksDataTable
            Dim ds As New BooksDataSet()
            Using adp As New BooksDataSetTableAdapters.borrow_booksTableAdapter()
                adp.FillBy(ds.borrow_books, id)
            End Using
            Return ds.borrow_books
        End Function

        Function History(id As String) As BooksDataSet.borrow_books_historiesDataTable
            Dim ds As New BooksDataSet()
            Using adp As New BooksDataSetTableAdapters.borrow_books_historiesTableAdapter()
                adp.FillBy(ds.borrow_books_histories, id)
            End Using
            Return ds.borrow_books_histories
        End Function

        Function Login() As BooksDataSet.usersDataTable
            Dim ds As New BooksDataSet()
            Using adp As New BooksDataSetTableAdapters.usersTableAdapter()
                adp.Fill(ds.users)
            End Using
            Return ds.users
        End Function

        Function bookAdd(model As Controllers.AddDataViewModel)
            Dim ds As New BooksDataSet()
            Using adp As New BooksDataSetTableAdapters.booksTableAdapter()
                adp.Insert(model.title, model.author, model.isbn)
            End Using
            Return True
        End Function


    End Class
End Namespace
