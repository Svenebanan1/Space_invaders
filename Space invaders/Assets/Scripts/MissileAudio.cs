using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MissileAudio : MonoBehaviour
{
    GameObject Missile;

    [SerializeField] private AudioSource Missilesound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Missile == null)
        {
            audioSource.Play();
        }
    }

    
}
