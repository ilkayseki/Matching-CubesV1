using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class TrailRendererController : MonoBehaviour
{
    public static TrailRendererController Instance { get; private set; }
    private void Awake() 
    { 
        #region Singleton
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        #endregion
        
    }


    public void TrailRendererOn(Color c )
    {
        this.gameObject.GetComponent<TrailRenderer>().enabled = true;
        this.gameObject.GetComponent<TrailRenderer>().startColor = c;
        this.gameObject.GetComponent<TrailRenderer>().endColor = c;

    }
    public void TrailRendererOff()
    {
        this.gameObject.GetComponent<TrailRenderer>().enabled = false;
    }
    
}
    
