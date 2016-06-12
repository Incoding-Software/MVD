namespace MVD.Domain
{
    using Incoding.CQRS;

    public class AddEntityCommand<TEntity> : CommandBase
    {
        protected override void Execute()
        {
            this.Result = typeof(TEntity).Name;
        }
    }
}