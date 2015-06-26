namespace Мinesweeper
{
    using System.Collections.Generic;
    using System.Text;

    public class Mines
    {
        public static string GetRating(IList<Points> points)
        {
            StringBuilder rating = new StringBuilder();

            rating.AppendLine("\nPoints:");

            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    rating.AppendLine(string.Format("{0}. {1} --> {2} boxes", i + 1, points[i].Name, points[i].Point));
                }

                rating.AppendLine();
            }
            else
            {
                rating.AppendLine("Empty rating!\n");
            }

            return rating.ToString();
        }
    }
}
