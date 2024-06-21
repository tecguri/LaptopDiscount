using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaptopDiscount;
using NUnit.Framework.Internal;

namespace LaptopDiscount.Tests
{
    public class DiscountTests
    {

        // Test that no discount is applied for PartTime employees
        [Test]
        public void PartTimeEmployee_NoDiscountApplied()
        {
            EmployeeDiscount employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.PartTime,
                Price = 1000m
            };

            decimal discountedPrice = employeeDiscount.CalculateDiscountedPrice();

            Assert.AreEqual(1000m, discountedPrice);
        }

        // Test that 5% discount is applied for PartialLoad employees
        [Test]
        public void PartialLoadEmployee_5PercentDiscountApplied()
        {
            EmployeeDiscount employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.PartialLoad,
                Price = 1000m
            };

            decimal discountedPrice = employeeDiscount.CalculateDiscountedPrice();

            Assert.AreEqual(950m, discountedPrice);
        }

        // Test that 10% discount is applied for FullTime employees
        [Test]
        public void FullTimeEmployee_10PercentDiscountApplied()
        {
            EmployeeDiscount employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.FullTime,
                Price = 1000m
            };

            decimal discountedPrice = employeeDiscount.CalculateDiscountedPrice();

            Assert.AreEqual(900m, discountedPrice);
        }

        //Test that 20% discount is applied for CompanyPurchasing employees
        [Test]
        public void CompanyPurchasingEmployee_20PercentDiscountApplied()
        {
            EmployeeDiscount employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.CompanyPurchasing,
                Price = 1000m
            };

            decimal discountedPrice = employeeDiscount.CalculateDiscountedPrice();

            Assert.AreEqual(800m, discountedPrice);
        }

        //Test that no discount is applied when the price is zero
        [Test]
        public void ZeroPrice_NoDiscountApplied()
        {
            EmployeeDiscount employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.PartTime,
                Price = 0m
            };

            decimal discountedPrice = employeeDiscount.CalculateDiscountedPrice();

            Assert.AreEqual(0m, discountedPrice);
        }

        [Test]
        public void HighPrice_Purchasing()
        {
            EmployeeDiscount employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.CompanyPurchasing,
                Price = 1000000m
            };

            var discountedPrice = employeeDiscount.CalculateDiscountedPrice();

            Assert.AreEqual(800000m, discountedPrice);
        }
    }
}
