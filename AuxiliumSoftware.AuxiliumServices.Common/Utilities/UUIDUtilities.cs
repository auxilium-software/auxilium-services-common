using AuxiliumSoftware.AuxiliumServices.Common.Enumerators;
using System.Security.Cryptography;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Utilities
{
    /// <summary>
    /// Utilities related to generating and parsing UUIDs.
    /// </summary>
    public static class UUIDUtilities
    {
        /// <summary>
        /// Takes in a DatabaseObjectType and generates a Version 5 UUID
        /// </summary>
        private static readonly Dictionary<DatabaseObjectType, string> NamespacePaths = new()
        {
            [DatabaseObjectType.RefreshToken] = "/auxilium/3/database-object/refresh_token",

            [DatabaseObjectType.User] = "/auxilium/3/database-object/mariadb/user",
            [DatabaseObjectType.UserAdditionalProperty] = "/auxilium/3/database-object/mariadb/user/additional-property",
            [DatabaseObjectType.UserFile] = "/auxilium/3/database-object/mariadb/user/file",

            [DatabaseObjectType.Case] = "/auxilium/3/database-object/mariadb/case",
            [DatabaseObjectType.CaseTimelineItem] = "/auxilium/3/database-object/mariadb/case/timeline-item",
            [DatabaseObjectType.CaseTodoItem] = "/auxilium/3/database-object/mariadb/case/todo-item",
            [DatabaseObjectType.CaseAdditionalProperty] = "/auxilium/3/database-object/mariadb/case/additional-property",
            [DatabaseObjectType.CaseWorker] = "/auxilium/3/database-object/mariadb/case/worker",
            [DatabaseObjectType.CaseClient] = "/auxilium/3/database-object/mariadb/case/client",
            [DatabaseObjectType.CaseMessage] = "/auxilium/3/database-object/mariadb/case/message",
            [DatabaseObjectType.CaseFile] = "/auxilium/3/database-object/mariadb/case/file",

            [DatabaseObjectType.LogCaseMessageReadByEvent] = "/auxilium/3/database-object/mariadb/log/case-message-read-by-event",
            [DatabaseObjectType.LogLoginAttemptEvent] = "/auxilium/3/database-object/mariadb/log/login-attempt-event",
            [DatabaseObjectType.LogSystemBulletinEntryDismissalEvent] = "/auxilium/3/database-object/mariadb/log/system-bulletin-entry-dismissal-event",
            [DatabaseObjectType.LogSystemBulletinEntryViewEvent] = "/auxilium/3/database-object/mariadb/log/system-bulletin-entry-view-event",

            [DatabaseObjectType.SystemBulletinEntry] = "/auxilium/3/database-object/mariadb/system-bulletin-entry",

            [DatabaseObjectType.WemwbsAssessment] = "/auxilium/3/database-object/mariadb/assessments/wemwbs",
        };


        /// <summary>
        /// Takes in a DatabaseObjectType and gets the precomputed Namespace UUID for it.
        /// </summary>
        private static readonly Dictionary<DatabaseObjectType, Guid> NamespaceUuids =
            NamespacePaths.ToDictionary(
                kvp => kvp.Key,
                kvp => PathToUuid(kvp.Value)
            );

        /// <summary>
        /// Generates a Version 5 UUID for the given DatabaseObjectType.
        /// </summary>
        /// <param name="objectType">The DatabaseObjectType to use</param>
        /// <returns>A UUID (Guid).</returns>
        public static Guid GenerateV5(DatabaseObjectType objectType)
        {
            var namespaceId = NamespaceUuids[objectType];
            var name = $"{objectType}_{DateTime.UtcNow.Ticks}_{Guid.NewGuid()}";

            return GenerateV5(namespaceId, name);
        }

        /// <summary>
        /// Generates a Version 5 UUID given a namespace UUID and a name.
        /// </summary>
        /// <param name="namespaceId">The UUID (Guid) that represents the namespace to use.</param>
        /// <param name="name">The name to use.</param>
        /// <returns>A UUID (Guid).</returns>
        public static Guid GenerateV5(Guid namespaceId, string name)
        {
            var namespaceBytes = namespaceId.ToByteArray();
            var nameBytes = Encoding.UTF8.GetBytes(name);

            SwapByteOrder(namespaceBytes);

            var hash = SHA1.HashData(namespaceBytes.Concat(nameBytes).ToArray());

            var newGuid = new byte[16];
            Array.Copy(hash, 0, newGuid, 0, 16);

            newGuid[6] = (byte)(newGuid[6] & 0x0F | 0x50);
            newGuid[8] = (byte)(newGuid[8] & 0x3F | 0x80);

            SwapByteOrder(newGuid);

            return new Guid(newGuid);
        }

        /// <summary>
        /// Converts a path string to a Version 5 UUID using SHA-1 hashing.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static Guid PathToUuid(string path)
        {
            var hash = SHA1.HashData(Encoding.UTF8.GetBytes(path));

            var uuid = new byte[16];
            Array.Copy(hash, 0, uuid, 0, 16);

            uuid[6] = (byte)(uuid[6] & 0x0F | 0x50);
            uuid[8] = (byte)(uuid[8] & 0x3F | 0x80);

            return new Guid(uuid);
        }

        /// <summary>
        /// Takes in a GUID byte array and swaps the byte order to match RFC 4122.
        /// </summary>
        /// <param name="guid">A 16-byte array representing a GUID. The array is modified in place.</param>
        private static void SwapByteOrder(byte[] guid)
        {
            SwapBytes(guid, 0, 3);
            SwapBytes(guid, 1, 2);
            SwapBytes(guid, 4, 5);
            SwapBytes(guid, 6, 7);
        }

        /// <summary>
        /// Swaps two bytes in a byte array.
        /// </summary>
        /// <param name="guid">The byte array to target for swapping bytes.</param>
        /// <param name="left">The index of the first byte to swap.</param>
        /// <param name="right">The index of the second byte to swap.</param>
        private static void SwapBytes(byte[] guid, int left, int right)
        {
            (guid[left], guid[right]) = (guid[right], guid[left]);
        }
    }
}
