using System.Text;
using SportsBet.DepthChartManager.Helpers;
using SportsBet.DepthChartManager.Models;

namespace SportsBet.DepthChartManager.Interfaces
{
    public abstract class ChartManagerBase : IDepthChartManager
    {
        protected Dictionary<string, LinkedList<Player>?>? Positions { get; set; }
        public abstract bool AddPlayerToChart(Player player, string postion, int depth = 0);
        public abstract void RemovePlayerFromChart(Player player, string position);
        public abstract LinkedList<Player>? GetPlayersUnderPlayer(Player player, string position);
        public abstract void PrintFullDepthChart();
        protected virtual bool AddPlayer(Player player, string position, int depth)
        {
            if (Positions == null)
            {
                throw new ArgumentNullException("Positions are undefined");
            }

            if (depth == 0)
            {
                Positions[position]?.AddFirst(player);
                return true;
            }

            if (depth >= Positions[position]?.Count)
            {
                Positions[position]?.AddLast(player);
                return true;
            }

            var node = Positions[position]?.GetNodeAt(depth);
            if (node == null)
            {
                return false;
            }

            Positions[position]?.AddAfter(node, player);
            return true;
        }
        protected virtual void RemovePlayer(Player player, string position)
        {
            if (Positions == null)
            {
                throw new ArgumentNullException("Positions are undefined");
            }

            var positions = Positions[position];

            if (positions == null)
            {
                this.IndicateNode(null, $"No Players playing in {position}");
                return;
            }

            var playerNode = positions?.Nodes().FirstOrDefault(a => a.Value?.Id == player.Id);
            if (playerNode == null)
            {
                this.IndicateNode(null, $"Player {player.Name} - id {player.Id} was not found in {position}");
                return;
            }

            positions?.Remove(playerNode);
            this.IndicateNode(null, $"Player {player.Name} - id {player.Id} removed from {position}");
            return;
        }
        protected virtual LinkedList<Player>? GetPlayersUnder(Player player, string position)
        {
            if (Positions == null)
            {
                throw new ArgumentNullException("Positions are undefined");
            }
            
            var positions = Positions[position];

            if (positions == null)
            {
                this.IndicateNode(null, $"Players below {player.Name} - id {player.Id} playing in {position}");
                return null;
            }

            var playerNode = positions?.Nodes().FirstOrDefault(a => a.Value?.Id == player.Id);

            var playersBelow = (playerNode != null) ? positions?.GetListBelowNode(playerNode) : null;

            this.IndicateNode(playersBelow?.First, $"Players below {player.Name} - id {player.Id} playing in {position}");
            return playersBelow;
        }
        public void IndicateNode(LinkedListNode<Player>? node, string printText)
        {
            Console.WriteLine(printText);
            if (node == null)
            {
                Console.WriteLine();
                return;
            }

            if (node.List == null)
            {
                Console.WriteLine("Node '{0}' is not in the list.\n",
                    node.Value?.Id);
                return;
            }

            var result = new StringBuilder("(" + node.Value?.Id + ")");
            var nodeP = node?.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value?.Id + " ");
                nodeP = nodeP?.Previous;
            }

            node = node?.Next;
            while (node != null)
            {
                result.Append(" " + node.Value?.Id);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}
