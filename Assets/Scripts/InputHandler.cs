using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class InputHandler : MonoBehaviour
{

    void Update() {
        Debug.Log("Updated");
    }
    void CheckInput() {

        // Left Click
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("Left Click");
        }
    }

}
