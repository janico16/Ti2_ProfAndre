namespace Ti2_Forum.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Ti2_Forum.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Ti2_Forum.Models.LojaXDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Ti2_Forum.Models.LojaXDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoidMsg creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var forum = new List<Forum> {
            new Forum {idForum=1},
            new Forum {idForum=2},
            new Forum {idForum=3}
         };
            forum.ForEach(aa => context.Forum.AddOrUpdate(a => a.idForum, aa));
            context.SaveChanges();

            var mensagem = new List<Mensagem> {
            new Mensagem {idMsg=1, mensagem="Ola sou eu", ForumIdFk=1},
            new Mensagem {idMsg=2, mensagem="Era uma vez um gato", ForumIdFk=1},
            new Mensagem {idMsg=3, mensagem="Gosto deste produto", ForumIdFk=2},
            new Mensagem {idMsg=4, mensagem="que caiu do telhado", ForumIdFk=1},
            new Mensagem {idMsg=5, mensagem="tambem eu", ForumIdFk=2},
            new Mensagem {idMsg=6, mensagem="tambem eu", ForumIdFk=2},
            new Mensagem {idMsg=7, mensagem="eu nao", ForumIdFk=3},
            new Mensagem {idMsg=8, mensagem="tambem eu", ForumIdFk=2},
            new Mensagem {idMsg=9, mensagem="tambem eu", ForumIdFk=2},
            new Mensagem {idMsg=10, mensagem="e morreu", ForumIdFk=1}
         };
            mensagem.ForEach(aa => context.Mensagem.AddOrUpdate(a => a.idMsg, aa));
            context.SaveChanges();

            /*try
            {
                
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }*/
        }
    }
}
