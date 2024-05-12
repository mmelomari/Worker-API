namespace Worker_CRUD.Models
{
    public class ServiceResponse<T>
    {
        public T? EmployeeData { get; set; }       
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
