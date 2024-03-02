using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyInEditor : MonoBehaviour
{
    private void Awake() 
    {
        // #if !UNITY_EDITOR
        //     this.gameObject.SetActive(false);
        // #endif
    }
}
