﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Timesheet.Models
{
    public class ImportFromExcelViewModel
    {
        [Required]
        public HttpPostedFileBase ExcelFile { get; set; }
    }
}