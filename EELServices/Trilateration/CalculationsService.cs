using EELData;
using System;

namespace EELServices.Trilateration {
    public class CalculationsService {
        public static double CalculateDistance(StarSystem s1, StarSystem s2) {
            if (s1 == null || s2 == null)
                return -1;

            //return Math.Sqrt(Math.Pow(s1.X - s2.X, 2) + Math.Pow(s1.y - s2.y, 2) + Math.Pow(s1.z - s2.z, 2));
            return Math.Sqrt((s1.X - s2.X) * (s1.X - s2.X) + (s1.Y - s2.Y) * (s1.Y - s2.Y) + (s1.Z - s2.Z) * (s1.Z - s2.Z));
        }
    }
}
