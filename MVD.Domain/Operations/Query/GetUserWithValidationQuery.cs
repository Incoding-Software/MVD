namespace MVD.Domain
{
    #region << Using >>

    using FluentValidation;
    using Incoding.CQRS;

    #endregion

    public class GetUserWithValidationQuery : QueryBase<string>
    {
        #region Properties

        public int LessThanOrEqual5 { get; set; }

        #endregion

        #region Nested classes

        public class GetUserWithValidationQueryValidator : AbstractValidator<GetUserWithValidationQuery>
        {
            #region Constructors

            public GetUserWithValidationQueryValidator()
            {
                RuleFor(r => r.LessThanOrEqual5)
                        .LessThanOrEqualTo(5);
            }

            #endregion
        }

        #endregion

        protected override string ExecuteResult()
        {
            return "5";
        }
    }
}