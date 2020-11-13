namespace Explore.AutoFixture.Repository
{
    internal interface IRepository
    {
        int Index { get; set; }

        string Identifier { get; set; }
    }
}