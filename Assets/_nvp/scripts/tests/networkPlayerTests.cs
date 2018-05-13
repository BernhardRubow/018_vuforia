using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace newvisionsproject.boardgame.tests
{
  public class networkPlayerTests
  {
    [UnityTest]
    public IEnumerator networkPlayer_can_be_loaded_from_custom_resources()
    {
      var networkPlayerPrefab = Resources.Load("Tests/networkPlayer");
      Assert.IsNotNull(networkPlayerPrefab);

      yield return null;
    }

    [UnityTest]
    public IEnumerator networkPlayer_can_be_instantiated()
    {
      var networkPlayerPrefab = Resources.Load("Tests/networkPlayer");
      Assert.IsNotNull(networkPlayerPrefab);

      var go = Object.Instantiate(networkPlayerPrefab, Vector3.zero, Quaternion.identity);

      yield return null;

      var networkPlayerInstance = GameObject.FindWithTag("networkPlayer");
      Assert.NotNull(networkPlayerInstance);
    }
  }

  // +++ helper +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

}
