using AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases.ClickHouse;

namespace AuxiliumSoftware.AuxiliumServices.Common.Configuration.Sections.Databases
{
    public class ClickHouseConfigurationSection
    {
        public required string Host { get; set; }
        public required ClickHousePortsConfigurationSection Ports { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Database { get; set; }
        public required string Table { get; set; }
        public required bool UseSSL { get; set; }
        public required bool VerifyServerCertificate { get; set; }
        public required bool CompressResponses { get; set; }
        public required int ConnectTimeoutInSeconds { get; set; }
        public required int SendReceiveTimeoutInSeconds { get; set; }
        public required int BatchSize { get; set; }
        public required int FlushIntervalInSeconds { get; set; }
        public required int MaxQueueSize { get; set; }
        public required int TTLInDays { get; set; }
        public required string PartitionBy { get; set; }
    }
}