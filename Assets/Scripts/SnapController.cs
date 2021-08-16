using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<DragAndDrop> draggableObjects;
    public float snapRange = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(DragAndDrop draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Field");
        //Debug.Log(gameObjects);
        foreach (GameObject game in gameObjects)
        {
            snapPoints.Add(game.transform);
        }
    }
    private void OnDragEnded(DragAndDrop draggable)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach(Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }
        if(closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
        }
    }

}
