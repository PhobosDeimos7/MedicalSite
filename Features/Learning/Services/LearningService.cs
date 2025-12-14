using System.Net.Http.Json;
using MedicalSite.Features.Learning.Models;

namespace MedicalSite.Features.Learning.Services;

public class LearningService
{
    private readonly HttpClient _http;
    private LearningData? _cachedData;

    public LearningService(HttpClient http)
    {
        _http = http;
    }

    private async Task<LearningData?> GetDataAsync()
    {
        if (_cachedData == null)
        {
            _cachedData = await _http.GetFromJsonAsync<LearningData>("data/learning-content.json");
        }
        return _cachedData;
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