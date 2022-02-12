using System.Collections;
using UnityEngine;
using Google.XR.Cardboard;
using UnityEngine.XR.Management;

public class VR_Controller : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Api.IsCloseButtonPressed)
            ExitVRMode();
        if(XRGeneralSettings.Instance.Manager.isInitializationComplete)
            Api.UpdateScreenParams();
    }
    public void ExitVRMode()
    {
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
    }
    public void EnterVRMode(){
        StartCoroutine(StartXR());
    }

    IEnumerator StartXR()
    {
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
        if (!XRGeneralSettings.Instance.Manager.activeLoader)
            XRGeneralSettings.Instance.Manager.StartSubsystems();
    }
}

