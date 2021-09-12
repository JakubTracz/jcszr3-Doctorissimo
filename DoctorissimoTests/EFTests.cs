using DAL.Data;
using DAL.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DoctorissimoTests
{
    [Trait("Category", "Patient")]
    public class EfTests
    {
        [Fact]
        public async void GetPatientByMail()
        {
            await using var context = new DoctorissimoContext(new DbContextOptions<DoctorissimoContext>());
            var patientsRepository = new PatientRepository(context);
            var patient = patientsRepository.GetPatientEmailByEmail("JKuB@MAIL.COM");
            patient.Should().Be(false);
        }
    }
}
