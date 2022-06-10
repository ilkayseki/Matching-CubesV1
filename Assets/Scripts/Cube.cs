using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    private bool _isCollected =false;
    
    [SerializeField]
    private int _index;


    [SerializeField]
    private CubeProperties cubeProperties;
    
    [HideInInspector]
    public int colourValue;    
    
    void Start()
    {
        GetComponent<Renderer>().material.color = cubeProperties.cubeColour;
        colourValue = cubeProperties.colourValue;
    }

    public bool GetCollectable()
    {
        return _isCollected;
    }

    public void SetCollectable()
    {
        _isCollected = true;
        transform.localPosition = new Vector3(0, -_index, 0);
    }

    public void SetIndex(int index)
    {
        this._index = index;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall"&& PlayerController.Instance.isFiverMode==false )
        {
            StartCoroutine(nameof(Crushed));
            this.transform.parent = null;
            this.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<BoxCollider>().enabled = false;
            transform.localPosition = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
        }
    }

    IEnumerator Crushed()
    {
        yield return new WaitForSeconds(0.4f);
        Collector.Instance.DecreaseHeight();
    }

    public void DestroyGameObject()
    {
        Collector.Instance.DecreaseHeight();
        Destroy(gameObject);
    }
    
}
