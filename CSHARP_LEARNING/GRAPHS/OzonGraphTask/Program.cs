var first = new TreeNode
{
    val = 1,
    left = new TreeNode
    {
        val = 2,
        left = new TreeNode
        {
            val = 4,
            left = null,
            right = null
        },
        right = new TreeNode
        {
            val = 5,
            left = null,
            right = null
        }
    },
    right = new TreeNode
    {
        val = 3,
        left = null,
        right = null
    }
};

var second = new TreeNode
{
    val = 1,
    left = new TreeNode
    {
        val = 2,
        left = new TreeNode
        {
            val = 4,
            left = null,
            right = null
        },
        right = new TreeNode
        {
            val = 5,
            left = null,
            right = null
        }
    },
    right = new TreeNode
    {
        val = 3,
        left = null,
        right = null
    }
};

var result = GraphEquals(first, second);
Console.WriteLine(result);

bool GraphEquals(TreeNode first, TreeNode second)
{
    if(first == null && second != null || first != null && second == null)
    {
        return false;
    }

    if (first == null && second == null)
    {
        return true;
    }

    return (first.val == second.val) && GraphEquals(first.right, second.right) && GraphEquals(first.left, second.left);
}

class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
}