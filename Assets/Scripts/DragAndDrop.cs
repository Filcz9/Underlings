using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    public delegate void DragEndedDelegate(DragAndDrop draggableObject);

    public DragEndedDelegate dragEndedCallback;
    public GameObject range;
    public bool isDragged = false;
    public bool dropped = false;
    public bool dropSucces = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    public Vector3 spriteDragEndPosition;

    private void OnMouseDown()
    {
        if (gameObject.GetComponent<CharacterStats>().actions > 0)
        {
            isDragged = true;
            range.GetComponent<Transform>().localPosition = gameObject.transform.localPosition;
            range.GetComponent<BoxCollider2D>().size = new Vector2(gameObject.GetComponent<CharacterStats>().haste, gameObject.GetComponent<CharacterStats>().haste);
            range.SetActive(true);
            mouseDragStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            spriteDragStartPosition = transform.localPosition;
        }
    }
    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPosition - (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z+.5f)) - mouseDragStartPosition);
        }

    }
    private void OnMouseUp()
    {
        isDragged = false;
        dropped = true;
        if (!dropSucces)
        {
            transform.localPosition = spriteDragStartPosition;
        }
        dropSucces = false;
        range.SetActive(false);
        dragEndedCallback(this);
    }
    public void CheckEndField(Vector3 end)
    {
        Debug.Log(end);
        Debug.Log(spriteDragStartPosition);
        if(end != spriteDragStartPosition) gameObject.GetComponent<CharacterStats>().actions -= 1;
    }
    
}

