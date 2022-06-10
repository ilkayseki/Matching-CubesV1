using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ColourManager : MonoBehaviour
{
    public static ColourManager Instance { get; private set; }
    private int _feverMode = 0;
    private bool _canFever =false;

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

    public void ControlColour()
    {
            for (int i = 1; i < this.transform.childCount-1; i++)
            {
                if ((this.transform.GetChild(i - 1).GetComponent<Renderer>().material.color ==
                     this.transform.GetChild(i).GetComponent<Renderer>().material.color) &&
                    this.transform.GetChild(i).GetComponent<Renderer>().material.color ==
                    this.transform.GetChild(i+1 ).GetComponent<Renderer>().material.color)
                {
                    transform.GetChild(i - 1).GetComponent<Cube>().DestroyGameObject();
                    transform.GetChild(i ).GetComponent<Cube>().DestroyGameObject();
                    transform.GetChild(i + 1).GetComponent<Cube>().DestroyGameObject();
                    _canFever = true;
                }
            }


            FeverCount();
            
            FeverModeControl();
    }

    private void FeverCount()
    {
        if (_canFever)
        {
            _feverMode++;
        }
        else 
        {
            _feverMode = 0;
        }

        _canFever = false;
    }
    
    private void FeverModeControl()
    {
        if (_feverMode == 3)
        {
            _feverMode = 0;
            PlayerController.Instance.EnterFiverMod();
            Debug.Log("Fever Mode");
        }
    }
}
