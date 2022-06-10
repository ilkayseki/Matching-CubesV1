using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private Renderer[] _colourIndex;
    
    public CubeProperties[] allColour;

    private int randomInt;

    public int[] colourValues;
    public static GateController Instance { get; private set; }
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
    
    
    public void RandomGate()
    {
        SortColourIndex();
        ChooseRandomColour();
        ChangeColourInCube();
        Collector.Instance.ControlTrailRenderer();
    }

    public void OrderGate()
    {
        SortColourIndex();
        OrderColour();
        ChangeColourInCube();
        Collector.Instance.ControlTrailRenderer();
    }

    private void SortColourIndex()
    {
        _colourIndex = gameObject.GetComponentsInChildren<Renderer>();
    }

    /*
    private void ChooseRandomColour()
    {
        if (_colourIndex.Length != 0)
        {
            for (int i = 0; i < _colourIndex.Length; i++)
            {
                randomInt= Random.Range(0,allColour.Length);
                _colourIndex[i].GetComponent<Renderer>().material.color = allColour[randomInt].cubeColour;
                Debug.Log(allColour[randomInt].cubeColour);
            }
        }
    }
*/
    
    private void ChooseRandomColour()
    {
        if (_colourIndex.Length != 0)
        {
            colourValues = new int[_colourIndex.Length];
            for (int i = 0; i < colourValues.Length; i++)
            {
                randomInt= Random.Range(0,allColour.Length);
                colourValues[i] = randomInt;
            }
            
        }
    }
    
    private void OrderColour()
    {
        if (_colourIndex.Length != 0)
        {
            int temp;
            colourValues = new int[_colourIndex.Length];
            
            for (int i = 0; i < colourValues.Length; i++)
            {
                colourValues[i] = _colourIndex[i].GetComponent<Cube>().colourValue;
            }

            for (int i = 0; i < colourValues.Length - 1; i++)
            {
                for (int j = i; j < colourValues.Length; j++)
                {
                    if (colourValues[i] > colourValues[j])
                    {
                        temp = colourValues[j];
                        colourValues[j] = colourValues[i];
                        colourValues[i] = temp;
                    }

                }

            }
        }
    }

    private void ChangeColourInCube()
    {
        for (int i = 0; i < colourValues.Length; i++)
        {
            switch (colourValues[i])
            {
                case 0:
                    this.gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color = allColour[0].cubeColour;
                    this.gameObject.transform.GetChild(i).GetComponent<Cube>().colourValue = colourValues[i];
                    break;
                case 1:
                    this.gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color = allColour[1].cubeColour;
                    this.gameObject.transform.GetChild(i).GetComponent<Cube>().colourValue = colourValues[i];
                    break;
                case 2:
                    this.gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color = allColour[2].cubeColour;
                    this.gameObject.transform.GetChild(i).GetComponent<Cube>().colourValue = colourValues[i];
                    break;
                    
            }
                
        }
    }


}
    
    

