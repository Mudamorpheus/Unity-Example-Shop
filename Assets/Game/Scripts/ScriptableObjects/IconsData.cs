using System;

using UnityEngine;

namespace Example.Scripts.ScriptableObjects
{
    [System.Serializable]
    internal struct IconData
    {
        public string Name;
        public Sprite Sprite;
    }

    [CreateAssetMenu(fileName = "IconsData", menuName = "ScriptableObjects/IconsData", order = 1)]
    internal class IconsData : ScriptableObject
    {
        [Tooltip("Items")]
        [SerializeField] private IconData[] _icons;

        public IconData Find(string name)
        {
            return Array.Find(_icons, x => x.Name == name);
        }

        public Sprite FindSprite(string name)
        {
            return Find(name).Sprite;
        }
    }
}
