using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePedestal : MonoBehaviour
{
    public void RotateDegrees(float degrees)
    {
        transform.rotation = Quaternion.Euler(0, degrees, 0);
    }
}
