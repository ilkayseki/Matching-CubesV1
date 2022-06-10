using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public static Collector Instance { get; private set; }
    
    [SerializeField]
    private GameObject _mainCube;

    [SerializeField]
    private int _height;
  
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube"&&other.gameObject.GetComponent<Cube>().GetCollectable()==false)
        {
            IncreaseHeight();
            other.gameObject.GetComponent<Cube>().SetIndex(_height);
            other.gameObject.transform.parent = _mainCube.transform;
            other.gameObject.GetComponent<Cube>().SetCollectable();
            SetHeight();
            DestroyControl();
            ControlTrailRenderer();
        }

        else if (other.gameObject.tag == "Wall" && _height == 0)
        {
            Time.timeScale = 0;
        }

        else if (other.gameObject.tag == "RandomGate")
        {
            GateController.Instance.RandomGate();
        }
        else if (other.gameObject.tag == "OrderGate")
        {
            GateController.Instance.OrderGate();
        }
        
        else if (other.gameObject.tag == "Faster")
        {
            PowerUps.Instance.EnterFaster();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Faster")
        {
            PowerUps.Instance.ExitFaster();
        }
    }

    public void DestroyControl()
    {
        if (_height >= 3)
        {
            ColourManager.Instance.ControlColour();
        }
    }

    public void IncreaseHeight()
    {
        _height += 1;
    }
    
    public void DecreaseHeight()
    {
        _height--;
        SetHeight();
        ControlTrailRenderer();
    }

    public void SetHeight()
    {
        PlayerController.Instance.transform.position = new Vector3(transform.position.x, _height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -_height, 0f);
    }

    public void ControlTrailRenderer()
    {
        if (_height == 0)
        {
            TrailRendererController.Instance.TrailRendererOff();
        }
        else
        {
            TrailRendererController.Instance.TrailRendererOn(_mainCube.transform.GetChild(_mainCube.transform.childCount-1).GetComponent<Renderer>().material.color);
        }
    }
    
}
