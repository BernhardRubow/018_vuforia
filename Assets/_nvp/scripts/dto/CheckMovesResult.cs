using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace newvisionsproject.boardgame.dto
{
  public class CheckMovesResult
  {
    public List<PlayerMove> PossibleMoves;
    public bool CanMove;
    public string Msg;
    public bool AdditionalThrowGranted;

    public CheckMovesResult(bool canMove, string msg)
    {
      CanMove = canMove;
      Msg = msg;
    }
  }
}
