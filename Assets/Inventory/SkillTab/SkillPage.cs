using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillPage : MonoBehaviour
{
    // Start is called before the first frame update

    private enum skills
    {
        DASHNODA,
        DASHTWO,
        DASHDIS,
        ATTDIS,
        ATTFRE,
        ATTFAR,
        DISNEEDLE,
        SILKBURST,
        DOWNATT,
        DASHDAMA,
    }
    public TextMeshProUGUI Level;
    public TextMeshProUGUI SkillName;
    public TextMeshProUGUI SkillDes;
    public TextMeshProUGUI SkillCost;
    public TextMeshProUGUI Coppershard;

    public Image SkillIcon;
    public Image Copper;

    public GameObject[] Skills;
    public Sprite[] icons;
    public float[] price;
    public string[] SkillNames;
    public string[] SkillDess;

    private PlayerData playerStat;
    private int indexSkill;
    private void OnEnable()
    {
        playerStat = GameMaster.instance.playerData;
        indexSkill = (int)skills.DASHNODA;
        //SetAllUnActive();
        SetSelectedSkillActive();
    }
    // Update is called once per frame
    void Update()
    {
        Level.text = "Level: " + playerStat.level.ToString();
        Coppershard.text = ": " + playerStat.copperShard.ToString();

        if (Input.GetKeyDown(KeyCode.D) && indexSkill == (int)skills.DASHNODA)
        {
            SetSelectedSkillUnActive();
            indexSkill = (int)skills.DASHDAMA;
            SetSelectedSkillActive();
        }
        else if (Input.GetKeyDown(KeyCode.A) && indexSkill == (int)skills.DASHDAMA)
        {
            SetSelectedSkillUnActive();
            indexSkill = (int)skills.DASHNODA;
            SetSelectedSkillActive();
        }
        else if (Input.GetKeyDown(KeyCode.W) && indexSkill != (int)skills.DASHDAMA)
        {
            SetSelectedSkillUnActive();
            indexSkill--;
            if (indexSkill < 0)
            {
                indexSkill = Skills.Length - 2;
            }
            SetSelectedSkillActive();
        }
        else if (Input.GetKeyDown(KeyCode.S) && indexSkill != (int)skills.DASHDAMA)
        {
            SetSelectedSkillUnActive();
            indexSkill++;
            if (indexSkill >= Skills.Length - 1)
            {
                indexSkill = 0;
            }
            SetSelectedSkillActive();
        }
        SkillIcon.gameObject.SetActive(true);
        SkillDes.text = SkillDess[indexSkill];
        SkillIcon.sprite = icons[indexSkill];
        SkillName.text = SkillNames[indexSkill];
        SkillCost.text = "Need:      " + price[indexSkill];
        Copper.gameObject.SetActive(true);

    }
    private void SetSelectedSkillActive()
    {
        GameObject selectedGameObject = null;
        selectedGameObject = Skills[indexSkill];
        if (selectedGameObject != null)
        {
            selectedGameObject.SetActive(true);
        }
    }
    private void SetSelectedSkillUnActive()
    {
        GameObject selectedGameObject = null;
        selectedGameObject = Skills[indexSkill];
        if (selectedGameObject != null)
        {
            selectedGameObject.SetActive(false);
        }
    }
}
