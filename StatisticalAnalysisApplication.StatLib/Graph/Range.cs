/// <summary>
/// File that hold Range Entity
/// </summary>
namespace StatisticalAnalysisApplication.StatLib.Graph
{
    /// <summary>
    /// Helper Range data stucture
    /// Mainly used for gistogram
    /// </summary>
    public struct Range
    {
        public Range(double lower, double upper) {
            this.Lower = lower;
            this.Upper = upper;
        }

        public double Lower;
        public double Upper;
    }
}
