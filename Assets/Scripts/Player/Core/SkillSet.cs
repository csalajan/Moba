using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Player.Core
{
    public class SkillSet
    {
        private Skill _qSkill;
        private Skill _wSkill;
        private Skill _eSkill;
        private Skill _rSkill;

        public SkillSet(Skill qSkill, Skill wSkill, Skill eSkill, Skill rSkill)
        {
            _qSkill = qSkill;
            _wSkill = wSkill;
            _eSkill = eSkill;
            _rSkill = rSkill;
            
        }

        public Skill getQ()
        {
            return _qSkill;
        }

        public Skill getW()
        {
            return _wSkill;
        }

        public Skill getE()
        {
            return _eSkill;
        }

        public Skill getR()
        {
            return _rSkill;
        }
    }
}
