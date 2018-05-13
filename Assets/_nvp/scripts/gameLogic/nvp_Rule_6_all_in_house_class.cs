using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using newvisionsproject.boardgame.enums;
using newvisionsproject.boardgame.interfaces;
using newvisionsproject.boardgame.dto;

public class nvp_Rule_6_all_in_house_class : IRule
{
  private IRule _nextRule;
  public CheckMovesResult CheckRule(PlayerColors playerColor, List<PlayerFigure> playerFigures, int diceValue)
  {
    CheckMovesResult result = null;

    // no player figure is on the game field which means no player figure has movepoint score between 0 and up to 40
    var numberOfFiguresOnBoard = playerFigures.Count(
      x => x.MovePoints >= 0
      && x.MovePoints <= 40
      && x.Color == playerColor);

    // at least on player figure is in the house
    var numberOfPlayerInTheHouse = playerFigures.Count(
      x => x.MovePoints < 0
      && x.Color == playerColor);

    // general rule
    if (numberOfFiguresOnBoard > 0 || numberOfPlayerInTheHouse == 0 || diceValue < 6) 
			return _nextRule.CheckRule(playerColor, playerFigures, diceValue);

		result = new CheckMovesResult(true, "nvp_Rule_6_all_in_house_class: move out");
		result.AdditionalThrowGranted = true;

		// get figure to move
    var pf = playerFigures.Single(x => x.Index == 0 && x.Color == playerColor);

		// enlist the move for display
    result.PossibleMoves = new List<PlayerMove>();
    var move = new PlayerMove();
    move.Color = playerColor;
    move.Index = 0;
    move.MovePoints = 0;
    move.GameBoardLocation = pf.OffSet;
    result.PossibleMoves.Add(move);

    return result;


    // numberOfTries++;
    // if (numberOfTries >= 3)
    // {
    //   if (diceValue < 6)
    //   {
		// 		numberOfTries = 0;
    //     // all rolls are used to get a figure out of the house
    //     // player can't do anything so exit here
    //     result = new CheckMovesResult(false, "nvp_Rule_6_all_in_house_class: next player");
    //     result.AdditionalThrowGranted = false;
    //     return result;
    //   }
    // }
    // else
    // {
		// 	if(diceValue < 6)
		// 	{
		// 		// all rolls are used to get a figure out of the house
    //     // player can't do anything so exit here
    //     result = new CheckMovesResult(false, "nvp_Rule_6_all_in_house_class: additional roll");
    //     result.AdditionalThrowGranted = true;
    //     return result;
		// 	}
    // }

		

    

    
  }

  public IRule SetNextRule(IRule nextRule)
  {
    _nextRule = nextRule;
    return this;
  }
}
