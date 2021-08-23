using System;
using System.Linq;
using DAL.Enums;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Data
{
    public class AppSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new DoctorissimoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DoctorissimoContext>>());
            if (context.Patients.Any())
            {
                return;
            }

            context.Patients.AddRange(
new Patient{FirstName = "Jack", LastName = "Black", DateOfBirth = DateTime.Parse("2000-08-19"), Address ="Cambridge", MailAddress = "jack.black@mail.com"},
                new Patient{FirstName = "Laura", LastName = "Anand", DateOfBirth = DateTime.Parse("1998-10-01"), Address ="London", MailAddress = "lanand@o2.com"},
                new Patient{FirstName = "Peggy", LastName = "Justice", DateOfBirth = DateTime.Parse("2005-02-02"), Address ="Yorkshire", MailAddress = "justice.peggy.99@gmail.com"},
                new Patient{FirstName = "Nino", LastName = "Olivetto", DateOfBirth = DateTime.Parse("1987-09-29"), Address ="Playmouth", MailAddress = "oNino@gmail.com"},
                new Patient{FirstName = "Arthur", LastName = "Swan", DateOfBirth = DateTime.Parse("1994-04-16"), Address ="Oxford", MailAddress = "arthurino@yahoo.com"}
            );
            context.SaveChanges();

            context.Doctors.AddRange(
                new Doctor{FirstName = "Jonathan", LastName = "Brown",Specialty = DoctorSpecialty.Anesthesiologist},
                new Doctor{FirstName = "Jonathan", LastName = "Brown",Specialty = DoctorSpecialty.ObstetricianAndGynecologist},
                new Doctor{FirstName = "Anne", LastName = "King",Specialty = DoctorSpecialty.CriticalCareMedicineSpecialist},
                new Doctor{FirstName = "Greg", LastName = "Paddy",Specialty = DoctorSpecialty.PlasticSurgeon},
                new Doctor{FirstName = "Evan", LastName = "Farmer",Specialty = DoctorSpecialty.EmergencyMedicineSpecialist},
                new Doctor{FirstName = "Lucy", LastName = "Flower",Specialty = DoctorSpecialty.ColonAndRectalSurgeon}
            );
            context.SaveChanges();
        }
    }
}
