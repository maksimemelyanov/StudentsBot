namespace StudentsBot.Students.Domain.Students;

public class Student : BaseEntity
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int GroupId { get; set; }
}