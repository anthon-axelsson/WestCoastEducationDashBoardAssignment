using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Models;

namespace WestCoastEducation.Services;

public class RestDbService : IRestDbService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "	0267f4ecbcbaf4f1d32c467c593125eff5fd7";
    private const string BaseUrl = "https://westcoasteducation-60a8.restdb.io/rest/";

    public RestDbService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("x-apikey", ApiKey);
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Course>>(BaseUrl + "courses") ?? new();
    }

    public async Task AddCourseAsync(Course course)
    {
        await _httpClient.PostAsJsonAsync(BaseUrl + "courses", course);
    }

    public async Task UpdateCourseAsync(string id, Course course)
    {
        await _httpClient.PutAsJsonAsync($"{BaseUrl}courses/{id}", course);
    }



    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Student>>(BaseUrl + "students") ?? new();
    }

    public async Task AddStudentAsync(Student student)
    {
        await _httpClient.PostAsJsonAsync(BaseUrl + "students", student);
    }





    public async Task<List<Teacher>> GetTeachersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Teacher>>(BaseUrl + "teachers") ?? new();
    }

    public async Task AddTeacherAsync(Teacher teacher)
    {
        await _httpClient.PostAsJsonAsync(BaseUrl + "teachers", teacher);
    }

    public async Task UpdateTeacherAsync(string id, Teacher teacher)
    {
        await _httpClient.PutAsJsonAsync($"{BaseUrl}teachers/{id}", teacher);
    }

}
