namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertRecordToMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,NumberInStock,GenreId)" +
               "VALUES('Hangover','6/11/2009','4/5/2016',5,1)");
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,NumberInStock,GenreId)" +
                "VALUES('Die Hard','6/11/2009','4/5/2016',5,2)");
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,NumberInStock,GenreId)" +
                "VALUES('The Terminator','6/11/2009','4/5/2016',5,2)");
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,NumberInStock,GenreId)" +
                "VALUES('Toy Story','6/11/2009','4/5/2016',5,3)");
            Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,NumberInStock,GenreId)" +
                "VALUES('Titanic','6/11/2009','4/5/2016',5,4)");
        }
        
        public override void Down()
        {
        }
    }
}
