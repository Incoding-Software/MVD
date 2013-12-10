namespace MVD.Domain
{
    using Incoding.CQRS;

    public class AddEntityCommand<TEntity> : CommandBase
    {
        public override void Execute()
        {
            this.Result = typeof(TEntity).Name;
        }
    }
}