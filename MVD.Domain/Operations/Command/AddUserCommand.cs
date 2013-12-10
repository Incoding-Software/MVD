namespace MVD.Domain
{
    using Incoding.CQRS;

    public class AddUserCommand : CommandBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public override void Execute()
        {
            Result = Id + Name;
        }
    }
}