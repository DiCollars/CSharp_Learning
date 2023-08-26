var node4 = new ListNode(4);
var node2 = new ListNode(2);
var node1 = new ListNode(1);
var node3 = new ListNode(3);
var node5 = new ListNode(5);
var node6 = new ListNode(6);
var node1again = new ListNode(1);

node4.next = node2;
node2.next = node1;
node1.next = node3;
node3.next = node5;
node5.next = node6;
node6.next = node1again;

var result = SortList(node4);

var item = result;
while (item != null)
{
    Console.Write($"{item.val} - ");
    item = item.next;
}

ListNode SortList(ListNode head)
{
    if (head == null)
    {
        return null;
    }

    if (head.next == null)
    {
        return head;
    }

    var pivot = head;
    var less = GetLess(head, pivot);
    var greatest = GetGreatest(head, pivot);

    var sortedLess = SortList(less);
    var sortedPivot = new ListNode(pivot.val);
    var sortedGreatest = SortList(greatest);

    return Gluer(sortedLess, sortedPivot, sortedGreatest);
}

ListNode Gluer(ListNode? node1, ListNode? node2, ListNode? node3)
{
    if (node1 == null && node2 != null && node3 != null)
    {
        GetTale(node2).next = node3;
        return node2;
    }

    if (node1 != null && node2 == null && node3 != null)
    {
        GetTale(node1).next = node3;
        return node1;
    }

    if (node1 != null && node2 != null && node3 == null)
    {
        GetTale(node1).next = node2;
        return node1;
    }

    if (node1 != null && node2 != null && node3 != null)
    {
        GetTale(node1).next = node2;
        GetTale(node2).next = node3;

        return node1;
    }

    return null;
}

ListNode GetLess(ListNode node, ListNode pivot)
{
    ListNode lessNodes = null;

    var item = node;
    while (item != null)
    {
        if (item.val <= pivot.val && item != pivot)
        {
            if (lessNodes == null)
            {
                lessNodes = new ListNode(item.val);
            }
            else
            {
                GetTale(lessNodes).next = new ListNode(item.val);
            }
        }

        item = item.next;
    }

    return lessNodes;
}

ListNode GetGreatest(ListNode node, ListNode pivot)
{
    ListNode gretestNodes = null;

    var item = node;
    while (item != null)
    {
        if (item.val > pivot.val && item != pivot)
        {
            if (gretestNodes == null)
            {
                gretestNodes = new ListNode(item.val);
            }
            else
            {
                GetTale(gretestNodes).next = new ListNode(item.val);
            }
        }

        item = item.next;
    }

    return gretestNodes;
}

ListNode GetTale(ListNode listNode)
{
    var last = listNode;
    var item = listNode;
    while (item != null)
    {
        last = item;
        item = item.next;
    }

    return last;
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}