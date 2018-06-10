using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Placed.KR
{
    public class Rake 
    {
        public List<Wagon> Wagons = new List<Wagon>();

        public DateTime CreatedOn { get; set; }
        public string DisplayName { get { return _DisplayName(); } }
        public DateTime PlacementCompletedOn { get; set; }
        public DateTime PlacementDeadline { get; set; }
        public string LateReason { get; set; }


        public Rake()
        {
            CreatedOn = DateTime.Now;

        }

        private string _DisplayName()
        {
            string FirstWagon, LastWagon,CreatedTime;
            FirstWagon = Wagons.Find(x => x.MarshalOrder == 1).ID;
            LastWagon = Wagons.Find(x => x.MarshalOrder == Wagons.Count).ID;
            CreatedTime = CreatedOn.ToShortTimeString();
            return string.Format("{0} : {1} - {2}", CreatedTime, FirstWagon, LastWagon);

        }


    }
}
