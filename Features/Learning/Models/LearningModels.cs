namespace MedicalSite.Features.Learning.Models;

public class LearningData
{
    public List<Subject> Subjects { get; set; } = new();
}

public class Subject
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public List<Topic> Topics { get; set; } = new();
}

public class Topic
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    
    // CRITICAL FIX: Use 'object' here. 
    // This allows it to load the JSON whether "overview" is a String OR an Object.
    public object Overview { get; set; } = new();
    
    public string Summary { get; set; } = "";
    public string ClinicalRelevance { get; set; } = "";
    public List<string> ExamPearls { get; set; } = new();
    public List<Definition> Definitions { get; set; } = new();
    
    public List<Flashcard> Flashcards { get; set; } = new();
    public FlowchartNode RootFlowchartNode { get; set; } = new();
}

public class Definition
{
    public string Term { get; set; } = "";
    public string Meaning { get; set; } = "";
}

public class Flashcard
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Front { get; set; } = "";
    public string Back { get; set; } = "";
    public int Difficulty { get; set; } = 1;
    public string Yield { get; set; } = "Medium";
    public List<string> Tags { get; set; } = new();
}

public class FlowchartNode
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Type { get; set; } = "Standard"; 
    public List<FlowchartNode> Children { get; set; } = new();
}