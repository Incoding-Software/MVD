namespace MVD.Domain
{
    #region << Using >>

    using Incoding.CQRS;

    #endregion

    public class GetUserQuery : QueryBase<GetUserQuery.Response>
    {
        #region Nested classes

        public class Response
        {
            #region Properties

            public string Id { get; set; }

            public string Name { get; set; }

            #endregion
        }

        #endregion

        protected override Response ExecuteResult()
        {
            return new Response
                       {
                               Id = "1",
                               Name = "Incoding Software"
                       };
        }
    }
}