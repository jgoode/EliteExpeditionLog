
using EELData;
using System;
using System.Text.RegularExpressions;

namespace EELServices.Trilateration {
    public class ReferenceSystem {
        public double Distance { get; set; }
        public double Azimuth { get; set; }
        public double Altitude { get; set; }

        private StarSystem _refSys;

        public StarSystem System
        {
            get { return _refSys; }
        }


        public double Weight
        {
            get
            {
                int modifier = 0;
                if (_refSys.Name.EndsWith("0"))  // Elite has a bug with selecting systems ending with 0.  Prefere others first.
                    modifier += 50;

                if (Regex.IsMatch(_refSys.Name, "\\s[A-Z][A-Z].[A-Z]\\s"))
                    modifier += 20;

                if (Distance > 20000)
                    modifier += 10;

                if (Distance > 30000)
                    modifier += 20;

                return _refSys.Name.Length * 2 + Math.Sqrt(Distance) / 3.5 + modifier;
                //return refSys.name.Length + Distance/100 + modifier;
            }
        }

        public ReferenceSystem(StarSystem refsys, StarSystem EstimatedPosition) {
            _refSys = refsys;
            Azimuth = Math.Atan2(_refSys.Y - EstimatedPosition.Y, _refSys.X - EstimatedPosition.X);
            Distance = CalculationsService.CalculateDistance(_refSys, EstimatedPosition);
            Altitude = Math.Acos((_refSys.Z - EstimatedPosition.Z) / Distance);
        }
    }
}
