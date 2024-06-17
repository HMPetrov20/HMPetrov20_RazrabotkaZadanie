using (var context = new LibraryContext())
{
    // CREATE
    var book = new Book { Title = "Dune", Author = "Frank Herbert", PublicationYear = 1965, ISBN = "9780441013593", Quantity = 10, AvailableQuantity = 10, CategoryID = 1 };
    context.Books.Add(book);
    context.SaveChanges();

    // READ
    var books = context.Books.ToList();
    foreach (var bk in books)
    {
        Console.WriteLine($"{bk.BookID}: {bk.Title} by {bk.Author}");
    }

    // UPDATE
    var bookToUpdate = context.Books.FirstOrDefault(b => b.BookID == book.BookID);
    if (bookToUpdate != null)
    {
        bookToUpdate.Quantity = 12;
        bookToUpdate.AvailableQuantity = 12;
        context.SaveChanges();
    }

    // DELETE
    var bookToDelete = context.Books.FirstOrDefault(b => b.BookID == book.BookID);
    if (bookToDelete != null)
    {
        context.Books.Remove(bookToDelete);
        context.SaveChanges();
    }
}
