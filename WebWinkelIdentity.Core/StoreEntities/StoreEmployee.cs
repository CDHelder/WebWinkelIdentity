namespace WebWinkelIdentity.Core.StoreEntities
{
    public class StoreEmployee
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
