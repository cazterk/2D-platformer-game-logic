using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{

    public GameObject completeLevelUI;
     void OnTriggerEnter2D(Collider2D other)
    {
        completeLevelUI.SetActive(true);
    }


}
