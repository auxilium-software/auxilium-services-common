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

        LogCaseMessageReadByEvent,
        LogLoginAttemptEvent,
        LogSystemBulletinEntryDismissalEvent,
        LogSystemBulletinEntryViewEvent,

        SystemBulletinEntry,

        WemwbsAssessment,
    }
}
