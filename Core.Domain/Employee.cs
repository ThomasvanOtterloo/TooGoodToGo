namespace Core.Domain
{
	public class Employee
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public int EmployeeNumber { get; set; }
		public Canteen? Canteen { get; set; }

        //public Login Login { get; set; }
    }
}
