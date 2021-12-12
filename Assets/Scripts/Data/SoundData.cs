using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(menuName = "GameData/SoundData", fileName = "SoundData")]
    public class SoundData : ScriptableObject
    {
        [SerializeField] private AudioClip _backgroundMusicClip;
        [SerializeField] private AudioClip _shotWeaponClip;

        public AudioClip BackgroundMusicClip => _backgroundMusicClip;
        public AudioClip ShotWeaponClip => _shotWeaponClip;


    }
}
