namespace MVD.Domain
{
    using Incoding.CQRS;

    public class ApproveUserCommand : CommandBase
    {
        public string UserId { get; set; }

        public override void Execute()
        {
            Result = UserId;
        }
    }
}