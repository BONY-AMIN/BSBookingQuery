﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Rating:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int No { get; set; }
    }
}
