using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class SkillPage : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Level;
    public TextMeshProUGUI HPmax;
    public TextMeshProUGUI SPmax;
    public TextMeshProUGUI Damage;
    public TextMeshProUGUI Ability;
    public GameObject[] bottons;
    private PlayerData playerStat;
    private int index;
    private void OnEnable()
    {
        playerStat = GameMaster.instance.playerData;
        index = 0;
        //SetAllUnActive();
        SetSelectedButtonActive();
    }
    // Update is called once per frame
    void Update()
    {
        HPmax.text = playerStat.maxHp.ToString();
        SPmax.text = playerStat.maxSilk.ToString();
        Damage.text = playerStat.damage.ToString();
        Level.text = "Level: " + playerStat.level.ToString();
        Ability.text = "Abilities: " + playerStat.ability.ToString();
        if(Input.GetKeyDown(KeyCode.S))
        {
            SetSelectedButtonUnActive();
            index++;
            if(index >= bottons.Length)
            {
                index = 0;
            }
            SetSelectedButtonActive();
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            SetSelectedButtonUnActive();
            index--;
            if (index < 0)
            {
                index = bottons.Length - 1;
            }
            SetSelectedButtonActive();
        }
    }
    private void SetSelectedButtonActive()
    {
        GameObject selectedGameObject = null;
        selectedGameObject = bottons[index];
        if(selectedGameObject != null)
        {
            selectedGameObject.SetActive(true);
        }
    }
    private void SetSelectedButtonUnActive()
    {
        GameObject selectedGameObject = null;
        selectedGameObject = bottons[index];
        if (selectedGameObject != null)
        {
            selectedGameObject.SetActive(false);
        }
    }
}
