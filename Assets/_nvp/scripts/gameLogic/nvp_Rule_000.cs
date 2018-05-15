using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.boardgame.gameLogic;
using newvisionsproject.boardgame.enums;
using newvisionsproject.boardgame.dto;
using newvisionsproject.boardgame.interfaces;

public class nvp_Rule_000_MustLeaveStart : IRule
{
  private IRule _nextRule;
  public CheckMovesResult CheckRule(PlayerColors playerColor, List<PlayerFigure> playerFigures, int diceNumber)
  {
    if(nvp_RuleHelper.IsFieldOccupiedByOwnFigure(playerColor, playerFigures, 0)){
      if(nvp_RuleHelper.CanExitStart(playerColor, playerFigures, diceNumber)){
        var pf = nvp_RuleHelper.GetPlayerFigureOnField(playerColor, playerFigures, 0);
        var result = new CheckMovesResult(true, false, "");
        
        var pm = new PlayerMove();
        pm.Color = playerColor;
        pm.Index = pf.Index;
        pm.MovePoints = diceNumber;

        result.PossibleMoves = new List<PlayerMove>();
        result.PossibleMoves.Add(pm);  
        return result;      
      }
      else
      {
        var result = new CheckMovesResult(false, false, "");
        return result;
      }      
    }
    else {
      return _nextRule.CheckRule(playerColor, playerFigures, diceNumber);
    }
  }

  public IRule SetNextRule(IRule nextRule)
  {
    _nextRule = nextRule;
    return this;
  }
}
