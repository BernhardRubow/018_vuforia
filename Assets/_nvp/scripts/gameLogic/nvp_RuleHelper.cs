using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using newvisionsproject.boardgame.dto;
using newvisionsproject.boardgame.enums;

public static class nvp_RuleHelper {

	public static int CountPlayersOnBoard(PlayerColors playerColor, List<PlayerFigure> playerFigures){
		int count = playerFigures.Count(
      x => x.MovePoints >= 0
      && x.MovePoints <= 40
      && x.Color == playerColor);
		
		return count;
	}

	public static int CountPlayersInHouse(PlayerColors playerColor, List<PlayerFigure> playerFigures){
		int count = playerFigures.Count(
      x => x.MovePoints < 0
      && x.Color == playerColor);
		
		return count;
	}

	public static bool IsFieldOccupiedByOwnFigure(PlayerColors playerColor, List<PlayerFigure> playerFigures, int field)
	{
		return playerFigures.Count(x=>x.Color == playerColor && x.MovePoints == field) == 1;
	}

	public static bool CanExitStart(PlayerColors playerColor, List<PlayerFigure> playerFigures, int diceValue){
		return playerFigures.Count(x => x.Color == playerColor && x.MovePoints == diceValue) == 0;
	}

	public static PlayerFigure GetPlayerFigureOnField(PlayerColors playerColor, List<PlayerFigure> playerFigures, int field){
		return playerFigures.Single(x => x.Color == playerColor && x.MovePoints == field);
	}
	
	public static PlayerFigure GetNextFigureToLeaveHouse(PlayerColors playerColor, List<PlayerFigure> playerFigures){
		return playerFigures.First(x => x.Color == playerColor && x.MovePoints == -1);
	}
}
