using System;
using Homo.Api;

namespace Homo.FarmApi
{
    public abstract partial class DTOs
    {

        public partial class StrawberryMachineLearningRaw
        {
            public DateTime CreatedAt { get; set; }
            [Required]
            [MaxLength(128)]
            public String FileName { get; set; }
            public STRAWBERRY_DISEASE Disease { get; set; }
        }
    }
}
