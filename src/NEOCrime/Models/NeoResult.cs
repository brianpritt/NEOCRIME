using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEOCrime.Models
{
    public class NeoResult
    {
        public class Links
        {
            public string self { get; set; }
        }

        public class Kilometers
        {
            public double estimated_diameter_min { get; set; }
            public double estimated_diameter_max { get; set; }
        }

        public class Meters
        {
            public double estimated_diameter_min { get; set; }
            public double estimated_diameter_max { get; set; }
        }

        public class Miles
        {
            public double estimated_diameter_min { get; set; }
            public double estimated_diameter_max { get; set; }
        }

        public class Feet
        {
            public double estimated_diameter_min { get; set; }
            public double estimated_diameter_max { get; set; }
        }

        public class EstimatedDiameter
        {
            public Kilometers kilometers { get; set; }
            public Meters meters { get; set; }
            public Miles miles { get; set; }
            public Feet feet { get; set; }
        }

        public class RelativeVelocity
        {
            public string kilometers_per_second { get; set; }
            public string kilometers_per_hour { get; set; }
            public string miles_per_hour { get; set; }
        }

        public class MissDistance
        {
            public string astronomical { get; set; }
            public string lunar { get; set; }
            public string kilometers { get; set; }
            public string miles { get; set; }
        }

        public class CloseApproachData
        {
            public string close_approach_date { get; set; }
            public long epoch_date_close_approach { get; set; }
            public RelativeVelocity relative_velocity { get; set; }
            public MissDistance miss_distance { get; set; }
            public string orbiting_body { get; set; }
        }

        public class RootObject
        {
            public Links links { get; set; }
            public string neo_reference_id { get; set; }
            public string name { get; set; }
            public string nasa_jpl_url { get; set; }
            public double absolute_magnitude_h { get; set; }
            public EstimatedDiameter estimated_diameter { get; set; }
            public bool is_potentially_hazardous_asteroid { get; set; }
            public List<CloseApproachData> close_approach_data { get; set; }
        }
    }
}
