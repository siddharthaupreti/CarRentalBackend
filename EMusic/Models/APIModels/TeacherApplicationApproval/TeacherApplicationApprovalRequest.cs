namespace EMusic.Models.APIModels.TeacherApplicationApproval
{
    public class TeacherApplicationApprovalRequest
    {
        public string UserId { get; set; }
        public string TeacherName { get; set; }
        public string AdminDecision { get; set; }
    }
}
