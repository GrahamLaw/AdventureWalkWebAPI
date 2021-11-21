using System;
using System.Collections.Generic;

#nullable disable

namespace AdventureWalk.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Score { get; set; }
        public int? TimeSpent { get; set; }
    }
}
