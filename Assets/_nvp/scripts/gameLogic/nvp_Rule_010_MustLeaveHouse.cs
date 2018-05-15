using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using newvisionsproject.boardgame.enums;
using newvisionsproject.boardgame.interfaces;
using newvisionsproject.boardgame.dto;

public class nvp_Rule_010_MustLeaveHouse : IRule
{
  private IRule _nextRule;
  public CheckMovesResult CheckRule(PlayerColors playerColor, List<PlayerFigure> playerFigures, int diceValue)
  {
    CheckMovesResult result = null;

    // no player figure is on the game field which means no player figure has movepoint score between 0 and up to 40
    var numberOfFiguresOnBoard = nvp_RuleHelper.CountPlayersOnBoard(playerColor, playerFigures);

    // at least on player figure is in the house
    var numberOfPlayerInTheHouse = nvp_RuleHelper.CountPlayersInHouse(playerColor, playerFigures);

    // general rule
    if (numberOfPlayerInTheHouse == 0 || diceValue < 6) 
			return _nextRule.CheckRule(playerColor, playerFigures, diceValue);

		result = new CheckMovesResult(true, true, "nvp_Rule_6_all_in_house_class: move out");

		// get figure to move
    var pf = playerFigures.Single(x => x.Index == 0 && x.Color == playerColor);

		// enlist the move for display
    result.PossibleMoves = new List<PlayerMove>();
    var move = new PlayerMove();
    move.Color = playerColor;
    move.Index = nvp_RuleHelper.GetNextFigureToLeaveHouse(playerColor, playerFigures).Index;
    move.MovePoints = 0;
    move.GameBoardLocation = pf.OffSet;
    result.PossibleMoves.Add(move);

    return result;
  }

  public IRule SetNextRule(IRule nextRule)
  {
    _nextRule = nextRule;
    return this;
  }
}
