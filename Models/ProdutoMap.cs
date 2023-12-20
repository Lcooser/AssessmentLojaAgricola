using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AgricolaLoja.Models;

namespace ProjetoLojaAgricola.Models
{
    public class ContatoMap : IEntityTypeConfiguration<ProdutosModel>
    {
        public void Configure(EntityTypeBuilder<ProdutosModel> builder)
        {
            builder.HasKey(x => x.Id);
            
        }
    }
}
