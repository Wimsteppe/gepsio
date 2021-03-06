﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeffFerguson.Gepsio.Test.IssueTests
{
    /// <summary>
    /// This class contains tests methods that test issues using a single method with no
    /// private helper methods are external files required.
    /// </summary>
    [TestClass]
    public class SingleMethodIssueTests
    {
        [TestMethod]
        public void VerifyFixForIssue1()
        {
            var xbrlDoc = new XbrlDocument();
            xbrlDoc.Load("http://xbrlsite.com/US-GAAP/BasicExample/2010-09-30/abc-20101231.xml");
            Assert.IsTrue(xbrlDoc.IsValid);
        }

        /// <summary>
        /// The bug for this issue was throwing an exception. This test is not concerned
        /// with document validity but simply concerned with making sure that no exceptions
        /// are thrown during loading.
        /// </summary>
        [TestMethod]
        public void VerifyFixForIssue8()
        {
            var xbrlDoc = new XbrlDocument();
            xbrlDoc.Load("https://www.sec.gov/Archives/edgar/data/1688568/000168856818000036/csc-20170331.xml");
        }

        /// <summary>
        /// Ensure that the namespace http://xbrl.sec.gov/dei/2014-01-31, which was added
        /// to Gepsio's support of industry standard namespaces, does not appear anywhere
        /// in a validation error message.
        /// </summary>
        [TestMethod]
        public void VerifyFixForIssue9()
        {
            var xbrlDoc = new XbrlDocument();
            xbrlDoc.Load("https://www.sec.gov/Archives/edgar/data/1688568/000168856818000036/csc-20170331.xml");
            foreach(var validationError in xbrlDoc.ValidationErrors)
            {
                if(validationError.Message.Contains("http://xbrl.sec.gov/dei/2014-01-31") == true)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// Ensure that the namespace http://fasb.org/us-gaap/2017-01-31, which was added
        /// to Gepsio's support of industry standard namespaces, does not appear anywhere
        /// in a validation error message.
        /// </summary>
        [TestMethod]
        public void VerifyFixForIssue10()
        {
            var xbrlDoc = new XbrlDocument();
            xbrlDoc.Load("https://www.sec.gov/Archives/edgar/data/1688568/000168856818000036/csc-20170331.xml");
            foreach (var validationError in xbrlDoc.ValidationErrors)
            {
                if (validationError.Message.Contains("http://fasb.org/us-gaap/2017-01-31") == true)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// Ensure that the namespace http://xbrl.sec.gov/invest/2013-01-31, which was added
        /// to Gepsio's support of industry standard namespaces, does not appear anywhere
        /// in a validation error message.
        /// </summary>
        [TestMethod]
        public void VerifyFixForIssue11()
        {
            var xbrlDoc = new XbrlDocument();
            xbrlDoc.Load("https://www.sec.gov/Archives/edgar/data/1688568/000168856818000036/csc-20170331.xml");
            foreach (var validationError in xbrlDoc.ValidationErrors)
            {
                if (validationError.Message.Contains("http://xbrl.sec.gov/invest/2013-01-31") == true)
                {
                    Assert.Fail();
                }
            }
        }
    }
}
