﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using newvisionsproject.boardgame.dto;
using newvisionsproject.boardgame.enums;
using newvisionsproject.boardgame.interfaces;
using UnityEngine;

public class nvp_Rule_5to1_all_in_house_class : IRule
{
  IRule _nextRule;
  int _numberOfTries;
  public CheckMovesResult CheckRule(PlayerColors playerColor, List<PlayerFigure> playerFigures, int diceNumber)
  {
    // no player figure is on the game field which means no player figure has movepoint score between 0 and up to 40
    var numberOfFiguresOnBoard = nvp_RuleHelper.CountPlayersOnBoard(playerColor, playerFigures);

    // at least on player figure is in the house
    var numberOfPlayerInTheHouse = nvp_RuleHelper.CountPlayersInHouse(playerColor, playerFigures);

    // general rule
    if (numberOfFiguresOnBoard > 0 || numberOfPlayerInTheHouse == 0) return _nextRule.CheckRule(playerColor, playerFigures, diceNumber);

    CheckMovesResult result = null;
    _numberOfTries++;
    if(_numberOfTries >= 3 && diceNumber < 6){
      // used all free rolls
      result = new CheckMovesResult(false, false, "nvp_Rule_5to1_all_in_house_class");
      _numberOfTries = 0;
      return result;
    }

    if(diceNumber == 6){
      result = new CheckMovesResult(true, true, "nvp_Rule_5to1_all_in_house_class");
      _numberOfTries = 0;
      return result;
    }
    else{      
      result = new CheckMovesResult(false, true, "nvp_Rule_5to1_all_in_house_class");
      return result;
    }
  }

  public IRule SetNextRule(IRule nextRule)
  {
    _nextRule = nextRule;
    return this;
  }
}
