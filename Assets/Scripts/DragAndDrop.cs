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
    public bool dropSucces = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    private void OnMouseDown()
    {
        if (gameObject.GetComponent<CharacterStats>().hisTurn)
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
        if (isDragged)
        {
            isDragged = false;
            if (!dropSucces)
            {
                transform.localPosition = spriteDragStartPosition;//new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            }
            dropSucces = false;
            range.SetActive(false);
            gameObject.GetComponent<CharacterStats>().actions -= 1;
            //dragEndedCallback(this);
        }
    }
    
}

