using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.boardgame.enums;

namespace newvisionsproject.boardgame.interfaces
{
  public interface IGameManager
  {
    void ReportDiceThrow(PlayerColors playerColor, int diceValue);
  }
}