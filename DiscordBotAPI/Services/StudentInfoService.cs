using DiscordBotAPI.Models;
using StudProf;

namespace DiscordBotAPI.services;

public class StudentInfoService : IStudentInfoService
{
    private readonly Prof _prof;
    
    public StudentInfoService()
    {
        _prof = new Prof();
    }
    
    private static StudentInfo BuildData(GetUsersComposition student)
    {
        var studentInfo = new StudentInfo
        {
            Name = student.Студент.Имя,
            Department = student.СпециальностьСтудента.GUIDСпециальностиСтудента,
            Group = student.ГруппаСтудента.Наименование,
            Surname = student.Студент.Фамилия,
            OneCGuid = student.Студент.GUIDСтудента
        };
        
        return studentInfo;
    }
    
    public StudentInfo GetStudentInfo(string guid)
    {
        GetUsersComposition student;
        try
        {
            _prof.Connection();
            student = _prof.GetStudentData(guid);
        }
        catch (Exception e)
        {
            Console.WriteLine("Не получилось взять данные с 1С");
            return null;
        }
        return BuildData(student);
    }

    public void Dispose()
    {
        _prof.Dispose();
    }

    public void Connect()
    {
        _prof.Connection();
    }
}