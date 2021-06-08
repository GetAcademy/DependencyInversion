namespace DependencyInversion
{
    interface IFileReader
    {
        string[] Read(string filename);
    }
}
