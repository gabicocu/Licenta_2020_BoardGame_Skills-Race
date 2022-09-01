using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAudioInScenes : MonoBehaviour
{
   void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);        
    }
}
