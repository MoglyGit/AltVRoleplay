namespace AltVRoleplay.SQL.Inventory
{
    interface IInventory
    {
        int[] Inv { get; set; }
        float MaxWeight { get; set; }
    }
}
