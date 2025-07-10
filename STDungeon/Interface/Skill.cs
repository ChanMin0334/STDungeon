using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STDungeon
{
    // 스킬의 공통적인 속성을 정의하는 인터페이스
    internal interface ISkill
    {
        string Name { get; }        // 스킬 이름
        string Effect { get; }      // 스킬 효과 설명
        int Damage { get; }         // 스킬 데미지
    }
}
