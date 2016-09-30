using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DurhamUniversity.ViewModels
{
    public class AssignedModuleData
    {
        public int ModuleID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}