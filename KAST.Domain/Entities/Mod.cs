using KAST.Domain.Common;
using KAST.Domain.Enums;


namespace KAST.Domain.Entities
{
    public class Mod : BaseEntity
    {
        public Guid ModId { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public bool IsLocal { get; internal set; }
        public ModStatus? Status { get; set; }
        public ulong ActualSize { get; set; }
        public virtual Author? Author { get; set; }
        public ulong SteamID { get; set; }
        public string? Url { get; set; }
        public DateTime? SteamLastUpdated { get; set; }
        public DateTime? LocalLastUpdated { get; set; }
        public ulong? ExpectedSize { get; set; }
    }
}

