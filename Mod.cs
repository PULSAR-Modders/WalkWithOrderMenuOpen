using PulsarModLoader;

namespace Walk_with_order_menu_open
{
    public class Mod : PulsarMod
    {
        public override string Version => "0.0.0";

        public override string Author => "18107";

        public override string ShortDescription => "Allows the player to continue moving while using the order menu";

        public override string Name => "Walk with order menu open";

        public override string ModID => "walkwithordermenuopen";

        public override string HarmonyIdentifier()
        {
            return "id107.walkwithordermenuopen";
        }
    }
}
