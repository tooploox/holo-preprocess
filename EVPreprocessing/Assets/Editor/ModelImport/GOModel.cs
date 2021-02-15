﻿using System.IO;
using UnityEditor;
using UnityEngine;

namespace ModelImport
{
    class GOModel : ModelImporter
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GOModel(string rootDirectory) : base(rootDirectory) { }

        protected override void ImportLayer(ModelLayerInfo layerInfo)
        {
            string objectName = Info.Caption + "_" + Path.GetFileName(layerInfo.Directory);
            string absolutePath = layerInfo.Directory + "/" + layerInfo.AssetFileName;
            string objectPath = "Assets" + absolutePath.Substring(Application.dataPath.Length);

            GameObject modelGameObject = AssetDatabase.LoadAssetAtPath<GameObject>(@"Test Models/Skull/skull_body");
            if (modelGameObject == null)
            {
                throw Log.ThrowError("Cannot import model from " + objectPath, new IOException());
            }
            GameObject modelInstance = UnityEngine.Object.Instantiate(modelGameObject);
            AddLayerComponent(modelInstance, layerInfo);
            CreatePrefab(layerInfo, modelInstance, objectName);
            if (layerInfo.UseAsIcon) {
                LayerAutomaticIconGenerate(modelInstance);
            }
            GameObject.DestroyImmediate(modelInstance);
        }

        // Exports finished GameObject to a .prefab
        private void CreatePrefab(ModelLayerInfo layerInfo, GameObject modelGameObject, string objectName)
        {
            string rootAssetsDir = AssetDirs.TempAssetsDir + "/" + Info.Caption;
			AssetDirs.CreateAssetDirectory(rootAssetsDir);

			string prefabPath = rootAssetsDir + "/" + objectName + ".prefab";
			AssetPaths.Add(prefabPath);
            PrefabUtility.SaveAsPrefabAsset(modelGameObject, prefabPath);
        }
    }
}
