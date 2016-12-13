namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);

            Sql("INSERT INTO Genres(Id, Name) VALUES(1, 'Action');");
            Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Thriller');");
            Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Family');");
            Sql("INSERT INTO Genres(Id, Name) VALUES(4, 'Romance');");
            Sql("INSERT INTO Genres(Id, Name) VALUES(5, 'Comedy');");

            Sql("INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES('Suiced Squad', 1, '2016-05-01', '2016-04-01', 100);");
            Sql("INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES('Inferno', 2, '2016-08-01', '2016-04-01', 100);     ");
            Sql("INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES('Zootopis', 3, '2016-01-01', '2015-12-01', 100);    ");
            Sql("INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES('Choise', 4, '2016-04-01', '2015-04-01', 100);      ");
            Sql("INSERT INTO Movies(Name, GenreId, DateAdded, ReleaseDate, NumberInStock) VALUES('Deadpool', 5, '2016-02-01', '2016-01-01', 100);    ");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
