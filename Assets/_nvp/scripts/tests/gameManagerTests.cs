using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;


namespace newvisionsproject.boardgame.tests
{
  
  public class gameManagerTests
  {
    // +++ game manager tests +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [UnityTest]
    public IEnumerator _gameManager_can_be_loaded_from_custom_resources()
    {

      var gameManagerPrefab = Resources.Load("Tests/gameManager");
      Assert.IsNotNull(gameManagerPrefab);

      yield return null;
    }

    [UnityTest]
    public IEnumerator _gameManager_can_be_instantiated()
    {
      var gameManagerPrefab = Resources.Load("Tests/gameManager");
      Assert.IsNotNull(gameManagerPrefab);

      var gameManagerGO = (GameObject)Object.Instantiate(gameManagerPrefab, Vector3.zero, Quaternion.identity);
      Assert.IsNotNull(gameManagerGO);

      yield return null;
    }

    [UnityTest]
    public IEnumerator _gameManager_exists_in_scene(){
      yield return null;

      var spawnedGameManager = GetGameController();
      Assert.IsNotNull(spawnedGameManager);
    }

    [UnityTest]
    public IEnumerator _gameControllerScript_is_accessible(){
      yield return null;

      nvp_GameManager_scr gameManagerScript = GetGameManagerScript();
      Debug.Log(gameManagerScript.GetType());
      Assert.IsNotNull(gameManagerScript);
    }

    // +++ helper +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SetUp]
    public void SetupGameBoard(){
      var gameManagerPrefab = Resources.Load("Tests/gameManager");
      var gameManagerGO = (GameObject)Object.Instantiate(gameManagerPrefab, Vector3.zero, Quaternion.identity);      
    }

    [TearDown]
    public void TearDown(){
      foreach(var gm in GameObject.FindGameObjectsWithTag("GameController")){
        Object.Destroy(gm);
      }
    }

    public GameObject GetGameController(){
      return GameObject.FindWithTag("GameController");
    }

    public nvp_GameManager_scr GetGameManagerScript(){
      var go = GameObject.FindGameObjectWithTag("GameController");
      return go.GetComponent<nvp_GameManager_scr>();
    }
  }
}
