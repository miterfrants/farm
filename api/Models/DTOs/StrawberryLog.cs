using System;
using Homo.Api;

namespace Homo.FarmApi
{
    public abstract partial class DTOs
    {

        public partial class StrawberryLog
        {
            public DateTime CreatedAt { get; set; }
            [Required]
            [MaxLength(128)]
            public string CurrentState { get; set; }
            [Required]
            public int TenderLeaves { get; set; }

            [Required]
            public int OldLeaves { get; set; }
            [Required]
            public int FlowerBud { get; set; }
            [Required]
            public int LeavesBud { get; set; }
            [Required]
            public int Flower { get; set; }
            [Required]
            public int Fruit { get; set; }
            [Required]
            public int IsRepotting { get; set; }
            [Required]
            public int IsPruning { get; set; }
            [Required]
            public int IsFertilize { get; set; }

            [Required]
            public int Stolon { get; set; }
            [MaxLength(512)]
            public string Comment { get; set; }
        }
    }
}
