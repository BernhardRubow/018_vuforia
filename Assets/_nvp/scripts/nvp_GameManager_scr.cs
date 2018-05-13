using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using newvisionsproject.managers.events;
using newvisionsproject.boardgame.gameLogic;
using newvisionsproject.boardgame.interfaces;
using newvisionsproject.boardgame.enums;

public class nvp_GameManager_scr : MonoBehaviour, IGameManager
{

  // +++ inspector fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  [SerializeField] private nvp_PlayerManager_scr[] playerManagers;


  // +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  private nvp_GameBoard_class gameBoard;
  


  // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  void Awake()
  {
    
  }
  void Start()
  {

  }

  // +++ Interface methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  public void ReportDiceThrow(PlayerColors playerColor, int diceValue){

  }


  // +++ methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  private nvp_PlayerManager_scr GetPlayerByColor(PlayerColors color)
  {
    var pm = playerManagers.Single(x => x.GetPlayerColor() == color);
    return pm;
  }
}

