using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Admin.Models.Metadata
{
    public partial class DonVi
    {
        internal sealed class KhachHangMetadata
        {
            [Display(Name = "Mã đơn vị")]
            public int MaDV { get; set; }

            [Display(Name = "Tên đơn vị")]
            public string TenDV { get; set; }
        } 
    }
}