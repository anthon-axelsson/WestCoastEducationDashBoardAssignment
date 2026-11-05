using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WestCoastEducation.Models;

namespace WestCoastEducation.Interfaces;

public interface IRestDbService
{
    Task<List<Course>> GetCoursesAsync();
    Task AddCourseAsync(Course course);
    Task UpdateCourseAsync(string id, Course course);

    Task <List<Student>> GetStudentsAsync();
    Task AddStudentAsync(Student student);

    Task<List<Teacher>> GetTeachersAsync();
    Task AddTeacherAsync(Teacher teacher);
    Task UpdateTeacherAsync(string id, Teacher teacher);
}
