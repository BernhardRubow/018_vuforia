using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.boardgame.dto;
using newvisionsproject.boardgame.enums;


namespace newvisionsproject.boardgame.interfaces
{
  public interface IRule
  {
    IRule SetNextRule(IRule nextRule);
    CheckMovesResult CheckRule(PlayerColors playerColor, List<PlayerFigure> playerFigures, int diceNumber);
  }
}
