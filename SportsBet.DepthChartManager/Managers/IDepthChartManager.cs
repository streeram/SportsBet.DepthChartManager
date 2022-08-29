using SportsBet.DepthChartManager.Models;

namespace SportsBet.DepthChartManager.Interfaces
{
    public interface IDepthChartManager
    {
        bool AddPlayerToChart(Player player, string postion, int depth = 0);
        void RemovePlayerFromChart(Player player, string position);
        LinkedList<Player>? GetPlayersUnderPlayer(Player player, string position);
        void PrintFullDepthChart();
    }
}