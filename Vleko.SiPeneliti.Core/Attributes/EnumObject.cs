namespace Vleko.Bayarind.Core.Attributes
{
    public enum StatusPenelitianEnum
    {
        Baru=1,
        Lanjutan=2
    }
    public enum WorkflowEnum
    {
        Process,
        Reject,
        Approved
    }
    public enum WorkflowStatusEnum
    {
        Waiting = 0,
        Request = 1,
        Review = 2,
        Approve = 3,
        Approve_Parallel = 4,
        Reject = 5,
        Reject_Parallel = 6,
        Adhoc = 7,
        Delegasi = 8,
    }
    public enum GenderEnum
    {
        Male=1,
        Female=2
    }
    public enum NationalityEnum
    {
        WNI = 1,
        WNA = 2
    }
}
