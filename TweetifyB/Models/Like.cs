﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tweety_Boss.Models
{
    public class Like
    {
        public int Id { get; set; }
        public Tweet Tweet { get; set; }
        public User User { get; set; }

    }
}
