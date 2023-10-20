using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName= "Pokemon", menuName = "Pokemon/New Pokemon")]
public class PokemonBase : ScriptableObject
{
  [SerializeField] private int ID;
  [SerializeField] private string name;
  public string Name => name;
  [TextArea][SerializeField] private string description;
  public string Description =>description;
  [SerializeField] private Sprite frontSprite;
  public Sprite FrontSprite => frontSprite;
  public Sprite BackSprite => backSprite;
  [SerializeField] private Sprite backSprite;
  [SerializeField] private PokemonType type1;
  public PokemonType Type1 =>type1;
  [SerializeField] private PokemonType type2;
  public PokemonType Type2 =>type2;
  //stats
  [SerializeField] private int maxHP;
  [SerializeField] private int attack;
  [SerializeField] private int defense;
  [SerializeField] private int spAttack;
  [SerializeField] private int spDefense;
  [SerializeField] private int speed;
  
  // Métodos de acceso/consulta
  public int MaxHP => maxHP;
  public int Attack => attack;
  public int SpAttack => spAttack;
  public int Defense => defense;
  public int SpDefense => spDefense;
  public int Speed => speed;

  [SerializeField] private List<LearnableMove> learnableMoves;

  public List<LearnableMove> LearnableMoves => learnableMoves;
}

public enum PokemonType
{
  None,
  Normal,
  Fire,
  Water,
  Electric,
  Grass,
  Ice,
  Fighting,
  Poison,
  Ground,
  Flying,
  Psychic,
  bug,
  Rock,
  Ghost,
  Steel,
  Dragon,
  Dark,
  Fairy,
}

[Serializable]
public class LearnableMove
{
  [SerializeField] private MoveBase move;
  [SerializeField] private int level;

  public MoveBase Move => move;
  public int Level => level;
}
