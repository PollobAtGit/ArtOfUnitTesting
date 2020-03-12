using AUT.Revise;

namespace AUT.Test.Fake
{
    public class FakeExtensionManager : IExtensionManager
    {
        public bool IsValid(string filePath) => true;
    }
}