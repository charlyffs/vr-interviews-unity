using UnityEngine;
using UnityEditor.Animations;

public class InterviewStep : MonoBehaviour
{
    private int duration;
    private string animatorControllerPath;
    private string audioClipPath;

    public InterviewStep(int duration, string animatorControllerPath, string audioClipPath){
        this.duration = duration;
        this.animatorControllerPath = animatorControllerPath;
        this.audioClipPath = audioClipPath;
    }

    public int getDuration(){
        return duration;
    }

    public string getAudioClipPath(){
        return audioClipPath;
    }

    public string getAnimatorControllerPath(){
        return animatorControllerPath;
    }
}
