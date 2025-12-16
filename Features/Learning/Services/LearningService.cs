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
            // REVERTED: We go back to expecting the "LearningData" wrapper
            // because your JSON has a root "subjects" key containing a List.
            var result = await _http.GetFromJsonAsync<LearningData>(FirebaseUrl);
            
            if (result != null && result.Subjects != null)
            {
                // SAFETY: Firebase Arrays can have "null" holes if you delete items (e.g. index 1 is deleted).
                // We remove those nulls here to prevent crashes later.
                result.Subjects = result.Subjects.Where(s => s != null).ToList();

                // Clean up topics inside subjects too
                foreach (var subject in result.Subjects)
                {
                    if (subject.Topics != null)
                    {
                        subject.Topics = subject.Topics.Where(t => t != null).ToList();
                    }
                }
                
                Console.WriteLine($"SUCCESS: Loaded {result.Subjects.Count} subjects.");
            }
            else
            {
                Console.WriteLine("WARNING: Connected, but 'subjects' list is empty or null.");
            }

            return result;
        }
        catch (Exception ex)
        {
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