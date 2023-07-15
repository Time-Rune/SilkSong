using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [Header("Stat")]
    public int maxHp = 100;
    public int currentHp = 100;
    public int lifebloodHp = 0;
    public int currentSilk = 0;
    public int maxSilk = 20;
    public int silkHeal = 20;
    public int damage = 10;
    public float moveSpeed = 7f;
    public float jumpForce = 12f;
    public float dashForce = 20f;
    public int maxDash = 1;
    public int extraJump = 0;
    public float dashTime = 0.25f;
    public float enemyKnockbackPower = 5f;
    public float selfKnockbackPower = 1f;
    public float attackCooldown = 0.15f;
    public float parryWindow = 0.25f;
    public float parryCooldown = 1f;
    public float toolCooldown = 0.35f;
    public float level = 1f;
    public float ability = 0f;
    public float currentExp = 0f;
    public float maxExp = 100f;
    public float maxHPLe = 10f;
    public float nowHPLe = 0f;
    public float maxSPLe = 10f;
    public float nowSPLe = 0f;
    public float maxDamageLe = 10f;
    public float nowDamageLe = 0f;

    [Header("Location")]
    public string respawnScene = "DirtCave0";
    public string respawnChairName = "";
    public Vector3 respawnPos = Vector3.zero; // Use when there is no chair

    [Header("Inventory")]
    public int copperShard = 0;
    public int scaleShard = 0;

    [Header("Skill")]
    public bool SilkDash = false;
    public bool StrongDash = false;
    public bool RocketDash = false;
    public bool SlenderNeedle = false;
    public bool SpeedyHack = false;
    public bool NeedleWave = false;
    public bool NeedleJect = false;
    public bool SilkBurst = false;
    public bool CrazySwivel = false;
    public bool SharpDash = false;

    public int[] inventoryItemAmount; // all item

    public List<Talisman.TalismanName> foundTalismans = new List<Talisman.TalismanName>();
    public Talisman.TalismanName equippedTalismanName = Talisman.TalismanName.wanderer;
    public float[] redToolsCurrentCharge; // all tool
    public List<RedTool.ToolName> foundRedTools = new List<RedTool.ToolName>();
    public List<RedTool.ToolName> equippedRedTools = new List<RedTool.ToolName>();
    public int selectedRedToolId;
    public List<BlueTool.ToolName> foundBlueTools = new List<BlueTool.ToolName>();
    public List<BlueTool.ToolName> equippedBlueTools = new List<BlueTool.ToolName>();
    public List<YellowTool.ToolName> foundYellowTools = new List<YellowTool.ToolName>();
    public List<YellowTool.ToolName> equippedYellowTools = new List<YellowTool.ToolName>();

    [Header("Misc")]
    public float stunTime = 0.4f;
    public float iFrameTime = 1.5f;

    public void ResetToNewGameState()
    {
        maxHp = 100;
        currentHp = 100;
        lifebloodHp = 0;
        currentSilk = 0;
        maxSilk = 20;
        silkHeal = 20;
        damage = 10;
        moveSpeed = 7f;
        jumpForce = 12f;
        dashForce = 20f;
        maxDash = 1;
        extraJump = 0;
        dashTime = 0.25f;
        enemyKnockbackPower = 5f;
        selfKnockbackPower = 1f;
        attackCooldown = 0.15f;
        parryWindow = 0.25f;
        parryCooldown = 1f;
        copperShard = 0;
        scaleShard = 0;
        level = 1f;
        ability = 0f;
        currentExp = 0f;
        maxExp = 100f;
        maxHPLe = 10f;
        nowHPLe = 0f;
        maxSPLe = 10f;
        nowSPLe = 0f;
        maxDamageLe = 10f;
        nowDamageLe = 0f;
        stunTime = 0.4f;
        iFrameTime = 1.5f;
        respawnChairName = "";
        respawnScene = "DirtCave0";
        respawnPos = Vector3.zero;
        toolCooldown = 0.35f;
    }

    //public void CopyStatFromThis(PlayerStatSO statToCopy)
    //{
    //    maxHp = statToCopy.maxHp;
    //    currentHp = statToCopy.currentHp;
    //    currentSilk = statToCopy.currentSilk;
    //    maxSilk = statToCopy.maxSilk;
    //    silkHeal = statToCopy.silkHeal;
    //    damage = statToCopy.damage;
    //    moveSpeed = statToCopy.moveSpeed;
    //    jumpForce = statToCopy.jumpForce;
    //    dashForce = statToCopy.dashForce;
    //    maxDashCount = statToCopy.maxDashCount;
    //    dashTime = statToCopy.dashTime;
    //    enemyKnockbackPower = statToCopy.enemyKnockbackPower;
    //    selfKnockbackPower = statToCopy.selfKnockbackPower;
    //    attackCooldown = statToCopy.attackCooldown;
    //    parryWindow = statToCopy.parryWindow;
    //    parryCooldown = statToCopy.parryCooldown;
    //    copperShard = statToCopy.copperShard;
    //    scaleShard = statToCopy.scaleShard;
    //    stunTime = statToCopy.stunTime;
    //    iFrameTime = statToCopy.iFrameTime;
    //}
}
