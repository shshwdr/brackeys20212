#if UNITY_EDITOR 
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Text;
using LitJson;

/// <summary>
/// Spine 文件导入 修改Spine.json文件内的版本设置
/// </summary>
public class SpineImportSetting : AssetPostprocessor
{
    //任何资源（包括文件夹）导入都会被调用的方法
    void OnPreprocessAsset()
    {
        try
        {
            if (!this.assetPath.EndsWith(".json"))
                return;

            //先判断是否是 spine 文件
            string msg = File.ReadAllText(this.assetPath, Encoding.UTF8);
            JsonData jsonObj = JsonMapper.ToObject(msg);
            JsonData item = jsonObj["skeleton"]["spine"];

            if (item != null && item.IsString && item.ToString() != "3.8")
            {
                jsonObj["skeleton"]["spine"] = "3.8";//美术破解的 3.8.75 导入会报错
                string newjson = JsonMapper.ToJson(jsonObj);
                File.WriteAllText(this.assetPath, newjson);
                AssetDatabase.Refresh();
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"SpineImportSetting 异常 {e.Message}");
        }
    }
}
#endif