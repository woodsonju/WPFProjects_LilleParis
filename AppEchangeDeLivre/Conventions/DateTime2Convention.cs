using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEchangeDeLivre.Conventions
{
    /// <summary>
    /// Permet de faire la convention de la propriété DateTime
    /// </summary>
    public class DateTime2Convention : Convention
    {
        public DateTime2Convention()
        {
            //this.Properties<DateTime>() : la convention s'appliquera à la  propriété DateTime
            //Maintenant, toute propriété de notre modèle de type DateTime sera configurée comme 
            //un type datetime2
            this.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
