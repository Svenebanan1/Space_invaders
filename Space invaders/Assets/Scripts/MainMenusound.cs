using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenusound : MonoBehaviour
{
    [SerializeField] private AudioSource MusicMain;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
