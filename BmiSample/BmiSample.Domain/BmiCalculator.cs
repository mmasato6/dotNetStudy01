using System;

namespace BmiSample.Domain
{
    public class BmiCalculator
    {
        public double Calculate(int heightCm,int weightKg)
        {
            const int CentimeterPerMeter = 100;
            double heightM = heightCm / CentimeterPerMeter;
            return (weightKg / (Math.Pow(heightM,2)));
        }

    }
}
