namespace TequipWiseServer.DTO
{
    public class AssignedAssetDTO
    {
       
        public string EquipmentName { get; set; }
        public int? QtEquipment { get; set; }
        public string? AssetSN { get; set; }
        public string? AssetModele { get; set; }
        public DateTime AssetReceiveByEMployeAt { get; set; }
      
    }
}
