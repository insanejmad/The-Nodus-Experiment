﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public string Name;
    public Sprite Avatar;
    public AudioClip[] VoiceClipList;
    public DialogMeta DialogMeta;
}
