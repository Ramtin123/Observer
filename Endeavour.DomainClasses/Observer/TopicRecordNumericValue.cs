﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.DomainClasses.Observer
{
    public class TopicRecordNumericValue:TopicRecordValue 
    {
        public int Value { set; get; }
    }
}
