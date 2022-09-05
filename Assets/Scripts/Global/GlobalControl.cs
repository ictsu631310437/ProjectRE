using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{ 
    public static bool disableInv = false;
    public static bool disablePause = false;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (disablePause == true)
        {
            disableInv = true;
        }
        else
        {
            disableInv = false;

        }
    }
}
