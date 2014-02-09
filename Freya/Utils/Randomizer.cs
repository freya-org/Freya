/***********************************************************************************************
 COPYRIGHT 2014 Drahník Lukáš
 --------------------------

 This file is part of Freya.
 (Project Website: https://github.com/freya-org)

 Freya is a free software. You can redistribute it and/or modify it under the terms of
 the GNU General Public License as published by the Free Software Foundation, either version 3
 of the License, or (at your option) any later version.

 Freya is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 (See the GNU General Public License for more details: http://www.gnu.org/licenses/)

 ***********************************************************************************************/


using System;

namespace Freya.Utils
{
    public static class Randomizer
    {
        private static readonly Random random = new Random();

        public static double GetRandom()
        {
            return random.NextDouble();
        }

        public static double GetRandom(double min, double max)
        {
            if (min > max)
            {
                return GetRandom(max, min);
            }
            return (min + (max - min) * random.NextDouble());
        }

        public static int[] GetRandomOrder(int size)
        {
            int[] randomOrder = new int[size];

            // Initialize the array serially
            for (int i = 0; i < size; i++)
            {
                randomOrder[i] = i;
            }

            // Swap ith element with random elements for all position i.
            for (int i = 0; i < size; i++)
            {
                int randomPosition = random.Next(size);
                int temp = randomOrder[i];
                randomOrder[i] = randomOrder[randomPosition];
                randomOrder[randomPosition] = temp;
            }
            return randomOrder;
        }

        public static double[] Normalize(double[] vector)
        {
            return Normalize(vector, 1d);
        }

        public static double[] Normalize(double[] vector, double magnitude)
        {
            // Calculate the root of sum of squares
            double factor = 0d;
            for (int i = 0; i < vector.Length; i++)
            {
                factor += vector[i] * vector[i];
            }

            // Divide each value with the root of sum of squares
            double[] normalizedVector = new double[vector.Length];
            if (factor != 0)
            {
                factor = Math.Sqrt(magnitude / factor);
                for (int i = 0; i < normalizedVector.Length; i++)
                {
                    normalizedVector[i] = vector[i] * factor;
                }
            }
            return normalizedVector;
        }

        public static double[] GetRandomVector(int count, double magnitude)
        {
            double[] result = new double[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = GetRandom();
            }
            return Normalize(result, magnitude);
        }
    }
}
