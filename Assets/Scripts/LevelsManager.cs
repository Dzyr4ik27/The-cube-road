using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour {

    public static LevelsManager Instance;


    private void Awake() {
        Instance = this;
    }


}
