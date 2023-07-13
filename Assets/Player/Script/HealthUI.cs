using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private PlayerData playerStat;
    //public Sprite maskIcon;
    //public Sprite emptyMaskIcon;
    //private List<Image> maskList = new List<Image>();
    public GameObject HP;
    //public Image maskPrefab;

    private int lastCurrentHp;
    private int lastMaxHp;
    private int lastLifebloodHp;
    private float mInitBarWidth = 0f;
    //private float baseHP = 100f;

    private void Start()
    {
        playerStat = GameMaster.instance.playerData;
        lastCurrentHp = playerStat.currentHp;
        lastMaxHp = playerStat.maxHp;
        lastLifebloodHp = playerStat.lifebloodHp;
        //HP.GetComponent<RectTransform>().sizeDelta = new Vector2(160,20);
        mInitBarWidth = HP.GetComponent<RectTransform>().sizeDelta.x;
        InitNumberOfMask();
    }

    private void Update()
    {
        //Debug.Log("size.x = "+ HP.GetComponent<RectTransform>().sizeDelta.x);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        // Update current health with white mask / empty mask sprite
        if (lastCurrentHp != playerStat.currentHp)
        {
            RecalibrateCurrentMask();
        }

        // Update maximum number of permanent mask, used when acquired new mask
        // Currently there is no case of lowering max hp
        if (lastMaxHp < playerStat.maxHp)
        {
            InitNumberOfMask();
            lastMaxHp = playerStat.maxHp;
        }

        // Check for lifeblood hp (the blue temporary bonus masks)


        //// Update according to max hp
        //if (playerStat.maxHp + playerStat.lifebloodHp > maskList.Count)
        //    IncreaseNumberOfMask();
        //if (playerStat.maxHp + playerStat.lifebloodHp < maskList.Count)
        //    InitNumberOfMask();

        ////TODO: Possible room for optimization
        //// Update according to current hp
        //for (int i = 0; i < maskList.Count; i++)
        //{
        //    if (i < playerStat.currentHp)
        //        maskList[i].sprite = maskIcon;
        //    else
        //        maskList[i].sprite = emptyMaskIcon;
        //}
    }

    public void InitNumberOfMask()
    {
        // Delete all masks first
        //foreach (Transform child in transform)
        //{
        //    GameObject.Destroy(child.gameObject);
        //}
        //maskList.Clear();
        float MaxPercentage = (float)playerStat.maxHp / (float)lastMaxHp;
        Vector2 s = HP.GetComponent<RectTransform>().sizeDelta;
        s.x = MaxPercentage * mInitBarWidth;
        HP.GetComponent<RectTransform>().sizeDelta = s;


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
        float hpPercentage = (float)playerStat.currentHp/ (float)playerStat.maxHp;
        //Debug.Log("hpPercentage " + hpPercentage);
        //Debug.Log("currentHp " + playerStat.currentHp);
        Vector2 s = HP.GetComponent<RectTransform>().sizeDelta;
        s.x = hpPercentage * mInitBarWidth;
        HP.GetComponent<RectTransform>().sizeDelta = s;
        lastCurrentHp = playerStat.currentHp;
    }
}