using AUT.Revise;
using AUT.Test.Fake;
using FluentAssertions;
using Xunit;

namespace AUT.Test.Tests
{
    public class LogAnalyzerShould
    {
        [Fact]
        public void Return_True_Provided_That_File_Path_Has_Five_Parts_And_Extension_Manager_Is_Valid_Is_True()
        {
            ExtensionManagerFactory.SetExtensionManager(new FakeExtensionManager());
            
            var logAnalyzer = new LogAnalyzer();

            // ReSharper disable once StringLiteralTypo
            logAnalyzer.IsValidLogFileName("abcdef.txt").Should().BeTrue();
        }
    }
}
