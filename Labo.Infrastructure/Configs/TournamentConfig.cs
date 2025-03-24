using Labo.Application.Utils;
using Labo.Domain.Entities;
using Labo.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labo.Infrastructure.Configs
{
    internal class TournamentConfig : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.ToTable(t => 
                t.HasCheckConstraint("CK_MIN_ELO", "MinElo BETWEEN 0 AND 3000")
            );

            builder.ToTable(t =>
                t.HasCheckConstraint("CK_MAX_ELO", "MaxElo BETWEEN 0 AND 3000")
            );

            builder.ToTable(t =>
            t.HasCheckConstraint("CK_MIN_MEMBERS", "MinMembers BETWEEN 2 AND 32")
        );

            builder.ToTable(t =>
                t.HasCheckConstraint("CK_MAX_MEMBERS", "MaxMembers BETWEEN 2 AND 32")
            );

            builder.ToTable(t =>
                t.HasCheckConstraint("CK_MAX_DEADLINE", "(DeadlineDate >= DATEADD(DAY, MinMembers, GETDATE()))")
       );



            builder.Property(u => u.CurrentRound).HasDefaultValue(0);

            builder.Property(u => u.Status).HasDefaultValue(Status.Pending);           

        }
    }
}
