using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.boardgame.enums;

namespace newvisionsproject.boardgame.dto
{
  public class PlayerFigure
  {

    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public int Index { get; private set; }
    public PlayerColors Color { get; private set; }
    public int OffSet {get; private set;}
    public int MovePoints { get; set; }
    public int GameBoardLocation { get; set; }


    // +++ constructor ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public PlayerFigure(PlayerColors playerColor, int index = 0, int offSet = 0)
    {
      Index = index;
      Color = playerColor;
      MovePoints = -1;
      GameBoardLocation = -1;
    }
  }
}
