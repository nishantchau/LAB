﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class ClassSubjectFacultyTableHelper
    {
        private List<API.LABURNUM.COM.ClassSubjectFacultyTable> ClassSubjectFacultyTables;

        public ClassSubjectFacultyTableHelper()
        {
            this.ClassSubjectFacultyTables = new List<API.LABURNUM.COM.ClassSubjectFacultyTable>();
        }

        public ClassSubjectFacultyTableHelper(List<API.LABURNUM.COM.ClassSubjectFacultyTable> classSubjectFacultyTables)
        {
            if (classSubjectFacultyTables == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.ClassSubjectFacultyTables = classSubjectFacultyTables;
        }

        public ClassSubjectFacultyTableHelper(API.LABURNUM.COM.ClassSubjectFacultyTable classSubjectFacultyTable)
        {
            if (classSubjectFacultyTable == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.ClassSubjectFacultyTables = new List<API.LABURNUM.COM.ClassSubjectFacultyTable>();
            this.ClassSubjectFacultyTables.Add(classSubjectFacultyTable);
        }

        public List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> Map()
        {
            if (this.ClassSubjectFacultyTables == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel> dtoBusRoutes = new List<DTO.LABURNUM.COM.ClassSubjectFacultyTableModel>();
            foreach (API.LABURNUM.COM.ClassSubjectFacultyTable item in this.ClassSubjectFacultyTables)
            {
                dtoBusRoutes.Add(MapCore(item));
            }
            return dtoBusRoutes;
        }

        public DTO.LABURNUM.COM.ClassSubjectFacultyTableModel MapSingle()
        {
            if (this.ClassSubjectFacultyTables == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.ClassSubjectFacultyTables.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.ClassSubjectFacultyTables[0]);
        }

        private DTO.LABURNUM.COM.ClassSubjectFacultyTableModel MapCore(API.LABURNUM.COM.ClassSubjectFacultyTable apiModel)
        {

            DTO.LABURNUM.COM.ClassSubjectFacultyTableModel dtoClass = new DTO.LABURNUM.COM.ClassSubjectFacultyTableModel()
            {
                ClassSubjectFacultyTableId = apiModel.ClassSubjectFacultyTableId,
                ClassId = apiModel.ClassId,
                SubjectId = apiModel.SubjectId.GetValueOrDefault() != 0 ? apiModel.SubjectId : null,
                FacultyId = apiModel.FacultyId,
                SectionId = apiModel.SectionId,
                CreatedOn = apiModel.CreatedOn,
                LastUpdated = apiModel.LastUpdated,
                IsActive = apiModel.IsActive,
                ClassName = apiModel.Class.ClassName,
                SubjectName = apiModel.SubjectId.GetValueOrDefault() != 0 ? apiModel.Subject.SubjectName : "",
                FacultyName = apiModel.Faculty.FacultyName,
                SectionName = apiModel.Section.SectionName,
                FacultyContact = apiModel.Faculty.ContactNumber,
                FacultyEmail = apiModel.Faculty.Email,
            };
            return dtoClass;
        }
    }
}