namespace BranchDieselAPI.Models
{
    public class UpdateDieselRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Branch { get; set; }
        public int RequestQty { get; set; }
        public int ActualQty { get; set; }
    }
}
