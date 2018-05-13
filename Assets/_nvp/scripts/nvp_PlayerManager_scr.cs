using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.managers.events;
using newvisionsproject.boardgame.gameLogic;
using newvisionsproject.boardgame.enums;
using newvisionsproject.boardgame.interfaces;

public class nvp_PlayerManager_scr : MonoBehaviour
{

  // +++ inspector fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  [SerializeField] private List<Transform> _playerEntities;
  [SerializeField] private Transform _startPosition;
  [SerializeField] private PlayerColors _playerColor;
  [SerializeField] private int _offset;


  // +++ unity callbacks +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void Start(){

	}

	void Update(){

	}


  // +++ methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  public List<Transform> GetPlayerEntities()
  {
    return _playerEntities;
  }

  public Vector3 GetStartingPosition()
  {
    return _startPosition.localPosition;
  }

  public PlayerColors GetPlayerColor()
  {
    return _playerColor;
  }

  public int GetOffset()
  {
    return _offset;
  }
}
