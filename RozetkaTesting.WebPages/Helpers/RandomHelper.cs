using System;

namespace RozetkaTesting.WebPages.Helpers
{
    class RandomHelper
    {
        /// <summary>
        /// Gets random number from the range of min and max values.
        /// </summary>
        /// <param name="min">Min value of the random number.</param>
        /// <param name="max">Max value of the random number.</param>
        /// <returns></returns>
        public static int GetRandomValue(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}
