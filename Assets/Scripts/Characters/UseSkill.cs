using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public SpriteRenderer selected;
    private Transform caster;
    public GameObject range;
    public float skillRange;
    private Vector3 target;
    private float speed = 10.0f;
    private bool active = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private void Start()
    {
        caster = transform.parent.parent;
        target = transform.position;
        //range = GameObject.FindGameObjectWithTag("Range");
    }
    private void Update()
    {
        if (active)
        {
            range.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
            //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target.z = transform.position.z;
            if (range.transform.position.x <= (caster.position.x + skillRange) || range.transform.position.y <= (caster.position.y + skillRange))
            {
                range.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z - mouseDragStartPosition.z));
            }
            Debug.Log(range.transform.position);
        }
    }
    private void OnMouseOver()
    {        
        selected.sortingOrder = 2;
    }
    private void OnMouseExit()
    {
        selected.sortingOrder = 0;
    }
    private void OnMouseDown()
    {
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        
        range.SetActive(true);
        range.transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));//new Vector2(caster.localPosition.x + 1, caster.localPosition.y);
        range.transform.localPosition = new Vector3(range.transform.localPosition.x, range.transform.localPosition.x, 0);
        range.transform.position = new Vector3(0, 0, 0);
        spriteDragStartPosition = transform.localPosition;
        active = true;
    }
}
