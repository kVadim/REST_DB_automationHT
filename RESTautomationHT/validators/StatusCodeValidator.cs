using NUnit.Framework;
using System;
using System.Net;

namespace RESTautomationHT.validators
{
    public class StatusCodeValidator
    {
        public static void Validate(String Expected, HttpWebResponse ActualResponse)
        {
            Assert.IsTrue(ActualResponse.StatusCode.ToString() == Expected,
                String.Format("Expected status code is different from Actual. Expected: {0}, Actual: {1}", Expected, ActualResponse.StatusCode.ToString())
                );
        }
    }
}
