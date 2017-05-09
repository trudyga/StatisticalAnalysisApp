namespace StatisticalAnalysisApplication.StatLib.Graph
{
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
