using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

enum LobbyState
{
    Ready,
    Scan,
    ScanEnd,
    Finish,
    
}
public class LobbyUI : MonoBehaviour
{
    LobbyState state = LobbyState.Ready;
    [SerializeField]
    Image progressBar;


    public void SetState(int state)
    {
        this.state = (LobbyState)state;
    }

    private void Start()
    {
        Managers.Game.LoadGame();
    }
    private void Update()
    {
        switch(state)
        {
            case LobbyState.Ready:
                UpdateReady();
                break;
            case LobbyState.Scan:
                UpdateScan();
                break;
            case LobbyState.ScanEnd:
                UpdateScanEnd();
                break;
            case LobbyState.Finish:
                UpdateFinish();
                break;
        }
    }

    private void UpdateReady()
    {

    }
    private void UpdateScan()
    {
        UpdateProgress();

    }
    private void UpdateScanEnd()
    {

    }
    private void UpdateFinish()
    {

    }


    private void UpdateProgress()
    {
        float progress = (float)Managers.Game.NextStage /  (float)Define.GameSceneOrder.Count;
        if(progressBar.fillAmount <= progress)
        {
            progressBar.fillAmount += 0.1f * Time.deltaTime;
        }
    }
}