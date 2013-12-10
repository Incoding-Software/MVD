namespace MVD.Domain
{
    using System;
    using Incoding.CQRS;

    public class GetCurrentDtQuery : QueryBase<string>
    {
        protected override string ExecuteResult()
        {
            return DateTime.Now.ToString();
        }
    }
}