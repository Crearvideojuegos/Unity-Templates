using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenColliders : MonoBehaviour
{
    void Awake()
    {
        #if !UNITY_EDITOR
            var meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;
        #endif
    }

}
