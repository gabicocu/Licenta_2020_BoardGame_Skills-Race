using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    //public DiceScript diceScript;
    //public DiceScript2 diceScript2;

    float time;
    float timeDelay;


    public GameObject diceCamera;
    public GameObject boardCamera;
    //
    public Transform stone1;
    public Transform stone2;
    public Transform player;

    public GameObject zoomCamera;
    public static bool isZoomCamera;
    AudioListener zoomCameraAudioLis;

    // mini games

    public GameObject game2Camera;
    public static bool isGame2Camera;
    AudioListener game2CameraAudioLis;

    //

    public GameObject game3Camera;
    public static bool isGame3Camera;
    AudioListener game3CameraAudioLis;

    public GameObject game4Camera;
    public static bool isGame4Camera;
    AudioListener game4CameraAudioLis;

    bool zoom;
    //

    public static bool isDiceCamera;
    public static bool isBoardCamera;

    AudioListener diceCameraAudioLis;
    AudioListener boardCameraAudioLis;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timeDelay = 1.2f; // the delay between switching scenes
        
        isDiceCamera = false;
        isBoardCamera = false;
        diceCameraAudioLis = diceCamera.GetComponent<AudioListener>();
        boardCameraAudioLis = boardCamera.GetComponent<AudioListener>();

        //
        player = null;
        isZoomCamera = false;
        zoomCameraAudioLis = zoomCamera.GetComponent<AudioListener>();

        zoom = false;
        //

        isGame2Camera = false;
        game2CameraAudioLis = game2Camera.GetComponent<AudioListener>();

        //
        isGame3Camera = false;
        game3CameraAudioLis = game3Camera.GetComponent<AudioListener>();

        //
        isGame4Camera = false;
        game4CameraAudioLis = game4Camera.GetComponent<AudioListener>();

    }

    // Update is called once per frame
    void Update()
    {

        Transform player = null; // for the zoomCamera position
        if (Stone.player1Turn)
        {
            player = stone1;
        }
        else if (Stone2.player2Turn)
        {
            player = stone2;
        }
        zoomCamera.transform.position = player.transform.position + new Vector3(0, 1, -5);

        //
        if((Stone.player1Turn && Stone.game) || (Stone2.player2Turn && Stone2.game && !MainMenuScript.computer))
        {
            time += 1f * Time.deltaTime;
            if (time >= timeDelay)
            {
                time = 0f;
                if ((Stone.player1Turn && Stone.game2Turn) || (Stone2.player2Turn && Stone2.game2Turn))
                {
                    switchGame2Camera();
                } else if ((Stone.player1Turn && Stone.game3Turn) || (Stone2.player2Turn && Stone2.game3Turn))
                {
                    switchGame3Camera();
                }
                else if ((Stone.player1Turn && Stone.game4Turn) || (Stone2.player2Turn && Stone2.game4Turn))
                {
                    switchGame4Camera();
                }
            }
        } else if (Stone.isMoving || Stone2.isMoving)
        {
            time += 1f * Time.deltaTime; // a bit of delay between switching cameras
            if (Input.GetKeyDown(KeyCode.C))
            {
                //Debug.Log("Pressed C");
                if (isZoomCamera)
                {
                    zoom = false;
                    switchBoardCamera();
                }
                else if (isBoardCamera)
                {
                    zoom = true;
                    switchZoomCamera();
                }
            }
            
            if (time >= timeDelay)
            {
                time = 0f;
                if (zoom)
                {
                    switchZoomCamera();
                }
                else
                {
                    switchBoardCamera();
                }
            }
        } else
        {
            time += 1f * Time.deltaTime;
            if (time >= timeDelay)
            {
                time = 0f;
                switchDiceCamera();
            }
        }

        showCamera();
        //switchCameraOnPressC();
        
    }

    void switchDiceCamera()
    {
        isDiceCamera = true;
        isBoardCamera = false;
        isZoomCamera = false;
        isGame2Camera = false;
        isGame3Camera = false;
        isGame4Camera = false;
    }

    void switchBoardCamera()
    {
        isBoardCamera = true;
        isDiceCamera = false;
        isZoomCamera = false;
        isGame2Camera = false;
        isGame3Camera = false;
        isGame4Camera = false;
    }

    void switchZoomCamera()
    {
        isZoomCamera = true;
        isDiceCamera = false;
        isBoardCamera = false;
        isGame2Camera = false;
        isGame3Camera = false;
        isGame4Camera = false;
    }

    void switchGame2Camera()
    {
        isGame2Camera = true;
        isBoardCamera = false;
        isDiceCamera = false;
        isZoomCamera = false;
        isGame3Camera = false;
        isGame4Camera = false;
    }
    void switchGame3Camera()
    {
        isGame3Camera = true;
        isBoardCamera = false;
        isDiceCamera = false;
        isZoomCamera = false;
        isGame2Camera = false;
        isGame4Camera = false;
    }

    void switchGame4Camera()
    {
        isGame4Camera = true;
        isBoardCamera = false;
        isDiceCamera = false;
        isZoomCamera = false;
        isGame2Camera = false;
        isGame3Camera = false;
    }

    void showCamera()
    {
        if (isDiceCamera == true && isBoardCamera == false && isZoomCamera == false && isGame2Camera == false && isGame3Camera == false && isGame4Camera == false)
        {
            diceCamera.SetActive(true);
            diceCameraAudioLis.enabled = true;

            boardCameraAudioLis.enabled = false;
            boardCamera.SetActive(false);

            zoomCameraAudioLis.enabled = false;
            zoomCamera.SetActive(false);

            game2CameraAudioLis.enabled = false;
            game2Camera.SetActive(false);

            game3CameraAudioLis.enabled = false;
            game3Camera.SetActive(false);

            game4CameraAudioLis.enabled = false;
            game4Camera.SetActive(false);

        } else if (isDiceCamera == false && isBoardCamera == true && isZoomCamera == false && isGame2Camera == false && isGame3Camera == false && isGame4Camera == false)
        {
            boardCamera.SetActive(true);
            boardCameraAudioLis.enabled = true;

            diceCameraAudioLis.enabled = false;
            diceCamera.SetActive(false);

            zoomCameraAudioLis.enabled = false;
            zoomCamera.SetActive(false);

            game2CameraAudioLis.enabled = false;
            game2Camera.SetActive(false);

            game3CameraAudioLis.enabled = false;
            game3Camera.SetActive(false);

            game4CameraAudioLis.enabled = false;
            game4Camera.SetActive(false);
        } else if (isDiceCamera == false && isBoardCamera == false && isZoomCamera == true && isGame2Camera == false && isGame3Camera == false && isGame4Camera == false)
        {
            boardCamera.SetActive(false);
            boardCameraAudioLis.enabled = false;

            diceCameraAudioLis.enabled = false;
            diceCamera.SetActive(false);

            zoomCameraAudioLis.enabled = true;
            zoomCamera.SetActive(true);

            game2CameraAudioLis.enabled = false;
            game2Camera.SetActive(false);

            game3CameraAudioLis.enabled = false;
            game3Camera.SetActive(false);

            game4CameraAudioLis.enabled = false;
            game4Camera.SetActive(false);
        } else if (isDiceCamera == false && isBoardCamera == false && isZoomCamera == false && isGame2Camera == true && isGame3Camera == false && isGame4Camera == false)
        {
            boardCamera.SetActive(false);
            boardCameraAudioLis.enabled = false;

            diceCameraAudioLis.enabled = false;
            diceCamera.SetActive(false);

            zoomCameraAudioLis.enabled = false;
            zoomCamera.SetActive(false);

            game2CameraAudioLis.enabled = true;
            game2Camera.SetActive(true);

            game3CameraAudioLis.enabled = false;
            game3Camera.SetActive(false);

            game4CameraAudioLis.enabled = false;
            game4Camera.SetActive(false);
        } else if (isDiceCamera == false && isBoardCamera == false && isZoomCamera == false && isGame2Camera == false && isGame3Camera == true && isGame4Camera == false)
        {
            boardCamera.SetActive(false);
            boardCameraAudioLis.enabled = false;

            diceCameraAudioLis.enabled = false;
            diceCamera.SetActive(false);

            zoomCameraAudioLis.enabled = false;
            zoomCamera.SetActive(false);

            game2CameraAudioLis.enabled = false;
            game2Camera.SetActive(false);

            game3CameraAudioLis.enabled = true;
            game3Camera.SetActive(true);

            game4CameraAudioLis.enabled = false;
            game4Camera.SetActive(false);
        } else if (isDiceCamera == false && isBoardCamera == false && isZoomCamera == false && isGame2Camera == false && isGame3Camera == false && isGame4Camera == true)
        {
            boardCamera.SetActive(false);
            boardCameraAudioLis.enabled = false;

            diceCameraAudioLis.enabled = false;
            diceCamera.SetActive(false);

            zoomCameraAudioLis.enabled = false;
            zoomCamera.SetActive(false);

            game2CameraAudioLis.enabled = false;
            game2Camera.SetActive(false);

            game4CameraAudioLis.enabled = true;
            game4Camera.SetActive(true);

            game3CameraAudioLis.enabled = false;
            game3Camera.SetActive(false);
        }
    }

    /*
    void switchCamera()
    {
        if (isDiceCamera == true && isBoardCamera == false)
        {
            isDiceCamera = false;
            isBoardCamera = true;
        }
        else if (isDiceCamera == false && isBoardCamera == true)
        {
            isDiceCamera = true;
            isBoardCamera = false;
        }
    }

    void switchCameraOnPressC()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isDiceCamera == true && isBoardCamera == false)
            {
                isDiceCamera = false;
                isBoardCamera = true;
            } else if (isDiceCamera == false && isBoardCamera == true)
            {
                isDiceCamera = true;
                isBoardCamera = false;
            }

        }
    }
    */

}
