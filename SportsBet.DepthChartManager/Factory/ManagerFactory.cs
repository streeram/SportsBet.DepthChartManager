using SportsBet.DepthChartManager.Interfaces;
using SportsBet.DepthChartManager.Models;

namespace SportsBet.DepthChartManager.Factory
{
    public interface IDepthChartManagerFactory
    {
        IDepthChartManager CreateChartManager(string type);
    }

    public class DepthChartManagerFactory : IDepthChartManagerFactory
    {
        public IDepthChartManager CreateChartManager(string type)
        {
            if (!Enum.TryParse(type, true, out SportEnum sportType))
            {
                throw new NotImplementedException(nameof(type));
            }
            return sportType switch
            {
                SportEnum.NFL => new NFLDepthChartManager(),
                SportEnum.MLB => new MLBDepthChartManager(),
                _ => throw new ArgumentOutOfRangeException(nameof(sportType), $"Not expected sports value: {type}"),
            };
        }
    }
}