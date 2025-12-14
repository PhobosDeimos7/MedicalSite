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
    
    // --- NEW STRUCTURED CONTENT ---
    public string Summary { get; set; } = ""; // Main textbook text
    public string ClinicalRelevance { get; set; } = ""; // "Why this matters"
    public List<Definition> Definitions { get; set; } = new(); // Key terms
    public List<string> ExamPearls { get; set; } = new(); // "High yield" bullet points
    // ------------------------------

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
    public string Front { get; set; } = "";
    public string Back { get; set; } = "";
}

public class FlowchartNode
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = ""; // Changed from 'Label' to 'Title'
    public string Description { get; set; } = ""; // New field
    public string Type { get; set; } = "Standard"; 
    public List<FlowchartNode> Children { get; set; } = new();
}