﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Placed.KR
{
    public class Wagon
    {
        public string ID { get; set; }
        public int MarshalOrder { get; set; }

        public Wagon(string _ID, int _MarshallOrder)
        {
            ID = _ID;
            MarshalOrder = _MarshallOrder;

        }
    }
}