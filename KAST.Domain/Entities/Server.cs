namespace KAST.Domain.Entities
{
    public class Server
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? InstallPath { get; set; }
    }
}
