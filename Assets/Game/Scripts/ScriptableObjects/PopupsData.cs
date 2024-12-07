using System;

using UnityEngine;

namespace Example.Scripts.ScriptableObjects
{
    [System.Serializable]
    internal struct PopupData
    {
        public string Name;
        public GameObject Prefab;
    }

    [CreateAssetMenu(fileName = "PopupsData", menuName = "ScriptableObjects/PopupsData", order = 1)]
    internal class PopupsData : ScriptableObject
    {
        [Tooltip("Popups")]
        [SerializeField] private PopupData[] _popups;

        public PopupData Find(string name)
        {
            return Array.Find(_popups, x => x.Name == name);
        }
    }
}