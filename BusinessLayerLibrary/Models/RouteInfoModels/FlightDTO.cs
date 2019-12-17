using DreamBusDBLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayerLibrary.Models
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }

        public bool IsReverse { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public City StartCity
        {
            get => MediumPathes.Where(mp => mp.PathNum == 0).FirstOrDefault().NeighborCity.City;
        }

        public City EndCity
        {
            get
            {
                if (MediumPathes.Count() > 1)
                    return MediumPathes.Aggregate((e1, e2) => e1.PathNum > e2.PathNum ? e1 : e2)
                        .NeighborCity.Neighbor;

                return (MediumPathes.Count() == 0) ? null : MediumPathes.First().NeighborCity.Neighbor;
            }
        }

        public TimeSpan ArrivalTime
        {
            get
            {
                var mp = MediumPathes.Aggregate((e1, e2) => e1.PathNum > e2.PathNum ? e1 : e2);
                return this.DepartureTime.Add(new TimeSpan(0, mp.NeighborCity.MinutesInPath, 0));
            }       
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MediumPathe> MediumPathes { get; set; }
    }
}
