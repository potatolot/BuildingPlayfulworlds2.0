using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private List<Animator> animators;

    [SerializeField] private GameObject dayLight;
    [SerializeField] private GameObject nightLight;

    [SerializeField] private LightSwitch lightSwitch;

    [SerializeField] private AudioSource worldAudio;
    [SerializeField] private List<AudioClip> audioClips;

    private bool isDay = true;
    private bool playerEntered = false;

    private void OnTriggerEnter(Collider collision)
    {
        playerEntered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerEntered = false;
    }

    private void Update()
    {
        if (isDay && playerEntered && Input.GetKeyDown(KeyCode.Mouse0))
            SetToNight();

        else if (!isDay && playerEntered && Input.GetKeyDown(KeyCode.Mouse0))
            SetToDay();
        

    }

    private void SetToDay()
    {
        foreach (Animator animation in animators)
        {
            animation.SetBool("Day", true);
            print(animation.GetBool("Day"));
        }
        nightLight.SetActive(false);
        dayLight.SetActive(true);

        worldAudio.clip = audioClips[0];
        worldAudio.volume = 1;
        worldAudio.Play();

        lightSwitch.SetToDay();
        isDay = true;
    }

    private void SetToNight()
    {
        foreach(Animator animation in animators)
        {
            animation.SetBool("Day", false);
            print(animation.GetBool("Day"));
        }

        nightLight.SetActive(false);
        dayLight.SetActive(true);

        worldAudio.clip = audioClips[1];
        worldAudio.volume = 0.02f;
        worldAudio.Play();

        lightSwitch.SetToNight();
        isDay = false;
    }
}
