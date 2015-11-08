using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Player.Core;

namespace Assets.Scripts.Player.SkeletonMan
{
    public class SkeletonMan : PlayerScript
    {

        public SkeletonMan()
        {
            skillset = new SkillSet(new Skill(), new Skill(), new Skill(), new Skill());
        }
    }
}
