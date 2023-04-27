using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Interview : MonoBehaviour
{
    private string title;
    private string basePath;
    private int duration;
    private int length;
    private List<InterviewStep> steps;

    public Interview(string title, string basePath){
        this.title = title;
        this.basePath = basePath;
    }

    public void addStep(int duration, string animatorControllerPath, string audioClipPath){
        steps.Add(new InterviewStep(duration, animatorControllerPath, audioClipPath));
        this.length += 1;
        this.duration += duration;
    }

    public string getBasePath(){
        return basePath;
    }

    public List<InterviewStep> getSteps(){
        return steps;
    }
}
