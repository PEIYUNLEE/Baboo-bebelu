﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    protected IPlayer parent = null;
    public IPlayer Parent { set { if (parent == null) parent = value; } }
    public string PlayerInputString { set { playerInputString = value; } }
    [SerializeField]
    private string playerInputString;
    [SerializeField]
    private List<PlayerInputInfo> inputs= new List<PlayerInputInfo> ( );
    [SerializeField]
    private List<PlayerInputInfo> inputResults = new List<PlayerInputInfo>( );
    public List<PlayerInputInfo> InputResults { get { return inputResults; } }
    private bool bReset,bflag;
    

    // Start is called before the first frame update
    void Start()
    {
        bReset = false;
        bflag=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.iGameSystem.inputSystem.ConditionType==(int)EConditionType.INPUT)
        {
            GetPlayerInput();
        }
        else if (parent.iGameSystem.inputSystem.ConditionType==(int)EConditionType.ANIMATION&&bflag)
        {
            bReset = false;
            inputResults = SendResult(inputs);
            if(inputResults.Count>0)
                parent.uIManager.ShowColorResult(inputResults,playerInputString);
            bflag=false; //已進入過animation
        }
        else if (parent.iGameSystem.inputSystem.ConditionType==(int)EConditionType.READY&&!bflag)
        {
            if(inputResults.Count>0)
                parent.uIManager.ShowColorResult(playerInputString); //清除
            bflag=true; //已進入過ready
        }
    }

    void GetPlayerInput()
    {
        if (!bReset)
        {
            inputs.Clear();
            bReset = true;
        }
   
        if (Input.GetButtonDown(playerInputString + "ORANGE"))
        {
            inputs.Add(new PlayerInputInfo(EColor.ORANGE,parent.iGameSystem.musicManager.GetSongPosition,EInputCondition.NONE));
        }
        if (Input.GetButtonDown(playerInputString + "GREEN"))
        {
            inputs.Add(new PlayerInputInfo(EColor.GREEN, parent.iGameSystem.musicManager.GetSongPosition,EInputCondition.NONE));
        }
        if (Input.GetButtonDown(playerInputString + "PURPLE"))
        {
            inputs.Add(new PlayerInputInfo(EColor.PURPLE, parent.iGameSystem.musicManager.GetSongPosition,EInputCondition.NONE));
        }

        if (Input.GetButtonDown(playerInputString + "RED"))
        {
            inputs.Add(new PlayerInputInfo(EColor.RED, parent.iGameSystem.musicManager.GetSongPosition,EInputCondition.NONE));
        }
        if (Input.GetButtonDown(playerInputString + "YELLOW"))
        {
            inputs.Add(new PlayerInputInfo(EColor.YELLOW, parent.iGameSystem.musicManager.GetSongPosition,EInputCondition.NONE));
        }
        if (Input.GetButtonDown(playerInputString + "BLUE"))
        {
            inputs.Add(new PlayerInputInfo(EColor.BLUE, parent.iGameSystem.musicManager.GetSongPosition,EInputCondition.NONE));
        }

    }

    List<PlayerInputInfo> SendResult(List<PlayerInputInfo> inputs)
    {
        return parent.iGameSystem.inputSystem.GetInputResult(inputs);
    }

}