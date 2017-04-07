using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public class ClassHelper
    {
        private List<API.LABURNUM.COM.Class> Classes;

        public ClassHelper()
        {
            this.Classes = new List<API.LABURNUM.COM.Class>();
        }

        public ClassHelper(List<API.LABURNUM.COM.Class> classes)
        {
            if (classes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            this.Classes = classes;
        }

        public ClassHelper(API.LABURNUM.COM.Class Class)
        {
            if (Class == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_CANNOT_BE_NULL); };
            this.Classes = new List<API.LABURNUM.COM.Class>();
            this.Classes.Add(Class);
        }

        public List<DTO.LABURNUM.COM.ClassModel> Map()
        {
            if (this.Classes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };

            List<DTO.LABURNUM.COM.ClassModel> dtoClasses = new List<DTO.LABURNUM.COM.ClassModel>();
            foreach (API.LABURNUM.COM.Class item in this.Classes)
            {
                dtoClasses.Add(MapCore(item));
            }
            return dtoClasses;
        }

        public DTO.LABURNUM.COM.ClassModel MapSingle()
        {
            if (this.Classes == null) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            if (this.Classes.Count > 1) { throw new Exception(API.LABURNUM.COM.Component.Constants.ERRORMESSAGES.PARAMETER_LIST_CANNOT_BE_NULL); };
            return MapCore(this.Classes[0]);
        }

        private DTO.LABURNUM.COM.ClassModel MapCore(API.LABURNUM.COM.Class apiclass)
        {

            DTO.LABURNUM.COM.ClassModel dtoClass = new DTO.LABURNUM.COM.ClassModel()
            {
                ClassId = apiclass.ClassId,
                ClassName = apiclass.ClassName,
                CreatedOn = apiclass.CreatedOn,
                IsActive = apiclass.IsActive,
                LastUpdated = apiclass.LastUpdated
            };
            dtoClass.Sections = new SectionHelper(new FrontEndApi.SectionApi().GetSectionByAdvanceSearch(new DTO.LABURNUM.COM.SectionModel() { ClassId = apiclass.ClassId })).Map();
            dtoClass.EncryptId = new API.LABURNUM.COM.Component.Crypto().EncryptStringAES(Convert.ToString(apiclass.ClassId), LABURNUM.COM.Component.Constants.KEYS.SHAREDKEY);
            return dtoClass;
        }
    }
}