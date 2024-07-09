using TequipWiseServer.Models;

namespace TequipWiseServer.DTO
{
    public class SapNumberDto
    {
        public int? SApID { get; set; }

        public string? SapNum { get; set; }


        //controller (Finance Approver)
        public string? Idcontroller { get; set; }

        public string? Controller_name { get; set; }


    }
}
