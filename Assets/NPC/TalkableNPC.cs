using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkableNPC : InRangeInteractable
{
    [SerializeField] private DialogueGroup[] conversations;
    private GameObject npc;
    private int conversationId; // what are they talking about
    private int dialogueId; // which line or who talk in a conversation
    private bool isTalking;
    
    
    private bool isShopping;
    private bool canOpenShop;

    protected override void Start()
    {
        base.Start();
        // Handle conversationId depend on condition
        conversationId = 0;
        npc = this.gameObject;
    }

    private void Update()
    {
        HandleTalking();
        if (npc.name == "Malig")
        {
            HandleShopping(canOpenShop);
        }
    }

    private void HandleShopping(bool canShop)
    {
        if (canShop && !player.inMenu && !isTalking && !isShopping)
        {
            isShopping = true;
            StopAllCoroutines();
            StartCoroutine(Shopping());
            canOpenShop = false;
        }
    }

    private void HandleTalking()
    {
        bool pressUp = inputMaster.Dialogue.StartTalk.WasPressedThisFrame();
        if (playerInRange && pressUp && !player.inMenu && !isTalking)
        {
            isTalking = true;
            StopAllCoroutines();
            StartCoroutine(Talking());
            interactText.SetActive(false);
        }
    }

    private IEnumerator Shopping()
    {
        player.DisableGameplayControl(true);
        player.disableControlCounter += 1;
        GameObject ShopUI = GameObject.Find("ShopUI-MossyTown").transform.GetChild(0).gameObject;
        ShopUI.SetActive(true);
        while (true)
        {
            if (inputMaster.Dialogue.CloseShop.WasPressedThisFrame())
            {
                break;
            }
            yield return null;
        }
        player.disableControlCounter -= 1;
        player.DisableGameplayControl(false);
        ShopUI.SetActive(false);
        isShopping = false;
    }
    
    private IEnumerator Talking()
    {
        player.DisableGameplayControl(true);
        player.disableControlCounter += 1;
        GameObject dialogueBox = GameObject.Find("DialogueCanvas").transform.GetChild(0).gameObject;
        dialogueBox.SetActive(true);
        TextMeshProUGUI dialogueText = dialogueBox.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        dialogueId = 0;
        string speaker = conversations[conversationId].dialogues[dialogueId].speaker;
        string content = conversations[conversationId].dialogues[dialogueId].content;
        dialogueText.text = "[" + speaker + "]\n" + content;

        while (true)
        {
            if (inputMaster.Dialogue.Continue.WasPressedThisFrame())
            {
                dialogueId += 1;
                if (dialogueId >= conversations[conversationId].dialogues.Length - 1)
                {
                    break;
                }
                else
                {
                    speaker = conversations[conversationId].dialogues[dialogueId].speaker;
                    content = conversations[conversationId].dialogues[dialogueId].content;
                    dialogueText.text = "[" + speaker + "]\n" + content;
                }
            }
            yield return null;
        }

        while (true)
        {
            speaker = conversations[conversationId].dialogues[dialogueId].speaker;
            content = conversations[conversationId].dialogues[dialogueId].content;
            dialogueText.text = "[" + speaker + "]\n" + content;
            if (inputMaster.Dialogue.OpenShop.WasPressedThisFrame())
            {
                canOpenShop = true;
                break;
            }else if (inputMaster.Dialogue.CloseShop.WasPressedThisFrame())
            {
                canOpenShop = false;
                break;
            }
            yield return null;
        }
        
        player.disableControlCounter -= 1;
        player.DisableGameplayControl(false);
        dialogueBox.gameObject.SetActive(false);
        isTalking = false;
        interactText.SetActive(true);
    }
    
}
