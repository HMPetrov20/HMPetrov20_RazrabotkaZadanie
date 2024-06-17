using (var context = new LibraryContext())
{
    // CREATE
    var loan = new Loan { BookID = 1, MemberID = 1, LoanDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(14) };
    context.Loans.Add(loan);
    context.SaveChanges();

    // READ
    var loans = context.Loans.Include(l => l.Book).Include(l => l.Member).ToList();
    foreach (var ln in loans)
    {
        Console.WriteLine($"{ln.LoanID}: {ln.Book.Title} loaned to {ln.Member.Name}");
    }

    // UPDATE
    var loanToUpdate = context.Loans.FirstOrDefault(l => l.LoanID == loan.LoanID);
    if (loanToUpdate != null)
    {
        loanToUpdate.ReturnDate = DateTime.Now.AddDays(21);
        context.SaveChanges();
    }

    // DELETE
    var loanToDelete = context.Loans.FirstOrDefault(l => l.LoanID == loan.LoanID);
    if (loanToDelete != null)
    {
        context.Loans.Remove(loanToDelete);
        context.SaveChanges();
    }
}
