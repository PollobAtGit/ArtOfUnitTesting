using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using NUnitTest.Fakes;
using Service.Implementation;
using Service.Interface;

namespace NUnitTest
{
    [TestFixture]
    class LogAnalyzerServiceTesterWithConfigurableDependency
    {
        [Test]
        public void Should_Return_False_When_Configuration_File_Is_Missing()
        {
            var logFileAnalyzer = GetLogFileAnalyzer();

            logFileAnalyzer.ValidateFile("tester.txt");

            Assert.IsFalse(logFileAnalyzer.WasLastFileValid);
        }

        [TestCase(""), TestCase(null), TestCase("  "), TestCase("\t"), TestCase("\n")]
        public void Should_Throw_Exception_When_File_Is_Missing(string file)
        {
            var logFileAnalyzer = GetLogFileAnalyzer();

            Assert.Catch<ArgumentNullException>(() => logFileAnalyzer.ValidateFile(file));
            Assert.Catch<ArgumentNullException>(() => logFileAnalyzer.ValidateFile(file));
            Assert.Catch<ArgumentNullException>(() => logFileAnalyzer.ValidateFile(file));
            Assert.Catch<ArgumentNullException>(() => logFileAnalyzer.ValidateFile(file));
            Assert.Catch<ArgumentNullException>(() => logFileAnalyzer.ValidateFile(file));
        }

        private ILogFileAnalyzer GetLogFileAnalyzer() =>
            new LogFileAnalyzer(new FakeConfigurableFileReader(new FileNotFoundException()));
    }
}
