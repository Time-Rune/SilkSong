using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUI : MonoBehaviour
{
    private PlayerData playerStat;
    //public Sprite maskIcon;
    //public Sprite emptyMaskIcon;
    //private List<Image> maskList = new List<Image>();
    //public GameObject HP;
    //public Image maskPrefab;

    private float lastCurrentExp;
    private float lastMaxExp;
    private float mInitBarWidth = 0f;
    //private float baseHP = 100f;

    private void Start()
    {
        playerStat = GameMaster.instance.playerData;
        lastCurrentExp = playerStat.currentExp;
        lastMaxExp = playerStat.maxExp;
        //HP.GetComponent<RectTransform>().sizeDelta = new Vector2(160,20);
        mInitBarWidth = GetComponent<RectTransform>().sizeDelta.x;
        InitNumberOfMask();
    }

    private void Update()
    {
        //Debug.Log("MaxExp = "+ playerStat.maxExp);
        UpdateExpUI();

    }

    public void UpdateExpUI()
    {
        // Update current health with white mask / empty mask sprite
        if (lastCurrentExp != playerStat.currentExp)
        {
            RecalibrateCurrentMask();
        }

        // Update maximum number of permanent mask, used when acquired new mask
        // Currently there is no case of lowering max hp
        if(lastCurrentExp >= playerStat.maxExp)
        {
            playerStat.currentExp -= playerStat.maxExp;
            lastCurrentExp -= playerStat.maxExp;
            playerStat.ability++;
            UpdateExp();
            playerStat.level++;
        }

        // Check for lifeblood hp (the blue temporary bonus masks)


    }

    public void InitNumberOfMask()
    {
        // Delete all masks first
        //foreach (Transform child in transform)
        //{
        //    GameObject.Destroy(child.gameObject);
        //}
        //maskList.Clear();
        float MaxPercentage = (float)lastCurrentExp / (float)lastMaxExp;
        Vector2 s = GetComponent<RectTransform>().sizeDelta;
        s.x = MaxPercentage * mInitBarWidth;
        GetComponent<RectTransform>().sizeDelta = s;


        RecalibrateCurrentMask();
    }

    public void RecalibrateCurrentMask()
    {
        //for (int i = 0; i < playerStat.maxHp; i++)
        //{
        //if (i < playerStat.currentHp)
        //maskList[i].sprite = maskIcon;
        //else
        //maskList[i].sprite = emptyMaskIcon;
        //}
        float hpPercentage = (float)playerStat.currentExp / (float)playerStat.maxExp;
        //Debug.Log("hpPercentage " + hpPercentage);
        //Debug.Log("currentHp " + playerStat.currentHp);
        Vector2 s = GetComponent<RectTransform>().sizeDelta;
        s.x = hpPercentage * mInitBarWidth;
        GetComponent<RectTransform>().sizeDelta = s;
        lastCurrentExp = playerStat.currentExp;
    }
    public void UpdateExp()
    {
        playerStat.maxExp += playerStat.level * 20f;
        lastMaxExp = playerStat.maxExp;
        RecalibrateCurrentMask();
    }
}
