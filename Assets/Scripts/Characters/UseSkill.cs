using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public SpriteRenderer selected;
    public Transform target;
    public GameObject range;
    private GameObject player;
    public GameObject enemy;
    public int type;
    public float fRadius = 3.0f;
    public bool active = false;
    public float x;
    public float speedRotation;
    private bool enemyTarget;

    void Start()
    {
        player = gameObject.transform.parent.parent.gameObject;
    }

    void Update()
    {
        if (active && type == 1)
        {
            Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(target.position);
            targetScreenPos.z = 0;
            Vector3 targetToMouseDir = Input.mousePosition - targetScreenPos;

            Vector3 targetToMe = range.transform.position - target.position;
            targetToMe.z = 0;

            Vector3 newTargetToMe = Vector3.RotateTowards(targetToMe, targetToMouseDir, x, 0f);

            range.transform.position = target.position + /*distance from target center to stay at*/  newTargetToMe.normalized;
            float angle = Mathf.Atan2(targetToMe.y, targetToMe.x) * Mathf.Rad2Deg;
            range.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            

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
        if (player.GetComponent<CharacterStats>().actions > 0)
        {
            range.GetComponent<Range>().player = player;
            range.GetComponent<Range>().skill = gameObject;
            range.GetComponent<BoxCollider2D>().size = new Vector2(2, 0.3f);
            range.GetComponent<Range>().attack = true;
            range.SetActive(true);
            active = true;
        }
    }
    public void Action()
    {
        if (enemy != null)
        {
            enemy.GetComponent<EnemyStats>().currentHP -= player.GetComponent<CharacterStats>().str;
            player.GetComponent<CharacterStats>().actions -= 1;
            range.SetActive(false);
            active = false;
        }
    }

}
