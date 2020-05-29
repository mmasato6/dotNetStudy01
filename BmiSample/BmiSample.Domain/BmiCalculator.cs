using System;

namespace BmiSample.Domain
{
    public class BmiCalculator
    {
        public double Calculate(int heightCm,int weightKg)
        {
            if (heightCm <= 0) throw new ArgumentOutOfRangeException(nameof(heightCm),heightCm,"1以上を入力してください。");
            const int CentimeterPerMeter = 100;
            double heightM = heightCm / CentimeterPerMeter;

            if (weightKg <= 0) throw new ArgumentOutOfRangeException(nameof(weightKg), weightKg, "1以上を入力してください。");

            return (weightKg / (Math.Pow(heightM,2)));
        }

    }
}
