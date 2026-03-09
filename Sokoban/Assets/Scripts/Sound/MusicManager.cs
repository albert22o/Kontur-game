using UnityEngine;
using System.Collections;
using System;
using Unity.Mathematics;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip[] playList;         
    [SerializeField] AudioSource[] audioSource;    

    [SerializeField] double delay = 0.1;           
    [SerializeField, Range(0.1f, 3f)] double fadeDuration = 0.1f;  

    double startTime = 0;                         

    int currentClip = 0; 
    int currentSource = 0;                    

    void Start()
    {
        startTime = AudioSettings.dspTime + delay;  
        PlayClip(0);
        StartCoroutine(ChangeTrack());
    }

    private IEnumerator ChangeTrack()
    {
        while (true)
        {
            var waitTime = UnityEngine.Random.Range(2, 10);
            yield return new WaitForSeconds(waitTime);
            PlayClip((currentClip + 1) % playList.Length);
        }
    }

    public void PlayClip(int index) 
    {
        if (index >= playList.Length) 
            return;

        currentClip = index;
        startTime = AudioSettings.dspTime + delay;  
    }

    private void LateUpdate()
    {
        if (AudioSettings.dspTime > startTime - 1)  
        {
            StopCoroutine(ScheduleMusicClip());                   
            StartCoroutine(ScheduleMusicClip());   
        }
    }

    IEnumerator ScheduleMusicClip() 
    {
        var elapsedTime = 0f; 

        audioSource[currentSource].clip = playList[currentClip];  
        audioSource[currentSource].PlayScheduled(startTime);   

        var clipDuration = (double) playList[currentClip].samples / playList[currentClip].frequency;
        startTime = startTime + clipDuration;

        currentSource = 1 - currentSource;  
        if ((audioSource[currentSource].clip != null) && (audioSource[1 - currentSource].clip != null))
        {
            while (elapsedTime < fadeDuration)  
            {
     
                audioSource[1 - currentSource].volume = Mathf.Lerp(0, 1, (float)(elapsedTime / fadeDuration));
                audioSource[currentSource].volume = Mathf.Lerp(1, 0, (float)(elapsedTime / fadeDuration));

                elapsedTime += Time.deltaTime;  
                yield return null;
            }
        }
    }
}