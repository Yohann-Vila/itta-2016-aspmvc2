namespace CodeFirstCat {
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CatDB : DbContext {
         public CatDB()
            : base("name=CatDB") {
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CatThread> CatThreads { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }


    }

}