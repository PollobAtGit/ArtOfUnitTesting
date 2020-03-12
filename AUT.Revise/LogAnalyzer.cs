using System;
using System.IO;
using System.Linq;

namespace AUT.Revise
{
    public class LogAnalyzer
    {
        private IExtensionManager _extensionManager;

        public LogAnalyzer() => _extensionManager = ExtensionManagerFactory.Create();

        public bool IsValidLogFileName(string filePath)
        {
            if (_extensionManager == null)
                _extensionManager = ExtensionManagerFactory.Create();

            return _extensionManager.IsValid(filePath) && Path.GetFileNameWithoutExtension(filePath).Length > 5;
        }
    }

    public static class ExtensionManagerFactory
    {
        private static IExtensionManager _extensionManager;

        public static IExtensionManager Create() => _extensionManager ?? throw new InvalidOperationException($"Extension manager is not set. Invoke {nameof(SetExtensionManager)} to set extension manager");

        public static void SetExtensionManager(IExtensionManager extensionManager) => _extensionManager = extensionManager;
    }

    public interface IExtensionManager
    {
        bool IsValid(string filePath);
    }

    public class ExtensionManager : IExtensionManager
    {
        public bool IsValid(string filePath) => File.ReadLines(filePath).Any();
    }
}
