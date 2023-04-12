using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using TMPro;

public class InterviewController : MonoBehaviour
{

    private GameObject dummy;
    private Animator animator;
    public TextMeshProUGUI textMesh;

    void Start()
    {
        dummy = GameObject.FindGameObjectWithTag("Player");
        animator = dummy.gameObject.GetComponent<Animator>();
        StartCoroutine(InterviewFlow());
    }

    IEnumerator InterviewFlow()
    {
        for (int i = 0; i < 5; i++){
            debugLog((5 - i).ToString());
            yield return new WaitForSeconds(1);
        }
        animator.runtimeAnimatorController = Resources.Load<AnimatorController>("Animations/Controllers/Capoeira");
    }

    private void debugLog(string text){
        Debug.Log("Stage " + text + ". At time: " + Time.time);
        textMesh.text = text;
    }
}
