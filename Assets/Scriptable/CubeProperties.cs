using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Cube Type", menuName = "Cube Type")] 

public class CubeProperties : ScriptableObject
{
    public Color cubeColour= Color.yellow;
    public int colourValue;
}
