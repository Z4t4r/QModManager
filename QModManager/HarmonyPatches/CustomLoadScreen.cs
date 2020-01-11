namespace QModManager.HarmonyPatches.CustomLoadScreen
{
    using Harmony;
    using System;
    using System.IO;
    using UnityEngine;
    using UnityEngine.UI;

    [HarmonyPatch(typeof(uGUI_SceneLoading), nameof(uGUI_SceneLoading.Init))]
    internal static class uGUI_SceneLoading_Init
    {
        internal static GameObject progressBar;

        [HarmonyPrefix]
        internal static void Prefix(uGUI_SceneLoading __instance)
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine(Environment.CurrentDirectory, "Subnautica_Data/Managed/loadingscreen"));
            GameObject prefab = bundle.LoadAsset<GameObject>("Assets/LoadingScreen/LoadingBar.prefab");
            GameObject obj = GameObject.Instantiate(prefab);
            GameObject background = obj.transform.Find("Loading bar/Loading bar background").gameObject;
            ImageWithRoundedCorners iwrc = background.EnsureComponent<ImageWithRoundedCorners>();
            Material mat = bundle.LoadAsset<Material>("Assets/LoadingScreen/Rounded Corners.mat");
            iwrc.material = mat;
            iwrc.radius = 20;
            iwrc.Refresh();
        }
    }

    internal class ImageWithRoundedCorners : MonoBehaviour
    {
        private static readonly int Props = Shader.PropertyToID("_WidthHeightRadius");

        public Material material;
        public float radius = 20;

        internal void Refresh()
        {
            var rect = ((RectTransform)transform).rect;
            material.SetVector(Props, new Vector4(rect.width, rect.height, radius, 0));
        }
    }
}
