using MachineFeed.Dao;
using MachineFeed.Projection;

namespace MachineFeed.Handler {
    public interface IMachineHandler {
        MachineDetails getMachineDetails(int machineId);

        List<Repair> getRepairs(int machineId);

        List<Session> getSessions(int machineId);

        List<MachineFeedDetails> getMachineFeed(int machineId, string feedType);
    }
}
