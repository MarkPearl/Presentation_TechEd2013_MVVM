using System;
using System.Fakes;
using Customers.DTO;
using Customers.Repositories;
using Customers.Repositories.Fakes;
using Customers.Services.Fakes;
using Customers.ViewModels;
using Microsoft.QualityTools.Testing.Fakes;
using Moq;
using NUnit.Framework;

namespace Customers.Tests.ViewModels
{
    [TestFixture]
    public class CustomerViewModelTests
    {

       [Test]
        public void ShouldReturnRateAsGoldIfRatingIsOne()
        {
            const int ratingServiceReturnValue = 1;
            var customer = new Customer { Name = "Test Person", Id = 1 };
            var ratingService = new StubIRatingService();
            var customerRepository = new StubICustomerRepository();

            // !! Canned result !!
            ratingService.RateCustomer = customerOverride => ratingServiceReturnValue;

            var sut = new CustomerViewModel(
                customer,
                ratingService,
                customerRepository);

            var result = sut.DisplayRate;
            Assert.That(result, Is.EqualTo("Gold"));
        }

        [Test]
        public void ShouldReturnRateAsOrdinaryIfRatingIsZero()
        {
            const int ratingServiceReturnValue = 0;
            var customer = new Customer { Name = "Test Person", Id = 1 };
            var ratingService = new StubIRatingService();
            var customerRepository = new StubICustomerRepository();

            // !! Canned result !!
            ratingService.RateCustomer = customerOverride => ratingServiceReturnValue;

            var sut = new CustomerViewModel(
                customer,
                ratingService,
                customerRepository);

            var result = sut.DisplayRate;
            Assert.That(result, Is.EqualTo("Ordinary"));
        }


        [Test]
        public void ShouldSaveRepoWhenDataIsRefreshed()
        {
            var customer = new Customer {Name = "Test Person", Id = 1};
            var ratingService = new StubIRatingService();
            var customerRepository = new Mock<ICustomerRepository>();            

            var sut = new CustomerViewModel(
                customer, 
                ratingService, 
                customerRepository.Object);

            // Set up expectation
            customerRepository.Setup(
                x => x.Save(It.IsAny<Customer>())).Verifiable();

            sut.Update();

            // ? How do we know it is happened?
            customerRepository.Verify();
        }


        [Test]
        public void ShouldUpdateLastUpdatedDateAfterRefreshing()
        {
            var customer = new Customer { Name = "Test Person", Id = 1 };
            var dateTimeBefore = new DateTime(1980, 1, 19, 14, 0, 0);
            var dateTimeAfter = new DateTime(1980, 1, 19, 15, 0, 0);

            var ratingService = new StubIRatingService();
            var customerRepository = new StubICustomerRepository();
            
            var sut = new CustomerViewModel(
                customer, 
                ratingService, 
                customerRepository);

            using (ShimsContext.Create())
            {
                // Apply Shim 
                ShimDateTime.NowGet = () => dateTimeBefore;
                sut.Update();
                
                Assert.That(sut.DisplayLastUpdated, Is.EqualTo(dateTimeBefore));

                // Apply Shim 
                ShimDateTime.NowGet = () => dateTimeAfter;
                sut.Update();

                Assert.That(sut.DisplayLastUpdated, Is.EqualTo(dateTimeAfter));
            }
        }



         
    }
}