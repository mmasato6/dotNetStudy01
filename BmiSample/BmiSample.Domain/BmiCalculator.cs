using System;

namespace BmiSample.Domain
{
    public class BmiCalculator
    {
        public double Calculate(int heightCm,int weightKg)
        {
            if (heightCm <= 0) throw new ArgumentOutOfRangeException(nameof(heightCm),heightCm,"1以上を入力してください。");
            //int同士の除算は戻り値がintになって小数点以下が切り捨てられてしまうのでdoubleにしてから計算する
            double dblHeightCm = (double)heightCm;
            const double CentimeterPerMeter = 100.0;
            double heightM = dblHeightCm / CentimeterPerMeter;

            if (weightKg <= 0) throw new ArgumentOutOfRangeException(nameof(weightKg), weightKg, "1以上を入力してください。");

            return (weightKg / (Math.Pow(heightM,2)));
        }

    }
}
