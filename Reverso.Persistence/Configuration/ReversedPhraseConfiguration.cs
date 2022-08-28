using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reverso.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverso.Persistence.Configuration
{
    public class ReversedPhraseConfiguration : IEntityTypeConfiguration<ReversedPhrase>
    {
        public void Configure(EntityTypeBuilder<ReversedPhrase> builder)
        {
            builder.ToTable("ReversedPhrase").HasKey(rp => rp.Id);
        }
    }
}
