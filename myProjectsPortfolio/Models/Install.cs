using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace myProjectsPortfolio.Models {
    public class Install {
        [Key]
        public int Install_ID { get; set; }
        public string TheInstall { get; set; }


        public int AngAuto_ID { get; set; }
        public AngAuto AngAuto { get; set; }
    }
}