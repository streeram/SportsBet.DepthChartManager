using SportsBet.DepthChartManager.Models;
using SportsBet.DepthChartManager.Helpers;
namespace SportsBet.DepthChartManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            NFL();
            MLB();
        }

        private static void NFL()
        {
            var chartManager = new NFLDepthChartManager();
            
            var player1 = new Player
            {
                Id = 1,
                Name = "Sriram"
            };

            var player2 = new Player
            {
                Id = 2,
                Name = "Divya"
            };

            chartManager?.AddPlayerToChart(player1, NFLPositionEnum.QB.GetDescription(), 0);
            chartManager?.AddPlayerToChart(player2, NFLPositionEnum.QB.GetDescription(), 0);

            var player3 = new Player
            {
                Id = 3,
                Name = "Samanvi"
            };

            var player4 = new Player
            {
                Id = 4,
                Name = "Aditi"
            };

            // FIND THE NODE IN 2ND POSITION AND ADD AFTER THAT
            chartManager?.AddPlayerToChart(player3, NFLPositionEnum.QB.GetDescription(), 2);
            Console.WriteLine("");
            Console.WriteLine("Printing the entire Depth Chart for NFL Game!");
            Console.WriteLine("");

            chartManager?.AddPlayerToChart(player1, NFLPositionEnum.WR.GetDescription(), 0);
            chartManager?.AddPlayerToChart(player2, NFLPositionEnum.WR.GetDescription(), 1);
            chartManager?.AddPlayerToChart(player3, NFLPositionEnum.WR.GetDescription(), 2);
            chartManager?.AddPlayerToChart(player4, NFLPositionEnum.WR.GetDescription(), 3);
            chartManager?.PrintFullDepthChart();

            var players = chartManager?.GetPlayersUnderPlayer(player3, "WR");

            chartManager?.RemovePlayerFromChart(player2, "WR");
            chartManager?.PrintFullDepthChart();
        }

        private static void MLB()
        {
            var chartManager = new MLBDepthChartManager();
            
            var player1 = new Player
            {
                Id = 5,
                Name = "Rishika"
            };

            var player2 = new Player
            {
                Id = 6,
                Name = "Ramkumar"
            };

            chartManager?.AddPlayerToChart(player1, MLBPositionEnum.SP.GetDescription(), 0);
            chartManager?.AddPlayerToChart(player2, MLBPositionEnum.SP.GetDescription(), 0);

            var player3 = new Player
            {
                Id = 7,
                Name = "Raji"
            };

            var player4 = new Player
            {
                Id = 8,
                Name = "Rengarajan"
            };

            // FIND THE NODE IN 2ND POSITION AND ADD AFTER THAT
            chartManager?.AddPlayerToChart(player3, MLBPositionEnum.SP.GetDescription(), 2);
            Console.WriteLine("");
            Console.WriteLine("Printing the entire Depth Chart for MLB Game!");
            Console.WriteLine("");

            chartManager?.AddPlayerToChart(player1, MLBPositionEnum.CF.GetDescription(), 0);
            chartManager?.AddPlayerToChart(player2, MLBPositionEnum.CF.GetDescription(), 1);
            chartManager?.AddPlayerToChart(player3, MLBPositionEnum.CF.GetDescription(), 2);
            chartManager?.AddPlayerToChart(player4, MLBPositionEnum.CF.GetDescription(), 3);
            chartManager?.PrintFullDepthChart();

            var players = chartManager?.GetPlayersUnderPlayer(player3, "CF");

            chartManager?.RemovePlayerFromChart(player2, "CF");
            chartManager?.PrintFullDepthChart();
        }
    }
}