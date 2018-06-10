using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Placed.KR
{
    public class Rake 
    {
        public ObservableCollection<Wagon> Wagons = new ObservableCollection<Wagon>();

        public DateTime CreatedOn { get; set; }
        public string DisplayName { get { return _DisplayName(); } }
        public DateTime PlacementCompletedOn { get; set; }
        public DateTime PlacementDeadline { get; set; }
        public string LateReason { get; set; }
        public RakeStatus Status;
        public string PlaceLocation { get; set; }

        public Guid ID { get; private set; }

        public enum RakeStatus
        {
            Pending,
            PlacedOnTime,
            PlacedLate
        }

        public Rake()
        {
            this.ID = Guid.NewGuid();

        }

        private string _DisplayName()
        {
            string FirstWagon, CreatedTime;
            FirstWagon = Wagons[0]?.ID;
            if (Wagons.Count>0) FirstWagon += string.Format(" and {0} others.",Wagons.Count-1)
;
            CreatedTime = CreatedOn.ToShortTimeString();
            return string.Format("{0} : {1} - {2}", Status.ToString(), CreatedTime, FirstWagon);

        }


    }
}
