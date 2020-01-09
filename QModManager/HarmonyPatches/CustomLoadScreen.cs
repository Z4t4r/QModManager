
namespace QModManager.HarmonyPatches.CustomLoadScreen
{
    using Harmony;
    using System;
    using UnityEngine;

    [HarmonyPatch(typeof(uGUI_SceneLoading), nameof(uGUI_SceneLoading.Init))]
    internal static class uGUI_SceneLoading_Init
    {
        internal static GameObject progressBar;

        [HarmonyPrefix]
        internal static void Prefix(uGUI_SceneLoading __instance)
        {
            AssetBundle bundle = AssetBundle.LoadFromMemory(Convert.FromBase64String(LoadingBarAssetBundle.data));
            GameObject prefab = bundle.LoadAsset<GameObject>("Assets/Prefabs/LoadingBar.prefab");
            GameObject obj = GameObject.Instantiate(prefab);
        }

        internal static class LoadingBarAssetBundle
        {
            public const data = "removed due to VS performance reasons :P";
        }
    }
}
