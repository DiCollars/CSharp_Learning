using static System.Net.Mime.MediaTypeNames;

var head = new ListNode
{
    val = 1,
    next = new ListNode
    {
        val = 2,
        next = new ListNode
        {
            val = 3,
            next = new ListNode
            {
                val = 4,
                next = new ListNode
                {
                    val = 5,
                    next = null
                }
            }
        }
    }
};

var result = RotateRight(head, 21);

var item = result;
while(item != null)
{
    Console.Write($"{item.val} - ");
    item = item.next;
}
Console.Read();

ListNode RotateRight(ListNode head, int k)
{
    var nElements = GetListN(head);
    var realRotate = k - ((k / nElements) * nElements);
    if (head == null || head.next == null)
    {
        return head;
    }

    int count = realRotate;

    var newNode = head;
    while (count != 0)
    {
        newNode = GetTale(newNode);

        count--;
    }

    return newNode;
}

int GetListN(ListNode head)
{
    var n = 0;
    var tale = head;
    while (tale.next != null)
    {
        n++;
        tale = tale.next;
    }

    return n;
}

ListNode GetTale(ListNode head)
{
    var tale = head.next;
    var before = head;
    while (tale != null)
    {
        before = tale;
        tale = tale.next;
    }

    before.next = null;
    tale.next = head;

    return tale;
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
