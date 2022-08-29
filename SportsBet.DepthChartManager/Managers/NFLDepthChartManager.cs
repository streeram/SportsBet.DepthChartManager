using System.Text;
using SportsBet.DepthChartManager.Helpers;
using SportsBet.DepthChartManager.Models;
using SportsBet.DepthChartManager.Interfaces;

namespace SportsBet.DepthChartManager
{
    public class NFLDepthChartManager : ChartManagerBase
    {
        public NFLDepthChartManager()
        {
            Positions = new Dictionary<string, LinkedList<Player>?>();
            Positions.Add(NFLPositionEnum.QB.GetDescription(), new LinkedList<Player>());
            Positions.Add(NFLPositionEnum.WR.GetDescription(), new LinkedList<Player>());
            Positions.Add(NFLPositionEnum.RB.GetDescription(), new LinkedList<Player>());
            Positions.Add(NFLPositionEnum.TE.GetDescription(), new LinkedList<Player>());
            Positions.Add(NFLPositionEnum.K.GetDescription(), new LinkedList<Player>());
            Positions.Add(NFLPositionEnum.P.GetDescription(), new LinkedList<Player>());
            Positions.Add(NFLPositionEnum.KR.GetDescription(), new LinkedList<Player>());
            Positions.Add(NFLPositionEnum.PR.GetDescription(), new LinkedList<Player>());
        }
        public override bool AddPlayerToChart(Player player, string position, int depth = 0)
        {
            if (player == null || string.IsNullOrWhiteSpace(position))
            {
                return false;
            }

            if (Enum.TryParse(position, out NFLPositionEnum positionEnum))
            {
                return AddPlayer(player, positionEnum.GetDescription(), depth);
            }

            return false;
        }
        
        public override void RemovePlayerFromChart(Player player, string position)
        {
            if (Enum.TryParse(position, out NFLPositionEnum positionEnum))
            {
                RemovePlayer(player, positionEnum.GetDescription());
            }
            return;
        }
        
        public override LinkedList<Player>? GetPlayersUnderPlayer(Player player, string position)
        {
            if (Enum.TryParse(position, out NFLPositionEnum positionEnum))
            {
                return GetPlayersUnder(player, positionEnum.GetDescription());
            }
            return null;
        }
        
        public override void PrintFullDepthChart()
        {
            if (Positions == null)
            {
                throw new ArgumentNullException("Positions are undefined");
            }
            
            IndicateNode(Positions[NFLPositionEnum.QB.GetDescription()]?.First, $"{NFLPositionEnum.QB.GetDescription()} position players");
            IndicateNode(Positions[NFLPositionEnum.WR.GetDescription()]?.First, $"{NFLPositionEnum.WR.GetDescription()} position players");
            IndicateNode(Positions[NFLPositionEnum.RB.GetDescription()]?.First, $"{NFLPositionEnum.RB.GetDescription()} position players");
            IndicateNode(Positions[NFLPositionEnum.TE.GetDescription()]?.First, $"{NFLPositionEnum.TE.GetDescription()} position players");
            IndicateNode(Positions[NFLPositionEnum.K.GetDescription()]?.First, $"{NFLPositionEnum.K.GetDescription()} position players");
            IndicateNode(Positions[NFLPositionEnum.P.GetDescription()]?.First, $"{NFLPositionEnum.P.GetDescription()} position players");
            IndicateNode(Positions[NFLPositionEnum.KR.GetDescription()]?.First, $"{NFLPositionEnum.KR.GetDescription()} position players");
            IndicateNode(Positions[NFLPositionEnum.PR.GetDescription()]?.First, $"{NFLPositionEnum.PR.GetDescription()} position players");
        }
    }
}