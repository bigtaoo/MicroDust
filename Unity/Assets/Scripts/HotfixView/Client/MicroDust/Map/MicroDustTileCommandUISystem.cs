using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustTileCommandUIComponent))]
    [FriendOf(typeof(MicroDustTileCommandUIComponent))]
    [FriendOfAttribute(typeof(MicroDustTileCommandUIComponent))]
    public static partial class MicroDustTileCommandUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustTileCommandUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.Move = rc.Get<GameObject>("move");
            self.Occupy = rc.Get<GameObject>("occupy");
            self.ResourceName = rc.Get<GameObject>("resource");

            self.SetResourceName();

            self.Move.GetComponent<Button>().onClick.AddListener(() => { self.OnMoveClick().Coroutine(); });
            self.Occupy.GetComponent<Button>().onClick.AddListener(() => { self.OnOccupyClick().Coroutine(); });
        }

        private static void SetResourceName(this MicroDustTileCommandUIComponent self)
        {
            var selectedTile = self.Root().GetComponent<MicroDustSelectedMapTileComponent>();
            self.ResourceName.GetComponent<TMP_Text>().text = selectedTile.TileType;
        }

        private static async ETTask OnMoveClick(this MicroDustTileCommandUIComponent self)
        {
            var selectedTile = self.Root().GetComponent<MicroDustSelectedMapTileComponent>();
            selectedTile.ArmyCommandType = MicroDustArmyCommandType.Move;

            if (self.Root().GetComponent<MicroDustHeroComponent>() != null)
            {
                await UIHelper.Create(self.Root(), UIType.MicroDustArmyCommand, UILayer.Mid);
            }
            else
            {
                await MicroDustHerosHelper.GetHerosInfo(self.Root(), UIType.MicroDustArmyCommand);
            }
        }

        private static async ETTask OnOccupyClick(this MicroDustTileCommandUIComponent self)
        {
            var selectedTile = self.Root().GetComponent<MicroDustSelectedMapTileComponent>();
            selectedTile.ArmyCommandType = MicroDustArmyCommandType.Occupy;

            if (self.Root().GetComponent<MicroDustHeroComponent>() != null)
            {
                await UIHelper.Create(self.Root(), UIType.MicroDustArmyCommand, UILayer.Mid);
            }
            else
            {
                await MicroDustHerosHelper.GetHerosInfo(self.Root(), UIType.MicroDustArmyCommand);
            }
        }
    }
}
