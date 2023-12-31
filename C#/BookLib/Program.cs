﻿//TODO MAKE THIS USE LISTS AND NOT ARRAYS 
using System.Collections.Generic;

namespace BookLibrary;

public class Page {
    public string content = "";
    public int pageNumber = 1;


}
public class Book {



    public string title = "";

    public int currentPage = 0;

    public List<Page> pages = new List<Page>();

    public void CreateNewPage(string newContent, int newNumber) {
        Page newPage = new Page();

        newPage.content = newContent;
        newPage.pageNumber = newNumber;

        pages.Add(newPage);
    }

    public void OpenBook(Book requestedBook) {
        Console.Clear();
        Console.WriteLine(pages.Count());
        Console.WriteLine(requestedBook.title);
        Console.ReadKey();
        DisplayPage(currentPage);
    }

    public void DisplayPage(int pageRequest) {
        currentPage = pageRequest;
        Console.Clear();
        Console.WriteLine(pages[pageRequest].content);
        Console.WriteLine(pages[pageRequest].pageNumber.ToString());
        Console.WriteLine("");
        Console.WriteLine("next to continue, close to exit: ");
        string? input = Console.ReadLine();

        if(input != null) {
            if(input == "next") {
                DisplayPage(pageRequest + 1);
            } 
            else if(input == "close") {
                Library.StartLibrary();
            } else if(pageRequest + 1 > pages.Count()) {
                Library.JustFinishedBook();
            }
        } else {
            Library.StartLibrary();
        }
    }

}

public class Library {

    public static List<Book> library = new List<Book>();

    static void Main(string[] args) {
        SetUpBooks();
        StartLibrary();
    }

    static void SetUpBooks() {
        Book book1 = new Book();
        book1.title = "the first book";
        book1.CreateNewPage("this is a book wowow", 1);
        book1.CreateNewPage("page 2 😱", 2);
        book1.CreateNewPage("the end 😭", 3);

        Book book2 = new Book();
        book2.title = "the book of bing bong";
        book2.CreateNewPage("bing bong", 1);
        book2.CreateNewPage("bing bong page 2 😱", 2);
        book2.CreateNewPage("the end of bing bong 😭", 3);

        Book book3 = new Book();
        book3.title = "the last book";
        book3.CreateNewPage("this is insane", 1);
        book3.CreateNewPage("page 2 😱 omg", 2);
        book3.CreateNewPage("the end 😭 so sad", 3);

        library.Add(book1);
        library.Add(book2);
        library.Add(book3);

    }

    public static void StartLibrary() {
        Console.Clear();

        Console.WriteLine("Current books:");
        Console.WriteLine("the first book");
        Console.WriteLine("the book of bing bong");
        Console.WriteLine("the last book");
        Console.WriteLine("");
        Console.WriteLine("Type the name of the book or close to exit the library: ");
        var input = Console.ReadLine();

        if(input == "close") {
            Console.WriteLine("Thank you for using the Library!");
            Environment.Exit(0);
        }

        foreach(Book book in library) {
            if(book.title == input) {
                book.OpenBook(book);
            }
        }
        Console.WriteLine("Could not find a book with that name, sorry!");
        Console.ReadKey();
        StartLibrary();
    }
    public static void JustFinishedBook() {
        Console.WriteLine("Book finished!");
        Console.ReadKey();
        StartLibrary();
    }
}