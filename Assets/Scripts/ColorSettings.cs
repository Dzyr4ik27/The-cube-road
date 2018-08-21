using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;


public class ColorSettings : MonoBehaviour {
    /*
    #region bad
    public float speedChange;
    private int colorIndex;

    public Color[] colorsArray;
    public Color[] lightColorsArray;

    [SerializeField]
    private Color startColor;
    public Color endColor;

    public Animator wallAnimator;
    public Light playerLight;

    private void Start() {
        StartCoroutine("RandomColor");
    }


    private void Update() {
        FogColorSmoothChange();
        PlayerLightColorSmoothChange();

    }


    void FogColorSmoothChange() {
        startColor = RenderSettings.fogColor;
        RenderSettings.fogColor = Color.Lerp(startColor, endColor, speedChange * Time.deltaTime);


    }

    void PlayerLightColorSmoothChange() {
        playerLight.color = Color.Lerp(playerLight.color, lightColorsArray[colorIndex], speedChange * Time.deltaTime);
    }

    IEnumerator RandomColor() {
        while (true) {
            yield return new WaitForSeconds(5f); //27f
            SetRandomColor();

        }
    }

    void SetRandomColor() {
        colorIndex = Random.Range(0, colorsArray.Length);
        endColor = colorsArray[colorIndex];

        switch (colorIndex) {
            case 0: {
                    wallAnimator.SetTrigger("SetBlue");
                    break;
                }
            case 1: {
                    wallAnimator.SetTrigger("SetGreen");
                    break;
                }
            case 2: {
                    wallAnimator.SetTrigger("SetYellow");
                    break;
                }
            case 3: {
                    wallAnimator.SetTrigger("SetOrange");
                    break;
                }
            case 4: {
                    wallAnimator.SetTrigger("SetPurple");
                    break;
                }
        }
    }
    #endregion bad
    */

    public PostProcessingProfile ppProfile;
    public Vector3[] colorsArray;

    private int colorIndex;
    private Vector3 startVector;
    private Vector3 endVector;
    public Vector3 colorVector;

    public float speedChange = 1;

    private void Start() {
        endVector = Vector3.one;
        StartCoroutine("Color");
    }

    private void Update() {
        SmoothChangeLevelColor();
    }

    void ChangeLevelColor() {
        ColorGradingModel.Settings colorSettings = ppProfile.colorGrading.settings;

        colorSettings.colorWheels.log.slope.r = colorVector.x;
        colorSettings.colorWheels.log.slope.g = colorVector.y;
        colorSettings.colorWheels.log.slope.b = colorVector.z;

        ppProfile.colorGrading.settings = colorSettings;
        
    }


    void SmoothChangeLevelColor() {
        startVector = colorVector;
        colorVector = Vector3.Lerp(startVector, endVector, speedChange * Time.deltaTime);
        ChangeLevelColor();
    }

    IEnumerator Color() {
        while (true) {
            yield return new WaitForSeconds(27f);
            SetRandomColor();
        }
        
    }

    void SetRandomColor() {
        colorIndex = Random.Range(0, colorsArray.Length);
        endVector = colorsArray[colorIndex];
    }

    

}
