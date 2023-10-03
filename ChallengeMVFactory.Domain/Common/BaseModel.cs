 

namespace ChallengeMVFactory.Domain.Common
{
    public class BaseModel
    {

        public int Id { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? updateDate { get; set; }

        public string? createdBy { get; set; }

        public string? updateBy { get; set; }
    }
}
