using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Tiled2Unity.CustomTiledImporter]
public class CustomImporter : Tiled2Unity.ICustomTiledImporter
{
    public void HandleCustomProperties(UnityEngine.GameObject gameObject,
        IDictionary<string, string> props)
    {
        // Does this game object have a spawn property?
        if (!props.ContainsKey("Add"))
            return;

        // Are we spawning an Appearing Block?
        if (props["Add"] != "pacdot")
            return;

        // Load the prefab assest and Instantiate it
        //BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        //collider.isTrigger = true;
        //PacDot theDot = gameObject.AddComponent<PacDot>();
        string prefabPath = "Assets/Prefabs/PacDot.prefab";
        UnityEngine.Object spawn = UnityEditor.AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
        if (spawn != null)
        {
            GameObject spawnInstance =
                (GameObject)GameObject.Instantiate(spawn);
            spawnInstance.name = spawn.name;

            // Use the position of the game object we're attached to
            spawnInstance.transform.parent = gameObject.transform;
            spawnInstance.transform.localPosition = new Vector3(1f,1f,0f);
        }

    }

    public void CustomizePrefab(UnityEngine.GameObject prefab)
    {
        // Do nothing
    }
}
