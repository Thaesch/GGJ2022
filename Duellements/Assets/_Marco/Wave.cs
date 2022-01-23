using System;
using UnityEngine;

namespace _Marco
{
    [Serializable]
    public class Wave
    {

        [SerializeField] public int GhostPerWave;
        [SerializeField] public int GhostHealth;
        [SerializeField] public int Duration;
    }
}