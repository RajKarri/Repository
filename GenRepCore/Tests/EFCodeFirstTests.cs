using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Repository.Interfaces;
using Repository.Repositories;

namespace Tests
{
    [TestClass]
    public class EFCodeFirstTests
    {
        public EFCodeFirstTests()
        {
        }

        [TestMethod]
        public void EFCodeFirst_CreateCustomerTest()
        {
            IRepository<Customer> customersRepository = new EntityFrameworkRepository<Customer>();
            Customer customer = new Customer()
            {
                FName = "Dave" + DateTime.Now,
                LName = "Richardson",
                Address1 = "605 Sharview Cir",
                Address2 = "#1735",
                State = "NC",
                Country = "USA",
                Zipcode = "28217",
                Phone = "1234567890",
                Email = "a@a.com"
            };
            var response = customersRepository.Add(customer);
            customersRepository.SaveChanges();
        }

        [TestMethod]
        public void EFCodeFirst_RetrieveCustomersTest()
        {
            IRepository<Customer> customersRepository = new EntityFrameworkRepository<Customer>();
            var customers = customersRepository.GetAll().ToList();
        }

        [TestMethod]
        public void EFCodeFirst_UpdateCustomerTest()
        {
            IRepository<Customer> customersRepository = new EntityFrameworkRepository<Customer>();
            var customer = customersRepository.GetBy(x => x.Id == 1);
            customer.FName = "Andy";
            var response = customersRepository.Update(customer);
            customersRepository.SaveChanges();
        }

        [TestMethod]
        public void EFCodeFirst_DeleteCustomerTest()
        {
            IRepository<Customer> customersRepository = new EntityFrameworkRepository<Customer>();
            var customer = customersRepository.GetBy(x => x.Id == 1);
            var response = customersRepository.Remove(customer);
            customersRepository.SaveChanges();
        }
    }
}
