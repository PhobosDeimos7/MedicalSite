namespace MedicalSite.Features.Learning.Models;

public class LearningData
{
    public List<Subject> Subjects { get; set; } = new();
    public List<BlogPost> BlogPosts { get; set; } = new(); // NEW
}

public class Subject
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Category { get; set; } = "Para-clinical"; 
    public List<Topic> Topics { get; set; } = new();
}

public class Topic
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    
    // --- THE BIG CHANGE ---
    // Instead of fixed "Summary" or "ExamPearls", we use a flexible list.
    public List<ContentSection> Sections { get; set; } = new(); 
    
    // Keep these as they are distinct interactive features
    public List<Flashcard> Flashcards { get; set; } = new();
    public FlowchartNode RootFlowchartNode { get; set; } = new();
}

// NEW CLASS: This allows you to name sections whatever you want in JSON
public class ContentSection
{
    public string Title { get; set; } = "";   // e.g., "Mechanism", "Vascular Events"
    public string Content { get; set; } = ""; // The text content
    public bool IsExamPearl { get; set; } = false; // Optional: Highlights the section yellow
}

// NEW CLASS: For your updates page
public class BlogPost
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = "";
    public string Date { get; set; } = "";
    public string Author { get; set; } = "Dr. T";
    public string Content { get; set; } = "";
    public string Tag { get; set; } = "Update"; // e.g., "New Content", "Feature"
}

// (Keep Flashcard, Definition, FlowchartNode classes as they were...)
public class Flashcard
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Front { get; set; } = "";
    public string Back { get; set; } = "";
    public List<string> Tags { get; set; } = new();
}

public class FlowchartNode
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    
    // ADD THIS LINE BACK:
    public string Type { get; set; } = "Standard"; 
    
    public List<FlowchartNode> Children { get; set; } = new();
}
