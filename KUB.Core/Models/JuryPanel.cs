using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KUB.Core.Models
{
    public class JuryPanel
    {
        public Guid PanelId { get; set; }
        public string Panel { get; set; }
        public virtual ICollection<JuryInPanel> JuryInPanels { get; set; }
    }
}
