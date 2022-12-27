using System;
using Homo.Api;

namespace Homo.FarmApi
{
    public partial class Strawberry
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        [MaxLength(32)]
        public string Label { get; set; }

        [Required]
        [MaxLength(64)]
        public string Spec { get; set; }

        [Required]
        [MaxLength(128)]
        public string InitialState { get; set; }

        [Required]
        [MaxLength(128)]
        public string Situation { get; set; }
        [Required]
        public BORN_FORM BornFrom { get; set; }
    }
}
