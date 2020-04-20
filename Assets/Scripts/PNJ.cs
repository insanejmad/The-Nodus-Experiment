﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameObjectBehavior;
using DialogSystem;


[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Walkable))]
public class PNJ : MonoBehaviour
{
    public delegate void PNJEvent(PNJ pnj);
    public static PNJEvent OnQuestFinished;
    public static PNJEvent OnDied;

    public Character Info;
    public Dialog PendingDialog;
    public Dialog ValidDialog;
    public List<Item> ItemToObtainList = new List<Item>();

    bool Died = false;
    bool AllItemObtained {
        get {
            foreach (Item item in ItemToObtainList) {
                if (!PlayerInventory.instance.ContainsItem(item.ItemName))
                    return false;
            }
            return true;
        }
    }

    Interactable Interactable;
    Walkable Walkable;

    void Awake()
    {
        Interactable = GetComponent<Interactable>();
        Walkable = GetComponent<Walkable>();
    }

    void Update()
    {
        if (Walkable.IsFinished && !Died)
            Die();
    }

    void OnEnable()
    {
        Interactable.OnInteracted.AddListener(TriggerDialog);
    }

    void OnDisable()
    {
        Interactable.OnInteracted.RemoveListener(TriggerDialog);
    }

    void TriggerDialog()
    {
        if (UIDialogManager.Instance.InDialog)
            return;

        Dialog dialog = PendingDialog;

        if (AllItemObtained) {
            dialog = ValidDialog;
            UIDialogManager.Instance.OnDialogFinished.AddListener(QuestFinished);
        }

        UIDialogManager.Instance.Dialog = dialog;
    }

    void QuestFinished() {
        UIDialogManager.Instance.OnDialogFinished.RemoveListener(QuestFinished);
        OnQuestFinished.Invoke(this);
    }

    void Die()
    {
        Died = true;
        gameObject.SetActive(false);

        if (null != OnDied)
            OnDied(this);
    }
}