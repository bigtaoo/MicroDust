using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustSkillsUIComponent))]
    [FriendOf(typeof(MicroDustSkillsUIComponent))]
    [FriendOfAttribute(typeof(MicroDustSkillsUIComponent))]
    public static partial class MicroDustSkillsUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustSkillsUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");
            self.Content = rc.Get<GameObject>("Content");
            self.Skill = rc.Get<GameObject>("skillInfo");

            self.DisplaySkills();

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
            self.Skill.SetActive(false);
        }

        private static async ETTask OnBackClick(this MicroDustSkillsUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustSkills);
        }

        private static async ETTask OnSkillClick(this MicroDustSkillsUIComponent self, MicroDustSkill skill)
        {
            await ETTask.CompletedTask;
        }

        private static void DisplaySkills(this MicroDustSkillsUIComponent self)
        {
            var skills = self.Root().GetComponent<MicroDustSkillComponent>();
            var index = 0;
            foreach (var skill in skills.Skills)
            {
                var s = UnityEngine.Object.Instantiate(self.Skill);
                ++index;
                s.transform.SetParent(self.Content.transform, false);
                var rect = s.GetComponent<RectTransform>();
                rect.localPosition = new Vector3(10, -index * 80, 0);
                var config = MicroDustSkillConfigCategory.Instance.Get(skill.ConfigId);

                s.GetComponent<Button>().onClick.AddListener(() => { self.OnSkillClick(skill).Coroutine(); });

                var texts = s.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
                foreach (var text in texts)
                {
                    if (text.name == "name")
                    {
                        text.text = config.Name;
                    }
                    else if (text.name == "type")
                    {
                        text.text = config.SkillType.ToString();
                    }
                    else if (text.name == "rate")
                    {
                        text.text = $"{config.Rate} %";
                    }
                    else if(text.name == "description")
                    {
                        text.text = config.Description;
                    }
                    else if (text.name == "count")
                    {
                        text.text = config.Count.ToString();
                    }
                }
            }
            //var contentRect = self.Content.GetComponent<RectTransform>();
            //var currentSize = contentRect.sizeDelta;
            //contentRect.sizeDelta = new Vector2(currentSize.x, index / 3 * 370 + 500);
        }
    }
}
