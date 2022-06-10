using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public static PowerUps Instance { get; private set; }

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
    
    public void EnterFaster()
    {
        Time.timeScale = 2f;
    }
    public void ExitFaster()
        
    {
        Time.timeScale = 1f;
    }

}
