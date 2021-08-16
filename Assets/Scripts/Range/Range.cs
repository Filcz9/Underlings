using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Range : MonoBehaviour
{
    //private List<GameObject> enemies = new List<GameObject>();
    public bool attack;
    public GameObject player;
    public GameObject skill = null;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && skill.GetComponent<UseSkill>().active)
        {
            skill.GetComponent<UseSkill>().Action();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && attack)
        {
            collision.gameObject.GetComponent<EnemyStats>().isTarget = true;
            skill.GetComponent<UseSkill>().enemy = collision.gameObject;
            //Debug.Log(collision.gameObject.GetComponentcollision.gameObject<EnemyStats>().isTarget);

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && attack)
        {
            collision.gameObject.GetComponent<EnemyStats>().isTarget = false;
            skill.GetComponent<UseSkill>().enemy = null;
            //Debug.Log(collision.gameObject.GetComponent<EnemyStats>().isTarget);
        }
    }
    private void Attack(GameObject enemy, GameObject player)
    {
        enemy.GetComponent<EnemyStats>().currentHP -= player.GetComponent<CharacterStats>().str;
    }
}
