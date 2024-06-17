using (var context = new LibraryContext())
{
    // CREATE
    var member = new Member { Name = "John Doe", Address = "123 Main St", Phone = "555-5555", Email = "john@example.com" };
    context.Members.Add(member);
    context.SaveChanges();

    // READ
    var members = context.Members.ToList();
    foreach (var mem in members)
    {
        Console.WriteLine($"{mem.MemberID}: {mem.Name}, {mem.Address}, {mem.Phone}, {mem.Email}");
    }

    // UPDATE
    var memberToUpdate = context.Members.FirstOrDefault(m => m.MemberID == member.MemberID);
    if (memberToUpdate != null)
    {
        memberToUpdate.Phone = "555-1234";
        context.SaveChanges();
    }

    // DELETE
    var memberToDelete = context.Members.FirstOrDefault(m => m.MemberID == member.MemberID);
    if (memberToDelete != null)
    {
        context.Members.Remove(memberToDelete);
        context.SaveChanges();
    }
}
