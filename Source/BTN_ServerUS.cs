﻿using UnityEngine;

public class BTN_ServerUS : MonoBehaviour
{
    private void OnClick()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.ConnectToMaster("app-us.exitgamescloud.com", 0x13bf, FengGameManagerMKII.applicationId, UIMainReferences.ServerKey);
        FengGameManagerMKII.OnPrivateServer = false;
    }
}

