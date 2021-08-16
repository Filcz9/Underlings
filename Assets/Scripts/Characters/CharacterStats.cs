using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update

    public string characterName;
    public bool hisTurn = false;
    public int maxHP;
    public int currentHP;
    public int str;
    public int def;
    public int haste;
    public int actions;
    public int maxActions;
    public int nextLevelExp;
    public int currentExp;

    public TMP_Text Hp;
    public TMP_Text Str;
    public TMP_Text Def;

    private void Start()
    {
        maxActions = actions;
    }
    // Update is called once per frame
    void Update()
    {
        Hp.SetText(currentHP.ToString() + "/" + maxHP.ToString());
        Str.SetText(str.ToString());
        Def.SetText(def.ToString());
        //if (actions == 0) actions = maxActions;
    }
}
