using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CUIT_Framework.Framework
{
    public class Assertions
    {
        public static void IsTrue(bool condition)
        {
            try
            {
                Assert.IsTrue(condition);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion IsTrue has been failed - Condition not matched");
            }
        }

        public static void IsTrue(bool condition, string message)
        {
            try
            {
                Assert.IsTrue(condition, message);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion IsTrue has been failed - Condition not matched");
            }
        }

        public static void IsFalse(bool condition)
        {
            try
            {
                Assert.IsFalse(condition);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion IsTrue has been failed - Condition not matched");
            }
        }

        public static void IsFalse(bool condition, string message)
        {
            try
            {
                Assert.IsFalse(condition, message);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion IsTrue has been failed - Condition not matched");
            }
        }

        public static void AreEqual(string expected, string actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreEqual(string expected, string actual, string message)
        {
            try
            {
                Assert.AreEqual(expected, actual, message);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreEqual(object expected, object actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreEqual(object expected, object actual, string message)
        {
            try
            {
                Assert.AreEqual(expected, actual, message);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreNotEqual(string notExpected, string actual)
        {
            try
            {
                Assert.AreNotEqual(notExpected, actual);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreNotEqual(string notExpected, string actual, string message)
        {
            try
            {
                Assert.AreNotEqual(notExpected, actual, message);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreNotEqual(object notExpected, object actual)
        {
            try
            {
                Assert.AreNotEqual(notExpected, actual);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreNotEqual(object notExpected, object actual, string message)
        {
            try
            {
                Assert.AreNotEqual(notExpected, actual, message);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreSame(object expected, object actual)
        {
            try
            {
                Assert.AreSame(expected, actual);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreSame(object expected, object actual, string message)
        {
            try
            {
                Assert.AreSame(expected, actual, message);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreNotSame(object notExpected, object actual)
        {
            try
            {
                Assert.AreNotSame(notExpected, actual);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void AreNotSame(object notExpected, object actual, string message)
        {
            try
            {
                Assert.AreNotSame(notExpected, actual, message);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void Equal(object expected, object actual)
        {
            try
            {
                Assert.Equals(expected, actual);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void IsNull(object value)
        {
            try
            {
                Assert.IsNull(value);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void IsNull(object value, string message)
        {
            try
            {
                Assert.IsNull(value, message);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void IsNotNull(object value)
        {
            try
            {
                Assert.IsNotNull(value);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }

        public static void IsNotNull(object value, string message)
        {
            try
            {
                Assert.IsNotNull(value, message);
            }
            catch (AssertFailedException)
            {
                Assert.Fail("Assertion AreEqual has been failed - Condition not matched");
            }
        }
    }
}
