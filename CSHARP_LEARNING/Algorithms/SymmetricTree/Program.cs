var head = new TreeNode()
{
    val = 1,
    left = new TreeNode()
    {
        val = 2,
        left = new TreeNode()
        {
            val = 3,
        },
        right = new TreeNode()
        {
            val = 4
        }
    },
    right = new TreeNode()
    {
        val = 2,
        left = new TreeNode()
        {
            val = 3,
        },
        right = new TreeNode()
        {
            val = 4
        }
    }
};

var head2 = new TreeNode()
{
    val = 1,
    left = new TreeNode()
    {
        val = 2,
        left = new TreeNode()
        {
            val = 3,
        }
    },
    right = new TreeNode()
    {
        val = 2,
        right = new TreeNode()
        {
            val = 3,
        }
    }
};

var result = IsSymmetric(head2);
Console.ReadLine();

bool IsSymmetric(TreeNode root)
{
    if (root == null) return false;

    return Checker(root?.left, root?.right);
}

bool Checker(TreeNode left, TreeNode right)
{
    if ((left == null && right != null) && (left != null && right == null))
    {
        return true;
    }

    if (left == null && right == null)
    {
        return true;
    }

    if (left?.val != right?.val)
    {
        return false;
    }

    return true && Checker(left?.left, right?.right) && Checker(left?.right, right?.left);
}

public class TreeNode
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
