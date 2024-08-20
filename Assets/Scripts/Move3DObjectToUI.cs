using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3DObjectToUI : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Transform objectToMove;
    public RectTransform uiTarget;
    public float nearPlaneOffset = 5f;
    public float movementSpeed = 50.0f;

    public Action OnMoveComplete;

    public AudioSource pickUpSFX;

    private void Start()
    {
        objectToMove = this.gameObject.transform;

        GameObject uiGameObject = GameObject.Find("UITargetImage");
        if (uiGameObject != null)
        {
            uiTarget = uiGameObject.GetComponent<RectTransform>();
            if (uiTarget == null)
            {
                Debug.LogError("No RectTransform found on the GameObject named UITargetImage");
            }
        }
        pickUpSFX.Play();
    }

    void Update()
    { 
        Vector3 uiTargetWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(uiTarget.position.x, uiTarget.position.y, Camera.main.nearClipPlane + nearPlaneOffset));
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, uiTargetWorldPos, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(objectToMove.position, uiTargetWorldPos) < 0.1f)
        {
            meshRenderer.enabled = false;
            OnMoveComplete.Invoke();
            OnMoveComplete = null;
            enabled = false;
        }
    }
}
