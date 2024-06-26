using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAttach.Tests.Tests
{
    public class PatientValidationTests
    {
        [TestFixture]
        public class PatientValidationTests
        {
            [TestCase("John3", "Doe", "William")]
            [TestCase("John", "Doe5", "William")]
            [TestCase("John", "Doe", "William2")]
            public async Task CreatePatient_WhenNameContainsDigits_ReturnsBadRequest(string firstName, string lastName, string middleName)
            {
                // Arrange
                var controller = new PatientsController(new MockPatientService()); // Assuming MockPatientService is an implementation of IPatientService
                var patientRequest = new PatientRequest
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    Iin = "123456789012" // Valid IIN for the purpose of this test
                };

                // Act
                var result = await controller.CreatePatient(patientRequest);

                // Assert
                Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            }

            [Test]
            public async Task CreatePatient_WhenAnyFieldIsEmpty_ReturnsBadRequest()
            {
                // You can iterate over different combinations of empty fields if necessary
                var controller = new PatientsController(new MockPatientService());
                var patientRequest = new PatientRequest
                {
                    FirstName = "",
                    LastName = "Doe",
                    MiddleName = "William",
                    Iin = "123456789012"
                };

                // Act
                var result = await controller.CreatePatient(patientRequest);

                // Assert
                Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            }

            [TestCase("abcdefghijk")]
            [TestCase("12345678901")]
            [TestCase("1234567890123")]
            public async Task CreatePatient_WhenIINIsInvalid_ReturnsBadRequest(string iin)
            {
                var controller = new PatientsController(new MockPatientService());
                var patientRequest = new PatientRequest
                {
                    FirstName = "John",
                    LastName = "Doe",
                    MiddleName = "William",
                    Iin = iin
                };

                // Act
                var result = await controller.CreatePatient(patientRequest);

                // Assert
                Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            }
        }
    }
}
