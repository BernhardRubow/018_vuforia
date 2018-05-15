using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using newvisionsproject.boardgame.dto;
using newvisionsproject.boardgame.gameLogic;
using newvisionsproject.boardgame.enums;
using System;
using System.Linq;

namespace newvisionsproject.boardgame.tests
{
  public class gameBoardTests
  {
    // +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private nvp_GameBoard_class _gameboard;

    // +++ setup and Teardown +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SetUp]
    public void Setup(){
      _gameboard = new nvp_GameBoard_class(4);
    }

    [TearDown]
    public void TearDown(){
      _gameboard = null;
    }


    // +++ tests ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    // +++ check moves tests +++
    [Test]
    public void default_game_board_moves_player_to_start_on_dice_6(){

      // on a default game board with 4 players the red player rolls a 6
      int diceValue = 6;
      var result = _gameboard.CheckPossiblePlayerMoves(PlayerColors.red, diceValue);

      Assert.AreEqual(true, result.CanMove);
      Assert.AreEqual(true, result.AdditionalThrowGranted);

      // do the move and test
      _gameboard.Move(result.PossibleMoves[0], diceValue);
      Assert.AreEqual(true, nvp_RuleHelper.IsFieldOccupiedByOwnFigure(PlayerColors.red, _gameboard.playerFigures, 0));
    }
    
    [Test]
    public void default_game_board_all_in_house_throws_5_5_6(){

      int diceValue = 5;
      var result = _gameboard.CheckPossiblePlayerMoves(PlayerColors.red, diceValue);
      Assert.AreEqual(false, result.CanMove);
      Assert.AreEqual(true, result.AdditionalThrowGranted);

      diceValue = 5;
      if(result.AdditionalThrowGranted){
        result = _gameboard.CheckPossiblePlayerMoves(PlayerColors.red, diceValue);
        Assert.AreEqual(false, result.CanMove);
        Assert.AreEqual(true, result.AdditionalThrowGranted);
      }

      diceValue = 6;
      if(result.AdditionalThrowGranted){
        result = _gameboard.CheckPossiblePlayerMoves(PlayerColors.red, diceValue);
        Assert.AreEqual(true, result.CanMove);
        Assert.AreEqual(true, result.AdditionalThrowGranted);
      }

      // do the move and test
      _gameboard.Move(result.PossibleMoves[0], diceValue);
      Assert.AreEqual(true, nvp_RuleHelper.IsFieldOccupiedByOwnFigure(PlayerColors.red, _gameboard.playerFigures, 0));
    }

    [Test]
    public void default_game_board_all_in_house_throws_5_6(){

      int diceValue = 5;
      var result = _gameboard.CheckPossiblePlayerMoves(PlayerColors.red, diceValue);
      Assert.AreEqual(false, result.CanMove);
      Assert.AreEqual(true, result.AdditionalThrowGranted);

      diceValue = 6;
      if(result.AdditionalThrowGranted){
        result = _gameboard.CheckPossiblePlayerMoves(PlayerColors.red, diceValue);
        Assert.AreEqual(true, result.CanMove);
        Assert.AreEqual(true, result.AdditionalThrowGranted);
      }      

      // do the move and test
      _gameboard.Move(result.PossibleMoves[0], diceValue);
      Assert.AreEqual(true, nvp_RuleHelper.IsFieldOccupiedByOwnFigure(PlayerColors.red, _gameboard.playerFigures, 0));
    }
    
    [Test]
    public void default_game_board_all_in_house_throws_5_5_5(){

      var result = _gameboard.CheckPossiblePlayerMoves(PlayerColors.red, 5);

      Assert.AreEqual(false, result.CanMove);
      Assert.AreEqual(true, result.AdditionalThrowGranted);

      if(result.AdditionalThrowGranted){
        result = _gameboard.CheckPossiblePlayerMoves(PlayerColors.red, 5);
        Assert.AreEqual(false, result.CanMove);
        Assert.AreEqual(true, result.AdditionalThrowGranted);
      }

      if(result.AdditionalThrowGranted){
        result = _gameboard.CheckPossiblePlayerMoves(PlayerColors.red, 5);
        Assert.AreEqual(false, result.CanMove);
        Assert.AreEqual(false, result.AdditionalThrowGranted);
      }
      
    }


    // +++ creation tests +++
    [Test]
    public void gameBoardClass_can_be_created_with_2_players()
    {
      nvp_GameBoard_class gameboard = new nvp_GameBoard_class(2);

      var numberOfRedFigures = gameboard.playerFigures.Where(x => x.Color == PlayerColors.red).Count();
      var numberOfYellowFigures = gameboard.playerFigures.Where(x => x.Color == PlayerColors.yellow).Count();

      Assert.AreEqual(4, numberOfRedFigures);
      Assert.AreEqual(4, numberOfYellowFigures);

      var playersInHouse = gameboard.playerFigures.Where(x => x.GameBoardLocation == -1).Count();
      Assert.AreEqual(gameboard.playerFigures.Count, playersInHouse);

      var sumOfPlayerIndices = gameboard.playerFigures.Sum(x => x.Index);
      Assert.AreEqual(gameboard.playerFigures.Count / 2 * 3, sumOfPlayerIndices);
    }
    
    [Test]
    public void gameBoardClass_can_be_created_with_3_players()
    {
      nvp_GameBoard_class gameboard = new nvp_GameBoard_class(3);

      var numberOfRedFigures = gameboard.playerFigures.Where(x => x.Color == PlayerColors.red).Count();
      var numberOfYellowFigures = gameboard.playerFigures.Where(x => x.Color == PlayerColors.yellow).Count();
      var numberOfBlackFigures = gameboard.playerFigures.Where(x => x.Color == PlayerColors.black).Count();

      Assert.AreEqual(4, numberOfRedFigures);
      Assert.AreEqual(4, numberOfYellowFigures);
      Assert.AreEqual(4, numberOfBlackFigures);

      var playersInHouse = gameboard.playerFigures.Where(x => x.GameBoardLocation == -1).Count();
      Assert.AreEqual(gameboard.playerFigures.Count, playersInHouse);

      var sumOfPlayerIndices = gameboard.playerFigures.Sum(x => x.Index);
      Assert.AreEqual(gameboard.playerFigures.Count / 2 * 3, sumOfPlayerIndices);
    }
    
    [Test]
    public void gameBoardClass_can_be_created_with_4_players()
    {
      nvp_GameBoard_class gameboard = new nvp_GameBoard_class(4);

      var numberOfRedFigures = gameboard.playerFigures.Where(x => x.Color == PlayerColors.red).Count();
      var numberOfYellowFigures = gameboard.playerFigures.Where(x => x.Color == PlayerColors.yellow).Count();
      var numberOfBlackFigures = gameboard.playerFigures.Where(x => x.Color == PlayerColors.black).Count();
      var numberOfGreenFigures = gameboard.playerFigures.Where(x => x.Color == PlayerColors.green).Count();

      Assert.AreEqual(4, numberOfRedFigures);
      Assert.AreEqual(4, numberOfYellowFigures);
      Assert.AreEqual(4, numberOfBlackFigures);
      Assert.AreEqual(4, numberOfGreenFigures);
      
      var playersInHouse = gameboard.playerFigures.Where(x => x.GameBoardLocation == -1).Count();
      Assert.AreEqual(gameboard.playerFigures.Count, playersInHouse);

      var sumOfPlayerIndices = gameboard.playerFigures.Sum(x => x.Index);
      Assert.AreEqual(gameboard.playerFigures.Count / 2 * 3, sumOfPlayerIndices);
    }
  }
}
