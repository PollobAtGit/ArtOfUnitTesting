using NUnit.Framework;
using NUnitTest.Fakes;
using Service.Implementation;
using Service.Interface;

namespace NUnitTest
{
    [TestFixture]
    public class LogAnalyzerTester
    {
        [Test]
        public void Should_Flag_Valid_File_Status_For_File_Verifier()
        {
            var (fileVerifierMock, logFileAnalyzer) = GetFileVerifierAndLogAnalyzer(true);

            logFileAnalyzer.ValidateFile(string.Empty);

            Assert.AreEqual(fileVerifierMock.FileStatus, FileStatus.Valid);
        }

        [Test]
        public void Should_Flag_Invalid_File_Status_For_File_Verifier()
        {
            var (fileVerifierMock, logFileAnalyzer) = GetFileVerifierAndLogAnalyzer(false);

            logFileAnalyzer.ValidateFile(string.Empty);

            Assert.AreEqual(fileVerifierMock.FileStatus, FileStatus.Invalid);
        }

        private static (IFileVerifier, ILogFileAnalyzer) GetFileVerifierAndLogAnalyzer(bool isValid)
        {
            var fileVerifierMock = new FileVerifierMock(isValid);

            ILogFileAnalyzer logFileAnalyzer = new LogAnalyzer(fileVerifierMock);

            return (fileVerifierMock, logFileAnalyzer);
        }
    }
}
