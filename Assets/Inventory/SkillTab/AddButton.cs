using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddButton : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject selectFrame;
    private Image image;
    private PlayerData playerStat;
    public int type;
    //private bool canUP;
    public void OnEnable()
    {
        //selectFrame = transform.GetChild(0).gameObject;
        image = GetComponent<Image>();
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
                    playerStat.maxHp += 20;
                    break;
                case 2:
                    playerStat.maxSilk += 5;
                    break;
                case 3:
                    playerStat.damage += 5;
                    break;
                default:
                    break;
            }
            playerStat.ability--;
        }
        
        
    }
}
