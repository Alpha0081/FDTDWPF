using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComplexTests
{
    [TestClass]
    public class ComplexTests
    {
        [TestMethod]
        public void TestComplexEquals()
        {
            Complex a = new Complex(1, 2);
            Complex b = new Complex(1, 2);
            Assert.IsTrue(a == b);
        }
        [TestMethod]
        public void TestComplexToString()
        {
            Complex a = new Complex(1, 2);
            Assert.IsTrue(a.ToString() == "1+2j");
        }
        [TestMethod]
        public void TestComplexSum()
        {
            Complex a = new Complex(1, 2);
            Complex b = new Complex(3, 4);
            Complex c = new Complex(4, 6);
            Assert.IsTrue((a + b) == c);
        }
        [TestMethod]
        public void TestComplexSubstract()
        {
            Complex a = new Complex(2, 3);
            Complex b = new Complex(1, 1);
            Complex c = new Complex(1, 2);
            Assert.IsTrue((a - b) == c);
        }
        [TestMethod]
        public void TestComplexMultiplication()
        {
            Complex a = new Complex(2, 3);
            Complex b = new Complex(1, 2);
            Complex c = new Complex(-4, 7);
            Assert.IsTrue((a * b) == c);
        }
        [TestMethod]
        public void TestComplexDividersToDouble()
        {
            Complex a = new Complex(3, 6);
            Complex b = new Complex(1, 2);
            Assert.IsTrue((a / 3) == b);
        }
        [TestMethod]
        public void TestComplexDividers()
        {
            Complex a = new Complex(3, 6);
            Complex b = new Complex(1, 2);
            Complex c = new Complex(3, 0);
            Assert.IsTrue((a / b) == c);
        }
        [TestMethod]
        public void TestComplexExp()
        {
            Complex a = Complex.Exp(Math.PI);
            Complex b = new Complex(Math.Cos(Math.PI), Math.Sin(Math.PI));
            Assert.IsTrue(a == b);
        }
        [TestMethod]
        public void TestComplexHypot()
        {
            Complex a = new Complex(3, 4);
            Assert.IsTrue(a.hypot() == 5.0);
        }
        [TestMethod]
        public void TestComplexSqrt()
        {
            Complex a = Complex.Sqrt(4);
            Complex b = new Complex(2, 0);
            Complex c = Complex.Sqrt(-4);
            Complex d = new Complex(0, 2);
            Assert.IsTrue((a == b) && (c == d));
        }
        [TestMethod]
        public void TestComplexReflection()
        {
            Complex a = new Complex(1, 2);
            Complex b = new Complex(1, -2);
            Assert.IsTrue(a.reflection() == b);
        }
        [TestMethod]
        public void TestConvertDoubleToComplex()
        {
            Complex a = 3;
            Complex b = new Complex(3, 0);
            Assert.IsTrue(a == b);
        }
    }
} 
