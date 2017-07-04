using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.LABURNUM.COM.Component;

namespace API.LABURNUM.COM.Controllers
{
    public class AttendanceReportsController : ApiController
    {
        public DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryReportModel SearchAttendanceSummary(DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryRequestModel model)
        {
            if (new FrontEndApi.ApiClientApi().IsClientValid(model.ApiClientModel.UserName, model.ApiClientModel.Password))
            {
                return GetAttendanceSummary(model.StartDate, model.EndDate);
            }
            else
            {
                return null;
            }
        }

        public DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryReportModel GetAttendanceSummary(DateTime startDate, DateTime endDate)
        {
            DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryReportModel attendanceSummaryReportModel = new DTO.LABURNUM.COM.AttendanceReporting.AttendanceSummaryReportModel();
            int totalstudents = 0, totalMorningPresent = 0, totalMorningAbsent = 0, totalLunchPresent = 0, totalLunchAbsent = 0;
            List<API.LABURNUM.COM.Student> dbstudents = new FrontEndApi.StudentApi().GetActiveStudents();

            List<DTO.LABURNUM.COM.ClassModel> classes = new ClassHelper(new FrontEndApi.ClassApi().GetActiveClass()).Map();

            DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendanceSummary daysummary = new DTO.LABURNUM.COM.AttendanceReporting.DayWiseAttendanceSummary();
            foreach (DTO.LABURNUM.COM.ClassModel item in classes)
            {
                int studentsinclass = 0, morningpresent = 0, morningAbsent = 0, lunchpresent = 0, lunchAbsent = 0;
                List<DTO.LABURNUM.COM.AttendanceReporting.SectionModelForAttendance> sections = new List<DTO.LABURNUM.COM.AttendanceReporting.SectionModelForAttendance>();

                foreach (DTO.LABURNUM.COM.SectionModel item1 in item.Sections)
                {
                    DTO.LABURNUM.COM.DashBoard.ClassAttendanceStatus rmodel = new Controllers.DashBoardController().GetClassAttendanceStatus(item.ClassId, item1.SectionId, startDate, endDate);
                    int m = dbstudents.Where(x => x.ClassId == item.ClassId && x.SectionId == item1.SectionId).ToList().Count;
                    rmodel.TotalStudents = m;

                    sections.Add(new DTO.LABURNUM.COM.AttendanceReporting.SectionModelForAttendance()
                    {
                        SectionId = item1.SectionId,
                        SectionName = item1.SectionName,
                        ClassAttendanceStatus = rmodel
                    });


                    totalstudents = m + totalstudents;
                    if (rmodel.MorningPresentStudentCount == 0 && rmodel.LunchPresentStudentCount == 0)
                    {
                        totalMorningAbsent = m + totalMorningAbsent;
                        totalLunchAbsent = m + totalLunchAbsent;
                        rmodel.MorningAbsentStudentCount = m;
                        rmodel.LunchAbsentStudentCount = m;
                    }
                    else
                    {
                        totalMorningPresent = rmodel.MorningPresentStudentCount + totalMorningPresent;
                        totalMorningAbsent = rmodel.MorningAbsentStudentCount + totalMorningAbsent;
                        totalLunchPresent = rmodel.LunchPresentStudentCount + totalLunchPresent;
                        totalLunchAbsent = rmodel.MorningAbsentStudentCount + totalLunchAbsent;
                    }
                    studentsinclass = studentsinclass + m;
                    morningpresent = morningpresent + rmodel.MorningPresentStudentCount;
                    morningAbsent = morningAbsent + rmodel.MorningAbsentStudentCount;
                    lunchpresent = lunchpresent + rmodel.LunchPresentStudentCount;
                    lunchAbsent = lunchAbsent + rmodel.LunchAbsentStudentCount;
                }
                daysummary.ForDate = startDate;
                daysummary.ClassModelsForAttendance.Add(new DTO.LABURNUM.COM.AttendanceReporting.ClassModelForAttendance()
                {
                    ClassId = item.ClassId,
                    ClassName = item.ClassName,
                    SectionModelsForAttendance = sections,
                    StudentInClass = studentsinclass,
                    MorningPresentStudentInClass = morningpresent,
                    MorningAbsentStudentInClass = morningAbsent,
                    LunchPresentStudentInClass = lunchpresent,
                    LunchAbsentStudentInClass = lunchAbsent
                });
            }
            attendanceSummaryReportModel.DayWiseAttendanceSummaries.Add(daysummary);
            attendanceSummaryReportModel.TotalStudentsInSchool = totalstudents;
            attendanceSummaryReportModel.TotalStudentsMorningPresentCount = totalMorningPresent;
            attendanceSummaryReportModel.TotalStudentsMorningAbsentCount = totalMorningAbsent;
            attendanceSummaryReportModel.TotalStudentsLunchPresentCount = totalLunchPresent;
            attendanceSummaryReportModel.TotalStudentsLunchAbsentCount = totalLunchAbsent;
            return attendanceSummaryReportModel;
        }
    }
}