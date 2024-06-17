using (var context = new LibraryContext())
{
    // CREATE
    var category = new Category { Name = "Science Fiction" };
    context.Categories.Add(category);
    context.SaveChanges();

    // READ
    var categories = context.Categories.ToList();
    foreach (var cat in categories)
    {
        Console.WriteLine($"{cat.CategoryID}: {cat.Name}");
    }

    // UPDATE
    var categoryToUpdate = context.Categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
    if (categoryToUpdate != null)
    {
        categoryToUpdate.Name = "Sci-Fi";
        context.SaveChanges();
    }

    // DELETE
    var categoryToDelete = context.Categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
    if (categoryToDelete != null)
    {
        context.Categories.Remove(categoryToDelete);
        context.SaveChanges();
    }
}
