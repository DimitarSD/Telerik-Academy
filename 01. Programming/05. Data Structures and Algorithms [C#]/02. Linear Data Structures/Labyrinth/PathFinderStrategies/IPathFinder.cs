namespace Labyrinth.PathFinderStrategies
{
    public interface IPathFinder
    {
        string[,] FindAllPaths(string[,] matrix);
    }
}
