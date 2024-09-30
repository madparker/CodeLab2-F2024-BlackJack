using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManagementScript : MonoBehaviour
{
    private static SingletonManagementScript singletonScript;
    public AudioSource musicPlayer;
    public int timesCheated = 0;
    private void Awake()
    {
        if (singletonScript == null)
        {
            singletonScript = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.Play();
    }

}
