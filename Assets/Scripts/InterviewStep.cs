using UnityEngine;
using UnityEditor.Animations;

public class InterviewStep : MonoBehaviour
{
    private int duration;
    private string animatorControllerPath;
    private string audioClipPath;

    private Interview interview;

    public InterviewStep(int duration, string animatorControllerPath, string audioClipPath, Interview owner){
        this.duration = duration;
        this.animatorControllerPath = animatorControllerPath;
        this.audioClipPath = audioClipPath;
        interview = owner;
    }

    public int getDuration(){
        return duration;
    }

    public AudioClip getAudioClip(){
        string path = interview.getBasePath() + "/Audio/" + audioClipPath;
        print("loading from path: " + path);
        return Resources.Load<AudioClip>(path);
    }

    public AnimatorController getAnimatorController(){
        string path = interview.getBasePath() + "/Animations/" + animatorControllerPath;
        print("loading from path: " + path);
        return Resources.Load<AnimatorController>(path);
    }
}
