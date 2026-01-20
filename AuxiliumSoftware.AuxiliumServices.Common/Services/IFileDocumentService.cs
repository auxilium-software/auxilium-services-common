using AuxiliumSoftware.AuxiliumServices.Common.EntityModels;

namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces;

public interface IFileDocumentService
{
    Task<CaseFileEntityModel?> GetCaseFileMetadataAsync(Guid fileId);
    Task<List<CaseFileEntityModel>> GetFilesForCaseAsync(Guid caseId);
    Task<(string uri, CaseFileEntityModel metadata)> SaveCaseFileAsync(
        byte[] fileContent,
        string filename,
        string contentType,
        Guid uploadedBy,
        Guid caseId,
        string? description = null);
    Task DeleteCaseFileAsync(Guid fileId);
    Task<bool> CheckCaseFileAccessAsync(Guid fileId, UserEntityModel currentUser);



    Task<UserFileEntityModel?> GetUserFileMetadataAsync(Guid fileId);
    Task<List<UserFileEntityModel>> GetFilesForUserAsync(Guid userId);
    Task<(string uri, UserFileEntityModel metadata)> SaveUserFileAsync(
        byte[] fileContent,
        string filename,
        string contentType,
        Guid uploadedBy,
        Guid userId,
        string? description = null);
    Task DeleteUserFileAsync(Guid fileId);
    Task<bool> CheckUserFileAccessAsync(Guid fileId, UserEntityModel currentUser);



    Task<byte[]?> GetFileContentsAsync(Guid fileId);
}
