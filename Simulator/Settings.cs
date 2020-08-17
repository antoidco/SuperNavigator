namespace SuperNavigator.Simulator
{
    public class Settings
    {
        public AlgorithmPrefer AlgorithmPrefer { get; set; }
        public PredictionType PredictionType { get; set; }
        public CalcType CalcType { get; set; }
    }
    public enum AlgorithmPrefer
    {
        PreferBase,
        PreferRVO
    }
    public enum PredictionType
    {
        Full,
        Simple,
        Linear
    }
    public enum CalcType
    {
        Default,
        ForceRVO,
        NoRVO
    }
}
