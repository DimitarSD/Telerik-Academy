namespace PrintStatistics
{
    using System;
    using System.Text;

    public class Statistic
    {
        public string PrintStatistics(double[] dataColection, int dataColectionLength)
        {
            StringBuilder resultFromStatistic = new StringBuilder();

            double maxValue = Double.MinValue;

            for (int i = 0; i < dataColectionLength; i++)
            {
                if (dataColection[i] > maxValue)
                {
                    maxValue = dataColection[i];
                }
            }
            
            string maxValueAsString = string.Format("The maximum value from the given data is {0}", maxValue);
            resultFromStatistic.AppendLine(maxValueAsString);

            double minValue = Double.MaxValue;

            for (int i = 0; i < dataColectionLength; i++)
            {
                if (dataColection[i] < minValue)
                {
                    minValue = dataColection[i];
                }
            }

            string minValueAsString = string.Format("The minimum value from the given data is {0}", minValue);
            resultFromStatistic.AppendLine(minValueAsString);

            double sum = 0;

            for (int i = 0; i < dataColectionLength; i++)
            {
                sum += dataColection[i];
            }

            double averageValue = sum / dataColectionLength;

            string averageValueAsString = string.Format("The average value from the given data is {0}", averageValue);
            resultFromStatistic.AppendLine(averageValueAsString);

            return resultFromStatistic.ToString();
        }
    }
}
