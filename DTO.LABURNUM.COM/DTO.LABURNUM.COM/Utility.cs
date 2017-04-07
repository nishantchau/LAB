using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.LABURNUM.COM
{
    public class Utility
    {
        public enum EnumUserType
        {
            ADMIN = DTO.LABURNUM.COM.Utility.UserType.Admin,
            PRINCIPLE = DTO.LABURNUM.COM.Utility.UserType.Principle,
            FACULTY = DTO.LABURNUM.COM.Utility.UserType.Faculty,
            PARENT = DTO.LABURNUM.COM.Utility.UserType.Parent,
            STUDENT = DTO.LABURNUM.COM.Utility.UserType.Student,
            ACCOUNT = DTO.LABURNUM.COM.Utility.UserType.Account,
            INVALIDUSER = DTO.LABURNUM.COM.Utility.UserType.InvalidUser
        }

        public static class UserType
        {
            public const Int32 InvalidUser = -1;
            public const Int32 Admin = 1;
            public const Int32 Principle = 2;
            public const Int32 Faculty = 3;
            public const Int32 Parent = 4;
            public const Int32 Student = 5;
            public const Int32 Account = 6;

            public static EnumUserType GetEnumUserTypeById(long UserTypeId)
            {
                EnumUserType userType;
                switch (UserTypeId)
                {
                    case Admin:
                        userType = EnumUserType.ADMIN;
                        break;
                    case Principle:
                        userType = EnumUserType.PRINCIPLE;
                        break;
                    case Faculty:
                        userType = EnumUserType.FACULTY;
                        break;
                    case Parent:
                        userType = EnumUserType.PARENT;
                        break;
                    case Student:
                        userType = EnumUserType.STUDENT;
                        break;
                    case Account:
                        userType = EnumUserType.ACCOUNT;
                        break;
                    default:
                        userType = EnumUserType.INVALIDUSER;
                        break;
                }
                return userType;
            }

            public static Int64 GetValue(EnumUserType enumUserType)
            {
                if (enumUserType == EnumUserType.ADMIN)
                { return DTO.LABURNUM.COM.Utility.UserType.Admin; }

                if (enumUserType == EnumUserType.PRINCIPLE)
                { return DTO.LABURNUM.COM.Utility.UserType.Principle; }

                if (enumUserType == EnumUserType.FACULTY)
                { return DTO.LABURNUM.COM.Utility.UserType.Faculty; }

                if (enumUserType == EnumUserType.PARENT)
                { return DTO.LABURNUM.COM.Utility.UserType.Parent; }

                if (enumUserType == EnumUserType.STUDENT)
                { return DTO.LABURNUM.COM.Utility.UserType.Student; }

                if (enumUserType == EnumUserType.ACCOUNT)
                { return DTO.LABURNUM.COM.Utility.UserType.Account; }
                return -1;
            }
        }

        public enum EnumAdmissionType
        {
            NEWADMISSION = DTO.LABURNUM.COM.Utility.AdmissionType.NewAdmission,
            READMISSION = DTO.LABURNUM.COM.Utility.AdmissionType.ReAdmission,
            INVALIDADMISSIONTYPE = DTO.LABURNUM.COM.Utility.AdmissionType.InvalidAdmissionType,
        }

        public static class AdmissionType
        {
            public const Int32 InvalidAdmissionType = -1;
            public const Int32 NewAdmission = 1;
            public const Int32 ReAdmission = 2;

            public static EnumAdmissionType GetEnumAdmissionTypeById(long AdmissionTypeId)
            {
                EnumAdmissionType admissionType;
                switch (AdmissionTypeId)
                {
                    case NewAdmission:
                        admissionType = EnumAdmissionType.NEWADMISSION;
                        break;
                    case ReAdmission:
                        admissionType = EnumAdmissionType.READMISSION;
                        break;
                    default:
                        admissionType = EnumAdmissionType.INVALIDADMISSIONTYPE;
                        break;
                }
                return admissionType;
            }

            public static Int64 GetValue(EnumAdmissionType enumAdmissionType)
            {
                if (enumAdmissionType == EnumAdmissionType.NEWADMISSION)
                { return DTO.LABURNUM.COM.Utility.AdmissionType.NewAdmission; }

                if (enumAdmissionType == EnumAdmissionType.READMISSION)
                { return DTO.LABURNUM.COM.Utility.AdmissionType.ReAdmission; }

                return -1;
            }
        }

        public enum EnumSalutationType
        {
            MALE = DTO.LABURNUM.COM.Utility.SalutationType.Male,
            FEMALE = DTO.LABURNUM.COM.Utility.SalutationType.Female,
            INVALIDSALUTATION = DTO.LABURNUM.COM.Utility.SalutationType.InvalidSalutation,
        }

        public static class SalutationType
        {
            public const Int32 InvalidSalutation = -1;
            public const Int32 Male = 1;
            public const Int32 Female = 2;

            public static EnumSalutationType GetEnumSalutationById(long SalutationId)
            {
                EnumSalutationType salutationType;
                switch (SalutationId)
                {
                    case Male:
                        salutationType = EnumSalutationType.MALE;
                        break;
                    case Female:
                        salutationType = EnumSalutationType.FEMALE;
                        break;
                    default:
                        salutationType = EnumSalutationType.INVALIDSALUTATION;
                        break;
                }
                return salutationType;
            }

            public static Int64 GetValue(EnumSalutationType enumSalutationType)
            {
                if (enumSalutationType == EnumSalutationType.MALE)
                { return DTO.LABURNUM.COM.Utility.SalutationType.Male; }

                if (enumSalutationType == EnumSalutationType.FEMALE)
                { return DTO.LABURNUM.COM.Utility.SalutationType.Female; }

                return -1;
            }
        }

        public enum EnumClass
        {
            PRENURSERY = DTO.LABURNUM.COM.Utility.Class.PreNursery,
            LKG = DTO.LABURNUM.COM.Utility.Class.LKG,
            UKG = DTO.LABURNUM.COM.Utility.Class.UKG,
            FIRST = DTO.LABURNUM.COM.Utility.Class.First,
            SECOND = DTO.LABURNUM.COM.Utility.Class.Second,
            THIRD = DTO.LABURNUM.COM.Utility.Class.Third,
            FOURTH = DTO.LABURNUM.COM.Utility.Class.Fourth,
            FIFTH = DTO.LABURNUM.COM.Utility.Class.Fifth,
            SIXTH = DTO.LABURNUM.COM.Utility.Class.Sixth,
            SEVENTH = DTO.LABURNUM.COM.Utility.Class.Seventh,
            EIGHTH = DTO.LABURNUM.COM.Utility.Class.Eighth,
            NINTH = DTO.LABURNUM.COM.Utility.Class.Ninth,
            TENTH = DTO.LABURNUM.COM.Utility.Class.Tenth,
            ELEVENTH = DTO.LABURNUM.COM.Utility.Class.Eleventh,
            TWELTH = DTO.LABURNUM.COM.Utility.Class.Twelth,
            INVALIDCLASS = DTO.LABURNUM.COM.Utility.Class.InvalidClass,
        }

        public static class Class
        {
            public const Int32 InvalidClass = -1;
            public const Int32 PreNursery = 1;
            public const Int32 LKG = 2;
            public const Int32 UKG = 3;
            public const Int32 First = 4;
            public const Int32 Second = 5;
            public const Int32 Third = 6;
            public const Int32 Fourth = 7;
            public const Int32 Fifth = 8;
            public const Int32 Sixth = 9;
            public const Int32 Seventh = 10;
            public const Int32 Eighth = 11;
            public const Int32 Ninth = 12;
            public const Int32 Tenth = 13;
            public const Int32 Eleventh = 14;
            public const Int32 Twelth = 15;

            public static EnumClass GetEnumClassById(long classId)
            {
                EnumClass Class;
                switch (classId)
                {
                    case PreNursery:
                        Class = EnumClass.PRENURSERY;
                        break;
                    case UKG:
                        Class = EnumClass.UKG;
                        break;
                    case LKG:
                        Class = EnumClass.LKG;
                        break;
                    case First:
                        Class = EnumClass.FIRST;
                        break;
                    case Second:
                        Class = EnumClass.SECOND;
                        break;
                    case Third:
                        Class = EnumClass.THIRD;
                        break;
                    case Fourth:
                        Class = EnumClass.FOURTH;
                        break;
                    case Fifth:
                        Class = EnumClass.FIFTH;
                        break;
                    case Sixth:
                        Class = EnumClass.SIXTH;
                        break;
                    case Seventh:
                        Class = EnumClass.SEVENTH;
                        break;
                    case Eighth:
                        Class = EnumClass.EIGHTH;
                        break;
                    case Ninth:
                        Class = EnumClass.NINTH;
                        break;
                    case Tenth:
                        Class = EnumClass.TENTH;
                        break;
                    case Eleventh:
                        Class = EnumClass.ELEVENTH;
                        break;
                    case Twelth:
                        Class = EnumClass.TWELTH;
                        break;
                    default:
                        Class = EnumClass.INVALIDCLASS;
                        break;
                }
                return Class = 0;
            }

            public static Int64 GetValue(EnumClass enumClass)
            {
                if (enumClass == EnumClass.PRENURSERY)
                { return DTO.LABURNUM.COM.Utility.Class.PreNursery; }

                if (enumClass == EnumClass.UKG)
                { return DTO.LABURNUM.COM.Utility.Class.UKG; }

                if (enumClass == EnumClass.LKG)
                { return DTO.LABURNUM.COM.Utility.Class.LKG; }

                if (enumClass == EnumClass.FIRST)
                { return DTO.LABURNUM.COM.Utility.Class.First; }

                if (enumClass == EnumClass.SECOND)
                { return DTO.LABURNUM.COM.Utility.Class.Second; }

                if (enumClass == EnumClass.THIRD)
                { return DTO.LABURNUM.COM.Utility.Class.Third; }

                if (enumClass == EnumClass.FOURTH)
                { return DTO.LABURNUM.COM.Utility.Class.Fourth; }

                if (enumClass == EnumClass.FIFTH)
                { return DTO.LABURNUM.COM.Utility.Class.Fifth; }

                if (enumClass == EnumClass.SIXTH)
                { return DTO.LABURNUM.COM.Utility.Class.Sixth; }

                if (enumClass == EnumClass.SEVENTH)
                { return DTO.LABURNUM.COM.Utility.Class.Seventh; }

                if (enumClass == EnumClass.EIGHTH)
                { return DTO.LABURNUM.COM.Utility.Class.Eighth; }

                if (enumClass == EnumClass.NINTH)
                { return DTO.LABURNUM.COM.Utility.Class.Ninth; }

                if (enumClass == EnumClass.TENTH)
                { return DTO.LABURNUM.COM.Utility.Class.Tenth; }

                if (enumClass == EnumClass.ELEVENTH)
                { return DTO.LABURNUM.COM.Utility.Class.Eleventh; }

                if (enumClass == EnumClass.TWELTH)
                { return DTO.LABURNUM.COM.Utility.Class.Twelth; }

                return -1;
            }
        }


    }
}
