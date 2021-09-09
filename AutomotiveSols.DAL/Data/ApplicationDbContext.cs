using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomotiveSols.BLL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutomotiveSols.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<AutoPart> AutoParts { get; set; }

        public DbSet<PartGallery> PartGalleries { get; set; }
        public DbSet<ApplicationUser > ApplicationUsers { get; set; }
     //   public DbSet<Organization> Organizations { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }

        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        public DbSet<Services> Services { get; set; }

        public DbSet<Appointments> Appointments { get; set; }

        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Trim> Trims { get; set; }

        public DbSet<Year> Years { get; set; }
        
        public DbSet<RegistrationCity> RegistrationCities { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Mileage> Mileages { get; set; }


        public DbSet<Features> Features { get; set; }


        public DbSet<Car> Cars { get; set; }

        public DbSet<CarAppointment> CarAppointments { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<ServicesAppointment> ServicesAppointments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }


            builder.Entity<Category>().HasKey(a => a.Id);
            builder.Entity<Category>().Property(a => a.Name).IsRequired();
            builder.Entity<Category>().Property(a => a.DisplayOrder).IsRequired();


            builder.Entity<SubCategory>().HasKey(k => k.Id);
            builder.Entity<SubCategory>().Property(k => k.Name).IsRequired();
            builder.Entity<SubCategory>().HasOne(k => k.Category)
                .WithMany(k => k.SubCategories).HasForeignKey(k => k.CategoryId);

            builder.Entity<Transmission>().HasKey(k => k.Id);
            builder.Entity<Transmission>().Property(k => k.Name).IsRequired();

            builder.Entity<Trim>().HasKey(k => k.Id);
            builder.Entity<Trim>().Property(k => k.Name).IsRequired();

            builder.Entity<Year>().HasKey(k => k.Id);
            builder.Entity<Year>().Property(k => k.SolarYear).IsRequired();

            builder.Entity<RegistrationCity>().HasKey(k => k.Id);
            builder.Entity<RegistrationCity>().Property(k => k.Name).IsRequired();

            builder.Entity<Model>().HasKey(k => k.Id);
            builder.Entity<Model>().Property(k => k.Name).IsRequired();

            builder.Entity<Mileage>().HasKey(k => k.Id);
            builder.Entity<Mileage>().Property(k => k.NumberKm).IsRequired();

            builder.Entity<Brand>().HasKey(k => k.Id);
            builder.Entity<Brand>().Property(k => k.Name).IsRequired();

            
            builder.Entity<Car>().HasKey(k => k.Id);
            builder.Entity<Car>().Property(k => k.Price).IsRequired();
            builder.Entity<Car>().Property(k => k.Price).IsRequired();
            builder.Entity<Car>().Property(k => k.CreatedOn);
            builder.Entity<Car>().Property(k => k.UpdatedOn);
            builder.Entity<Car>().Property(k => k.Status);
            builder.Entity<Car>().HasOne(k => k.ApplicationUser)
               .WithMany(k => k.Cars).HasForeignKey(k => k.ApplicationUserId);
            builder.Entity<Car>().HasOne(k => k.Transmission)
              .WithMany(k => k.Cars).HasForeignKey(k => k.TransmissionId);
            builder.Entity<Car>().HasOne(k => k.Trim)
              .WithMany(k => k.Cars).HasForeignKey(k => k.TrimId);
            builder.Entity<Car>().HasOne(k => k.Year)
              .WithMany(k => k.Cars).HasForeignKey(k => k.YearId);
            builder.Entity<Car>().HasOne(k => k.RegistrationCity)
              .WithMany(k => k.Cars).HasForeignKey(k => k.RegistrationCityId);
            builder.Entity<Car>().HasOne(k => k.Model)
              .WithMany(k => k.Cars).HasForeignKey(k => k.ModelId);
            builder.Entity<Car>().HasOne(k => k.Mileage)
              .WithMany(k => k.Cars).HasForeignKey(k => k.MileageId);
            builder.Entity<Car>().HasOne(k => k.Brand)
              .WithMany(k => k.Cars).HasForeignKey(k => k.BranId);


            builder.Entity<Features>().HasKey(k => k.Id);
            builder.Entity<Features>().Property(k => k.Name).IsRequired();
            builder.Entity<Features>().Property(k => k.Description);


            builder.Entity<CarFeature>().HasKey(k => new { k.FeatureId, CarId = k.Id });
            builder.Entity<CarFeature>().HasOne(k => k.Car)
              .WithMany(k => k.GetCarFeatures).HasForeignKey(k => k.Id);

            builder.Entity<CarFeature>().HasOne(k => k.Features)
              .WithMany(k => k.GetCarFeatures).HasForeignKey(k => k.FeatureId);



            builder.Entity<CarAppointment>().HasKey(k => k.Id);
            builder.Entity<CarAppointment>().HasOne(k => k.Appointments)
                .WithMany(k => k.CarAppointments).HasForeignKey(k => k.AppointmentId);


            builder.Entity<CarAppointment>().HasOne(k => k.Car)
                .WithMany(k => k.CarAppointments).HasForeignKey(k => k.CarId);


            builder.Entity<Appointments>().HasKey(a => a.Id);
            builder.Entity<Appointments>().Property(k => k.AppointmentDate).IsRequired();
            builder.Entity<Appointments>().Property(k => k.CustomerEmail).IsRequired();
            builder.Entity<Appointments>().Property(k => k.CustomerName).IsRequired();
            builder.Entity<Appointments>().Property(k => k.CustomerPhoneNumber).IsRequired();
            builder.Entity<Appointments>().Property(k => k.isConfirmed);
            builder.Entity<Appointments>().HasOne(k => k.SalesPerson)
                .WithMany(k => k.Appointments).HasForeignKey(k => k.SalesPersonId);

            builder.Entity<ServicesAppointment>().HasKey(k => k.Id);
            builder.Entity<ServicesAppointment>().HasOne(k => k.Appointments)
                .WithMany(k => k.ServicesAppointments).HasForeignKey(k => k.AppointmentId);


            builder.Entity<ServicesAppointment>().HasOne(k => k.Service)
                .WithMany(k => k.ServicesAppointments).HasForeignKey(k => k.ServiceId);



            builder.Entity<ServiceType>().HasKey(k => k.Id);
            builder.Entity<ServiceType>().Property(k => k.Name).IsRequired();

            builder.Entity<Services>().HasKey(k => k.Id);
            builder.Entity<Services>().Property(k => k.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Services>().Property(k => k.Price).IsRequired();
            builder.Entity<Services>().Property(k => k.ImageUrl);
            builder.Entity<Services>().Property(k => k.SellerComments).IsRequired().HasMaxLength(300);
            builder.Entity<Services>().Property(k => k.Description).IsRequired().HasMaxLength(300);
            builder.Entity<Services>().Property(k => k.Status);
            builder.Entity<Services>().HasOne(k => k.ServiceType)
                    .WithMany(k => k.Services).HasForeignKey(k => k.ServiceTypeId);

            builder.Entity<Services>().HasOne(k => k.ApplicationUser)
                .WithMany(k => k.Services).HasForeignKey(l => l.ApplicationUserId);

            builder.Entity<AutoPart>().HasKey(k => k.Id);
            builder.Entity<AutoPart>().Property(k => k.Name).IsRequired();
            builder.Entity<AutoPart>().Property(k => k.ListPrice);
            builder.Entity<AutoPart>().Property(k => k.Price);
            builder.Entity<AutoPart>().Property(k => k.Price50);
            builder.Entity<AutoPart>().Property(k => k.Price100);
            builder.Entity<AutoPart>().Property(k => k.Description).IsRequired().HasMaxLength(300);
            builder.Entity<AutoPart>().Property(k => k.SellerComments).IsRequired().HasMaxLength(200);
            builder.Entity<AutoPart>().Property(k => k.MainImageUrl);
            builder.Entity<AutoPart>().Property(k => k.CreatedOn);
            builder.Entity<AutoPart>().Property(k => k.UpdatedOn);
            builder.Entity<AutoPart>().Property(k => k.Status);
            builder.Entity<AutoPart>().HasOne(k => k.Category).WithMany(k => k.AutoParts).HasForeignKey(m => m.CategoryId);
            builder.Entity<AutoPart>().HasOne(k => k.SubCategory).WithMany(k => k.AutoParts).HasForeignKey(m => m.SubCategoryId);

            builder.Entity<AutoPart>().HasOne(m => m.ApplicationUser).WithMany(m => m.AutoParts).HasForeignKey(m => m.ApplicationUserId);

            builder.Entity<PartGallery>().HasKey(s => s.Id);
            builder.Entity<PartGallery>().Property(s => s.Name);
            builder.Entity<PartGallery>().Property(s => s.URL);
            builder.Entity<PartGallery>().HasOne(k => k.AutoPart).WithMany(k => k.PartGalleries).HasForeignKey(s => s.AutoPartId);


            builder.Entity<CarGallery>().HasKey(s => s.Id);
            builder.Entity<CarGallery>().Property(s => s.Name);
            builder.Entity<CarGallery>().Property(s => s.URL);
            builder.Entity<CarGallery>().HasOne(k => k.Car).WithMany(k => k.CarGalleries).HasForeignKey(s => s.CarId);

            //builder.Entity<Organization>().HasKey(m => m.Id);
            //builder.Entity<Organization>().Property(m => m.Name).IsRequired();
            //builder.Entity<Organization>().Property(m => m.StreetAddress).IsRequired();
            //builder.Entity<Organization>().Property(m => m.PhoneNumber).IsRequired();
            //builder.Entity<Organization>().Property(m => m.PostalCode).IsRequired();
            //builder.Entity<Organization>().Property(m => m.State).IsRequired();
            //builder.Entity<Organization>().Property(m => m.City).IsRequired();
            //builder.Entity<Organization>().Property(m => m.IsAuthorizedCompany).IsRequired();

            //builder.Entity<ShoppingCart>().HasKey(m => m.Id);
            builder.Entity<ShoppingCart>().Property(m => m.Count);

            builder.Entity<OrderHeader>().HasKey(m => m.Id);
            builder.Entity<OrderHeader>().Property(g => g.OrderDate);
            builder.Entity<OrderHeader>().Property(g => g.ShippingDate);
            builder.Entity<OrderHeader>().Property(g => g.OrderTotalOriginal);
            builder.Entity<OrderHeader>().Property(g => g.OrderTotal);
            builder.Entity<OrderHeader>().Property(g => g.CouponCode);
            builder.Entity<OrderHeader>().Property(g => g.CouponCodeDiscount);
            builder.Entity<OrderHeader>().Property(g => g.TrackingNumber);
            builder.Entity<OrderHeader>().Property(g => g.Carrier);
            builder.Entity<OrderHeader>().Property(g => g.OrderStatus);
            builder.Entity<OrderHeader>().Property(g => g.PaymentStatus);
            builder.Entity<OrderHeader>().Property(g => g.PaymentDate);
            builder.Entity<OrderHeader>().Property(g => g.PaymentDueDate);
            builder.Entity<OrderHeader>().Property(g => g.TransactionId);
            builder.Entity<OrderHeader>().Property(g => g.PhoneNumber);
            builder.Entity<OrderHeader>().Property(g => g.CashonDelivery);

            builder.Entity<OrderHeader>().Property(g => g.StreetAddress);
            builder.Entity<OrderHeader>().Property(g => g.City);
            builder.Entity<OrderHeader>().Property(g => g.State);
            builder.Entity<OrderHeader>().Property(g => g.PostalCode);

            builder.Entity<OrderHeader>().Property(g => g.Name);

            builder.Entity<OrderHeader>().HasOne(m => m.ApplicationUser).WithMany(m => m.OrderHeaders).HasForeignKey(m => m.ApplicationUserId);

            builder.Entity<OrderDetails>().HasKey(y => y.Id);
            builder.Entity<OrderDetails>().Property(y => y.Count);
            builder.Entity<OrderDetails>().Property(y => y.Price);

            builder.Entity<OrderDetails>().HasOne(y => y.OrderHeader).WithOne(y => y.OrderDetails).HasForeignKey<OrderDetails>(y => y.OrderId);
            builder.Entity<OrderDetails>().HasOne(y => y.AutoPart).WithMany
                (y => y.OrderDetails).HasForeignKey(y => y.AutoPartId);


            builder.Entity<Coupon>().HasKey(y => y.Id);
            builder.Entity<Coupon>().Property(y => y.Name);
            builder.Entity<Coupon>().Property(y => y.CouponType);
            builder.Entity<Coupon>().Property(y => y.Discount); 
            builder.Entity<Coupon>().Property(y => y.MinimumAmount); 
            builder.Entity<Coupon>().Property(y => y.Picture); 
            builder.Entity<Coupon>().Property(y => y.IsActive); 
        }


    }
}
