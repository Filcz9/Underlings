using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    public bool dropable;
    private bool selected;
    //public GameObject Selected;
    private void Update()
    {
        if (dropable)
        {
            if (!selected)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Range")
        {
            dropable = true;
            //collision.gameObject.GetComponentInParent<DragAndDrop>().dropSucces = true;
            //if (collision.gameObject.GetComponentInParent<DragAndDrop>().isDragged) 
            //gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            if (dropable)
            {
                collision.gameObject.GetComponentInParent<DragAndDrop>().dropSucces = true;
            }
            if (collision.gameObject.GetComponentInParent<DragAndDrop>().isDragged) {
                //gameObject.GetComponent<SpriteRenderer>().color = Color.yellow; 
                //Selected.GetComponent<SpriteRenderer>().enabled = true;
                selected = true;
            }
            else if (collision.gameObject.GetComponentInParent<DragAndDrop>().dropSucces = true && !collision.gameObject.GetComponentInParent<DragAndDrop>().isDragged)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                //collision.gameObject.GetComponentInParent<Transform>().localPosition = gameObject.transform.localPosition;
                //Selected.GetComponent<SpriteRenderer>().enabled = false;
                selected = false;
                collision.gameObject.GetComponent<DropCollider>().player.transform.localPosition = gameObject.transform.localPosition;
            }

        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            collision.gameObject.GetComponentInParent<DragAndDrop>().dropSucces = false;
            selected = false;
            //Selected.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (collision.gameObject.tag == "Range")
        {
            //collision.gameObject.GetComponentInParent<DragAndDrop>().dropSucces = true;
            //if (collision.gameObject.GetComponentInParent<DragAndDrop>().isDragged) 
            dropable = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
