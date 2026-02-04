using AuxiliumSoftware.AuxiliumServices.Common.Enumerators;
using System.Security.Cryptography;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Utilities
{
    /// <summary>
    /// Provides utility methods for generating and parsing UUIDs (Universally Unique Identifiers).
    /// This class implements UUID Version 5 generation as defined in RFC 4122, using SHA-1 hashing
    /// to create deterministic, namespace-based UUIDs.
    /// </summary>
    /// <remarks>
    /// UUID Version 5 creates a hash-based UUID using SHA-1. Given the same namespace and name,
    /// the same UUID will always be generated, making it useful for creating reproducible identifiers.
    /// </remarks>
    public static class UUIDUtilities
    {
        /// <summary>
        /// Maps each <see cref="DatabaseObjectType"/> to its corresponding namespace path string.
        /// These paths are used to generate unique namespace UUIDs for different database object types,
        /// ensuring that UUIDs generated for different object types will never collide.
        /// </summary>
        /// <remarks>
        /// The path format follows a hierarchical structure:
        /// <c>/auxilium/3/database-object/{storage-type}/{object-type}/{sub-type}</c>
        /// </remarks>
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
        /// A precomputed dictionary mapping each <see cref="DatabaseObjectType"/> to its namespace UUID.
        /// These UUIDs are generated once at static initialization by converting each namespace path
        /// in <see cref="NamespacePaths"/> to a UUID via <see cref="PathToUuid"/>.
        /// </summary>
        /// <remarks>
        /// Precomputing these values avoids repeated hashing operations during UUID generation,
        /// improving performance when generating many UUIDs.
        /// </remarks>
        private static readonly Dictionary<DatabaseObjectType, Guid> NamespaceUuids =
            NamespacePaths.ToDictionary(
                kvp => kvp.Key,
                kvp => PathToUuid(kvp.Value)
            );

        /// <summary>
        /// Generates a new Version 5 UUID for the specified database object type.
        /// The generated UUID incorporates the current UTC time and a random GUID to ensure uniqueness.
        /// </summary>
        /// <param name="objectType">
        /// The type of database object for which to generate a UUID.
        /// This determines which namespace UUID will be used in the generation process.
        /// </param>
        /// <returns>
        /// A new <see cref="Guid"/> representing a Version 5 UUID that is unique to the
        /// specified object type, current time, and a random component.
        /// </returns>
        /// <exception cref="KeyNotFoundException">
        /// Thrown if <paramref name="objectType"/> is not defined in <see cref="NamespaceUuids"/>.
        /// </exception>
        /// <example>
        /// <code>
        /// var userId = UUIDUtilities.GenerateV5(DatabaseObjectType.User);
        /// var caseId = UUIDUtilities.GenerateV5(DatabaseObjectType.Case);
        /// </code>
        /// </example>
        public static Guid GenerateV5(DatabaseObjectType objectType)
        {
            var namespaceId = NamespaceUuids[objectType];
            var name = $"{objectType}_{DateTime.UtcNow.Ticks}_{Guid.NewGuid()}";

            return GenerateV5(namespaceId, name);
        }

        /// <summary>
        /// Generates a Version 5 UUID using the specified namespace UUID and name string.
        /// This method implements the UUID Version 5 algorithm as defined in RFC 4122,
        /// using SHA-1 hashing to create a deterministic UUID from the inputs.
        /// </summary>
        /// <param name="namespaceId">
        /// The namespace UUID that categorizes the generated UUID.
        /// UUIDs generated with the same namespace and name will always be identical.
        /// </param>
        /// <param name="name">
        /// The name string used to generate the UUID. Combined with the namespace,
        /// this determines the final UUID value.
        /// </param>
        /// <returns>
        /// A <see cref="Guid"/> representing a Version 5 UUID. The same namespace and name
        /// will always produce the same UUID.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The algorithm performs the following steps:
        /// <list type="number">
        ///   <item>Converts the namespace UUID to bytes and swaps to network byte order (big-endian).</item>
        ///   <item>Concatenates the namespace bytes with the UTF-8 encoded name bytes.</item>
        ///   <item>Computes a SHA-1 hash of the concatenated bytes.</item>
        ///   <item>Takes the first 16 bytes of the hash to form the UUID.</item>
        ///   <item>Sets the version bits (4 bits) to 0101 (version 5).</item>
        ///   <item>Sets the variant bits (2 bits) to 10 (RFC 4122 variant).</item>
        ///   <item>Swaps bytes back to .NET's little-endian GUID format.</item>
        /// </list>
        /// </para>
        /// </remarks>
        /// <example>
        /// <code>
        /// var namespaceUuid = Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8"); // URL namespace
        /// var uuid = UUIDUtilities.GenerateV5(namespaceUuid, "https://example.com");
        /// </code>
        /// </example>
        public static Guid GenerateV5(Guid namespaceId, string name)
        {
            var namespaceBytes = namespaceId.ToByteArray();
            var nameBytes = Encoding.UTF8.GetBytes(name);

            // Convert from .NET's little-endian format to RFC 4122 big-endian format
            SwapByteOrder(namespaceBytes);

            // Compute SHA-1 hash of namespace + name
            var hash = SHA1.HashData(namespaceBytes.Concat(nameBytes).ToArray());

            // Take the first 16 bytes for the UUID
            var newGuid = new byte[16];
            Array.Copy(hash, 0, newGuid, 0, 16);

            // Set version to 5 (0101 in the high nibble of byte 6)
            newGuid[6] = (byte)(newGuid[6] & 0x0F | 0x50);

            // Set variant to RFC 4122 (10xx in the high bits of byte 8)
            newGuid[8] = (byte)(newGuid[8] & 0x3F | 0x80);

            // Convert back to .NET's little-endian GUID format
            SwapByteOrder(newGuid);

            return new Guid(newGuid);
        }

        /// <summary>
        /// Converts a path string to a Version 5-style UUID using SHA-1 hashing.
        /// This is used internally to generate namespace UUIDs from path strings.
        /// </summary>
        /// <param name="path">
        /// The path string to convert to a UUID. This should be a unique identifier
        /// for a namespace, typically in a hierarchical format.
        /// </param>
        /// <returns>
        /// A <see cref="Guid"/> derived from the SHA-1 hash of the path string,
        /// with version and variant bits set according to UUID Version 5 specification.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note: This method differs slightly from standard UUID Version 5 generation
        /// in that it does not use a namespace UUID; it hashes the path directly.
        /// The same path will always produce the same UUID.
        /// </para>
        /// <para>
        /// The method sets:
        /// <list type="bullet">
        ///   <item>Version bits (byte 6, high nibble) to 0101 (version 5).</item>
        ///   <item>Variant bits (byte 8, high 2 bits) to 10 (RFC 4122 variant).</item>
        /// </list>
        /// </para>
        /// </remarks>
        private static Guid PathToUuid(string path)
        {
            // Compute SHA-1 hash of the path string
            var hash = SHA1.HashData(Encoding.UTF8.GetBytes(path));

            // Take the first 16 bytes for the UUID
            var uuid = new byte[16];
            Array.Copy(hash, 0, uuid, 0, 16);

            // Set version to 5 (0101 in the high nibble of byte 6)
            uuid[6] = (byte)(uuid[6] & 0x0F | 0x50);

            // Set variant to RFC 4122 (10xx in the high bits of byte 8)
            uuid[8] = (byte)(uuid[8] & 0x3F | 0x80);

            return new Guid(uuid);
        }

        /// <summary>
        /// Swaps the byte order of a GUID byte array between .NET's little-endian format
        /// and RFC 4122's big-endian (network byte order) format.
        /// </summary>
        /// <param name="guid">
        /// A 16-byte array representing a GUID. The array is modified in place.
        /// </param>
        /// <remarks>
        /// <para>
        /// .NET's <see cref="Guid"/> structure stores the first three components
        /// (Data1, Data2, Data3) in little-endian format on little-endian systems,
        /// while RFC 4122 specifies big-endian (network byte order) for UUIDs.
        /// </para>
        /// <para>
        /// This method swaps:
        /// <list type="bullet">
        ///   <item>Bytes 0-3 (Data1, 32-bit): reverses byte order.</item>
        ///   <item>Bytes 4-5 (Data2, 16-bit): swaps the two bytes.</item>
        ///   <item>Bytes 6-7 (Data3, 16-bit): swaps the two bytes.</item>
        /// </list>
        /// Bytes 8-15 (Data4) are not swapped as they are stored identically in both formats.
        /// </para>
        /// </remarks>
        private static void SwapByteOrder(byte[] guid)
        {
            // Swap Data1 (bytes 0-3): 32-bit integer, reverse all 4 bytes
            SwapBytes(guid, 0, 3);
            SwapBytes(guid, 1, 2);

            // Swap Data2 (bytes 4-5): 16-bit integer, swap 2 bytes
            SwapBytes(guid, 4, 5);

            // Swap Data3 (bytes 6-7): 16-bit integer, swap 2 bytes
            SwapBytes(guid, 6, 7);
        }

        /// <summary>
        /// Swaps two bytes at the specified indices within a byte array.
        /// </summary>
        /// <param name="guid">The byte array in which to swap bytes.</param>
        /// <param name="left">The index of the first byte to swap.</param>
        /// <param name="right">The index of the second byte to swap.</param>
        /// <remarks>
        /// This is a helper method that performs an in-place swap using tuple deconstruction.
        /// </remarks>
        private static void SwapBytes(byte[] guid, int left, int right)
        {
            (guid[left], guid[right]) = (guid[right], guid[left]);
        }
    }
}