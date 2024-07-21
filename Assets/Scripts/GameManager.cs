using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WeaponController controller;
    [SerializeField] private int delay;
    void Start()
    {
        StartCoroutine(PlayerIntro(delay));
    }

    
    void Update()
    {
        
    }

    private IEnumerator PlayerIntro(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        controller.enabled = true;
    }
}
