using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityPage: MonoBehaviour
{
    // Start is called before the first frame update
    private enum abilities
    {
        ADDHP,
        ADDSP,
        ADDDAMAGE
    }
    public TextMeshProUGUI Level;
    public TextMeshProUGUI HPmax;
    public TextMeshProUGUI SPmax;
    public TextMeshProUGUI Damage;
    public TextMeshProUGUI Ability;
    public TextMeshProUGUI ExpNum;
    public GameObject HP;
    public GameObject SP;
    public GameObject DA;
    public GameObject EB;
    public GameObject[] Abilities;

    private PlayerData playerStat;
    private int indexAbility;
    private int indexSkill;
    public float widthHP;
    public float widthSP;
    public float widthDA;
    public float widthEB;
    
    private void OnEnable()
    {
        playerStat = GameMaster.instance.playerData;
        indexAbility = (int)abilities.ADDHP;
        widthHP = HP.GetComponent<RectTransform>().sizeDelta.x;
        widthSP = SP.GetComponent<RectTransform>().sizeDelta.x;
        widthDA = DA.GetComponent<RectTransform>().sizeDelta.x;
        widthEB = EB.GetComponent<RectTransform>().sizeDelta.x;
        //SetAllUnActive();
        SetSelectedAbilityActive();
    }
    // Update is called once per frame
    void Update()
    {
        HPmax.text = playerStat.maxHp.ToString();
        SPmax.text = playerStat.maxSilk.ToString();
        Damage.text = playerStat.damage.ToString();
        Level.text = "Level: " + playerStat.level.ToString();
        Ability.text = "Abilities: " + playerStat.ability.ToString();
        ExpNum.text = playerStat.currentExp.ToString() + "/" + playerStat.maxExp.ToString();

        if (Input.GetKeyDown(KeyCode.S))
        {
            SetSelectedAbilityUnActive();
            indexAbility++;
            if (indexAbility >= Abilities.Length)
            {
                indexAbility = (int)abilities.ADDHP;
            }
            SetSelectedAbilityActive();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetSelectedAbilityUnActive();
            indexAbility--;
            if (indexAbility < 0)
            {
                indexAbility = Abilities.Length - 1;
            }
            SetSelectedAbilityActive();
        }
        ShowAll();

    }
    private void SetSelectedAbilityActive()
    {
        GameObject selectedGameObject = null;
        selectedGameObject = Abilities[indexAbility];
        if (selectedGameObject != null)
        {
            selectedGameObject.SetActive(true);
        }
    }
    private void SetSelectedAbilityUnActive()
    {
        GameObject selectedGameObject = null;
        selectedGameObject = Abilities[indexAbility];
        if (selectedGameObject != null)
        {
            selectedGameObject.SetActive(false);
        }
    }
    public void ShowAll()
    {
        float Percentage = playerStat.nowHPLe / playerStat.maxHPLe;
        Vector2 s = HP.GetComponent<RectTransform>().sizeDelta;
        s.x = Percentage * widthHP;
        HP.GetComponent<RectTransform>().sizeDelta = s;

        Percentage = playerStat.nowSPLe / playerStat.maxSPLe;
        s = SP.GetComponent<RectTransform>().sizeDelta;
        s.x = Percentage * widthSP;
        SP.GetComponent<RectTransform>().sizeDelta = s;

        Percentage = playerStat.nowDamageLe / playerStat.maxDamageLe;
        s = DA.GetComponent<RectTransform>().sizeDelta;
        s.x = Percentage * widthDA;
        DA.GetComponent<RectTransform>().sizeDelta = s;

        Percentage = playerStat.currentExp / playerStat.maxExp;
        s = EB.GetComponent<RectTransform>().sizeDelta;
        s.x = Percentage * widthEB;
        EB.GetComponent<RectTransform>().sizeDelta = s;

    }
   
}
