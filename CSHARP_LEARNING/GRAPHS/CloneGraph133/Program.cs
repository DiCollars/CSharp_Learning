var graph1 = new Node()
{
    val = 1,
    neighbors = null
};

var graph2 = new Node()
{
    val = 2,
    neighbors = null
};

var graph3 = new Node()
{
    val = 3,
    neighbors = null
};

var graph4 = new Node()
{
    val = 4,
    neighbors = null
};

graph1.neighbors = new List<Node>() { graph2, graph4 };
graph2.neighbors = new List<Node>() { graph1, graph3 };
graph3.neighbors = new List<Node>() { graph2, graph4 };
graph4.neighbors = new List<Node>() { graph1, graph3 };

var result = CloneGraph(graph1);

Console.ReadKey();

Node CloneGraph(Node node)
{
    var dict = new Dictionary<int, List<int>>();

    var tempNodes = new Queue<Node>();
    tempNodes.Enqueue(node);

    while (tempNodes.Any())
    {
        var firstNode = tempNodes.Dequeue();

        foreach (var item in firstNode.neighbors)
        {
            if (dict.ContainsKey(item.val) == false)
            {
                tempNodes.Enqueue(item);
            }
        }

        if (dict.ContainsKey(firstNode.val) == false)
        {
            dict.Add(firstNode.val, firstNode.neighbors.Select(_ => _.val).ToList());
        }
    }

    var copyCat = new List<Node>();
    foreach (var item in dict)
    {
        copyCat.Add(new Node { val = item.Key });
    }

    foreach (var item in dict)
    {
        var el = copyCat.First(_ => _.val == item.Key);
        el.neighbors = copyCat.Where(_ => item.Value.Contains(_.val)).ToList();
    }

    var number = node.val;

    return copyCat.First(_ => _.val == number);
}

// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}
