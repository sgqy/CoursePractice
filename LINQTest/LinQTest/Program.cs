using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinQTest
{
    [Table(Name = "books")]
    internal class Books
    {
        [Column(IsPrimaryKey = true)]
        public ulong ISBN { get; set; }
        [Column()]
        public string Title { get; set; }
        [Column()]
        public string Author { get; set; }
        [Column()]
        public decimal Price { get; set; }
    }

    [Database(Name = "Books")]
    internal class MyContext : DataContext
    {
        public MyContext(IDbConnection connection) : base(connection, new AttributeMappingSource()) { }
        public Table<Books> Books { get { return GetTable<Books>(); } }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            string cstr = "Server = 127.0.0.1;"
                + "Database = test02;"
                + "User ID = root;"
                + "Password = root;"
                + "SQL Server Mode = true";

            var dbcon = new MySqlConnection(cstr);
            dbcon.Open();

            var context = new MyContext(dbcon);
            //context.CreateDatabase();

            context.Books.InsertOnSubmit(new Books()
            {
                ISBN = 9784057852070,
                Title = "title-0002",
                Author = "person-0005",
                Price = 88.97M,
            });

            // Do not change objects which sent by `InsertOnSubmit`
            context.Books.ForEach(x => x.Author = "someone");

            context.SubmitChanges();

            context.Dispose();
            dbcon.Close();
        }
    }

    internal static class Extensions
    {
        public static void ForEach<TEntity>(this Table<TEntity> table, Action<TEntity> action) where TEntity : class
        { foreach (var entity in table) { action(entity); } }
    }
}

