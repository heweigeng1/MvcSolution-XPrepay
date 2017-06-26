using System;

namespace Xprepay.Services.Dtos
{
    public class DtoBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public int Delflag { get; set; }
    }
}
