using System.Collections.Generic;

public class Interview 
{
    private string title;
    private string basePath;
    private List<InterviewStep> steps;

    public Interview(string title, string basePath){
        this.title = title;
        this.basePath = basePath;
        steps = new List<InterviewStep>();
    }

    public void addStep(InterviewStep step){
        steps.Add(step);
    }

    public string getTitle() {
        return title;
    }

    public string getBasePath(){
        return "Interviews/" + basePath;
    }

    public List<InterviewStep> getSteps(){
        return steps;
    }
}
