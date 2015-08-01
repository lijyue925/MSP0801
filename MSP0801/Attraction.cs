using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSP0801
{

    public class Attractions
    {
        public ObservableCollection<Attraction> Items { get; set;}
    }

    public class Attraction
    {
        public string Changetime { get; set; }
        public string Keyword { get; set; }
        public string Remarks { get; set; }
        public string Ticketinfo { get; set; }
        public string Parkinginfo_py { get; set; }
        public string Parkinginfo_px { get; set; }
        public string Parkinginfo { get; set; }
        public string Website { get; set; }
        public string Level { get; set; }
        public string Class3 { get; set; }
        public string Class2 { get; set; }
        public string Class1 { get; set; }
        public string Orgclass { get; set; }
        public string Py { get; set; }
        public string Px { get; set; }
        public string Gov { get; set; }
        public string Map { get; set; }
        public string Picdescribe3 { get; set; }
        public string Picture3 { get; set; }
        public string Picdescribe2 { get; set; }
        public string Picture2 { get; set; }
        public string Picdescribe1 { get; set; }
        public string Picture1 { get; set; }
        public string Opentime { get; set; }
        public string Travellinginfo { get; set; }
        public string Zipcode { get; set; }
        public string Add { get; set; }
        public string Tel { get; set; }
        public string Description { get; set; }
        public string Toldescribe { get; set; }
        public string Zone { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }

}
