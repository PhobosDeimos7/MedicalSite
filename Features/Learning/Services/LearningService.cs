using System.Net.Http.Json;
using MedicalSite.Features.Learning.Models;

namespace MedicalSite.Features.Learning.Services;

public class LearningService
{
    private readonly HttpClient _http;
    
    // Using your Firebase URL
    private const string FirebaseUrl = "https://medicalsite-fd05b-default-rtdb.asia-southeast1.firebasedatabase.app/.json";

    public LearningService(HttpClient http)
    {
        _http = http;
    }

    private async Task<LearningData?> GetDataAsync()
{
    try 
    {
        var result = await _http.GetFromJsonAsync<LearningData>(FirebaseUrl);
        
        // Debugging: Check if we got data but the list is empty
        if (result == null || result.Subjects == null || result.Subjects.Count == 0)
        {
            Console.WriteLine("WARNING: Connected to Firebase, but found 0 subjects.");
            Console.WriteLine("Check if your Firebase root starts with 'subjects'.");
        }
        else 
        {
            Console.WriteLine($"SUCCESS: Loaded {result.Subjects.Count} subjects from Firebase.");
        }

        return result;
    }
    catch (Exception ex)
    {
        // THIS IS KEY: Look at your Browser Console (F12) to see this message
        Console.WriteLine($"CRITICAL FIREBASE ERROR: {ex.Message}");
        return new LearningData(); 
    }
}
    public async Task<List<Subject>> GetSubjectsAsync() 
        => (await GetDataAsync())?.Subjects ?? new();

    public async Task<Topic?> GetTopicAsync(string subjectId, string topicId)
    {
        var data = await GetDataAsync();
        return data?.Subjects
            .FirstOrDefault(s => s.Id.Equals(subjectId, StringComparison.OrdinalIgnoreCase))?
            .Topics
            .FirstOrDefault(t => t.Id.Equals(topicId, StringComparison.OrdinalIgnoreCase));
    }
}