using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRail.API.Conso.Models
{

    public class Liveboard
    {
        public Departures Departures { get; set; }
        public string Station { get; set; }
        public Stationinfo Stationinfo { get; set; }
        public double Timestamp { get; set; }
        public string Version { get; set; }
    }

    public class Departures
    {
        public List<object> Departure { get; set; }
        public double Number { get; set; }
    }

    public class Stationinfo
    {
        public string Id { get; set; }

        /// <summary>
        /// The (iRail) id of the station. The NMBS id can be deducted by removing the leading
        /// 'BE.NMBS.00'
        /// </summary>
        public string StationinfoId { get; set; }

        /// <summary>
        /// The longitude of the station
        /// </summary>
        public double LocationX { get; set; }

        /// <summary>
        /// The latitude of the station
        /// </summary>
        public double LocationY { get; set; }

        /// <summary>
        /// The default name of this station
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The consistent name of this station
        /// </summary>
        public string Standardname { get; set; }
    }
}

