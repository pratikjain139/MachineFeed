using MachineFeed.Dal;
using MachineFeed.Dao;
using MachineFeed.Projection;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace MachineFeed.Handler {
    public class MachineHandler : IMachineHandler {

        private readonly IMachineDal machineDal;
        public MachineHandler(IMachineDal machineDal) {
            this.machineDal = machineDal;
        }
        public MachineDetails getMachineDetails(int machineId) {
            return machineDal.getMachineDetails(machineId);
        }

        public List<MachineFeedDetails> getMachineFeed(int machineId,string feedType) {
            List<MachineFeedDetails> res = new List<MachineFeedDetails>();
            var mcd = getMachineDetails(machineId);            
            var sessions = getSessions(machineId);
            var repairs = getRepairs(machineId);

            if (feedType != null) {
                if (feedType.Equals("S")) {
                    mapSessionToMfdList(res, mcd, sessions);
                } else if (feedType.Equals("R")) { 
                    mapRepairToMfdList(res, mcd, repairs);
                }

            } else {
                mapSessionToMfdList(res, mcd, sessions);

                mapRepairToMfdList(res, mcd, repairs);
            }

            res.Sort((x, y) => x.UpdatedAt.CompareTo(y.UpdatedAt));
            return res;
        }

        private void mapRepairToMfdList(List<MachineFeedDetails> res, MachineDetails mcd, List<Repair> repairs) {
            foreach (var item in repairs) {
                var mfd = mapMfdFromRepair(item, mcd);
                res.Add(mfd);
            }
        }

        private void mapSessionToMfdList(List<MachineFeedDetails> res, MachineDetails mcd, List<Session> sessions) {
            foreach (var item in sessions) {
                var mfd = mapMfdFromSession(item, mcd);
                res.Add(mfd);
            }
        }

        private MachineFeedDetails mapMfdFromSession(Session session,MachineDetails mcd) {
            MachineFeedDetails mfd = new MachineFeedDetails();
            mfd.Description = session.Description;
            mfd.UpdatedBy = session.UpdatedBy;
            mfd.UpdatedAt = session.UpdatedAt;
            mfd.FeedType = "S";
            mfd.Model = mcd.Model;
            mfd.Type = mcd.Type;
            mfd.Id = mcd.Id;
            return mfd;
        }

        private MachineFeedDetails mapMfdFromRepair(Repair repair, MachineDetails mcd) {
            MachineFeedDetails mfd = new MachineFeedDetails();
            mfd.Description = repair.Description;
            mfd.UpdatedBy = repair.UpdatedBy;
            mfd.UpdatedAt = repair.UpdatedAt;
            mfd.Image = repair.Image;
            mfd.FeedType = "R";
            mfd.Model = mcd.Model;
            mfd.Type = mcd.Type;
            mfd.Id = mcd.Id;
            return mfd;
        }



        public List<Repair> getRepairs(int machineId) {
            return machineDal.getRepairs(machineId);
        }

        public List<Session> getSessions(int machineId) {
            return machineDal.getSessions(machineId);
        }


    }
}
