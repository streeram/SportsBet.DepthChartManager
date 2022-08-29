using System.ComponentModel;

namespace SportsBet.DepthChartManager.Models
{
    public enum MLBPositionEnum
    {
        [Description("SP")]
        SP, 
        [Description("RP")]
        RP,
        [Description("C")]
        C,
        [Description("1B")]
        OneB,
        [Description("2B")]
        TwoB,
        [Description("3B")]
        ThreeB,
        [Description("SS")]
        SS,
        [Description("LF")]
        LF,
        [Description("RF")]
        RF,
        [Description("CF")]
        CF,
        [Description("DH")]
        DH
    }
}