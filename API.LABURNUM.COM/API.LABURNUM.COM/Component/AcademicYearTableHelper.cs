using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class AcademicYearTableHelper
    {
        private List<API.LABURNUM.COM.AcademicYearTable> AcademicYears;

        public AcademicYearTableHelper()
        {
            this.AcademicYears = new List<API.LABURNUM.COM.AcademicYearTable>();
        }

        public AcademicYearTableHelper(List<API.LABURNUM.COM.AcademicYearTable> academicYearTables)
        {
            if (academicYearTables == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.AcademicYears = academicYearTables;
        }


        public AcademicYearTableHelper(API.LABURNUM.COM.AcademicYearTable AcademicYearTableModel)
        {
            if (AcademicYearTableModel == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.AcademicYears = new List<API.LABURNUM.COM.AcademicYearTable>();
            this.AcademicYears.Add(AcademicYearTableModel);
        }


        public List<DTO.LABURNUM.COM.AcademicYearTableModel> Map()
        {
            if (this.AcademicYears == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.AcademicYearTableModel> dtoAcademicYearTableModels = new List<DTO.LABURNUM.COM.AcademicYearTableModel>();
            foreach (API.LABURNUM.COM.AcademicYearTable item in this.AcademicYears)
            {
                dtoAcademicYearTableModels.Add(MapCore(item));
            }
            return dtoAcademicYearTableModels;
        }

        public DTO.LABURNUM.COM.AcademicYearTableModel MapSingle()
        {
            if (this.AcademicYears == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.AcademicYears.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.AcademicYears[0]);
        }

        private DTO.LABURNUM.COM.AcademicYearTableModel MapCore(API.LABURNUM.COM.AcademicYearTable AcademicYearTableModel)
        {

            DTO.LABURNUM.COM.AcademicYearTableModel dtoClass = new DTO.LABURNUM.COM.AcademicYearTableModel()
            {
                AcademicYearTableId = AcademicYearTableModel.AcademicYearTableId,
                StartYear = AcademicYearTableModel.StartYear,
                EndYear = AcademicYearTableModel.EndYear,
                AcademicYear = AcademicYearTableModel.StartYear + "-" + AcademicYearTableModel.EndYear,
                CreatedOn = AcademicYearTableModel.CreatedOn,
                IsActive = AcademicYearTableModel.IsActive,
                LastUpdated = AcademicYearTableModel.LastUpdated
            };
            return dtoClass;
        }
    }
}