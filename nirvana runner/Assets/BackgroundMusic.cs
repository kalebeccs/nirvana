using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource sfx;
    GameObject results;

    void Awake()
    { 
        results = GameObject.Find("Results");
        sfx = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (results.activeSelf)
        {
            sfx.Stop();
        }
    }
}
