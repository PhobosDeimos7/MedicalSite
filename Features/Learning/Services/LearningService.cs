using System.Net.Http.Json;
using MedicalSite.Features.Learning.Models;

namespace MedicalSite.Features.Learning.Services;

public class LearningService
{
    private readonly HttpClient _http;
    private const string FirebaseUrl = "https://medicalsite-fd05b-default-rtdb.asia-southeast1.firebasedatabase.app/.json";

    public LearningService(HttpClient http)
    {
        _http = http;
    }

    private async Task<LearningData?> GetDataAsync()
    {
        try 
        {
            return await _http.GetFromJsonAsync<LearningData>(FirebaseUrl);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FIREBASE ERROR: {ex.Message}");
            return new LearningData(); 
        }
    }

    public async Task<List<Subject>> GetSubjectsAsync() 
        => (await GetDataAsync())?.Subjects ?? new();

    // NEW METHOD
    public async Task<List<BlogPost>> GetBlogPostsAsync() 
        => (await GetDataAsync())?.BlogPosts ?? new();

    public async Task<Topic?> GetTopicAsync(string subjectId, string topicId)
    {
        var data = await GetDataAsync();
        return data?.Subjects
            .FirstOrDefault(s => s.Id.Equals(subjectId, StringComparison.OrdinalIgnoreCase))?
            .Topics
            .FirstOrDefault(t => t.Id.Equals(topicId, StringComparison.OrdinalIgnoreCase));
    }
}