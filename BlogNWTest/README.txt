---Ce projet est réalisé avec asp .Net core
la BD utilisé est MSSQL Server
J'ai utilisé la migration pour créer la BD et 
tous ses objets.

Vous pouver commenter ceci:

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

avant de lancer la commande add-migration et l'update-database
et ensuite une fois la migration passé,décommenter le constructeur BlogContext et commenter ceci:

 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-VE5PN8N\\SQLEXPRESS;Database=blognwdb;Trusted_Connection=True");
        }
=====La recuperation de la valeur des elements de la dropdownlist m'a posé beaucoup de probleme.Il est possible
que save post et edit post generent des erreurs.

Merci