using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class CommonAttendanceController : ApiController
    {
        public long Add(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return AddAttendanceAsperClass(model);
            }
            else
            {
                return -1;
            }
        }

        private long AddAttendanceAsperClass(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            long AttendenceId = 0;
            switch (model.ClassId)
            {
                case 1:
                    DTO.LABURNUM.COM.AttendanceClassPreNurseryModel pmodel = new DTO.LABURNUM.COM.AttendanceClassPreNurseryModel()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    new FrontEndApi.AttendanceClassPreNurseryApi().Add(pmodel);
                    break;
                case 2:
                    DTO.LABURNUM.COM.AttendanceClassLKGModel lkgmodel = new DTO.LABURNUM.COM.AttendanceClassLKGModel()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClassLKGApi().Add(lkgmodel);
                    break;
                case 3:
                    DTO.LABURNUM.COM.AttendanceClassUKGModel ukgmodel = new DTO.LABURNUM.COM.AttendanceClassUKGModel()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClassUKGApi().Add(ukgmodel);
                    break;

                case 4:
                    DTO.LABURNUM.COM.AttendanceClass1Model firstmodel = new DTO.LABURNUM.COM.AttendanceClass1Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass1Api().Add(firstmodel);
                    break;

                case 5:
                    DTO.LABURNUM.COM.AttendanceClass2Model secondmodel = new DTO.LABURNUM.COM.AttendanceClass2Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass2Api().Add(secondmodel);
                    break;

                case 6:
                    DTO.LABURNUM.COM.AttendanceClass3Model thirdmodel = new DTO.LABURNUM.COM.AttendanceClass3Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass3Api().Add(thirdmodel);
                    break;

                case 7:
                    DTO.LABURNUM.COM.AttendanceClass4Model fourmodel = new DTO.LABURNUM.COM.AttendanceClass4Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass4Api().Add(fourmodel);
                    break;

                case 8:
                    DTO.LABURNUM.COM.AttendanceClass5Model fivemodel = new DTO.LABURNUM.COM.AttendanceClass5Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass5Api().Add(fivemodel);
                    break;

                case 9:
                    DTO.LABURNUM.COM.AttendanceClass6Model sixmodel = new DTO.LABURNUM.COM.AttendanceClass6Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass6Api().Add(sixmodel);
                    break;

                case 10:
                    DTO.LABURNUM.COM.AttendanceClass7Model sevenmodel = new DTO.LABURNUM.COM.AttendanceClass7Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass7Api().Add(sevenmodel);
                    break;

                case 11:
                    DTO.LABURNUM.COM.AttendanceClass8Model eightmodel = new DTO.LABURNUM.COM.AttendanceClass8Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass8Api().Add(eightmodel);
                    break;

                case 12:
                    DTO.LABURNUM.COM.AttendanceClass9Model ninemodel = new DTO.LABURNUM.COM.AttendanceClass9Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass9Api().Add(ninemodel);
                    break;

                case 13:
                    DTO.LABURNUM.COM.AttendanceClass10Model tenmodel = new DTO.LABURNUM.COM.AttendanceClass10Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass10Api().Add(tenmodel);
                    break;

                case 14:
                    DTO.LABURNUM.COM.AttendanceClass11Model elevenmodel = new DTO.LABURNUM.COM.AttendanceClass11Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass11Api().Add(elevenmodel);
                    break;

                case 15:
                    DTO.LABURNUM.COM.AttendanceClass12Model twelvemodel = new DTO.LABURNUM.COM.AttendanceClass12Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        Date = model.Date
                    };
                    AttendenceId = new FrontEndApi.AttendanceClass12Api().Add(twelvemodel);
                    break;
            }

            return AttendenceId;
        }

        public dynamic SearchAttendanceByAdvanceSearch(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return AttendanceByAdvanceSearch(model);
            }
            else
            {
                return -1;
            }
        }

        private dynamic AttendanceByAdvanceSearch(DTO.LABURNUM.COM.CommonAttendanceModel model)
        {

            switch (model.ClassId)
            {
                case 1:
                    DTO.LABURNUM.COM.AttendanceClassPreNurseryModel pmodel = new DTO.LABURNUM.COM.AttendanceClassPreNurseryModel()
                    {
                        AttendanceClassPreNurseryId = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClassPreNurseryHelper(new FrontEndApi.AttendanceClassPreNurseryApi().GetAttendanceClassPreNurseryByAdvanceSearch(pmodel)).Map();
                    break;
                case 2:
                    DTO.LABURNUM.COM.AttendanceClassLKGModel lkgmodel = new DTO.LABURNUM.COM.AttendanceClassLKGModel()
                    {
                        AttendanceClassLKGId = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClassLKGHelper(new FrontEndApi.AttendanceClassLKGApi().GetAttendanceClassLKGByAdvanceSearch(lkgmodel)).Map();
                    break;
                case 3:
                    DTO.LABURNUM.COM.AttendanceClassUKGModel ukgmodel = new DTO.LABURNUM.COM.AttendanceClassUKGModel()
                    {
                        AttendanceClassUKGId = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClassUKGHelper(new FrontEndApi.AttendanceClassUKGApi().GetAttendanceClassUKGByAdvanceSearch(ukgmodel)).Map();
                    break;

                case 4:
                    DTO.LABURNUM.COM.AttendanceClass1Model firstmodel = new DTO.LABURNUM.COM.AttendanceClass1Model()
                    {
                        AttendanceClass1Id = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass1Helper(new FrontEndApi.AttendanceClass1Api().GetAttendanceClass1ByAdvanceSearch(firstmodel)).Map();
                    break;

                case 5:
                    DTO.LABURNUM.COM.AttendanceClass2Model secondmodel = new DTO.LABURNUM.COM.AttendanceClass2Model()
                    {
                        AttendanceClass2Id = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass2Helper(new FrontEndApi.AttendanceClass2Api().GetAttendanceClass2ByAdvanceSearch(secondmodel)).Map();
                    break;

                case 6:
                    DTO.LABURNUM.COM.AttendanceClass3Model thirdmodel = new DTO.LABURNUM.COM.AttendanceClass3Model()
                    {
                        AttendanceClass3Id = model.AttendanceId,
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass3Helper(new FrontEndApi.AttendanceClass3Api().GetAttendanceClass3ByAdvanceSearch(thirdmodel)).Map();
                    break;

                case 7:
                    DTO.LABURNUM.COM.AttendanceClass4Model fourmodel = new DTO.LABURNUM.COM.AttendanceClass4Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        AttendanceClass4Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass4Helper(new FrontEndApi.AttendanceClass4Api().GetAttendanceClass4ByAdvanceSearch(fourmodel)).Map();
                    break;

                case 8:
                    DTO.LABURNUM.COM.AttendanceClass5Model fivemodel = new DTO.LABURNUM.COM.AttendanceClass5Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        AttendanceClass5Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass5Helper(new FrontEndApi.AttendanceClass5Api().GetAttendanceClass5ByAdvanceSearch(fivemodel)).Map();
                    break;

                case 9:
                    DTO.LABURNUM.COM.AttendanceClass6Model sixmodel = new DTO.LABURNUM.COM.AttendanceClass6Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        AttendanceClass6Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass6Helper(new FrontEndApi.AttendanceClass6Api().GetAttendanceClass6ByAdvanceSearch(sixmodel)).Map();
                    break;

                case 10:
                    DTO.LABURNUM.COM.AttendanceClass7Model sevenmodel = new DTO.LABURNUM.COM.AttendanceClass7Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        AttendanceClass7Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass7Helper(new FrontEndApi.AttendanceClass7Api().GetAttendanceClass7ByAdvanceSearch(sevenmodel)).Map();
                    break;

                case 11:
                    DTO.LABURNUM.COM.AttendanceClass8Model eightmodel = new DTO.LABURNUM.COM.AttendanceClass8Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        AttendanceClass8Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass8Helper(new FrontEndApi.AttendanceClass8Api().GetAttendanceClass8ByAdvanceSearch(eightmodel)).Map();
                    break;

                case 12:
                    DTO.LABURNUM.COM.AttendanceClass9Model ninemodel = new DTO.LABURNUM.COM.AttendanceClass9Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        AttendanceClass9Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass9Helper(new FrontEndApi.AttendanceClass9Api().GetAttendanceClass9ByAdvanceSearch(ninemodel)).Map();
                    break;

                case 13:
                    DTO.LABURNUM.COM.AttendanceClass10Model tenmodel = new DTO.LABURNUM.COM.AttendanceClass10Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        AttendanceClass10Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass10Helper(new FrontEndApi.AttendanceClass10Api().GetAttendanceClass10ByAdvanceSearch(tenmodel)).Map();
                    break;

                case 14:
                    DTO.LABURNUM.COM.AttendanceClass11Model elevenmodel = new DTO.LABURNUM.COM.AttendanceClass11Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        AttendanceClass11Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass11Helper(new FrontEndApi.AttendanceClass11Api().GetAttendanceClass11ByAdvanceSearch(elevenmodel)).Map();
                    break;

                case 15:
                    DTO.LABURNUM.COM.AttendanceClass12Model twelvemodel = new DTO.LABURNUM.COM.AttendanceClass12Model()
                    {
                        StudentId = model.StudentId,
                        ClassId = model.ClassId,
                        SectionId = model.SectionId,
                        IsPresent = model.IsPresent,
                        AttendanceClass12Id = model.AttendanceId,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate
                    };
                    return new AttendanceClass12Helper(new FrontEndApi.AttendanceClass12Api().GetAttendanceClass12ByAdvanceSearch(twelvemodel)).Map();
                    break;
            }
            return null;
        }
    }
}