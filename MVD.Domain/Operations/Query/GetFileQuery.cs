namespace MVD.Domain
{
    #region << Using >>

    using System;
    using System.IO;
    using Incoding.CQRS;

    #endregion

    public class GetFileQuery : QueryBase<byte[]>
    {
        protected override byte[] ExecuteResult()
        {
            return File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts/incoding.framework.js"));
        }
    }
}