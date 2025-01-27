using CBStuff.DialogueSystem;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LostInTheSnow
{
    [DialogueId("change_material")]
    public class SetMaterialDialogueAction : IDialogueActionFunc
    {
        public void Action(object[] args)
        {
            GameObject mesh = (GameObject)args[0];
            GameObject materialStoreObj = (GameObject)args[1];
            int materialIndex = ((JValue)args[2]).Value<int>();
            int whatMaterialWillChange = ((JValue)args[3]).Value<int>(); 

            MaterialStore materialStore = materialStoreObj.GetComponent<MaterialStore>();
            
            Material newMaterial = materialStore.materials[materialIndex];

            MeshRenderer meshRenderer = mesh.GetComponent<MeshRenderer>();
            Material[] newMaterials = meshRenderer.materials;
            newMaterials[whatMaterialWillChange] = newMaterial;

            meshRenderer.materials = newMaterials;
        }
    }
}
