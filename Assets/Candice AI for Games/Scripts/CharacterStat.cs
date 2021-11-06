using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEditor;
using UnityEngine;

namespace ViridaxGameStudios.AI
{
    [Serializable]
    public class CharacterStat
    {
        public string name;
        public float baseValue;
        public bool showStat;
        public bool showModifiers;
        public virtual float value
        {
            get
            {
                if (isDirty || baseValue != lastBaseValue)
                {
                    lastBaseValue = baseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }
        }

        protected bool isDirty = true;
        protected float _value;
        public readonly List<StatModifier> statModifiers;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers;
        protected float lastBaseValue = float.MaxValue;

        public CharacterStat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }
        public CharacterStat(string name, float baseValue) : this()
        {
            this.name = name;
            this.baseValue = baseValue;
        }

        public virtual void AddModifier(StatModifier mod)
        {
            isDirty = true;
            statModifiers.Add(mod);
            statModifiers.Sort(CompareModifiersOrder);
        }

        protected virtual int CompareModifiersOrder(StatModifier a, StatModifier b)
        {
            if (a.order < b.order)
                return -1;
            else if (a.order > b.order)
                return 1;
            return 0;
        }
        public virtual bool RemoveModifier(StatModifier mod)
        {

            if (statModifiers.Remove(mod))
            {
                isDirty = true;
                return true;
            }
            return false;
        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;
            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }
        public virtual float CalculateFinalValue()
        {
            float finalValue = baseValue;
            float sumPercentAdd = 0;
            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifier mod = statModifiers[i];
                if (mod.Type == StatModType.Flat)
                {
                    finalValue += mod.value;
                }
                else if (mod.Type == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.value;

                    if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (mod.Type == StatModType.PercentMult)
                {
                    finalValue *= 1 + mod.value;
                }
            }

            return (float)(Math.Round(finalValue, 4));
        }
        

    }
}

