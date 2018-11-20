using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace myProjectsPortfolio.Models {
    public class AngAuto {
        [Key]
        public int AngAuto_ID { get; set; }
        public string projectName { get; set; }
        public string thePath { get; set; }

        
        public List<Install> theInstalls;
        public AngAuto() {
            theInstalls = new List<Install>();
        }
    }
}