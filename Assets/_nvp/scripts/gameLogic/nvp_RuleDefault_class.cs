using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.boardgame.interfaces;
using newvisionsproject.boardgame.dto;
using newvisionsproject.boardgame.enums;

namespace newvisionsproject.boardgame.gameLogic
{
  public class nvp_RuleDefault_class : IRule
  {
    private IRule _nextRule;
    public CheckMovesResult CheckRule(PlayerColors playerColor, List<PlayerFigure> playerFigures, int diceNumber)
    {
      var result = new CheckMovesResult(false, "End of rule chain reached.");
      result.CanMove = false;
      result.PossibleMoves = null;
			return result;
    }

    public IRule SetNextRule(IRule nextRule)
    {
      _nextRule = nextRule;
      return this;
    }
  }
}
