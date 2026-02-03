namespace AuxiliumSoftware.AuxiliumServices.Common.Enumerators
{
    public enum DatabaseObjectType
    {
        RefreshToken,

        User,
        UserAdditionalProperty,
        UserFile,

        Case,
        CaseTimelineItem,
        CaseTodoItem,
        CaseAdditionalProperty,
        CaseWorker,
        CaseClient,
        CaseMessage,
        CaseFile,

        LogCaseModificationEvent,
        LogCaseMessageReadByEvent,
        LogLoginAttemptEvent,
        LogSystemBulletinEntryDismissalEvent,
        LogSystemBulletinEntryViewEvent,
        LogUserModificationEvent,

        SystemBulletinEntry,

        WemwbsAssessment,
    }
}
