using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LearnSkillButton : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerData playerStat;
    private GameObject showObject;
    public SkillPage here;
    public int cost = 0;
    public int type;
    //private bool canUP;
    public void OnEnable()
    {
        //selectFrame = transform.GetChild(0).gameObject
        showObject = gameObject.transform.GetChild(1).gameObject;
        playerStat = GameMaster.instance.playerData;
        //here = new SkillPage();
        //selectFrame.SetActive(true);
        //UpdateEquipState();
        //GameMaster.instance.OnTalismanChange += UpdateEquipState;
        //CheckIfToolFound();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerStat.copperShard >= cost && !showObject.activeSelf)
        {
            GetUp();
        }
    }
    private void GetUp()
    {
        GameObject selectObjet = null;
        selectObjet = gameObject.transform.GetChild(0).gameObject;
        
        if (selectObjet.activeSelf)
        {
            switch (type)
            {
                case 0:
                    playerStat.SilkDash = true;
                    break;
                case 1:
                    playerStat.StrongDash = true;
                    //playerStat.maxHp += 20;
                    break;
                case 2:
                    playerStat.RocketDash = true;
                    //playerStat.maxSilk += 5;
                    break;
                case 3:
                    playerStat.SlenderNeedle = true;
                    //playerStat.damage += 5;
                    break;
                case 4:
                    playerStat.SpeedyHack = true;
                    break;
                case 5:
                    playerStat.NeedleWave = true;
                    break;
                case 6:
                    playerStat.NeedleJect = true;
                    break;
                case 7:
                    playerStat.SilkBurst = true;
                    break;
                case 8:
                    playerStat.CrazySwivel = true;
                    break;
                case 9:
                    playerStat.SharpDash = true;
                    break;
                default:
                    break;
            }
            cost = (int)here.price[type];
            playerStat.copperShard -= cost;
            showObject.SetActive(true);
        }


    }
}
