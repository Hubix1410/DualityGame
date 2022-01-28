using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2DManageState : MonoBehaviour
{
    // 1 is bright
    // 0 is dark

    public int CurrentState = 1;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            switch (CurrentState)
            {
                case 0:
                    CurrentState = 1;
                    break;
                case 1:
                    CurrentState = 0;
                    break;
            }
            Debug.Log(CurrentState);
        }
    }
}
