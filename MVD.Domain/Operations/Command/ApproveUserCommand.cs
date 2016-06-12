namespace MVD.Domain
{
    using Incoding.CQRS;

    public class ApproveUserCommand : CommandBase
    {
        public string UserId { get; set; }

        protected override void Execute()
        {
            Result = UserId;
        }
    }
}