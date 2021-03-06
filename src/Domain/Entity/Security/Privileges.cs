﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Security
{
    /// <summary>
    /// Changing the names of items, string resources ids also should be changed
    /// </summary>
    public enum Privileges
    {
        NullPrivilegeRestricted,
        NullPrivilegeAllowed,
        Audit,
        CreatePipe,
        CreateJoint,
        CreateSpool,
        CreateComponent,
        CreateReleaseNote,
        EditPipe,
        EditJoint,
        EditSpool,
        EditComponent,
        EditReleaseNote,
        ViewPipe,
        ViewJoint,
        ViewSpool,
        ViewComponent,
        ViewReleaseNote,
        SearchPipes,
        SearchJoints,
        SearchParts,
        SearchReleaseNotes,
        PrintMillReports,
        PrintInspectionReports,
        PrintConstructionReports,
        PartsInspection,
        EditSettings,
        ViewSettings,
        ExportDataFromMill,
        ExportDataFromMaster,
        ExportDataFromConstruction,
        ImportDataAtMaster,
        ImportDataAtConstruction,
        UnshipAtMill,
        DeactivatePipe,
        DeactivateJoint,
        DeactivateSpool,
        DeactivateComponent,
        ViewExportImportHistory,
        /// <summary>
        /// This element is used in one of the database migration version. 
        /// The name change can lead to fatal errors!
        /// </summary>
        PrintWeldDateReport,
        /// <summary>
        /// This element is used in one of the database migration version. 
        /// The name change can lead to fatal errors!
        /// </summary>
        PrintWeldTracingReport
    }
}
