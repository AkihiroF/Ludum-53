using _Source.Core;
using UnityEngine;

namespace _Source.GenerationLevel
{
    public class CreatorPartsLevel : MonoBehaviour
    {
        public static GameObject CreatePart(GameObject reference) => Instantiate(reference);
    }
}