using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioControl : MonoBehaviour
{    
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("startMusic", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) audioSource.Stop();
    }
    
    public void startMusic()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
