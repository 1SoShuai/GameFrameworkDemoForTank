using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Tank
{
    /// <summary>
    /// 
    /// </summary>
    public class RefreshDll
    {
        private static string sourcePath = @"F:\C_Sharp_Project\TankServer\MessageType\bin\Debug\netcoreapp2.0";

        [MenuItem("Tool/RefreshMsgDll")]
        public static void RefreshMsgData()
        {
            if (Directory.Exists(sourcePath))
            {
                string destPath = Application.dataPath + @"\GameMain\Libraries\ProtoMsg.dll";
                File.Copy(sourcePath + @"\ProtoMsg.dll", destPath, true);
                Debug.Log("Refresh Dll Successful!");
            }
            else
            {
                Debug.LogError("Source path not found:" + sourcePath);
            }
        }
    }
}
