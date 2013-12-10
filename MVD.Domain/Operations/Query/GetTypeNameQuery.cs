namespace MVD.Domain
{
    using Incoding.CQRS;

    public class GetTypeNameQuery<TType> : QueryBase<string>
    {
        protected override string ExecuteResult()
        {
            return typeof(TType).Name;
        }
    }
}