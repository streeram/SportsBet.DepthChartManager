namespace SportsBet.DepthChartManager.Helpers
{
    public static class LinkedListExt
    {
        public static int IndexOf<T>(this LinkedList<T> list, T item)
        {
            if (item == null)
            {
                return -1;
            }

            var count = 0;
            for (var node = list.First; node != null; node = node.Next, count++)
            {
                if (item.Equals(node.Value))
                    return count;
            }
            return -1;
        }

        public static LinkedListNode<T>? GetNodeAt<T>(this LinkedList<T> _list, int position)
        {
            if(_list == null) {
                return null;
            }

            var mark = _list?.First;
            int i = 0;
            while (i < position)
            {
                mark = mark?.Next;
                i++;
            }
            return mark;
        }

        public static LinkedList<T>? GetListBelowNode<T>(this LinkedList<T> _list, LinkedListNode<T>? node)
        {
            if (node == null)
            {
                return null;
            }

            var newList = new LinkedList<T>();
            var index = _list.IndexOf(node.Value);
            index++;
            while (index < _list.Count)
            {
                var nextNode = _list.GetNodeAt<T>(index);
                if (nextNode == null)
                {
                    break;
                }

                newList.AddLast(nextNode.Value);
                index++;
            }

            return newList;
        }

        public static IEnumerable<LinkedListNode<T>> Nodes<T>(this LinkedList<T> list)
        {
            for (var node = list.First; node != null; node = node.Next)
            {
                yield return node;
            }
        }
    }
}