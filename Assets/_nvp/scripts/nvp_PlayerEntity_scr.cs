using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nvp_PlayerEntity_scr : MonoBehaviour
{

  // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  public Vector3 initialPosition { get; private set; }
  public PlayerLocations playerLocation;  
	public Vector3 MoveDirection;
  public int MovePoints;
  


  // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  void Start()
  {
    this.initialPosition = this.transform.localPosition;
  }

  // +++ custom methods +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  void Move(int numberOfFieldsToMove){
    
  }


}

public enum PlayerLocations{
  InTheHouse,
  OnBoard,
  SafeZone
}