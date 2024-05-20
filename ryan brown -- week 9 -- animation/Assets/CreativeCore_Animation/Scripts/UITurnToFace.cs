using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITurnToFace : MonoBehaviour
{
    public Transform cameraPosition;
    private Vector3 offsetPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 faceDirection = cameraPosition.position - transform.position;
        transform.rotation = Quaternion.LookRotation(faceDirection, Vector3.up);
    }
}
