using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Kore.SceneManagement
{
    [Serializable]
    public class SceneReference : ISerializationCallbackReceiver
    {
        public string scenePath;

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            BeforeSerializeCallBack();
#endif
        }

        public void OnAfterDeserialize() { }


#if UNITY_EDITOR
        public SceneAsset sceneAsset;
        public int sceneIndex;
        public bool sceneEnabled;

        private void BeforeSerializeCallBack()
        {
            if (sceneAsset == null)
            {
                sceneIndex = -1;
                scenePath = string.Empty;
                return;
            }

            string sceneAssetPath = AssetDatabase.GetAssetPath(sceneAsset);
            string sceneAssetGUID = AssetDatabase.AssetPathToGUID(sceneAssetPath);

            var scenes = EditorBuildSettings.scenes;

            int index = Array.FindIndex(scenes, s => s.guid.ToString() == sceneAssetGUID);
            if (index != -1)
            {
                sceneIndex = index;
                scenePath = scenes[index].path;
                sceneEnabled = scenes[index].enabled;
            }
            else
            {
                sceneIndex = -1;
                scenePath = string.Empty;
            }
        }
#endif
    }
}
