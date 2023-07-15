using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddButton : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerData playerStat;
    public int type;
    //private bool canUP;
    public void OnEnable()
    {
        //selectFrame = transform.GetChild(0).gameObject
        playerStat = GameMaster.instance.playerData;
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
        if (Input.GetKeyDown(KeyCode.Return) && playerStat.ability >= 1)
        {
            GetUp();
        }
    }
    private void GetUp()
    {
        GameObject selectObjet = null;
        selectObjet = gameObject.transform.GetChild(0).gameObject;
        if(selectObjet.activeSelf)
        {
            switch (type)
            {
                case 1:
                    if(playerStat.nowHPLe < playerStat.maxHPLe)
                    {
                        playerStat.maxHp += 20;
                        playerStat.nowHPLe++;
                        playerStat.ability--;
                    }
                    break;
                case 2:
                    if (playerStat.nowSPLe < playerStat.maxSPLe)
                    {
                        playerStat.maxSilk += 5;
                        playerStat.nowSPLe++;
                        playerStat.ability--;
                    }
                    break;
                case 3:
                    if (playerStat.nowDamageLe < playerStat.maxDamageLe)
                    {
                        playerStat.damage += 5;
                        playerStat.nowDamageLe++;
                        playerStat.ability--;
                    }
                    break;
                default:
                    break;
            }
            
        }
        
        
    }
}
