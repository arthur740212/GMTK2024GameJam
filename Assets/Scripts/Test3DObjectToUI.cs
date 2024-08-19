using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3DObjectToUI : MonoBehaviour
{
    public Transform objectToMove;
    public RectTransform uiTarget;
    public float nearPlaneOffset = 2f;
    public float movementSpeed = 20.0f;

    void Update()
    { 
        Vector3 uiTargetWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(uiTarget.position.x, uiTarget.position.y, Camera.main.nearClipPlane + nearPlaneOffset));
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, uiTargetWorldPos, movementSpeed * Time.deltaTime);
    }
}
