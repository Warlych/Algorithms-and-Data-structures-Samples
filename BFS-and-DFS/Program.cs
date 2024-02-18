using BFS_and_DFS;

Graph<char> graph = new Graph<char>();
graph.Add('A', 'B');
graph.Add('A', 'C');
graph.Add('B', 'D');
graph.Add('B', 'E');
graph.Add('C', 'F');
graph.Add('C', 'A');

DepthFirstSearch('C', graph, null);
DepthFirstSearchByStack('A', graph);
BreadthFirstSearch('C', graph);

void DepthFirstSearch<T>(T vertex, Graph<T> graph, HashSet<T> visited)
{
    if (visited == null)
        visited = new HashSet<T>();
    
    visited.Add(vertex);
    
    if (graph.AdjacencyTable.ContainsKey(vertex))
    {
        foreach (T neighbor in graph.AdjacencyTable[vertex])
        {
            if (!visited.Contains(neighbor))
                DepthFirstSearch(neighbor, graph, visited);
        }
    }
}

void DepthFirstSearchByStack<T>(T vertex, Graph<T> graph)
{
    var visited = new HashSet<T>();
    visited.Add(vertex);

    var stack = new Stack<T>();
    if (graph.AdjacencyTable.ContainsKey(vertex))
    {
        foreach (var neighbor in graph.AdjacencyTable[vertex])
            stack.Push(neighbor);
    }

    while (stack.Count > 0)
    {
        var v = stack.Pop();
        
        if (!visited.Contains(v))
        {
            visited.Add(v);
            
            if (graph.AdjacencyTable.ContainsKey(v))
            {
                foreach (var neighbor in graph.AdjacencyTable[v])
                    stack.Push(neighbor);
            }
        }
    }
}

void BreadthFirstSearch<T>(T vertex, Graph<T> graph)
{
    var visited = new HashSet<T>();
    visited.Add(vertex);

    var queue = new Queue<T>();
    queue.Enqueue(vertex);

    while (queue.Count > 0)
    {
        var v = queue.Dequeue();
        
        if (graph.AdjacencyTable.ContainsKey(v))
        {
            foreach (var neighbor in graph.AdjacencyTable[v])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}