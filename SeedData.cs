using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public static class SeedData
    {
        public static void Initialize(LibraryDbContext context)
        {
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            context.Books.AddRange(
                new Book
                {
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    ISBN = "9780132350884",
                    CopiesAvailable = 5,
                    BorrowCount = 20
                },
                new Book
                {
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt",
                    ISBN = "9780201616224",
                    CopiesAvailable = 3,
                    BorrowCount = 15
                },
                new Book
                {
                    Title = "Design Patterns",
                    Author = "Erich Gamma",
                    ISBN = "9780201633610",
                    CopiesAvailable = 2,
                    BorrowCount = 30
                },
                new Book
                {
                    Title = "Refactoring",
                    Author = "Martin Fowler",
                    ISBN = "9780201485677",
                    CopiesAvailable = 4,
                    BorrowCount = 10
                },
                new Book
                {
                    Title = "Clean Architecture",
                    Author = "Robert C. Martin",
                    ISBN = "9780134494166",
                    CopiesAvailable = 6,
                    BorrowCount = 25
                }

            );

            context.SaveChanges();
        }
    }
}
