using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_data
{
    class clsHistory_state
    {
        public string country { set; get; }
        public List<clsStateByCountry> stat_by_country;
    }
    class clsStateByCountry
    {
        public string id { set; get; }

        public string record_date { set; get; }

        public string new_cases { set; get; }

        public string total_cases { set; get; }

        public string active_cases { set; get; }

        public string total_death { set; get; }

        public string new_deaths { set; get; }

        public string total_recovered { set; get; }

        public string serious_critical { set; get; }

    }
}
