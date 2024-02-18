namespace BFS_and_DFS;

public class Graph<T>
{
    public Dictionary<T, List<T>> AdjacencyTable { get; set; }
    
    public Graph(Dictionary<T, List<T>> adjacencyTable) =>
        AdjacencyTable = adjacencyTable;
    
    public Graph() : this (new Dictionary<T, List<T>>()) { }

    public void Add(T from, T to)
    {
        if(!AdjacencyTable.ContainsKey(from))
            AdjacencyTable.Add(from, new List<T>());
        
        AdjacencyTable[from].Add(to);
    }
}