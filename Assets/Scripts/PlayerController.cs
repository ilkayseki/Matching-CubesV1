using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    
    [SerializeField]
    private float _runSpeed;
    [SerializeField] 
    private float _swipeSpeed;

    public bool isFiverMode = false;
    
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
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * _swipeSpeed * Time.deltaTime;
        this.transform.Translate(horizontal,0,_runSpeed*Time.deltaTime);
    }

    public void EnterFiverMod()
    {
        isFiverMode = true;
        Time.timeScale = 2;
        StartCoroutine(nameof(ExitFiverMode));
    }

    IEnumerator ExitFiverMode()
    {
        yield return new WaitForSeconds(2f);
        isFiverMode = false;
        Time.timeScale = 1f;
    }
}
