using System;
using Homo.Api;

namespace Homo.FarmApi
{
    public partial class StrawberryMachineLearningRaw
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        [MaxLength(128)]
        public String FileName { get; set; }
        public STRAWBERRY_DISEASE Disease { get; set; }
    }
}
