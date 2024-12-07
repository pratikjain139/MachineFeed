using MachineFeed.Dao;
using Newtonsoft.Json;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace MachineFeed.Dal {
    public class MachineDal : IMachineDal {
        public MachineDetails getMachineDetails(int machineId) {
            List<MachineDetails> mds = new List<MachineDetails>();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"MockJsons\machine.json");
            string machineDetails = File.ReadAllText(path);
            mds = JsonConvert.DeserializeObject<List<MachineDetails>>(machineDetails);

            return mds.Where(x=>x.Id.Equals(machineId)).FirstOrDefault();
        }

        public List<Repair> getRepairs(int machineId) {
            List<Repair> repairs = new List<Repair>();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"MockJsons\repair.json");
            string repairsJson = File.ReadAllText(path);
            repairs = JsonConvert.DeserializeObject<List<Repair>>(repairsJson);
            return repairs.Where(x=>x.Id.Equals(machineId)).ToList();
        }

        public List<Session> getSessions(int machineId) {
            List<Session> sessions = new List<Session>();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"MockJsons\session.json");
            string sessionsJson = File.ReadAllText(path);
            sessions = JsonConvert.DeserializeObject<List<Session>>(sessionsJson);
            return sessions.Where(x => x.Id.Equals(machineId)).ToList();
        }
    }
}
