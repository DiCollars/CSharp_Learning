//Given the root of a binary tree, the level of its root is 1, the level of its children is 2, and so on.
//Return the smallest level x such that the sum of all the values of nodes at level x is maximal.

//Input: root = [1, 7, 0, 7, -8, null, null]
//Output: 2
//Explanation:
//Level 1 sum = 1.
//Level 2 sum = 7 + 0 = 7.
//Level 3 sum = 7 + -8 = -1.
//So we return the level with the maximum sum which is level 2.

using System.Reflection.Emit;

var root = new TreeNode
{
    val = 1,
    left = new TreeNode
    {
        val = 7,
        left = new TreeNode
        {
            val = 7,
            left = null,
            right = null
        },
        right = new TreeNode
        {
            val = -8,
            left = null,
            right = null
        }
    },
    right = new TreeNode
    {
        val = 0,
        left = null,
        right = null
    }
};

Console.WriteLine(MaxLevelSum(root));

int MaxLevelSum(TreeNode root)
{
    int level = 1;

    List<(int sum, int level)> list = new List<(int sum, int level)>();
    List<TreeNode> tempNodes = new List<TreeNode>() { root };

    while (tempNodes.Any())
    {
        var res = GetSum(tempNodes);

        list.Add((res.sum, level));
        tempNodes = res.nodes;

        level++;
    }

    return list.MaxBy(x => x.sum).level;
}

(List<TreeNode> nodes, int sum) GetSum(List<TreeNode> nodes)
{
    List<TreeNode> returnNodes = new List<TreeNode>();
    int sum = nodes.Select(_ => _.val).Sum();
    foreach (var node in nodes)
    {
        if (node?.right != null)
        {
            returnNodes.Add(node.right);
        }
        if (node?.left != null)
        {
            returnNodes.Add(node.left);
        }
    }

    return (returnNodes, sum);
}

class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}