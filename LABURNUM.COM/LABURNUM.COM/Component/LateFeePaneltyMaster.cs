using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LABURNUM.COM.Component
{
    public class LateFeePaneltyMaster
    {
        public List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel> GetActiveLateFeePaneltyMasters()
        {
            try
            {
                DTO.LABURNUM.COM.LateFeePaneltyMasterModel model = new DTO.LABURNUM.COM.LateFeePaneltyMasterModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("LateFeePaneltyMaster/SearchActiveLateFeePaneltyMasters", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Late Fee Panelty Master List");
            }
        }

        public List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel> GetAllLateFeePaneltyMasters()
        {
            try
            {
                DTO.LABURNUM.COM.LateFeePaneltyMasterModel model = new DTO.LABURNUM.COM.LateFeePaneltyMasterModel();
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("LateFeePaneltyMaster/SearchAllLateFeePaneltyMasters", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel>>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw new Exception("Error While Getting Late Fee Panelty Master List");
            }
        }

        public void UpdateLateFeePaneltyMasterStatus(DTO.LABURNUM.COM.LateFeePaneltyMasterModel model)
        {
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("LateFeePaneltyMaster/UpdateStatus", model).Result;
                if (response.IsSuccessStatusCode)
                {

                }
                else { }
            }
            catch (Exception)
            {
                throw new Exception("Error While Updating Late Fee Panelty Master Status");
            }
        }

        public DTO.LABURNUM.COM.LateFeePaneltyMasterModel GetLateFeePaneltyMasterById(long lfpId)
        {
            DTO.LABURNUM.COM.LateFeePaneltyMasterModel model = new DTO.LABURNUM.COM.LateFeePaneltyMasterModel() { LateFeePaneltyMasterId = lfpId };
            try
            {
                model.ApiClientModel = new LABURNUM.COM.Component.Common().GetApiClientModel();
                HttpClient client = new LABURNUM.COM.Component.Common().GetHTTPClient("application/json");
                HttpResponseMessage response = client.PostAsJsonAsync("LateFeePaneltyMaster/SearchLateFeePaneltyMasterById", model).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<DTO.LABURNUM.COM.LateFeePaneltyMasterModel>(data);
                }
                else { return null; }
            }
            catch (Exception)
            {
                return model;
            }
        }

        public double GetFineAmount(int currentday)
        {
            double fineAmount = 0;
            try
            {
                int index = 0;
                List<DTO.LABURNUM.COM.LateFeePaneltyMasterModel> latefeelmaster = GetActiveLateFeePaneltyMasters();
                for (index = 0; index < latefeelmaster.Count; index++)
                {
                    if (currentday > latefeelmaster[index].DaysAfter)
                    {
                        //if (currentday > latefeelmaster[index + 1].DaysAfter) { }
                    }
                    else
                    {
                        if (index - 1 >= 0)
                        {
                            fineAmount = latefeelmaster[index - 1].Fine * (currentday - latefeelmaster[index - 1].DaysAfter);
                        }
                    }
                }

                if (fineAmount == 0) { fineAmount = (latefeelmaster[index - 1].Fine * (currentday - latefeelmaster[index - 1].DaysAfter)) + (latefeelmaster[0].Fine * (latefeelmaster[index - 1].DaysAfter - latefeelmaster[index - 2].DaysAfter)); }
                if (fineAmount < 0) { fineAmount = 0; }
                return fineAmount;
            }
            catch (Exception ex)
            {
                return fineAmount;
            }
        }
    }
}