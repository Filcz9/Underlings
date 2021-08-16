using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameController : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> TemporaryList = new List<GameObject>();
    public Stack<GameObject> participants = new Stack<GameObject>();
    public Stack<GameObject> temporaryStack = new Stack<GameObject>();
    public Stack<GameObject> Portraits = new Stack<GameObject>();
    private GameObject current;
    private int portraitsCount;

    void Start()
    {
        //Todo: Include enemies
        players = GameObject.FindGameObjectsWithTag("Player").ToList();
        players = players.OrderBy(x => x.GetComponent<CharacterStats>().haste).ToList();
        foreach (var portrait in players)
        {
            Portraits.Push(portrait.transform.Find("Portrait").gameObject);
        }
        portraitsCount = Portraits.Count();
        participants = new Stack<GameObject>(players);
        current = participants.Pop();
        current.GetComponent<CharacterStats>().hisTurn = true;
        temporaryStack.Push(current);
        InstantiatePortraits();
    }

    void Update()
    {

        if(current.GetComponent<CharacterStats>().actions == 0)
        {
            current.GetComponent<CharacterStats>().hisTurn = false;
            current.GetComponent<CharacterStats>().actions = current.GetComponent<CharacterStats>().maxActions;
            current = participants.Pop();
            current.GetComponent<CharacterStats>().hisTurn = true;
            temporaryStack.Push(current);
            if (participants.Count() == 0)
            {
                foreach (var item in temporaryStack)
                    TemporaryList.Add(item);
                TemporaryList.Reverse();
                FillPortraitStack(TemporaryList);
                //foreach (var item in TemporaryList)
                participants = new Stack<GameObject>(temporaryStack);
                temporaryStack.Clear();
                InstantiatePortraits();
            }
        }
    }
    void InstantiatePortraits()
    {
        for(int i = 0; i < portraitsCount; i++)
        {
            GameObject childObject = Instantiate(Portraits.Pop());
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localPosition = new Vector3(i, 0);
        }
    }
    void FillPortraitStack(List<GameObject> players)
    {
        foreach (var portrait in players)
        {
            Portraits.Push(portrait.transform.Find("Portrait").gameObject);
        }
        //Portraits = new Stack<GameObject>(players);
        portraitsCount = Portraits.Count();
    }
}
