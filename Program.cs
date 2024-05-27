// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// https://medium.com/@zzpzaf.se/ms-sql-server-in-docker-b0397a55859c
using System;
using System.Linq;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://www.google.com" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

// Display all Blogs from the database
var query = from b in db.Blogs
            orderby b.BlogId
            select b;

Console.WriteLine("All blogs in the database:");
foreach (var item in query)
{
    Console.WriteLine(item.BlogId);
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
// Delete
// Console.WriteLine("Delete the blog");
// db.Remove(blog);
// db.SaveChanges();
