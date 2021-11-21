using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWalk.Models
{
    public partial class Question
    {
        public int Qid { get; set; }
        public string Question1 { get; set; }
        public string Answer { get; set; }
        public string ImageName { get; set; }
    }
}
