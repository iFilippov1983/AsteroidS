using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Editor
{
    public sealed class AudioManagerWindow : EditorWindow
    {
        private static GameObject ObjectInstantiate;
        private static AudioMixerGroup audioMixerGroup;

        private AudioMixer _audioMixer;
        private AudioMixerGroup _audioMixerGroup;
        private AudioMixerGroup _effectsMixerGroup;
        private AudioClip _backgroundMusicClip;
        private AudioClip _shotWeaponClip;
        private AudioClip _armorHitsClip;
        private AudioClip _asteroidExplosionClip;
        private AudioClip _shipExplosionClip;
        private AudioClip _asteroidHitsClip;
        private AudioClip _buttonClip;

        private void OnGUI()
        {
            //GUILayout.Label("Аудио Менеджер", EditorStyles.boldLabel);
            //ObjectInstantiate = EditorGUILayout.ObjectField("", ObjectInstantiate, typeof(GameObject),true) as GameObject;
            GUILayout.Label("Audio Mixer", EditorStyles.boldLabel);
            _audioMixer = EditorGUILayout.ObjectField("Audio Mixer (AM)", ObjectInstantiate, typeof(AudioMixer), true) as AudioMixer;
            GUILayout.Label("Audio Mixer Group", EditorStyles.boldLabel);
            _audioMixerGroup = EditorGUILayout.ObjectField("AMGroup фона", ObjectInstantiate, typeof(AudioMixerGroup), true) as AudioMixerGroup;
            _effectsMixerGroup = EditorGUILayout.ObjectField("AMGroup эффектов", ObjectInstantiate, typeof(AudioMixerGroup), true) as AudioMixerGroup;
            GUILayout.Label("Audio Clip", EditorStyles.boldLabel);
            _backgroundMusicClip = EditorGUILayout.ObjectField("Фоновая музыка", ObjectInstantiate, typeof(AudioClip), true) as AudioClip;
            _shotWeaponClip = EditorGUILayout.ObjectField("Выстрел", ObjectInstantiate, typeof(AudioClip), true) as AudioClip;
            _armorHitsClip = EditorGUILayout.ObjectField("Попадание по броне", ObjectInstantiate, typeof(AudioClip), true) as AudioClip;
            _asteroidExplosionClip = EditorGUILayout.ObjectField("Взрыв астероида", ObjectInstantiate, typeof(AudioClip), true) as AudioClip;
            _shipExplosionClip = EditorGUILayout.ObjectField("Взрыв корабля", ObjectInstantiate, typeof(AudioClip), true) as AudioClip;
            _asteroidHitsClip = EditorGUILayout.ObjectField("Попадание по астероиду", ObjectInstantiate, typeof(AudioClip), true) as AudioClip;
            _buttonClip = EditorGUILayout.ObjectField("Звук кнопки", ObjectInstantiate, typeof(AudioClip), true) as AudioClip;
            var button = GUILayout.Button("Добавить");
            if (button)
            {

            }
            
        }
    }
}
