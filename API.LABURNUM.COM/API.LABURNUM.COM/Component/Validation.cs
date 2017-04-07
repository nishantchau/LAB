using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.LABURNUM.COM.Component
{
    public static class Validation
    {
        /// <summary>
        /// Validate Integer64 Value.
        /// </summary>
        /// <param name="value">Value To Be Validated.</param>
        public static void TryValidate(this Int64 value)
        {
            if (value <= 0) { throw new Exception("Int Value Cannot Be Zero Or Less Than Zero. Please Provide Valid Positive Integer."); }
        }

        /// <summary>
        /// Validate Integer Value.
        /// </summary>
        /// <param name="value">Value To Be Validated</param>
        public static void TryValidate(this int value)
        {
            if (value <= 0) { throw new Exception("Int Value Cannot Be Zero Or Less Than Zero. Please Provide Valid Positive Integer."); }
        }

        public static void TryValidate(this double value)
        {
            if (value <= 0) { throw new Exception("Int Value Cannot Be Zero Or Less Than Zero. Please Provide Valid Positive Integer."); }
        }

        /// <summary>
        /// Validate String Value.
        /// </summary>
        /// <param name="value">Value To Be Validated.</param>
        public static string TryValidate(this string value)
        {
            if (value == null) { throw new Exception("String Value Cannot Be Blank. Please Provide The Value."); }
            if (value.Trim().Equals("")) { throw new Exception("Invalid String Value. Please Provide Valid Value."); }
            return value.Trim();
        }

        /// <summary>
        /// Validate String Value.
        /// </summary>
        /// <param name="value">Value To Be Validated.</param>
        public static string TryValidateNullSstring(this string value)
        {
            if (value == null) { throw new Exception("String Value Cannot Be Blank. Please Provide The Value."); }
            return value.Trim();
        }

        public static void TryValidate(this DTO.LABURNUM.COM.FeeModel item)
        {
            item.ClassId.TryValidate();
            item.AdmissionTypeId.TryValidate();
            item.AdmissionFee.TryValidate();
        }

        public static void TryValidate(this DTO.LABURNUM.COM.StudentFeeDetailModel item)
        {
            item.StudentId.TryValidate();
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
        }

        public static void TryValidate(this DTO.LABURNUM.COM.StudentFeeModel item)
        {
            item.StudentId.TryValidate();
            item.AdmissionTypeId.TryValidate();
            item.ClassId.TryValidate();
        }

        public static void TryValidate(this DTO.LABURNUM.COM.StudentModel item)
        {
            item.ClassId.TryValidate();
            item.ClassStartWithId.TryValidate();
            item.FirstName.TryValidate();
            item.SalutationId.TryValidate();
            item.EmailId.TryValidate();
            item.Mobile.TryValidate();
            item.Address.TryValidate();
            item.FatherName.TryValidate();
            item.FatherMobile.TryValidate();
            item.FatherProfession.TryValidate();
            item.MotherName.TryValidate();
            item.MotherMobile.TryValidate();
            item.MotherProfession.TryValidate();
        }

        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClassPreNurseryModel item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClassUKGModel item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClassLKGModel item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }

        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass1Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass2Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass3Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass4Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass5Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass6Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass7Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass8Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass9Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass10Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass11Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
        public static void TryValidate(this DTO.LABURNUM.COM.AttendanceClass12Model item)
        {
            item.ClassId.TryValidate();
            item.SectionId.TryValidate();
            item.StudentId.TryValidate();
        }
    }
}