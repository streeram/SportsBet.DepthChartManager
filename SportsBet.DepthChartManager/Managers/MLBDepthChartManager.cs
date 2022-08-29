using SportsBet.DepthChartManager.Helpers;
using SportsBet.DepthChartManager.Models;
using SportsBet.DepthChartManager.Interfaces;

namespace SportsBet.DepthChartManager
{
    public class MLBDepthChartManager : ChartManagerBase
    {
        public MLBDepthChartManager()
        {
            Positions = new Dictionary<string, LinkedList<Player>?>();
            Positions.Add(MLBPositionEnum.SP.GetDescription(), new LinkedList<Player>());
            Positions.Add(MLBPositionEnum.RP.GetDescription(), new LinkedList<Player>());
            Positions.Add(MLBPositionEnum.C.GetDescription(), new LinkedList<Player>());
            Positions.Add(MLBPositionEnum.OneB.GetDescription(), new LinkedList<Player>());
            Positions.Add(MLBPositionEnum.TwoB.GetDescription(), new LinkedList<Player>());
            Positions.Add(MLBPositionEnum.ThreeB.GetDescription(), new LinkedList<Player>());
            Positions.Add(MLBPositionEnum.SS.GetDescription(), new LinkedList<Player>());
            Positions.Add(MLBPositionEnum.LF.GetDescription(), new LinkedList<Player>());
            Positions.Add(MLBPositionEnum.RF.GetDescription(), new LinkedList<Player>());
            Positions.Add(MLBPositionEnum.CF.GetDescription(), new LinkedList<Player>());
            Positions.Add(MLBPositionEnum.DH.GetDescription(), new LinkedList<Player>());
        }
        public override bool AddPlayerToChart(Player player, string position, int depth = 0)
        {
            if (player == null || string.IsNullOrWhiteSpace(position))
            {
                return false;
            }

            if (Enum.TryParse(position, out MLBPositionEnum positionEnum))
            {
                return AddPlayer(player, positionEnum.GetDescription(), depth);
            }

            return false;
        }
        
        public override void RemovePlayerFromChart(Player player, string position)
        {
            if (Enum.TryParse(position, out MLBPositionEnum positionEnum))
            {
                RemovePlayer(player, positionEnum.GetDescription());
            }
            return;
        }
        
        public override LinkedList<Player>? GetPlayersUnderPlayer(Player player, string position)
        {
            if (Enum.TryParse(position, out MLBPositionEnum positionEnum))
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

            IndicateNode(Positions[MLBPositionEnum.SP.GetDescription()]?.First, $"{MLBPositionEnum.SP.GetDescription()} position players");
            IndicateNode(Positions[MLBPositionEnum.RP.GetDescription()]?.First, $"{MLBPositionEnum.RP.GetDescription()} position players");
            IndicateNode(Positions[MLBPositionEnum.C.GetDescription()]?.First, $"{MLBPositionEnum.C.GetDescription()} position players");
            IndicateNode(Positions[MLBPositionEnum.OneB.GetDescription()]?.First, $"{MLBPositionEnum.OneB.GetDescription()} position players");
            IndicateNode(Positions[MLBPositionEnum.TwoB.GetDescription()]?.First, $"{MLBPositionEnum.TwoB.GetDescription()} position players");
            IndicateNode(Positions[MLBPositionEnum.ThreeB.GetDescription()]?.First, $"{MLBPositionEnum.ThreeB.GetDescription()} position players");
            IndicateNode(Positions[MLBPositionEnum.SS.GetDescription()]?.First, $"{MLBPositionEnum.SS.GetDescription()} position players");
            IndicateNode(Positions[MLBPositionEnum.LF.GetDescription()]?.First, $"{MLBPositionEnum.LF.GetDescription()} position players");
            IndicateNode(Positions[MLBPositionEnum.RF.GetDescription()]?.First, $"{MLBPositionEnum.RF.GetDescription()} position players");
            IndicateNode(Positions[MLBPositionEnum.CF.GetDescription()]?.First, $"{MLBPositionEnum.CF.GetDescription()} position players");
            IndicateNode(Positions[MLBPositionEnum.DH.GetDescription()]?.First, $"{MLBPositionEnum.DH.GetDescription()} position players");
        }
    }
}