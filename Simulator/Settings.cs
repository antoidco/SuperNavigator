namespace SuperNavigator.Simulator
{
    public class Settings
    {
        public AlgorithmPrefer AlgorithmPrefer { get; set; }
        public PredictionType PredictionType { get; set; }
        public CalcType CalcType { get; set; }
        public bool OngoingWhenManeuver { get; set; } = true;
        // todo: add time_step as setting
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
