using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STDungeon
{
    // 다양한 대상(플레이어, 몬스터, 아이템)에 공통적으로 사용할 수 있는 스탯 구조체
    internal struct StatStruct
    {
        public int Attack;     // 공격력
        public int Defense;    // 방어력
        public int MaxHP;      // 최대 체력

        public StatStruct(int attack, int defense, int maxHP)
        {
            Attack = attack;
            Defense = defense;
            MaxHP = maxHP;
        }

        // 두 스탯을 더하는 연산자 오버로딩
        public static StatStruct operator +(StatStruct a, StatStruct b)
        {
            return new StatStruct(
                a.Attack + b.Attack,
                a.Defense + b.Defense,
                a.MaxHP + b.MaxHP
            );
        }

        // 두 스탯을 빼는 연산자 오버로딩
        public static StatStruct operator -(StatStruct a, StatStruct b)
        {
            return new StatStruct(
                a.Attack - b.Attack,
                a.Defense - b.Defense,
                a.MaxHP - b.MaxHP
            );
        }
    }

    internal class Stat
    {
        public StatStruct Value { get; set; }

        public Stat(int attack, int defense, int maxHP)
        {
            Value = new StatStruct(attack, defense, maxHP);
        }
    }
}
