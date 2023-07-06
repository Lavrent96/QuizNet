using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
        public DbSet<ShipmentContainer> ShipmentContainers { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<ShipmentRemark> ShipmentRemarks { get; set; }
        public DbSet<Stuffing> Stuffings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Shipment>().HasData(
                new Shipment
                {
                    Id = 1,
                    ServiceProviderName = "Service Provider 1",
                    CargooReference = "C2023001999",
                },
                new Shipment
                {
                    Id = 2,
                    ServiceProviderName = "Service Provider 2",
                    CargooReference = "C2023001888",
                },
                new Shipment
                {
                    Id = 3,
                    ServiceProviderName = "Service Provider 3",
                    CargooReference = "C2023001777",
                }
                );

            modelBuilder.Entity<ShipmentContainer>().HasData(
                new ShipmentContainer
                {
                    Id = 1,
                    Number = "N0001",
                    OriginalType = "Open top container",
                    Type = "42GP",
                    ShipmentId = 1
                },
                new ShipmentContainer
                {
                    Id = 2,
                    Number = "N0002",
                    OriginalType = "Double door container",
                    Type = "42GP",
                    ShipmentId = 1
                },
                new ShipmentContainer
                {
                    Id = 3,
                    Number = "N0003",
                    OriginalType = "Double door container",
                    Type = "48GP",
                    ShipmentId = 2
                }
                ,
                new ShipmentContainer
                {
                    Id = 4,
                    Number = "N0004",
                    OriginalType = "Double door container",
                    Type = "48GP",
                    ShipmentId = 2
                },
                new ShipmentContainer
                {
                    Id = 5,
                    Number = "N0005",
                    OriginalType = "Double door container",
                    Type = "48GP",
                    ShipmentId = 3
                });

            modelBuilder.Entity<ShipmentItem>().HasData(
                new ShipmentItem
                {
                    Id = 1,
                    ArticleCode = "ArticleCode 1",
                    ArticleDescription = "ArticleDescription 1",
                    CommodityCode = "CD",
                    Packages = 5,
                    PackageType = "PT1",
                    Pieces = 5,
                    Volume = 5,
                    ShipmentId = 1
                },
                new ShipmentItem
                {
                    Id = 2,
                    ArticleCode = "ArticleCode 2",
                    ArticleDescription = "ArticleDescription 2",
                    CommodityCode = "CD",
                    Packages = 5,
                    PackageType = "PT1",
                    Pieces = 15,
                    Volume = 15,
                    ShipmentId = 2
                },
                new ShipmentItem
                {
                    Id = 3,
                    ArticleCode = "ArticleCode 3",
                    ArticleDescription = "ArticleDescription 3",
                    CommodityCode = "CD",
                    Packages = 5,
                    PackageType = "PT1",
                    Pieces = 15,
                    Volume = 15,
                    ShipmentId = 2
                },
                new ShipmentItem
                {
                    Id = 4,
                    ArticleCode = "ArticleCode 4",
                    ArticleDescription = "ArticleDescription 4",
                    CommodityCode = "CD",
                    Packages = 15,
                    PackageType = "PT1",
                    Pieces = 15,
                    Volume = 15,
                    ShipmentId = 2
                },
                new ShipmentItem
                {
                    Id = 5,
                    ArticleCode = "ArticleCode 5",
                    ArticleDescription = "ArticleDescription 5",
                    CommodityCode = "CD",
                    Packages = 15,
                    PackageType = "PT4",
                    Pieces = 15,
                    Volume = 15,
                    ShipmentId = 3
                },
                new ShipmentItem
                {
                    Id = 6,
                    ArticleCode = "ArticleCode 6",
                    ArticleDescription = "ArticleDescription 6",
                    CommodityCode = "CD",
                    Packages = 8,
                    PackageType = "PT8",
                    Pieces = 25,
                    Volume = 20,
                    ShipmentId = 3
                });
            modelBuilder.Entity<Transport>().HasData(
                new Transport
                {
                    Id = 1,
                    CarrierCode = "MAEU",
                    Type = TransportType.ORIGIN,
                    ShipmentId = 1
                },
                new Transport
                {
                    Id = 2,
                    CarrierCode = "SLMU",
                    Type = TransportType.ORIGIN,
                    ShipmentId = 1
                },
                new Transport
                {
                    Id = 3,
                    CarrierCode = "SLMU",
                    Type = TransportType.MAIN,
                    ShipmentId = 1
                }, new Transport
                {
                    Id = 4,
                    CarrierCode = "MAEU",
                    Type = TransportType.ORIGIN,
                    ShipmentId = 2
                },
                new Transport
                {
                    Id = 5,
                    CarrierCode = "SLMU",
                    Type = TransportType.ORIGIN,
                    ShipmentId = 2
                },
                new Transport
                {
                    Id = 6,
                    CarrierCode = "SLMU",
                    Type = TransportType.DESTINATION,
                    ShipmentId = 3
                });
            modelBuilder.Entity<ShipmentRemark>().HasData(
                new ShipmentRemark
                {
                    Id = 1,
                    CreatedById = 1,
                    CreatedOn = DateTime.UtcNow,
                    Remark = "Remark",
                    RemarkTemplateId = 1,
                    ShipmentId = 1
                },
                new ShipmentRemark
                {
                    Id = 2,
                    CreatedById = 1,
                    CreatedOn = DateTime.UtcNow,
                    Remark = "Remark 1",
                    RemarkTemplateId = 1,
                    ShipmentId = 1
                },
                new ShipmentRemark
                {
                    Id = 3,
                    CreatedById = 1,
                    CreatedOn = DateTime.UtcNow,
                    Remark = "Remark 2",
                    RemarkTemplateId = 1,
                    ShipmentId = 1
                },
                new ShipmentRemark
                {
                    Id = 4,
                    CreatedById = 1,
                    CreatedOn = DateTime.UtcNow,
                    Remark = "Remark 7",
                    RemarkTemplateId = 2,
                    ShipmentId = 2
                },
                new ShipmentRemark
                {
                    Id = 5,
                    CreatedById = 1,
                    CreatedOn = DateTime.UtcNow,
                    Remark = "Remark 8",
                    RemarkTemplateId = 2,
                    ShipmentId = 2
                },
                new ShipmentRemark
                {
                    Id = 6,
                    CreatedById = 1,
                    CreatedOn = DateTime.UtcNow,
                    Remark = "Remark 8",
                    RemarkTemplateId = 2,
                    ShipmentId = 3
                });
            modelBuilder.Entity<Stuffing>().HasData(
                new Stuffing
                {
                    Id = 1,
                    SealNumber = "SealNumber 1",
                    TrackerNumber = "TrackerNumber 1",
                    ShipmentId = 1
                },
                new Stuffing
                {
                    Id = 2,
                    SealNumber = "SealNumber 2",
                    TrackerNumber = "TrackerNumber 2",
                    ShipmentId = 1
                },
                new Stuffing
                {
                    Id = 3,
                    SealNumber = "SealNumber 3",
                    TrackerNumber = "TrackerNumber 3",
                    ShipmentId = 2
                },
                new Stuffing
                {
                    Id = 4,
                    SealNumber = "SealNumber 4",
                    TrackerNumber = "TrackerNumber 4",
                    ShipmentId = 2
                },
                new Stuffing
                {
                    Id = 5,
                    SealNumber = "SealNumber 5",
                    TrackerNumber = "TrackerNumber 54",
                    ShipmentId = 3
                });
        }
    }
}